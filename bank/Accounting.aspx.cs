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
    public partial class Accounting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                Label1.Text = Session["USER_ID"].ToString();
            }
            else { Response.Redirect("AccountingLogin.aspx"); }
            if (Session["USER_IDS"] != null)
            {
                Label20.Text = Session["USER_IDS"].ToString();
            }
            else { Response.Redirect("AccountingLogin.aspx"); }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("USER_ID");
            Session.RemoveAll();
            Response.Redirect("AccountingLogin.aspx");
        }

    }
}