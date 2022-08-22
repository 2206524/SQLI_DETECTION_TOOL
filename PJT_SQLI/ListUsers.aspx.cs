using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLIDetector;
using BusinessLibrary;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace PJT_SQLI
{
    public partial class ListUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var httpRequestBase = new HttpRequestWrapper(HttpContext.Current.Request);
            if (SQLIDetector.IPAddressBlocker.CheckBlackListIPA(httpRequestBase))
            {
                Server.Transfer("AccessDeniedError.aspx");
            }
            


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bool FNameValid = true;
            bool LNameValid = true;
            if (!(SQLIValidator.Validate_SQLIStrings(txtFname.Text.Trim()) && SQLIValidator.Validate_SQLIStrings(TxtLname.Text.Trim())))
            {
                var httpRequestBase = new HttpRequestWrapper(HttpContext.Current.Request);
                IPAddressBlocker.BlockIPA(httpRequestBase);
                Server.Transfer("AccessDeniedError.aspx");
            }
            if(!(txtFname.Text== null || txtFname.Text == ""))
            {
                if (SQLIValidator.isValidTextInput(txtFname.Text.Trim()))
                {
                    FNameValid = false;
                    lblValidateFName.Text = "Invalid characters in First Name.";
                }
                else
                {
                    lblValidateFName.Text = "";
                }
            }
            if (!(TxtLname.Text == null || TxtLname.Text == ""))
            {
                if (SQLIValidator.isValidTextInput(TxtLname.Text.Trim()))
                {
                    LNameValid = false;
                    lblValidateLName.Text = "Invalid characters in  Last Name.";
                }
                else
                {
                    lblValidateLName.Text = "";
                }
            }
               
            if (FNameValid && LNameValid)
            { 
                BusinessLibrary.ContactBusiness contacts = new ContactBusiness();
                grdContacts.DataSource = contacts.GetContacts(txtFname.Text.Trim(), TxtLname.Text.Trim());
                grdContacts.DataBind();
            }
        }

    }
}