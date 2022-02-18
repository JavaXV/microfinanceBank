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
    public partial class CustomerCare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // displaymessage2.Enabled = false;

           // txtmonthyear.Text = DateTime.Now.ToString("MM/yyyy");

        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button1_Click1(object sender, EventArgs e)
        {

            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(constr);
            string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Withdraw, PostedBy FROM [dbo].[Withdraw] where Date ='" + txtdate3.Text + "' and FieldOfficer = '" + txtofficers.Text + "'  ORDER BY Date DESC ";
            // string sqlquery = "SELECT * FROM Deposite ORDER BY Deposite DESC ";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sdy = new SqlDataAdapter(sqlcomm);
            DataTable dty = new DataTable();
            sdy.Fill(dty);
            SqlDataReader sdu = sqlcomm.ExecuteReader();
            if (sdu.Read())
            {
                //--------------------------------------------------------------------
                GridView1.DataSource = dty;
                GridView1.DataBind();
            }
            else
            {
                Lab1.Text = "No Record";
            }

            //--------------------------------------------------------------------------------------------------
            DataTable dtd = new DataTable();
            string consd = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            //string myquery = "Select id, Branch, FieldOfficer, Date, CashInChat, CashInHand, Balance, AllOf, Approved, ApprovalDate, ApprovedBy, AccountNo from [dbo].[FieldOfficerAmount] where AllOf = '" + txtall.Text + "' and  Date = '" + txtdate.Text + "'";
            // string myqueryd = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy, AccountBalance, SMSCharge FROM [dbo].[Deposite] where Date = '" + txtdate1.Text + "'  ORDER BY Date DESC";
            string sqlquerym = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Withdraw, PostedBy FROM [dbo].[Withdraw] where Date ='" + txtdate3.Text + "' and FieldOfficer = '" + txtofficers.Text + "'  ORDER BY Date DESC ";

            SqlConnection cnzd = new SqlConnection(consd);
            SqlCommand cmdd = new SqlCommand();
            cmdd.CommandText = sqlquerym;
            cmdd.Connection = cnzd;
            SqlDataAdapter dad = new SqlDataAdapter(cmdd);
            dad.SelectCommand = cmdd;

            dad.Fill(dtd);
            GridView1.DataSource = dtd;
            GridView1.DataBind();
            cnzd.Close();

            var result = dtd.AsEnumerable()
                .Sum(x => Convert.ToInt32(x["Withdraw"]));
            // Lab2.Text = " Total Withdraw:" + " " + result.ToString();

            Lab2.Text = " Total Withdraw:" + " :";
            Lab14.Text = result.ToString("#,##0.00") + "NGN";

            
            //------------------------------------------------------------------------------
            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from Deposite where FieldOfficer='" + txtofficerss.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            { }
            
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(constr);
            string sqlquery = "SELECT id, CustomerId,Branch,FieldOfficer,AccountNo,PageNumber,Date,PhoneNo,BankCharge,PostedBy,AccountType,AccountBalance,AllNumber FROM [dbo].[DormantAccount] where AllNumber = '" + txtall.Text + "'  ORDER BY FieldOfficer ASC ";
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

            //-------------------------------------------------ACCOUNTNO-------------------------
            string constrWE = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconnWE = new SqlConnection(constrWE);
            string sqlqueryWE = "SELECT id, CustomerId,Branch,FieldOfficer,AccountNo,PageNumber,Date,PhoneNo,BankCharge,PostedBy,AccountType,AccountBalance,AllNumber FROM [dbo].[DormantAccount] where AccountNo = '" + txtall.Text + "'  ORDER BY FieldOfficer ASC ";
            SqlCommand sqlcommWE = new SqlCommand(sqlqueryWE, sqlconnWE);
            sqlconnWE.Open();
            SqlDataAdapter sdyWE = new SqlDataAdapter(sqlcommWE);
            DataTable dtyWE = new DataTable();
            sdyWE.Fill(dtyWE);
            SqlDataReader sduWE = sqlcommWE.ExecuteReader();
            if (sduWE.Read())
            {
                GridView1.DataSource = dtyWE;
                GridView1.DataBind();
            }
            else
            {
                Lab1.Text = "No Record";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(constr);
            string sqlquery = "SELECT id,customername,accountno,phoneno FROM [dbo].[NewCustomer] where SmsId = '" + 2 + "'  ORDER BY customername ASC ";
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

        protected void Button3_Click(object sender, EventArgs e)
        {

            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(constr);
            string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy FROM [dbo].[Deposite] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficerss.Text + "'  ORDER BY Date DESC ";
            // string sqlquery = "SELECT * FROM Deposite ORDER BY Deposite DESC ";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sdy = new SqlDataAdapter(sqlcomm);
            DataTable dty = new DataTable();
            sdy.Fill(dty);
            SqlDataReader sdu = sqlcomm.ExecuteReader();
            if (sdu.Read())
            {
                //--------------------------------------------------------------------
                GridView1.DataSource = dty;
                GridView1.DataBind();
            }
            else
            {
                Lab1.Text = "No Record";
            }

            //--------------------------------------------------------------------------------------------------
            DataTable dtd = new DataTable();
            string consd = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            //string myquery = "Select id, Branch, FieldOfficer, Date, CashInChat, CashInHand, Balance, AllOf, Approved, ApprovalDate, ApprovedBy, AccountNo from [dbo].[FieldOfficerAmount] where AllOf = '" + txtall.Text + "' and  Date = '" + txtdate.Text + "'";
           // string myqueryd = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy, AccountBalance, SMSCharge FROM [dbo].[Deposite] where Date = '" + txtdate1.Text + "'  ORDER BY Date DESC";
            string sqlquerym = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy FROM [dbo].[Deposite] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficerss.Text + "'  ORDER BY Date DESC ";
          
            SqlConnection cnzd = new SqlConnection(consd);
            SqlCommand cmdd = new SqlCommand();
            cmdd.CommandText = sqlquerym;
            cmdd.Connection = cnzd;
            SqlDataAdapter dad = new SqlDataAdapter(cmdd);
            dad.SelectCommand = cmdd;

            dad.Fill(dtd);
            GridView1.DataSource = dtd;
            GridView1.DataBind();
            cnzd.Close();

            var result = dtd.AsEnumerable()
                .Sum(x => Convert.ToInt32(x["Deposite"]));
            //Lab2.Text = " Total Deposite:" + " " + result.ToString();

            Lab2.Text = " Total Deposite:" + " :";
            Lab14.Text = result.ToString("#,##0.00") + "NGN";
            



        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            if (txtAccountNo.Text == "" && txtmonth.Text == "")
            { }
            else
            {
                //----------------------------------------------------------------------------------------------------

             
            }
        }
        protected void Button59_Click(object sender, EventArgs e)
        {
            string constrxcZ = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconnxcZ = new SqlConnection(constrxcZ);
            // string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy, AccountBalance, SMSCharge FROM [dbo].[Deposite] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficer.Text + "'  ORDER BY Date DESC ";
            string sqlqueryxcZ = "SELECT id, SmsPrice, AcctNo, AcctType FROM [dbo].[SmsProfit] where AcctType ='" + DropDownList1.Text + "' and AcctNo = '" + txtAccountNo.Text + "'  ORDER BY SmsPrice DESC ";

            SqlCommand sqlcommxcZ = new SqlCommand(sqlqueryxcZ, sqlconnxcZ);
            sqlconnxcZ.Open();
            SqlDataAdapter sdyxcZ = new SqlDataAdapter(sqlcommxcZ);
            DataTable dtyxcZ = new DataTable();
            sdyxcZ.Fill(dtyxcZ);
            SqlDataReader sduxcZ = sqlcommxcZ.ExecuteReader();
            if (sduxcZ.Read())
            {
                //--------------------------------------------------------------------
                GridView1.DataSource = dtyxcZ;
                GridView1.DataBind();

                DataTable dtdxcZ = new DataTable();
                string consdxcZ = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                string sqlquerymxcZ = "SELECT id, sms, AcctNo, AcctType FROM [dbo].[BuckFixedSMS] WHERE AcctType ='" + DropDownList1.Text + "' AND AcctNo = '" + txtAccountNo.Text + "'";

                SqlConnection cnzdxcZ = new SqlConnection(consdxcZ);
                SqlCommand cmddxcZ = new SqlCommand();
                cmddxcZ.CommandText = sqlquerymxcZ;
                cmddxcZ.Connection = cnzdxcZ;
                SqlDataAdapter dadxcZ = new SqlDataAdapter(cmddxcZ);
                dadxcZ.SelectCommand = cmddxcZ;

                dadxcZ.Fill(dtdxcZ);
                GridView1.DataSource = dtdxcZ;
                GridView1.DataBind();
                cnzdxcZ.Close();

                var resultxcZ = dtdxcZ.AsEnumerable()
                    .Sum(x => Convert.ToInt32(x["sms"]));
                // Lab14.Text = " Total smsCharge:" + " " + resultxcZ.ToString();

                Lab2.Text = " Total SMSCharge:" + " :";
                Lab14.Text = resultxcZ.ToString("#,##0.00") + "NGN";
            }
            else
            {
                Lab1.Text = "No Record";
            }
            
        }

        protected void Button51_Click(object sender, EventArgs e)
        {

            if (txtAccountNo.Text == "" && txtmonth.Text == "")
            { }
            else
            {
             
                string constrxc = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                SqlConnection sqlconnxc = new SqlConnection(constrxc);
                // string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy, AccountBalance, SMSCharge FROM [dbo].[Deposite] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficer.Text + "'  ORDER BY Date DESC ";
                string sqlqueryxc = "SELECT id, msg, phoneno, date, accountno, depositebalance, smsCharge, month, Year FROM [dbo].[BuckFixedSMS] where accountno ='" + txtAccountNo.Text + "' and Year = '" + txtmonthyear.Text + "'  ORDER BY smsCharge DESC ";

                SqlCommand sqlcommxc = new SqlCommand(sqlqueryxc, sqlconnxc);
                sqlconnxc.Open();
                SqlDataAdapter sdyxc = new SqlDataAdapter(sqlcommxc);
                DataTable dtyxc = new DataTable();
                sdyxc.Fill(dtyxc);
                SqlDataReader sduxc = sqlcommxc.ExecuteReader();
                if (sduxc.Read())
                {
                    GridView1.DataSource = dtyxc;
                    GridView1.DataBind();

                    //------------------------------------------------------------------
                    DataTable dtdxc = new DataTable();
                    string consdxc = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    string sqlquerymxc = "SELECT id, msg, date, phoneno, accountno, depositebalance, sms, month, Year FROM [dbo].[BuckFixedSMS] where accountno ='" + txtAccountNo.Text + "' AND Year = '" + txtmonthyear.Text + "'";

                    SqlConnection cnzdxc = new SqlConnection(consdxc);
                    SqlCommand cmddxc = new SqlCommand();
                    cmddxc.CommandText = sqlquerymxc;
                    cmddxc.Connection = cnzdxc;
                    SqlDataAdapter dadxc = new SqlDataAdapter(cmddxc);
                    dadxc.SelectCommand = cmddxc;

                    dadxc.Fill(dtdxc);
                    GridView1.DataSource = dtdxc;
                    GridView1.DataBind();
                    cnzdxc.Close();

                    var resultxc = dtdxc.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["sms"]));
                   // Lab14.Text = " Total SMSCharge:" + " " + resultxc.ToString();

                    Lab2.Text = " Total SMSCharge:" + " :";
                    Lab14.Text = resultxc.ToString("#,##0.00") + "NGN";
                }
                else
                {
                    Lab1.Text = "No Record";
                }
                //--------------------------------------------------------------------


                string constrxcW = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                SqlConnection sqlconnxcW = new SqlConnection(constrxcW);
                // string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy, AccountBalance, SMSCharge FROM [dbo].[Deposite] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficer.Text + "'  ORDER BY Date DESC ";
                string sqlqueryxcW = "SELECT id, msg, phoneno, date, accountno, depositebalance, smCharge, month, Year FROM [dbo].[WeeklySMS1] where accountno ='" + txtAccountNo.Text + "' and Year = '" + txtmonthyear.Text + "'  ORDER BY smCharge DESC ";

                SqlCommand sqlcommxcW = new SqlCommand(sqlqueryxcW, sqlconnxcW);
                sqlconnxcW.Open();
                SqlDataAdapter sdyxcW = new SqlDataAdapter(sqlcommxcW);
                DataTable dtyxcW = new DataTable();
                sdyxcW.Fill(dtyxcW);
                SqlDataReader sduxcW = sqlcommxcW.ExecuteReader();
                if (sduxcW.Read())
                {
                    //--------------------------------------------------------------------
                    GridView1.DataSource = dtyxcW;
                    GridView1.DataBind();

                    DataTable dtdxcW = new DataTable();
                    string consdxcW = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    string sqlquerymxcW = "SELECT id, msg, date, phoneno, accountno, depositebalance, smCharge, month, Year FROM [dbo].[WeeklySMS1] where accountno ='" + txtAccountNo.Text + "' AND Year = '" + txtmonthyear.Text + "'";

                    SqlConnection cnzdxcW = new SqlConnection(consdxcW);
                    SqlCommand cmddxcW = new SqlCommand();
                    cmddxcW.CommandText = sqlquerymxcW;
                    cmddxcW.Connection = cnzdxcW;
                    SqlDataAdapter dadxcW = new SqlDataAdapter(cmddxcW);
                    dadxcW.SelectCommand = cmddxcW;

                    dadxcW.Fill(dtdxcW);
                    GridView1.DataSource = dtdxcW;
                    GridView1.DataBind();
                    cnzdxcW.Close();

                    var resultxcW = dtdxcW.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["smCharge"]));
                   // Lab14.Text = " Total SMSCharge:" + " " + resultxcW.ToString();

                    Lab2.Text = " Total SMSCharge:" + " :";
                    Lab14.Text = resultxcW.ToString("#,##0.00") + "NGN";
                }
                else
                {
                    Lab1.Text = "No Record";
                }

                //-----------------------------------------------------------------
                string constrxcWM = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                SqlConnection sqlconnxcWM = new SqlConnection(constrxcWM);
                // string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy, AccountBalance, SMSCharge FROM [dbo].[Deposite] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficer.Text + "'  ORDER BY Date DESC ";
                string sqlqueryxcWM = "SELECT id, msg, phoneno, date, accountno, depositebalance, smCharge, month, Year FROM [dbo].[WeeklySMS1] where msg ='" + DropDownList1.Text + "' and month = '" + txtmonth.Text + "'  ORDER BY smCharge DESC ";

                SqlCommand sqlcommxcWM = new SqlCommand(sqlqueryxcWM, sqlconnxcWM);
                sqlconnxcWM.Open();
                SqlDataAdapter sdyxcWM = new SqlDataAdapter(sqlcommxcWM);
                DataTable dtyxcWM = new DataTable();
                sdyxcWM.Fill(dtyxcWM);
                SqlDataReader sduxcWM = sqlcommxcWM.ExecuteReader();
                if (sduxcWM.Read())
                {
                    //--------------------------------------------------------------------
                    GridView1.DataSource = dtyxcWM;
                    GridView1.DataBind();


                    DataTable dtdxcW = new DataTable();
                    string consdxcW = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    string sqlquerymxcW = "SELECT id, msg, date, phoneno, accountno, depositebalance, smCharge, month, Year FROM [dbo].[WeeklySMS1] where msg ='" + DropDownList1.Text + "' AND month = '" + txtmonth.Text + "'";

                    SqlConnection cnzdxcW = new SqlConnection(consdxcW);
                    SqlCommand cmddxcW = new SqlCommand();
                    cmddxcW.CommandText = sqlquerymxcW;
                    cmddxcW.Connection = cnzdxcW;
                    SqlDataAdapter dadxcW = new SqlDataAdapter(cmddxcW);
                    dadxcW.SelectCommand = cmddxcW;

                    dadxcW.Fill(dtdxcW);
                    GridView1.DataSource = dtdxcW;
                    GridView1.DataBind();
                    cnzdxcW.Close();

                    var resultxcW = dtdxcW.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["smCharge"]));
                   // Lab14.Text = " Total SMSCharge:" + " " + resultxcW.ToString();

                    Lab2.Text = " Total SMSCharge:" + " :";
                    Lab14.Text = resultxcW.ToString("#,##0.00") + "NGN";
                }
                else
                {
                    Lab1.Text = "No Record";
                }

                //-----------------------------------------------------------------------------------------------

                string constrxcZ = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                SqlConnection sqlconnxcZ = new SqlConnection(constrxcZ);
                // string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy, AccountBalance, SMSCharge FROM [dbo].[Deposite] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficer.Text + "'  ORDER BY Date DESC ";
                string sqlqueryxcZ = "SELECT id, msg, phoneno, date, accountno, depositebalance, smsCharge, month, Year FROM [dbo].[BuckFixedSMS] where msg ='" + DropDownList1.Text + "' and accountno = '" + txtAccountNo.Text + "'  ORDER BY smsCharge DESC ";

                SqlCommand sqlcommxcZ = new SqlCommand(sqlqueryxcZ, sqlconnxcZ);
                sqlconnxcZ.Open();
                SqlDataAdapter sdyxcZ = new SqlDataAdapter(sqlcommxcZ);
                DataTable dtyxcZ = new DataTable();
                sdyxcZ.Fill(dtyxcZ);
                SqlDataReader sduxcZ = sqlcommxcZ.ExecuteReader();
                if (sduxcZ.Read())
                {
                    //--------------------------------------------------------------------
                    GridView1.DataSource = dtyxcZ;
                    GridView1.DataBind();

                    DataTable dtdxcZ = new DataTable();
                    string consdxcZ = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    string sqlquerymxcZ = "SELECT id, msg, date, phoneno, accountno, depositebalance, sms, month, Year FROM [dbo].[BuckFixedSMS] WHERE msg ='" + DropDownList1.Text + "' AND accountno = '" + txtAccountNo.Text + "'";

                    SqlConnection cnzdxcZ = new SqlConnection(consdxcZ);
                    SqlCommand cmddxcZ = new SqlCommand();
                    cmddxcZ.CommandText = sqlquerymxcZ;
                    cmddxcZ.Connection = cnzdxcZ;
                    SqlDataAdapter dadxcZ = new SqlDataAdapter(cmddxcZ);
                    dadxcZ.SelectCommand = cmddxcZ;

                    dadxcZ.Fill(dtdxcZ);
                    GridView1.DataSource = dtdxcZ;
                    GridView1.DataBind();
                    cnzdxcZ.Close();

                    var resultxcZ = dtdxcZ.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["sms"]));
                   // Lab14.Text = " Total smsCharge:" + " " + resultxcZ.ToString();

                    Lab2.Text = " Total SMSCharge:" + " :";
                    Lab14.Text = resultxcZ.ToString("#,##0.00") + "NGN";
                }
                else
                {
                    Lab1.Text = "No Record";
                }
            
                //-----------------------------------------------------------------------------------------------

                string constrxcZZ = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                SqlConnection sqlconnxcZZ = new SqlConnection(constrxcZZ);
                // string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy, AccountBalance, SMSCharge FROM [dbo].[Deposite] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficer.Text + "'  ORDER BY Date DESC ";
                string sqlqueryxcZZ = "SELECT id, msg, phoneno, date, accountno, depositebalance, smsCharge, month, Year FROM [dbo].[BuckFixedSMS] where Year ='" + txtmonthyear.Text + "' and msg = '" + DropDownList1.Text + "'  ORDER BY smsCharge DESC ";

                SqlCommand sqlcommxcZZ = new SqlCommand(sqlqueryxcZZ, sqlconnxcZZ);
                sqlconnxcZZ.Open();
                SqlDataAdapter sdyxcZZ = new SqlDataAdapter(sqlcommxcZZ);
                DataTable dtyxcZZ = new DataTable();
                sdyxcZZ.Fill(dtyxcZZ);
                SqlDataReader sduxcZZ = sqlcommxcZZ.ExecuteReader();
                if (sduxcZZ.Read())
                {
                    //--------------------------------------------------------------------
                    GridView1.DataSource = dtyxcZZ;
                    GridView1.DataBind();

                    DataTable dtdxcZ = new DataTable();
                    string consdxcZ = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    string sqlquerymxcZ = "SELECT id, msg, date, phoneno, accountno, depositebalance, sms, month, Year FROM [dbo].[BuckFixedSMS] where msg ='" + DropDownList1.Text + "' and Year = '" + txtmonthyear.Text + "'";

                    SqlConnection cnzdxcZ = new SqlConnection(consdxcZ);
                    SqlCommand cmddxcZ = new SqlCommand();
                    cmddxcZ.CommandText = sqlquerymxcZ;
                    cmddxcZ.Connection = cnzdxcZ;
                    SqlDataAdapter dadxcZ = new SqlDataAdapter(cmddxcZ);
                    dadxcZ.SelectCommand = cmddxcZ;

                    dadxcZ.Fill(dtdxcZ);
                    GridView1.DataSource = dtdxcZ;
                    GridView1.DataBind();
                    cnzdxcZ.Close();

                    var resultxcZ = dtdxcZ.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["sms"]));
                   // Lab14.Text = " Total smsCharge:" + " " + resultxcZ.ToString();

                    Lab2.Text = " Total SMSCharge:" + " :";
                    Lab14.Text = resultxcZ.ToString("#,##0.00") + "NGN";
                }
                else
                {
                    Lab1.Text = "No Record";
                }


                //-----------------------------------------------------------------
                string constrxcWMZ = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                SqlConnection sqlconnxcWMZ = new SqlConnection(constrxcWMZ);
                // string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy, AccountBalance, SMSCharge FROM [dbo].[Deposite] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficer.Text + "'  ORDER BY Date DESC ";
                string sqlqueryxcWMZ = "SELECT id, msg, phoneno, date, accountno, depositebalance, smCharge, month, Year FROM [dbo].[WeeklySMS1] where msg ='" + DropDownList1.Text + "' and Year = '" +txtmonthyear.Text + "'  ORDER BY smCharge DESC ";

                SqlCommand sqlcommxcWMZ = new SqlCommand(sqlqueryxcWMZ, sqlconnxcWMZ);
                sqlconnxcWMZ.Open();
                SqlDataAdapter sdyxcWMZ = new SqlDataAdapter(sqlcommxcWMZ);
                DataTable dtyxcWMZ = new DataTable();
                sdyxcWMZ.Fill(dtyxcWMZ);
                SqlDataReader sduxcWMZ = sqlcommxcWMZ.ExecuteReader();
                if (sduxcWMZ.Read())
                {
                    //--------------------------------------------------------------------
                    GridView1.DataSource = dtyxcWMZ;
                    GridView1.DataBind();


                    DataTable dtdxcW = new DataTable();
                    string consdxcW = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    string sqlquerymxcW = "SELECT id, msg, date, phoneno, accountno, depositebalance, smCharge, month, Year FROM [dbo].[WeeklySMS1] where msg ='" + DropDownList1.Text + "' AND Year = '" + txtmonthyear.Text + "'";

                    SqlConnection cnzdxcW = new SqlConnection(consdxcW);
                    SqlCommand cmddxcW = new SqlCommand();
                    cmddxcW.CommandText = sqlquerymxcW;
                    cmddxcW.Connection = cnzdxcW;
                    SqlDataAdapter dadxcW = new SqlDataAdapter(cmddxcW);
                    dadxcW.SelectCommand = cmddxcW;

                    dadxcW.Fill(dtdxcW);
                    GridView1.DataSource = dtdxcW;
                    GridView1.DataBind();
                    cnzdxcW.Close();

                    var resultxcW = dtdxcW.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["smCharge"]));

                    Lab2.Text = " Total SMSCharge:" + " :" ;
                    Lab14.Text = resultxcW.ToString("#,##0.00") + "NGN";
                }
                else
                {
                    Lab1.Text = "No Record";
                }
            }
        }
    }
}