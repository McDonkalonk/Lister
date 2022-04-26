using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;

namespace Lister
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnRegister_Click(object sender, EventArgs e)
        { 
            if(Page.IsValid)
            {
                string email = txtEmail.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                

                if(!IsEmailRegistered(email))
                {
                    RegisterUser(email, username, password);
                }
                else
                {

                }
            }
        }

        private void RegisterUser(string email, string username, string password)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["ListerConnectionString"].ConnectionString;
#pragma warning disable CS0618 // Type or member is obsolete
                string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
#pragma warning restore CS0618 // Type or member is obsolete
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO User(Email, Username, HashedPassword) VALUES('" + email + "', '" + username + "', '" + hashedPassword + "')"; 
                
                cmd.Connection = conn;
                conn.Open();

                if(cmd.ExecuteNonQuery() == 1)
                {
                    Response.Redirect("SignIn.aspx");
                }
                else
                {
                    lblRegisterFailed.Visible = true;
                    lblRegisterFailed.InnerText = "Register Failed, Try again.";
                }
            }

        }

        private bool IsEmailRegistered(string email)
        {
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["ListerConnectionString"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Users WHERE Email = '" + email + "'";
                cmd.Connection = conn;
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                if(sdr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }

}