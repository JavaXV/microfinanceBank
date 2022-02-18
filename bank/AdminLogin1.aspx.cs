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
    public partial class AdminLogin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        // call the linq
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button1_Click(object sender, EventArgs e)
        {

            String active = "Activate";
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from AdminTable1 where UserName='" + txtbranch.Text + "' and PassWord ='" + txtpassword.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["USER_ID"] = txtbranch.Text;
                Response.Redirect("AdminActivate.aspx");
            }
            else
            {
                Label1.Text = "InValid Branch & Password";
            }
        }
    }
}