using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntities
{
    public class Contact
    {
        public Contact()
        {
        }

        public Contact(DataRow dRow)
        {
            ContactID = Convert.ToInt32(dRow["ID"]);
            FirstName = Convert.ToString(dRow["FIRSTNAME"]);
            LastName = Convert.ToString(dRow["LASTNAME"]);
            Phone = Convert.ToString(dRow["PHONE"]);
            EMail = Convert.ToString(dRow["EMAIL"]);
            HouseNo = Convert.ToInt32(dRow["HOUSENO"]);
            StreetName1 = Convert.ToString(dRow["STREETNAME1"]);
            StreetName2 = Convert.ToString(dRow["STREETNAME2"]);
            PostCode = Convert.ToString(dRow["POSTALCODE"]);
            State = Convert.ToString(dRow["STATE"]);
            CountryCode = Convert.ToString(dRow["COUNTRYNAME"]);
            CreatedDate = Convert.ToString(dRow["CREATEDDATE"]);

        }

        public Int32 ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public Int32 HouseNo { get; set; }
        public string StreetName1 { get; set; }
        public string StreetName2 { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
        public string CreatedDate { get; set; }
    }
}