using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableAccessLayer
{
    public class SqlDataTableAccessLayer
    {
		// This field will be used by all methods, holds the open connection
		protected SqlConnection sqlConnection = null;

		// If restoring from backup, need to do identity_insert
		private bool restoringFromBackup = false;

		/// <summary>
		/// Open a connection to the sql database
		/// </summary>
		/// <param name="connectionString">Database connection string</param>
		public void OpenConnection(string connectionString)
		{
			sqlConnection = new SqlConnection { ConnectionString = connectionString };
			sqlConnection.Open();
		}

		/// <summary>
		/// Close the sql database connection
		/// </summary>
		public void CloseConnection()
		{
			sqlConnection.Close();
		}

		/// <summary>
		/// Gets the connection string from the app.config file
		/// 
		/// Note: this needs System.Configuration dll reference added
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public string GetConnectionString(string key)
		{
			if (key == null)
			{
				return null;
			}

			return ConfigurationManager.ConnectionStrings[key].ConnectionString;
		}

		/// <summary>
		/// Set identity_insert on or off for a table.
		/// Allows insertion of Ids into a table when set to ON
		/// </summary>
		/// <param name="table">Table needing identity_insert changed</param>
		/// <param name="value">true for ON, false for OFF</param>
		public void SetIdentityInsert(string table, bool value)
		{
			if (table == null)
			{
				return;
			}

			string identityInsertCommand = "SET IDENTITY_INSERT [dbo].[" + table + "] " + (value == true ? "ON" : "OFF");

			using (SqlCommand sqlCommand = new SqlCommand(identityInsertCommand, sqlConnection))
			{
				try
				{
					Debug.WriteLine("SetIdentityValue: " + sqlCommand.CommandText);
					sqlCommand.ExecuteNonQuery();
				}
				catch (SqlException ex)
				{
					Exception error = new Exception("Identity_Insert Failure: " + identityInsertCommand, ex);
					throw error;
				}
			}
		}



		/// <summary>
		/// Simple method to create and fill a DataTable object
		/// from any sql table.
		/// 
		/// Primary key columns are set.
		/// </summary>
		/// <param name="tableName">Name of the sql table</param>
		/// <returns>DataTable containing the sql data or null if table does not exist</returns>
		public DataTable GetDataTable(string tableName)
		{
			if (tableName == null)
				return null;

			DataTable dataTable = new DataTable
			{
				TableName = tableName,
			};

			// load the data from the database into the DataTable object

			LoadDataTable(dataTable);

			// get the primary keys from the database for the table, and load into the object

			SetPrimaryKey(dataTable);
			dataTable.AcceptChanges();

			return dataTable;
		}

		/// <summary>
		/// Set the primary keys in a data table.
		/// 
		/// Need to get the table schema by executing a select command on the table
		/// and return key information.
		/// 
		/// This will also work for composite keys
		/// 
		/// Should only need to do this once when getting the table from the db.
		/// </summary>
		/// <param name="table"></param>
		private void SetPrimaryKey(DataTable table)
		{
			if (table == null)
				return;

			// select command 

			var sqlCommand =
				new SqlCommand("Select * From [" + table.TableName + "]", sqlConnection);

			Debug.WriteLine("SetPrimaryKey: " + sqlCommand.CommandText);

			// get the table schema, and make sure we obtain the keys as well

			using (SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.KeyInfo))
			{
				// the schema is returned as a data table

				DataTable schema = dataReader.GetSchemaTable();

				// keep a list of all of the columns that are primary keys

				List<DataColumn> keyColumnList = new List<DataColumn>();

				// each row in the schema table contains metadata about columns in table
				// check to see which columns are keys, and add them to the list

				foreach (DataRow row in schema.Rows)
				{
					// is it a primary key?

					if ((bool)row["IsKey"] == true)
					{
						// get the column index of the primary key

						int columnOrdinal = (int)row["ColumnOrdinal"];

						// make sure it is one of the table columns, and if so add it to the key list

						if (columnOrdinal < table.Columns.Count)
						{
							keyColumnList.Add(table.Columns[columnOrdinal]);
							Debug.WriteLine("  Primary Key found: " + table.TableName + " " +
								row["ColumnName"] + " Column " + columnOrdinal);
						}
					}
				}

				// the PrimaryKey property is an array, so convert it and we are done

				table.PrimaryKey = keyColumnList.ToArray();
			}
		}

		/// <summary>
		/// Load records from a database table into an existing DataTable.
		/// 
		/// The DataTable must exist and have a TableName property set
		/// to a table that exists in the SQL database
		/// 
		/// The DataTable is cleared before the records are added, so
		/// any existing rows in the DataTable are removed.
		/// </summary>
		/// <param name="table">DataTable to be loaded</param>
		public void LoadDataTable(DataTable table)
		{
			table.Clear();

			var sqlCommand =
				new SqlCommand("Select * From [" + table.TableName + "]", sqlConnection);

			Debug.WriteLine("LoadDataTable: " + sqlCommand.CommandText);

			using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
			{
				// Fill the DataTable with data from the reader. This
				// set up the schema in the DataTable as well.

				table.Load(dataReader);
			}

			table.AcceptChanges();
		}

		/// <summary>
		/// Insert a DataRow into the database. This should be called in
		/// the RowChanged event handler.
		/// 
		/// The event handler must only invoke this from DataRowAction.Add
		/// event.
		/// </summary>
		/// <param name="row">new row belonging to a DataTable</param>
		/// <returns></returns>
		public void InsertTableRow(DataRow row)
		{
			// avoid potential race condition, as updating an id from the database
			// triggers a RowChangedEvent.Changed action below which should be ignored.

			if (row == null || row.RowState != DataRowState.Added)
				return;

			// carefully create the insert clause, followed by column names from the table
			//  and values from the row

			DataTable table = row.Table;

			string insertClause = "Insert into [" + table.TableName + "]";

			// start columns with this

			string columns = " (";

			// start values with this

			string values = " Values (";

			// if a column has autoincrement set, do not include it in the insert clause
			// and remember if this was done, as we will have to get the id from the DB later

			bool identityColumn = table.Columns[0].AutoIncrement;

			for (int i = 0; i < table.Columns.Count; i++)
			{
				if (table.Columns[i].AutoIncrement == false || restoringFromBackup == true)
				{
					// include the column and its value in the insert clause 

					columns += $"{table.Columns[i].ColumnName},";
					values += $"'{row[i]}',";
				}
			}

			// the last column and value has an extra comma so trim it and add a close parenthesis

			columns = columns.TrimEnd(',') + ")";
			values = values.TrimEnd(',') + ")";

			// now put together the command

			string insertCommand = insertClause + columns + values;

			using (SqlCommand sqlCommand = new SqlCommand(insertCommand, sqlConnection))
			{

				try
				{
					// set identity_insert only if there is an identity column and 
					// restoring from backup
					// for data restore purposes

					if (identityColumn == true && restoringFromBackup == true)
						SetIdentityInsert(table.TableName, true);

					Debug.WriteLine("InsertTableRow: " + insertCommand);
					sqlCommand.ExecuteNonQuery();

					if (identityColumn == true && restoringFromBackup == true)
						SetIdentityInsert(table.TableName, false);
				}
				catch (SqlException ex)
				{
					Debug.WriteLine("InsertTableRow: " + insertCommand);
					string id = row[0].ToString();
					row.RejectChanges();
					throw new Exception("Insert failed: " + ex.Message);
				}
			}

			table.AcceptChanges();

			// if identity is not set or restoring from backup
			// (ids are are already created with identity_insert), 
			// nothing else needs to be done

			if (identityColumn == false || restoringFromBackup == true)
			{
				return;
			}

			// identity is set, so need to get the id for the record as set by the DB, and update the
			// datatable. scope_identity() returns the id of the most recent query in this session, which is the one 
			// just issued.

			// the other alternative is to reload the entire table. or assign ids manually or via SEQUENCE

			string scopeIdentityCommand = "select scope_identity()";

			Debug.WriteLine("InsertTableRow: " + scopeIdentityCommand);

			using (SqlCommand sqlCommand =
				new SqlCommand(scopeIdentityCommand, sqlConnection))
			{
				decimal id = (decimal)sqlCommand.ExecuteScalar();
				Debug.WriteLine("InsertTableRow: ID from DB " + id);

				// to update the id, we need to allow writing

				table.Columns[0].ReadOnly = false;

				// set the value of the id field with what was returned from the db

				// unfortunately, this triggers another RowChangedEvent, which should be ignored.
				// deal with this in the entry to this method to prevent a race condition.

				row.SetField(0, id.ToString());

				// do not use itemarray, as it is a COPY of the items, so nothing happens
				// row.ItemArray[0] = id.ToString();

				// now set it back to readonly

				table.Columns[0].ReadOnly = true;

				table.AcceptChanges();
			}
		}

		/// <summary>
		/// Update the database with a changed row. This should be called
		/// by the ColumnChanged event handler.
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		public void UpdateTableRow(DataRow row)
		{
			// create the update clause

			DataTable table = row.Table;

			string updateClause = "Update " + table.TableName + " Set";

			// create SET name = 'value' statements
			// do NOT update the id column if AutoIncrement is set

			string values = "";

			for (int i = 0; i < table.Columns.Count; i++)
			{
				if (table.Columns[i].AutoIncrement == false)
					values += $" {table.Columns[i].ColumnName} = '{row[i]}',";
			}

			values = values.TrimEnd(','); // end may have a trailing comma, so get rid of it

			// use the original value for the id column in case we are changing the value of it

			string whereClause = $" where {table.Columns[0].ColumnName} = '{row[0, DataRowVersion.Original]}'";

			string updateCommand = updateClause + values + whereClause;

			Debug.WriteLine("UpdateTableRow: " + updateCommand);

			using (SqlCommand sqlCommand = new SqlCommand(updateCommand, sqlConnection))
			{
				try
				{
					sqlCommand.ExecuteNonQuery();
				}
				catch (SqlException ex)
				{
					string id = row[0].ToString();
					row.RejectChanges();
					throw new Exception("Update failed for id " + id + ": " + ex.Message);
				}
			}

			table.AcceptChanges();
		}

		/// <summary>
		/// Delete a row from the database. This should be called by the
		/// RowDeleted event handler.
		/// </summary>
		/// <param name="row"></param>
		public void DeleteTableRow(DataRow row)
		{
			DataTable table = row.Table;

			// create the delete command

			string deleteClause = "delete from " + table.TableName;

			// a deleted table row has no data. one has to get the original column data instead

			string whereClause = " where " + table.Columns[0].ColumnName +
				" = '" + row[0, DataRowVersion.Original] + "'";

			string deleteCommand = deleteClause + whereClause;

			Debug.WriteLine("DeleteTableRow: " + deleteCommand);

			using (SqlCommand sqlCommand = new SqlCommand(deleteCommand, sqlConnection))
			{
				// execute the delete command, and throw an exception if it cannot be done

				try
				{
					sqlCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					row.RejectChanges();
					throw new Exception("Delete failed for id " +
						row[0, DataRowVersion.Original] + ": " + ex.Message);
				}
				row.AcceptChanges();
			}

			// if there are no rows left in the table, make sure
			// all the rows are cleared in the control as well

			if (table.Rows.Count == 0)
			{
				table.Rows.Clear();
				table.AcceptChanges();
			}

		}

		/// <summary>
		/// Back up a DataSet to an XML file. 
		/// 
		/// File is named using the 
		/// <see cref="DataSet.DataSetName"/> with .xml appended
		/// </summary>
		/// <param name="dataSet">DataSet to be backked up</param>
		/// <param name="fileName">Name of the xml file (should have .xml extension)</param>
		public void BackupDataSetToXML(DataSet dataSet)
		{
			if (dataSet == null)
			{
				Debug.WriteLine("BackupDataSetToXML: Error - null dataset");
				return;
			}

			// writes the DataSet to an xml file including the schema

			Debug.WriteLine("BackupDataSetToXML: backing up to " + dataSet.DataSetName);

			dataSet.WriteXml(dataSet.DataSetName + ".xml", XmlWriteMode.WriteSchema);
		}



		/// <summary>
		/// Restore the DataSet from an xml file. The xml file must
		/// include a schema, and should have been written using
		/// <see cref="BackupDataSetToXML(DataSet, string)"/>
		/// 
		/// File is named using the 
		/// <see cref="DataSet.DataSetName"/> with .xml appended
		/// 
		/// DataSet tables must not be associated with views.
		/// 
		/// Tables in the dataset are cleared in the reverse order that they
		/// are represented in DataSet.Tables, so make sure any tables
		/// with dependencies are added to the dataset first.
		/// </summary>
		/// <param name="dataSet">DataSet to be restored</param>
		public void RestoreDataSetFromBackup(DataSet dataSet)
		{
			if (dataSet == null)
			{
				Debug.WriteLine("RestoreDataSetFromBackup: Error - null dataset");
				return;
			}

			Debug.WriteLine("RestoreDataSetFromBackup: restoring from " + dataSet.DataSetName);

			// need to clear all of the dataset tables before restore
			// Tables are cleared in the order they are in the Tables
			// list, so make sure any table with dependencies is at the beginning
			// of the list, or else an exception will result.

			// so clear the tables in reverse order in which they were added

			// NOTE: if this was in production, the rest of this code would
			// require a lock on the db so all transactions would be atomic.

			for (int i = dataSet.Tables.Count; i > 0; i--)
			{
				DataTable table = dataSet.Tables[i - 1];
				Debug.WriteLine("Clearing Table " + table.TableName + " column[0] " +
					table.Columns[0].ColumnName + " autoincrement " +
					table.Columns[0].AutoIncrement);

				ClearDatabaseTable(table);
				table.Clear();
			}

			// to restore a table with identity set from xml, the
			// id's will be in the file already, so identity insert
			// needs to be turned on.

			// the InsertTableRow method checks to see if autoincrement
			// is on and if this is a restore.
			// ReadXML adds rows to the dataset tables, which fires
			// the RowChanged event calling InsertTableRow.
			// This will set identity_insert for
			// each insertion.

			restoringFromBackup = true;
			// Read the data from the file and add it to the dataset
			// TODO: exception handling
			dataSet.ReadXml(dataSet.DataSetName + ".xml", XmlReadMode.ReadSchema);

			// restore completed

			restoringFromBackup = false;
		}

		/// <summary>
		/// Clears a database table. Reseeds the the data so IDs start at 1,
		/// if autoincrement is true,
		/// and then deletes all records.
		/// </summary>
		/// <param name="tableName"></param>
		public void ClearDatabaseTable(DataTable table)
		{
			// if identity is set, reseed the table

			if (table.Columns[0].AutoIncrement == true)
			{
				// reseed identity value should be 1 only if there were
				// no rows previously in the database

				int reseedStart = 0;

				if (table.Rows.Count > 0)
					reseedStart = 1;

				string reseedCommand = $"DBCC CHECKIDENT('{table.TableName}', RESEED, " +
					reseedStart + ")";

				Debug.WriteLine("ClearDatabaseTable: " + reseedCommand);
				using (SqlCommand sqlCommand = new SqlCommand(reseedCommand, sqlConnection))
				{
					sqlCommand.ExecuteNonQuery();
				}
			}

			// clear the table of all rows

			string deleteCommand = $"DELETE FROM {table.TableName}";

			Debug.WriteLine("ClearDatabaseTable: " + deleteCommand);

			using (SqlCommand sqlCommand = new SqlCommand(deleteCommand, sqlConnection))
			{
				sqlCommand.ExecuteNonQuery();
			}
		}
	}
}
