using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace BankA
{
    public partial class CustomerCareChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(constr);
            string sqlquery = "SELECT id, StaffName, Message, Date FROM [dbo].[Chat1] ORDER BY id DESC";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sdy = new SqlDataAdapter(sqlcomm);
            DataTable dty = new DataTable();
            sdy.Fill(dty);
            SqlDataReader sdu = sqlcomm.ExecuteReader();
            if (sdu.Read())
            {
                GridView1.DataSource = dty;
                GridView1.DataBind();
            }
            else
            {
                Lab1.Text = "No Record";
            }
        }
        // call the linq
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button5_Click(object sender, EventArgs e)
        {
            var sty = new Chat1
            {
                StaffName = txtstaff.Text,
                Message = txtarea.Text,
                Date = DateTime.Now.ToString("dd-MM-yyyy"),
            };

            db.Chat1s.InsertOnSubmit(sty);
            db.SubmitChanges();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerCareChat.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}