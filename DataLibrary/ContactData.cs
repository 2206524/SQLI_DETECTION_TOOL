using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SQLIDetector;
using BusinessEntities;

namespace DataLibrary
{
    public class ContactData : IDisposable
    {
        private SqlConnection Connection;

        public ContactData()
        {
            Connection = DBFactory.GetConnection();
            Connection.Open();
        }

        public void DeleteContact(int ContactID)
        {
            try
            {
                SqlCommand dbCommand = DBFactory.GetStoredProcCommand(Connection, "DeleteContact");
                DBFactory.AddParameter(dbCommand, "@ContactID", SqlDbType.Int, ContactID);
                dbCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdateContact(Contact dObject)
        {
            try
            {
                SqlCommand dbCommand = DBFactory.GetStoredProcCommand(Connection, "UpdateContact");
                DBFactory.AddParameter(dbCommand, "@ContactID", SqlDbType.Int, dObject.ContactID);
                DBFactory.AddParameter(dbCommand, "@Firstname", SqlDbType.NVarChar, dObject.FirstName);
                DBFactory.AddParameter(dbCommand, "@Lastname", SqlDbType.NVarChar, dObject.LastName);
                DBFactory.AddParameter(dbCommand, "@Phone", SqlDbType.Int, dObject.Phone);
                DBFactory.AddParameter(dbCommand, "@Email", SqlDbType.NVarChar, dObject.EMail);
                DBFactory.AddParameter(dbCommand, "@Houseno", SqlDbType.Int, dObject.HouseNo);
                DBFactory.AddParameter(dbCommand, "@Streetname1", SqlDbType.NVarChar, dObject.StreetName1);
                DBFactory.AddParameter(dbCommand, "@Streetname2", SqlDbType.NVarChar, dObject.StreetName2);
                DBFactory.AddParameter(dbCommand, "@State", SqlDbType.NVarChar, dObject.State);
                DBFactory.AddParameter(dbCommand, "@Country_Code", SqlDbType.NVarChar, dObject.State);
                DBFactory.AddParameter(dbCommand, "@CountryID", SqlDbType.NVarChar, dObject.CountryCode);
                DBFactory.AddParameter(dbCommand, "@Postalcode", SqlDbType.NVarChar, dObject.PostCode);
                DBFactory.AddParameter(dbCommand, "@Createddate", SqlDbType.DateTime, dObject.CreatedDate);
               

                dbCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public DataTable GetContacts()
        {
            try
            {
                DataSet dSet = null;

                SqlParameter[] sqlPrms = new SqlParameter[1];
                sqlPrms[0] = new SqlParameter("@Return", SqlDbType.Int);
                sqlPrms[0].Direction = ParameterDirection.ReturnValue;

                dSet = DBFactory.ExecuteDataset(Connection, CommandType.StoredProcedure, "GETContacts", sqlPrms);

                return dSet.Tables[0];
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public DataTable GetContacts(string strFirstname, string strLastName)
        {
            try
            {
                DataSet dSet = null;

                SqlParameter[] sqlPrms = new SqlParameter[3];
                sqlPrms[2] = new SqlParameter("@Return", SqlDbType.Int);
                sqlPrms[2].Direction = ParameterDirection.ReturnValue;
                sqlPrms[0] = new SqlParameter("@FirstName", strFirstname);
                sqlPrms[0].Direction = ParameterDirection.Input;
                sqlPrms[1] = new SqlParameter("@LastName", strLastName);
                sqlPrms[1].Direction = ParameterDirection.Input;

                dSet = DBFactory.ExecuteDataset(Connection, CommandType.StoredProcedure, "GETContacts", sqlPrms);

                return dSet.Tables[0];
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public Contact GetContacts(int ContactID)
        {
            try
            {
                DataSet dSet = null;

                SqlParameter[] sqlPrms = new SqlParameter[2];
                sqlPrms[1] = new SqlParameter("@Return", SqlDbType.Int);
                sqlPrms[1].Direction = ParameterDirection.ReturnValue;
                sqlPrms[0] = new SqlParameter("@ContactID", ContactID);
                sqlPrms[0].Direction = ParameterDirection.Input;

                dSet = DBFactory.ExecuteDataset(Connection, CommandType.StoredProcedure, "GetContactsByID", sqlPrms);
                Contact obj = new Contact(dSet.Tables[0].Rows[0]);
                return obj;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        //public String GetCountryName(int CountryID)
        //{
        //    try
        //    {
        //        DataSet dSet = null;
        //        string strCountryName = string.Empty;
        //        SqlParameter[] sqlPrms = new SqlParameter[2];
        //        sqlPrms[0] = new SqlParameter("@CountryID", CountryID);
        //        sqlPrms[0].Direction = ParameterDirection.Input;
        //        sqlPrms[1] = new SqlParameter("@Return", SqlDbType.Int);
        //        sqlPrms[1].Direction = ParameterDirection.ReturnValue;

        //        dSet = DBFactory.ExecuteDataset(Connection, CommandType.StoredProcedure, "GetCountryByID", sqlPrms);
        //        if (dSet.Tables[0].Rows.Count > 0)
        //            strCountryName = dSet.Tables[0].Rows[0]["CountryName"].ToString();
        //        return strCountryName;
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return null;
        //    }
        //}

        //public DataTable GetRegions()
        //{
        //    try
        //    {
        //        DataSet dSet = null;

        //        SqlParameter[] sqlPrms = new SqlParameter[1];
        //        sqlPrms[0] = new SqlParameter("@Return", SqlDbType.Int);
        //        sqlPrms[0].Direction = ParameterDirection.ReturnValue;

        //        dSet = DBFactory.ExecuteDataset(Connection, CommandType.StoredProcedure, "GetRegions", sqlPrms);

        //        return dSet.Tables[0];
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return null;
        //    }
        //}

        //public String GetRegionName(int RegionID)
        //{
        //    try
        //    {
        //        DataSet dSet = null;
        //        string strRegionName = string.Empty;

        //        SqlParameter[] sqlPrms = new SqlParameter[2];
        //        sqlPrms[0] = new SqlParameter("@RegionID", RegionID);
        //        sqlPrms[0].Direction = ParameterDirection.Input;
        //        sqlPrms[1] = new SqlParameter("@Return", SqlDbType.Int);
        //        sqlPrms[1].Direction = ParameterDirection.ReturnValue;

        //        dSet = DBFactory.ExecuteDataset(Connection, CommandType.StoredProcedure, "GetRegionByID", sqlPrms);
        //        if (dSet.Tables[0].Rows.Count > 0)
        //            strRegionName = dSet.Tables[0].Rows[0]["RegionName"].ToString();
        //        return strRegionName;
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return null;
        //    }
        //}

        //public String GetSelectionName(int SelectionID)
        //{
        //    try
        //    {
        //        DataSet dSet = null;
        //        string strSelectionName = string.Empty;
        //        SqlParameter[] sqlPrms = new SqlParameter[2];
        //        sqlPrms[0] = new SqlParameter("@SelectionID", SelectionID);
        //        sqlPrms[0].Direction = ParameterDirection.Input;
        //        sqlPrms[1] = new SqlParameter("@Return", SqlDbType.Int);
        //        sqlPrms[1].Direction = ParameterDirection.ReturnValue;

        //        dSet = DBFactory.ExecuteDataset(Connection, CommandType.StoredProcedure, "GetSelectionName", sqlPrms);
        //        if (dSet.Tables[0].Rows.Count > 0)
        //            strSelectionName = dSet.Tables[0].Rows[0]["SelectionName"].ToString();
        //        return strSelectionName;
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return null;
        //    }
        //}

        #region IDisposable Members

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }

        #endregion
    }
}