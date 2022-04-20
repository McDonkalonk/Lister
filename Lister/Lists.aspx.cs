using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lister
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["ListerConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO List VALUES('" + txtTitle.Text + "')";
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                lblFeedback.Visible = true;
                lblFeedback.Text = "the list <strong>" + txtTitle.Text + "</strong> was added successfully.";
            }
        }
    }
}