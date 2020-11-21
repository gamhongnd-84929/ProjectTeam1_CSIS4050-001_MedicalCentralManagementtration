using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentreCodeFirstFromDB
{
	partial class Service
	{

		public override string ToString()
		{
			return ServiceName + ": " + ServiceDescription;
		}
	}

	partial class Practitioner
	{

		public override string ToString()
		{
			return User.LastName + ", " + User.FirstName;
		}
	}
}
