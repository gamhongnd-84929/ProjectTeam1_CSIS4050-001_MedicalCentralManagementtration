using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalCentreUtilities
{
    public static class BaseFormMethods
    {

        /// <summary>
        /// Method to add a range of accepted province values to a combobox
        /// </summary>
        public static void PopulateProvinceComboBox(ComboBox comboBox)
        {
            // set style to dropdown- so user cannot edit
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            // add items
            comboBox.Items.AddRange(new string[] { "AB", "BC", "SK", "MB", "NL", "PE", "NS", "NB", "QB", "ON" });
        }

        /// <summary>
        /// Method to clear all fields in any form
        /// </summary>
        /// <param name="form"> Form to clear all controls </param>
        public static void ClearAllControls(Form form)
        {
            foreach (Control c in form.Controls)
            {
                if (c is TextBox)
                    (c as TextBox).Clear();
                else if (c is DateTimePicker)
                    (c as DateTimePicker).Value = DateTime.Now;
                else if (c is ComboBox)
                    (c as ComboBox).SelectedIndex = -1;
                else if (c is DateTimePicker)
                    (c as DateTimePicker).Value = DateTime.Now;
                else if (c is ListBox)
                    (c as ListBox).DataSource = null;
            }

        }
    }
}
