using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankA
{
    public partial class _666 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // call the linq
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button1_Click1(object sender, EventArgs e)
        {
            //----------------------------------AUTHEMTIFICATION--------------------------------------------
            if (txtbranch.Text == "" || txtpassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('All Field are Required');", true);

            }
            else
            {
                var styr = new AdminTable
                {
                    UserName = txtbranch.Text,
                    PassWord = txtpassword.Text,
                    Number = 2,
                };
                db.AdminTables.InsertOnSubmit(styr);
                db.SubmitChanges();
                Lab1.Text = "Permission Granted";


            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            //----------------------------update NewAcount---------------------------------
            var st = (from s in db.AdminTables where s.Number == 2 select s).First();
            st.UserName = txtbranch.Text;
            st.PassWord = txtpassword.Text;
            Lab1.Text = "Successful Rechange";
            db.SubmitChanges();
        }


    }
}