using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;


namespace Lister
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindList();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
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

                BindList();
            }
        }

        protected void BindList()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["ListerConnectionString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM List";
            cmd.Connection = conn;

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            conn.Open();

            sda.Fill(dt);
            gvListTitle.DataSource = dt;
            gvListTitle.DataBind();
            conn.Close();
        }

        protected void gvListTitle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button editButton = e.Row.FindControl("btnEdit") as Button;
                Button deleteButton = e.Row.FindControl("btnDelete") as Button;

                editButton.CommandArgument = e.Row.Cells[0].Text;
                deleteButton.CommandArgument = e.Row.Cells[0].Text;
            }
        }

        protected void gvListTitle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditList")
            {
                int ListID = int.Parse(e.CommandArgument.ToString());

                EditListById(ListID);
                lblListID.Text = e.CommandArgument.ToString();
            }
            else if (e.CommandName == "DeleteList")
            {
                int ListID = int.Parse(e.CommandArgument.ToString());
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["ListerConnectionString"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM List where ListID = " + ListID;
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                BindList();
            }
        }

        private void EditListById(int ListID)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["ListerConnectionString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM List where ListID = " + ListID;
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                txtTitle.Text = sdr[1].ToString();


            }

            btnTitle.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            pnlTitleList.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnTitle.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            pnlTitleList.Visible = true;
            txtTitle.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int ListID = int.Parse(lblListID.Text);

            SaveListById(ListID);


        }

        private void SaveListById(int ListID)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["ListerConnectionString"].ConnectionString;

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "UPDATE List SET Title='" + txtTitle.Text + "' WHERE ListID = " + ListID;
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                BindList();

                btnTitle.Visible = true;
                btnSave.Visible = false;
                btnCancel.Visible = false;
                pnlTitleList.Visible = true;
                txtTitle.Text = "";
            }




        }
    }
}