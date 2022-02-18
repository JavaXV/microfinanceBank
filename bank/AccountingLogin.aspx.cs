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
    public partial class AccountingLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // call the linq
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || txtpassword.Text == "" || txtbranch.Text == "")
            {
                Lab1.Text = "Please be Informed Fill in empty Field";
            }
            else
            {
                String value1 = "ccc";
                String value2 = "ccc";
                String active = "Activate";
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                con.Open();
                //  SqlCommand cmd = new SqlCommand("Select * from CustomerCareUser where Active='" + active + "' and Password ='" + txtpassword.Text + "'", con);
                SqlCommand cmd = new SqlCommand("Select * from AccountingUser where Branch ='" + txtbranch.Text + "' and PassWord ='" + txtpassword.Text + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["USER_ID"] = txtbranch.Text;
                    Session["USER_IDS"] = txtusername.Text;
                    Response.Redirect("Accounting.aspx");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //------------------------------------

            if (txtusername.Text == "" && txtpassword.Text == "" && txtbranch.Text == "")
            {
                Lab1.Text = "Please Inform Fill in empty Field";
            }
            else
            {
                var sty = new AccountingUser
                {
                    Username = txtusername.Text,
                    Password = "Not-Activated",
                    Active = txtpassword.Text,
                    Everyone = "Accounting",
                    Branch = txtbranch.Text,
                };

                db.AccountingUsers.InsertOnSubmit(sty);
                db.SubmitChanges();
                Lab1.Text = "Please Inform the Admin To Activate your Account";


                var sr = new UserTable1
                {
                    Username = txtusername.Text,       
                };

                db.UserTable1s.InsertOnSubmit(sr);
                db.SubmitChanges();
            }

            //------------------------------------
        }
    }
}