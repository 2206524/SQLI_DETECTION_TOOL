using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataLibrary;
using System.Data;
using System.Web.UI.WebControls;

namespace BusinessLibrary
{
    public class ContactBusiness
    {
        private ContactData dbObject;

        public ContactBusiness()
        {
            dbObject = new ContactData();
        }

        public void UpdateContact(Contact dObject)
        {
            dbObject.UpdateContact(dObject);
        }

        public void DeleteContact(int ContactID)
        {
            dbObject.DeleteContact(ContactID);
        }

        //public DataTable GetContactTypes()
        //{
        //    PropertyData dbPropObject = new PropertyData();
        //    return dbPropObject.GetSelections("ContactType"); 
        //}

        public DataTable GetContacts()
        {
            return dbObject.GetContacts();
        }

        public DataTable GetContacts(string FirstName, string LastName)
        {
            return dbObject.GetContacts(FirstName, LastName);
        }

        //public DataTable GetCompanyNames()
        //{
        //    return dbObject.GetCompanyNames();
        //}

        //public DataTable GetContacts(string strCompanyName)
        //{
        //    return dbObject.GetContacts(strCompanyName);
        //}

        public Contact GetContacts(int ContactID)
        {
            return dbObject.GetContacts(ContactID);
        }

        //public String GetSelectionName(int SelectionID)
        //{
        //    return dbObject.GetSelectionName(SelectionID);
        //}
        //public DataTable GetRegions()
        //{
        //    return dbObject.GetRegions();
        //}

        //public String GetRegionName(int RegionID)
        //{
        //    return dbObject.GetRegionName(RegionID);
        //}
    }
}