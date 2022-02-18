using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace BankA
{
    public partial class AccountHRview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["USER_ID"] != null)
            {
                Label1.Text = Session["USER_ID"].ToString();
            }
            else { Response.Redirect("Accounting.aspx"); }
        }

        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button1_Click1(object sender, EventArgs e)
        {


            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(constr);
            string sqlquery = "SELECT id, MonthlySalaryPayment, StaffName, Date, Emergency, MonthlyBenefit, Allowance, EmergencyNeed, Branch, Year, Salary FROM [dbo].[Payment] where Year = '" + TextBox1.Text + "' AND Branch = '" + txtbr.Text + "'";
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

                DataTable dtdV = new DataTable();
                string consdV = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                string sqlquerymV = "SELECT id, MonthlySalaryPayment, StaffName, Date, Emergency, MonthlyBenefit, Allowance, EmergencyNeed, Branch, Year, Salary FROM [dbo].[Payment] where Branch = '" + txtbr.Text + "' AND Year = '" + TextBox1.Text + "'";

                SqlConnection cnzdV = new SqlConnection(consdV);
                SqlCommand cmddV = new SqlCommand();
                cmddV.CommandText = sqlquerymV;
                cmddV.Connection = cnzdV;
                SqlDataAdapter dadV = new SqlDataAdapter(cmddV);
                dadV.SelectCommand = cmddV;

                dadV.Fill(dtdV);
                GridView1.DataSource = dtdV;
                GridView1.DataBind();
                cnzdV.Close();

                var resultV = dtdV.AsEnumerable()
                    .Sum(w => Convert.ToInt32(w["MonthlyBenefit"]));
                Label3.Text = "Total Sum of Monthly Payment is" + " " + resultV.ToString("#,##0.00") + "NGN";

                var resultC = dtdV.AsEnumerable()
                        .Sum(w => Convert.ToInt32(w["Salary"]));
                Label5.Text = "Total Sum of Salary Payment is" + " " + resultC.ToString("#,##0.00");
                        


            }
            else
            {
                Lab1.Text = "No Record" + "|";
            }

            //---------------------------Individual Staff-----------------------------
            string constrB = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconnB = new SqlConnection(constrB);
            string sqlqueryB = "SELECT id, MonthlySalaryPayment, StaffName, Date, Emergency, MonthlyBenefit, Allowance, EmergencyNeed, Year, Salary FROM [dbo].[Payment] where MonthlySalaryPayment = '" + txtmonth.Text + "' AND StaffName = '" + txtstaff.Text + "'";
            SqlCommand sqlcommB = new SqlCommand(sqlqueryB, sqlconnB);
            sqlconnB.Open();
            SqlDataAdapter sdyB = new SqlDataAdapter(sqlcommB);
            DataTable dtyB = new DataTable();
            sdyB.Fill(dtyB);
            SqlDataReader sduB = sqlcommB.ExecuteReader();
            if (sduB.Read())
            {
                GridView1.DataSource = dtyB;
                GridView1.DataBind();
            }
            else
            {
                Lab1.Text = "No Record";
            }


            //-------------------------------------------------------------------------------------------

            string constrW = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconnW = new SqlConnection(constrW);
            string sqlqueryW = "SELECT id, MonthlySalaryPayment, StaffName, Date, Emergency, MonthlyBenefit, Allowance, EmergencyNeed, Branch, Year, Salary FROM [dbo].[Payment] where MonthlySalaryPayment = '" + txtmonth.Text + "' AND Year = '" + TextBox1.Text + "'";
            //string sqlquery = "SELECT id, StaffName, LeaveDate, LeaveRange, LeaveReason, LeaveResume, LeaveMonth, ActiveStatus, NoOfLeave, Branch FROM [dbo].[Leave] where LeaveMonth = '" + txtmonth.Text + "' AND StaffName = '" + TextBox1.Text + "'";


            SqlCommand sqlcommW = new SqlCommand(sqlqueryW, sqlconnW);
            sqlconnW.Open();
            SqlDataAdapter sdyW = new SqlDataAdapter(sqlcommW);
            DataTable dtyW = new DataTable();
            sdyW.Fill(dtyW);
            SqlDataReader sduW = sqlcommW.ExecuteReader();
            if (sduW.Read())
            {
                GridView1.DataSource = dtyW;
                GridView1.DataBind();

                DataTable dtdV = new DataTable();
                string consdV = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // string sqlquerymV = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, BankCharge, PostedBy, AccountType, AccountBalance, Month, Year FROM [dbo].[NewAcount]  WHERE Branch = '" + txtbranch.Text + "' AND AccountType = '" + txtacctType.Text + "'  ORDER BY Date DESC ";
                //  string sqlquerymV = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy, AccountBalance, SMSCharge FROM [dbo].[Deposite] where Date = '" + txtdate2.Text + "' AND Branch = '" + txtbranch.Text + "'  ORDER BY Date DESC ";
                string sqlquerymV = "SELECT id, MonthlySalaryPayment, StaffName, Date, Emergency, MonthlyBenefit, Allowance, EmergencyNeed, Branch, Year, Salary FROM [dbo].[Payment] where MonthlySalaryPayment = '" + txtmonth.Text + "' AND Year = '" + TextBox1.Text + "'";

                SqlConnection cnzdV = new SqlConnection(consdV);
                SqlCommand cmddV = new SqlCommand();
                cmddV.CommandText = sqlquerymV;
                cmddV.Connection = cnzdV;
                SqlDataAdapter dadV = new SqlDataAdapter(cmddV);
                dadV.SelectCommand = cmddV;

                dadV.Fill(dtdV);
                GridView1.DataSource = dtdV;
                GridView1.DataBind();
                cnzdV.Close();

                var resultV = dtdV.AsEnumerable()
                    .Sum(w => Convert.ToInt32(w["MonthlyBenefit"]));
                Lab1.Text = "Total Sum of Monthly Payment is" + " " + resultV.ToString("#,##0.00") + "NGN";

                var resultC = dtdV.AsEnumerable()
                        .Sum(w => Convert.ToInt32(w["Salary"]));
                Label5.Text = "Total Sum of Salary Payment is" + " " + resultC.ToString("#,##0.00");
                        

            }
            else
            {
                Lab1.Text = "No Record";
            }




        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("USER_ID");
            Session.RemoveAll();
            Response.Redirect("HRLogin.aspx");
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {

            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(constr);
            string sqlquery = "SELECT id, StaffName, LeaveDate, LeaveRange, LeaveReason, LeaveResume, LeaveMonth, ActiveStatus, NoOfLeave, Branch, Year FROM [dbo].[Leave] where Year = '" + TextBox1.Text + "' AND Branch = '" + txtbr.Text + "'";
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

            //-----------------------------------------------------------------------------------

            string constrW = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconnW = new SqlConnection(constrW);
            // string sqlquery = "SELECT id, MonthlySalaryPayment, StaffName, Date, Emergency, MonthlyBenefit, Allowance, EmergencyNeed, Branch FROM [dbo].[Payment] where MonthlySalaryPayment = '" + txtmonth.Text + "' AND Branch = '" + DCase + "'";
            string sqlqueryW = "SELECT id, StaffName, LeaveDate, LeaveRange, LeaveReason, LeaveResume, LeaveMonth, ActiveStatus, NoOfLeave, Branch, Year FROM [dbo].[Leave] where Branch = '" + txtbr.Text + "' AND Year = '" + TextBox1.Text + "'";


            SqlCommand sqlcommW = new SqlCommand(sqlqueryW, sqlconnW);
            sqlconnW.Open();
            SqlDataAdapter sdyW = new SqlDataAdapter(sqlcommW);
            DataTable dtyW = new DataTable();
            sdyW.Fill(dtyW);
            SqlDataReader sduW = sqlcommW.ExecuteReader();
            if (sduW.Read())
            {
                GridView1.DataSource = dtyW;
                GridView1.DataBind();
            }
            else
            {
                Lab1.Text = "No Record";
            }



        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(constr);
            string sqlquery = "SELECT id, StaffName, LeaveDate, LeaveRange, LeaveReason, LeaveResume, LeaveMonth, ActiveStatus, NoOfLeave, Branch, Year FROM [dbo].[Leave] where Year = '" + TextBox1.Text + "' AND NoOfLeave = '" + 0 + "'";
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlConnection conws = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conws.Open();
            SqlCommand cmdws = new SqlCommand("Select * from [dbo].[Staff] where StaffName='" + txtstaff.Text + "'", conws);
            SqlDataAdapter daws = new SqlDataAdapter(cmdws);
            DataTable dtws = new DataTable();
            daws.Fill(dtws);
            if (dtws.Rows.Count > 0)
            {
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT Staff.Salary,Payment.MonthlyBenefit FROM Staff INNER JOIN Payment ON Staff.StaffName=Payment.StaffName WHERE dbo.Staff.StaffName='" + txtstaff.Text + "'"))
                    {
                        //  "SELECT dbo.Customer.SMSAlertPhoneNumbers, dbo.AccountBalance.Balance from dbo.Customer INNER JOIN dbo.AccountBalance ON dbo.Customer.CustomerId = dbo.AccountBalance.CustomerId WHERE dbo.AccountBalance.AccountNumber='"+accountNo+"'"; 

                        // using (SqlCommand cmdts = new SqlCommand("SELECT Staff.Salary, Emergency.EmergencyNeed FROM Staff INNER JOIN Emergency ON Staff.StaffName=StaffName.StaffName"))
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();
                            string Salry = sdrr["Salary"].ToString();
                            string PayT = sdrr["MonthlyBenefit"].ToString();

                            int DailyEquivalent = (int.Parse(Salry) / 21) * (int.Parse(TextBox1.Text));
                            //Lab5.Text = DailyEquivalent.ToString();

                            String alartMsg = txtstaff.Text + " " + "Your" + " " + TextBox1.Text + "Days Salary is" + "  " + DailyEquivalent;
                            String script = "alert('" + alartMsg + "');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                        }

                        conns.Close();
                    }
                }
            }
            else { }
        }
    }
}