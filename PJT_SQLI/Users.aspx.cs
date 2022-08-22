using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SQLIDetector;
using BusinessLibrary;
using BusinessEntities;
namespace PJT_SQLI
{
    public partial class Users : System.Web.UI.Page
    {
        private SqlConnection Connection;
        private SqlCommand cmd;
        private static int UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Connection = DBFactory.GetConnection();
            Connection.Open();
            if (!IsPostBack)
            {               

                if(SQLIValidator.ValidateURLStatement(Request.QueryString["Id"]))
                {
                    var httpRequestBase = new HttpRequestWrapper(HttpContext.Current.Request);
                    IPAddressBlocker.BlockIPA(httpRequestBase);
                    Server.Transfer("AccessDeniedError.aspx");
                }

                if (!(SQLIValidator.Validate_SQLIStrings(txtFname.Text.Trim())))
                {
                    var httpRequestBase = new HttpRequestWrapper(HttpContext.Current.Request);
                    IPAddressBlocker.BlockIPA(httpRequestBase);
                    Server.Transfer("AccessDeniedError.aspx");
                }

                if (int.TryParse(Request.QueryString["Id"], out UserId))
                {
                    var contacts = new ContactBusiness();
                    var contact = new BusinessEntities.Contact();
                    contact = contacts.GetContacts(UserId);
                    txtFname.Text = contact.FirstName;
                    txtLname.Text = contact.LastName;
                    txtPhone.Text = contact.Phone;
                    txtEmail.Text = contact.EMail;
                    txtHseNo.Text = contact.HouseNo.ToString();
                    txtAddress.Text = contact.StreetName1 + " " + contact.StreetName2;
                    txtCountry.Text = contact.CountryCode;
                    txtPostalCode.Text = contact.PostCode;
                }
            }

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {

            bool flgSubmit = true;
            if (!SQLIValidator.IsValidMobileNumber(txtPhone.Text.Trim()))
            {
                lblValidateLPhone.Text = "Invalid Phone number.";
                flgSubmit = false;
            }
            else
            {
                lblValidateLPhone.Text = "";
            }
            if (!SQLIValidator.IsValidEmail(txtEmail.Text.Trim()))
            {
                lblValidateLEmail.Text = "Invalid Email format.";
                flgSubmit = false;
            }
            else
            {
                lblValidateLEmail.Text = "";
            }

            if (!SQLIValidator.Validate_SQLIStrings(txtEmail.Text.Trim()))
            {
                var httpRequestBase = new HttpRequestWrapper(HttpContext.Current.Request);
                IPAddressBlocker.BlockIPA(httpRequestBase);
                Server.Transfer("AccessDeniedError.aspx");
            }
           


            if (!SQLIValidator.Validate_SQLIStrings(txtPhone.Text.Trim()))
            {
                var httpRequestBase = new HttpRequestWrapper(HttpContext.Current.Request);
                IPAddressBlocker.BlockIPA(httpRequestBase);
                Server.Transfer("AccessDeniedError.aspx");
            }
            if (flgSubmit)
            {
                cmd = new SqlCommand();
                SqlParameter[] paramCollection = new SqlParameter[3];
                SqlParameter param1 = new SqlParameter("@Email", txtEmail.Text.Trim());
                paramCollection[0] = param1;
                SqlParameter param2 = new SqlParameter("@phone", txtPhone.Text.Trim());
                paramCollection[1] = param2;
                SqlParameter param3 = new SqlParameter("@ID", UserId);
                paramCollection[2] = param3;
                var sqlText = "Update CONTACTS SET EMAIL = @Email, PHONE = @phone where ID = @ID";
                DBFactory.ExecuteNonQuery(DBFactory.GetConnectionString(), CommandType.Text, sqlText, paramCollection);
                Response.Redirect("ListUsers.aspx");
            }



        }

        
    }
}