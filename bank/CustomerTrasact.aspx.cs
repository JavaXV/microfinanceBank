using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Globalization;

namespace BankA
{
    public partial class CustomerTrasact : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
           // txtdate.Enabled = false;
           //txtdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (Session["USER_ID"] != null)
            {
                Label1.Text = Session["USER_ID"].ToString();
            }
            else { Response.Redirect("NewCustomerLogin.aspx"); }

            if (Session["USER_IDS"] != null)
            {
                Label20.Text = Session["USER_IDS"].ToString();
            }
            else { Response.Redirect("NewCustomerLogin.aspx"); }
        
            //---------------------------dormant account---------------------------

            //----------------------read highest ID----------------------------------------------------
            string cons = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection cnz = new SqlConnection(cons);

            SqlCommand cmdzs = new SqlCommand("SELECT MAX (id) FROM NewAcount ", cnz);
            cmdzs.CommandType = CommandType.Text;
            cmdzs.Connection.Open();
            SqlDataReader dr = cmdzs.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    string Lab = dr[0].ToString();
                    // Lab1.Text = dr[0].ToString();

                    //--------------------------END------------------------------------------------------------
                    int i = 1;
                    while (i <= int.Parse(Lab))
                    {
                        //-------------------------------------bank charge--------------------------------------------
                        string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        using (SqlConnection conns = new SqlConnection(constrings))
                        {
                            using (SqlCommand cmdts = new SqlCommand("SELECT id, CustomerId,Branch,FieldOfficer,AccountBalance,AccountNo,PageNumber,Date,PhoneNo,BankCharge,PostedBy,AccountType,SmsId,Coment,MaturityDate,NoOfMonth,Interest,Month,Year,Amount,InterestPercent,Months,Dates FROM NewAcount WHERE id = '" + i + "'"))
                            {
                                cmdts.CommandType = CommandType.Text;
                                cmdts.Connection = conns;
                                conns.Open();
                          
                                using (SqlDataReader sdrr = cmdts.ExecuteReader())
                                {
                                    sdrr.Read();
                                    string id = sdrr["id"].ToString();
                                    string CustomerId = sdrr["CustomerId"].ToString();
                                    string Branch = sdrr["Branch"].ToString();
                                    string FieldOfficer = sdrr["FieldOfficer"].ToString();
                                    string AccountNo = sdrr["AccountNo"].ToString();
                                    string PageNumber = sdrr["PageNumber"].ToString();
                                    string Date = sdrr["Date"].ToString();
                                    string PhoneNo = sdrr["PhoneNo"].ToString();
                                    string BankCharge = sdrr["BankCharge"].ToString();
                                    string PostedBy = sdrr["PostedBy"].ToString();
                                    string AccountBalance = sdrr["AccountBalance"].ToString();
                                    string AccountType = sdrr["AccountType"].ToString();
                                    string Amt = sdrr["Amount"].ToString();

                                    string NoOfMonth = sdrr["NoOfMonth"].ToString();
                                    string Coment = sdrr["Coment"].ToString();
                                    string Year = sdrr["Year"].ToString();
                                    string InterestPercent = sdrr["InterestPercent"].ToString();
                                    string Months = sdrr["Months"].ToString();
                                    string Dates = sdrr["Dates"].ToString();
                               

                                    //--------------codition--------------------------------

                                    String MatureDate = sdrr["MaturityDate"].ToString();
                                    String InitialDeposite = sdrr["BankCharge"].ToString();
                                    String AcNo = sdrr["AccountNo"].ToString();
                                    String Bals = sdrr["AccountBalance"].ToString();
                                    String Month = sdrr["NoOfMonth"].ToString();
                                    String Intery = sdrr["Interest"].ToString();
                                    //--------------------------------------------------------------------
                                    int dateInString = 0;

                                    DateTime startDate = DateTime.Parse(Date);
                                    DateTime expiryDate = startDate.AddDays(90);
                                    if (DateTime.Now > expiryDate && Double.Parse(AccountBalance) <= dateInString)
                                     {
                                        //... trial expired
                                        //----------------------------------insert to Table------------------------------------
                                        string connetionString;
                                        SqlConnection cnn;
                                        //string path;

                                        connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";

                                        cnn = new SqlConnection(connetionString);
                                        cnn.Open();

                                        SqlCommand command;
                                        SqlDataAdapter adapter = new SqlDataAdapter();
                                        String sql = "";
                                        String AllNumber = "All";

                                        sql = "Insert into DormantAccount(CustomerId,Branch,FieldOfficer,AccountBalance,AccountNo,PageNumber,Date,PhoneNo,BankCharge,PostedBy,AccountType,AllNumber,Coment,MaturityDate,NoOfMonth,Interest,Month,Year,Amount,InterestPercent,Months,Dates)values('" + CustomerId + "','" + Branch + "','" + FieldOfficer + "','" + AccountBalance + "','" + AccountNo + "','" + PageNumber + "','" + Date + "','" + PhoneNo + "','" + BankCharge + "','" + PostedBy + "','" + AccountType + "','" + AllNumber + "','" + Coment + "','" + MatureDate + "','" + NoOfMonth + "','" +Intery + "','" + Month + "','" + Year + "','" + Amt + "','" + InterestPercent + "','" + Months + "','" + Dates + "')";

                                        command = new SqlCommand(sql, cnn);
                                        adapter.InsertCommand = new SqlCommand(sql, cnn);
                                        adapter.InsertCommand.ExecuteNonQuery();

                                        command.Dispose();
                                        cnn.Close();
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Some Account Moved To Dormant Successful');", true);


                                       //---------------------------DELETE---------------------------------------------
                                        string connetionString0;
                                        SqlConnection cnn0;
                                        SqlCommand comand;
                                   
                                        connetionString0 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        cnn0 = new SqlConnection(connetionString0);
                                        cnn0.Open();

                                        string sql0 = "Select * from NewAcount where id='" +i+ "'";
                                        comand = new SqlCommand(sql0, cnn0);
                                        SqlDataAdapter da = new SqlDataAdapter(comand);
                                        DataTable dt = new DataTable();
                                        da.Fill(dt);
                                        if (dt.Rows.Count > 0)
                                        {

                                            //----------------------------update AccountBalance---------------------------------
                                            var tiny22 = (from s in db.NewAcounts where s.id == i select s).First();
                                            tiny22.AccountBalance = 1;

                                            //----------------------------update PhoneNo---------------------------------
                                            var tiny2 = (from s in db.NewAcounts where s.id == i select s).First();
                                            tiny2.AccountType = "DORMANT ACCOUNT";
                                            db.SubmitChanges();
                                          

                                        }
                                        else
                                        {

                                            // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Customer ID is required');", true);

                                        }


                                    }

                                  //-------------------------------------------------------------------------------------------


                                    if (AccountType == "Buck Fixed Account Yaba" || AccountType == "Buck Fixed Account Ikeja" || AccountType == "Buck Fixed Account Ikorodu" || AccountType == "Buck Fixed Account Aja" || AccountType == "Buck Fixed Account X" || AccountType == "Buck Fixed Account Y" || AccountType == "Buck Fixed Account Z")
                                    {
                                        CultureInfo ci = new CultureInfo("en-US");
                                        if (MatureDate == DateTime.Now.ToString("yyyy-MM-dd"))
                                        {

                                            Double FinalRes = (double.Parse(Amt) * double.Parse(Intery));
                                            Lab1.Text = " Interest |" + FinalRes.ToString();

                                            double OverAll = int.Parse(Bals) + FinalRes;
                                            Lab2.Text = OverAll.ToString();
                                            txtsms.Text = OverAll.ToString();
                                            //----------------------------update NewAcount---------------------------------
                                            var st = (from s in db.NewAcounts where s.id == i select s).First();
                                            st.AccountBalance = (OverAll);
                                            db.SubmitChanges();

                                            var stb = (from s in db.NewAcounts where s.id == i select s).First();
                                            st.AccountBalance = float.Parse(txtsms.Text);
                                            db.SubmitChanges();

                                            //----------------------------update NewAcount---------------------------------
                                            var sty = (from s in db.NewAcounts where s.id == i select s).First();
                                            sty.MaturityDate = "Program Completed";
                                            db.SubmitChanges();


                                            //---------------------------SUM-------------------------------------------------

                                            SqlConnection conwsB = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                            conwsB.Open();
                                            SqlCommand cmdwsB = new SqlCommand("Select * from BuckFixedSMS where accountno ='" + AccountNo + "'", conwsB);
                                            SqlDataAdapter dawsB = new SqlDataAdapter(cmdwsB);
                                            DataTable dtwsB = new DataTable();
                                            dawsB.Fill(dtwsB);
                                            if (dtwsB.Rows.Count > 0)
                                            {

                                                //-------------------------------------bank charge--------------------------------------------
                                                string constringsq = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                using (SqlConnection connsq = new SqlConnection(constringsq))
                                                {
                                                    using (SqlCommand cmdtsq = new SqlCommand("SELECT id, sms, accountno FROM BuckFixedSMS WHERE accountno = '" + AccountNo + "'"))
                                                    {
                                                        cmdtsq.CommandType = CommandType.Text;
                                                        cmdtsq.Connection = connsq;
                                                        connsq.Open();

                                                        using (SqlDataReader sdrrq = cmdtsq.ExecuteReader())
                                                        {
                                                            sdrrq.Read();
                                                            string balCharge = sdrrq["sms"].ToString();

                                                            Lab03.Text = " sumSMS |" + balCharge.ToString();

                                                            Double val1 = ((OverAll) - double.Parse(balCharge));
                                                            string val = val1.ToString();

                                                            //----------------------------update NewAcount---------------------------------

                                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                            SqlConnection connectionu = new SqlConnection(consst);
                                                            connectionu.Open();
                                                            // string queu = "select * from [dbo].[NewAcount] where id = '" + i + "' AND AccountNo = '" + AccountNo + "' ";
                                                            string queu = "update dbo.NewAcount set AccountBalance=@val where AccountNo = '" + AccountNo + "'";
                                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                                            cmd5.Parameters.AddWithValue("@val", val);
                                                            cmd5.ExecuteNonQuery();

                                                            connectionu.Close();
                                                            Lab02.Text = " Overall Balance |" + val.ToString();

                                                            //----------------------------update BuckFixed---------------------------------
                                                            var stu = (from s in db.BuckFixedSMs where s.accountno == AccountNo select s).First();
                                                            stu.sms = "0";
                                                            db.SubmitChanges();
                                                            txtAcountNo.Text = AccountNo;

                                                            var styr = new SMSAlertProfit
                                                            {
                                                                Month = (DateTime.Now.ToString("MM")),
                                                                AccountNo = AccountNo,
                                                                Profit = balCharge.ToString(),
                                                                Year = DateTime.Now.ToString("yyyy"),

                                                            };
                                                            db.SMSAlertProfits.InsertOnSubmit(styr);
                                                            db.SubmitChanges();

                                                            //----------------------yearlyProfit------------------------
                                                            var styry = new YearlyProfit
                                                            {
                                                                Month = (DateTime.Now.ToString("MM")),
                                                                AccountNo = AccountNo,
                                                                YearGain = balCharge.ToString(),
                                                                Year = DateTime.Now.ToString("yyyy"),
                                                            };
                                                            db.YearlyProfits.InsertOnSubmit(styry);
                                                            db.SubmitChanges();
                                                        }

                                                        connsq.Close();
                                                    }
                                                }

                                            }
                                            else
                                            { }




                                        }
                                        else
                                        { }
                                    }
                                    else { }

                                    //-----------------------------------------------------------------------------------------------

                                    if (AccountType == "Target Account Yaba" || AccountType == "Target Account Ikeja" || AccountType == "Target Account Ikorodu" || AccountType == "Target Account Aja" || AccountType == "Target Account X" || AccountType == "Target Account Y" || AccountType == "Target Account Z")
                                    {
                                        CultureInfo ci = new CultureInfo("en-US");
                                        if (MatureDate == DateTime.Now.ToString("yyyy-MM-dd") && float.Parse(Bals) >= float.Parse(Amt))
                                        {

                                            Double FinalRes = (double.Parse(Amt) * double.Parse(Intery));
                                            Lab1.Text = " Interest |" + FinalRes.ToString();                                            

                                            double OverAll = int.Parse(Bals) + FinalRes;
                                            Lab2.Text = " Current |" + OverAll.ToString();
                                            txtsms.Text = OverAll.ToString();
                                            //----------------------------update NewAcount---------------------------------
                                            var st = (from s in db.NewAcounts where s.id == i select s).First();
                                            st.AccountBalance = (OverAll);
                                            db.SubmitChanges();

                                            var stb = (from s in db.NewAcounts where s.id == i select s).First();
                                            st.AccountBalance = float.Parse(txtsms.Text);
                                            db.SubmitChanges();

                                            //----------------------------update NewAcount---------------------------------
                                            var sty = (from s in db.NewAcounts where s.id == i select s).First();
                                            sty.MaturityDate = "Program Completed";
                                            db.SubmitChanges();


                                            //---------------------------SUM-------------------------------------------------
                    
                                            SqlConnection conwsB = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                            conwsB.Open();
                                            SqlCommand cmdwsB = new SqlCommand("Select * from BuckFixedSMS where accountno ='" + AccountNo + "'", conwsB);
                                            SqlDataAdapter dawsB = new SqlDataAdapter(cmdwsB);
                                            DataTable dtwsB = new DataTable();
                                            dawsB.Fill(dtwsB);
                                            if (dtwsB.Rows.Count > 0)
                                            {
                                                
                                                //-------------------------------------bank charge--------------------------------------------
                                                string constringsq = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                using (SqlConnection connsq = new SqlConnection(constringsq))
                                                {
                                                    using (SqlCommand cmdtsq = new SqlCommand("SELECT id, smsCharge, accountno FROM BuckFixedSMS WHERE accountno = '" + AccountNo + "'"))
                                                    {
                                                        cmdtsq.CommandType = CommandType.Text;
                                                        cmdtsq.Connection = connsq;
                                                        connsq.Open();

                                                        using (SqlDataReader sdrrq = cmdtsq.ExecuteReader())
                                                        {
                                                            sdrrq.Read();
                                                            string balCharge = sdrrq["sms"].ToString();

                                                            Lab03.Text = " sumSMS |" + balCharge.ToString();

                                                            Double val = ((OverAll) - double.Parse(balCharge));
                                                          
                                                            //----------------------------update NewAcount---------------------------------

                                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                            SqlConnection connectionu = new SqlConnection(consst);
                                                            connectionu.Open();
                                                           // string queu = "select * from [dbo].[NewAcount] where id = '" + i + "' AND AccountNo = '" + AccountNo + "' ";
                                                            string queu = "update dbo.NewAcount set AccountBalance=@val where AccountNo = '" + AccountNo + "'";                                 
                                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                                            cmd5.Parameters.AddWithValue("@val", val);
                                                            cmd5.ExecuteNonQuery();

                                                            connectionu.Close();
                                                            Lab02.Text = " Overall Balance |" + val.ToString();

                                                            //----------------------------update BuckFixed---------------------------------
                                                            var stu = (from s in db.BuckFixedSMs where s.accountno == AccountNo select s).First();
                                                            stu.sms = "0";
                                                            db.SubmitChanges();
                                                            txtAcountNo.Text = AccountNo;


                                                            var styr = new SMSAlertProfit
                                                            {
                                                                Month = (DateTime.Now.ToString("MM")),
                                                                AccountNo = AccountNo,
                                                                Profit = balCharge.ToString(),
                                                                Year = DateTime.Now.ToString("yyyy"),

                                                            };
                                                            db.SMSAlertProfits.InsertOnSubmit(styr);
                                                            db.SubmitChanges();

                                                            //----------------------yearlyProfit------------------------
                                                            var styry = new YearlyProfit
                                                            {
                                                                Month = (DateTime.Now.ToString("MM")),
                                                                AccountNo = AccountNo,
                                                                YearGain = balCharge.ToString(),
                                                                Year = DateTime.Now.ToString("yyyy"),
                                                            };
                                                            db.YearlyProfits.InsertOnSubmit(styry);
                                                            db.SubmitChanges();
                                                        }

                                                        connsq.Close();
                                                    }
                                                }
                                              
                                            }
                                            else
                                            { }
                                        
                                        }
                                        else
                                        { }
                                    }
                                    else { }
                                  //------------------------------------------------------------------------------------------- 
                                }

                                conns.Close();
                            }
                        }

                        i++;
                    }
                }
            }
        }
        // call the linq
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (txtcustomerid.Text == "" || txtbr.Text == "" || txtofficer.Text == "" || txtAcountNo.Text == "" || txtpageno.Text == "" || txtsms.Text == "" || txtfee.Text == "" || txtpostedby.Text == "" || txtaccounttype.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('All field are required');", true);
            }
            else
            {
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                conw.Open();
                SqlCommand cmdw = new SqlCommand("Select * from Tmt where Branch='" + DCase + "'", conw);
                SqlDataAdapter daw = new SqlDataAdapter(cmdw);
                DataTable dtw = new DataTable();
                daw.Fill(dtw);
                if (dtw.Rows.Count > 0)
                {
                    //-------------------------------------------------------------------------------------
                  
                                    //-------------------------------------Read--------------------------------------------
                                    string constringsm = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    using (SqlConnection connsY = new SqlConnection(constringsm))
                                    {
                                        using (SqlCommand cmdtsY = new SqlCommand("SELECT id, Date FROM Tmt WHERE Branch = '" + DCase + "'"))
                                        {
                                            cmdtsY.CommandType = CommandType.Text;
                                            cmdtsY.Connection = connsY;
                                            connsY.Open();

                                            using (SqlDataReader sdrrY = cmdtsY.ExecuteReader())
                                            {
                                                sdrrY.Read();
                                                string Dater = sdrrY["Date"].ToString();

                                                if (txtdate.Text == Dater && txtbr.Text == DCase)
                                                {

                                                    if (txtaccounttype.Text == "Loan Account" || txtaccounttype.Text == "Target Account Yaba" || txtaccounttype.Text == "Target Account Ikeja" || txtaccounttype.Text == "Target Account Ikorodu" || txtaccounttype.Text == "Target Account Aja" || txtaccounttype.Text == "Target Account X" || txtaccounttype.Text == "Target Account Y" || txtaccounttype.Text == "Target Account Z" || txtaccounttype.Text == "Buck Fixed Account Yaba" || txtaccounttype.Text == "Buck Fixed Account Ikeja" || txtaccounttype.Text == "Buck Fixed Account Ikorodu" || txtaccounttype.Text == "Buck Fixed Account Aja" || txtaccounttype.Text == "Buck Fixed Account X" || txtaccounttype.Text == "Buck Fixed Account Y" || txtaccounttype.Text == "Buck Fixed Account Z" || txtaccounttype.Text == "Loan Account Yaba" || txtaccounttype.Text == "Loan Account Ikeja" || txtaccounttype.Text == "Loan Account Ikorodu" || txtaccounttype.Text == "Loan Account Aja" || txtaccounttype.Text == "Loan Account X" || txtaccounttype.Text == "Loan Account Y" || txtaccounttype.Text == "Loan Account Z")
                                                    { 
                                                        //-------------------------------check page exit or use with another accountno---------------
                                                        string connetionString10;
                                                        SqlConnection cnn10;
                                                        SqlCommand comand10;
                                                        //String path;


                                                        connetionString10 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                        cnn10 = new SqlConnection(connetionString10);
                                                        cnn10.Open();
                                                        string sql1 = "Select * from NewAcount where PageNumber='" + txtpageno.Text + "' ";
                                                        comand10 = new SqlCommand(sql1, cnn10);
                                                        SqlDataAdapter da1 = new SqlDataAdapter(comand10);
                                                        DataTable dt1 = new DataTable();
                                                        da1.Fill(dt1);
                                                        if (dt1.Rows.Count > 0)
                                                        {
                                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('PageNumber has Already been Used by Another Customer');", true);

                                                        }
                                                        else
                                                        {
                                                            SqlConnection conwW = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                                            conwW.Open();
                                                            SqlCommand cmdwW = new SqlCommand("Select * from NewCustomer where accountno='" + txtAcountNo.Text + "'", conwW);
                                                            SqlDataAdapter dawW = new SqlDataAdapter(cmdwW);
                                                            DataTable dtwW = new DataTable();
                                                            dawW.Fill(dtwW);
                                                            if (dtwW.Rows.Count > 0)
                                                            {
                                                                int monthNumber = int.Parse(DateTime.Now.ToString("MM"));
                                                                String mthNumber = new DateTimeFormatInfo().GetMonthName(monthNumber);
                                                                String Yr = DateTime.Now.ToString("MM/yyyy");
                                                                String Mnth = DateTime.Now.ToString("dd");

                                                                if (mthNumber == "Febuary")
                                                                {  //----------------------------------insert to Table------------------------------------
                                                                    string connetionString;
                                                                    SqlConnection cnn;
                                                                    String Feb = "0";



                                                                    connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";

                                                                    cnn = new SqlConnection(connetionString);
                                                                    cnn.Open();


                                                                    SqlCommand command2;
                                                                    SqlDataAdapter adapter = new SqlDataAdapter();
                                                                    String sql = "";
                                                                    int value = 2;
                                                                    Double val = Double.Parse(txtloan.Text) * Double.Parse(txtmoney.Text);


                                                                    sql = "Insert into NewAcount(CustomerId,Branch,FieldOfficer,AccountNo,PageNumber,Date,PhoneNo,BankCharge,PostedBy,AccountType, AccountBalance, SmsId,MaturityDate,NoOfMonth,Interest,Month,Year,Amount,InterestPercent,Dates)values('" + txtcustomerid.Text + "','" + txtbr.Text + "','" + txtofficer.Text + "','" + txtAcountNo.Text + "','" + txtpageno.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + txtsms.Text + "','" + txtfee.Text + "','" + txtpostedby.Text + "','" + txtaccounttype.Text + "','" + 0 + "','" + value + "','" + txtmaturity.Text + "','" + txtmonth.Text + "','" + val + "','" + mthNumber + "','" + Yr + "','" + txtmoney.Text + "','" + txtloan.Text + "','" + Feb + "')";


                                                                    command2 = new SqlCommand(sql, cnn);
                                                                    adapter.InsertCommand = new SqlCommand(sql, cnn);
                                                                    adapter.InsertCommand.ExecuteNonQuery();

                                                                    command2.Dispose();
                                                                    cnn.Close();
                                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successful Transact');", true);

                                                                    connetionString10 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                                    cnn10 = new SqlConnection(connetionString10);
                                                                    cnn10.Open();
                                                                    string sql1dd = "Select * from NewCustomerSMS where AccountNo ='" + txtAcountNo.Text + "' ";
                                                                    comand10 = new SqlCommand(sql1dd, cnn10);
                                                                    SqlDataAdapter da1dd = new SqlDataAdapter(comand10);
                                                                    DataTable dt1dd = new DataTable();
                                                                    da1dd.Fill(dt1dd);
                                                                    if (dt1dd.Rows.Count > 0)
                                                                    {

                                                                        //------------------------------Update NewCustomerSMS----------------------------------------------
                                                                        var sty = (from s in db.NewCustomerSMs where s.AccountNo == txtAcountNo.Text select s).First();
                                                                        sty.PageNo = txtpageno.Text;
                                                                        db.SubmitChanges();
                                                                    }
                                                                    else { }
                                                                }
                                                                else if (mthNumber == "April" || mthNumber == "June" || mthNumber == "September" || mthNumber == "November")
                                                                {  //----------------------------------insert to Table------------------------------------
                                                                    string connetionString;
                                                                    SqlConnection cnn;
                                                                    String Feb = "0";



                                                                    connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";

                                                                    cnn = new SqlConnection(connetionString);
                                                                    cnn.Open();


                                                                    SqlCommand command2;
                                                                    SqlDataAdapter adapter = new SqlDataAdapter();
                                                                    String sql = "";
                                                                    int value = 2;
                                                                    // Double val = Double.Parse(txtloan.Text) * Double.Parse(txtmoney.Text);
                                                                    Double val = Double.Parse(txtloan.Text.ToString()) * Double.Parse(txtmoney.Text.ToString());



                                                                    sql = "Insert into NewAcount(CustomerId,Branch,FieldOfficer,AccountNo,PageNumber,Date,PhoneNo,BankCharge,PostedBy,AccountType, AccountBalance, SmsId,MaturityDate,NoOfMonth,Interest,Month,Year,Amount,InterestPercent,Dates)values('" + txtcustomerid.Text + "','" + txtbr.Text + "','" + txtofficer.Text + "','" + txtAcountNo.Text + "','" + txtpageno.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + txtsms.Text + "','" + txtfee.Text + "','" + txtpostedby.Text + "','" + txtaccounttype.Text + "','" + 0 + "','" + value + "','" + txtmaturity.Text + "','" + txtmonth.Text + "','" + val + "','" + mthNumber + "','" + Yr + "','" + txtmoney.Text + "','" + txtloan.Text + "','" + Feb + "')";


                                                                    command2 = new SqlCommand(sql, cnn);
                                                                    adapter.InsertCommand = new SqlCommand(sql, cnn);
                                                                    adapter.InsertCommand.ExecuteNonQuery();

                                                                    command2.Dispose();
                                                                    cnn.Close();
                                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successful Transact');", true);

                                                                    connetionString10 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                                    cnn10 = new SqlConnection(connetionString10);
                                                                    cnn10.Open();
                                                                    string sql1dd = "Select * from NewCustomerSMS where AccountNo ='" + txtAcountNo.Text + "' ";
                                                                    comand10 = new SqlCommand(sql1dd, cnn10);
                                                                    SqlDataAdapter da1dd = new SqlDataAdapter(comand10);
                                                                    DataTable dt1dd = new DataTable();
                                                                    da1dd.Fill(dt1dd);
                                                                    if (dt1dd.Rows.Count > 0)
                                                                    {

                                                                        //------------------------------Update NewCustomerSMS----------------------------------------------
                                                                        var sty = (from s in db.NewCustomerSMs where s.AccountNo == txtAcountNo.Text select s).First();
                                                                        sty.PageNo = txtpageno.Text;
                                                                        db.SubmitChanges();
                                                                    }
                                                                    else { }
                                                                }
                                                                else
                                                                {  //----------------------------------insert to Table------------------------------------
                                                                    string connetionString;
                                                                    SqlConnection cnn;
                                                                    String Feb = "31";



                                                                    connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";

                                                                    cnn = new SqlConnection(connetionString);
                                                                    cnn.Open();


                                                                    SqlCommand command2;
                                                                    SqlDataAdapter adapter = new SqlDataAdapter();
                                                                    String sql = "";
                                                                    int value = 2;
                                                                    Double val = Double.Parse(txtloan.Text) * Double.Parse(txtmoney.Text);


                                                                    sql = "Insert into NewAcount(CustomerId,Branch,FieldOfficer,AccountNo,PageNumber,Date,PhoneNo,BankCharge,PostedBy,AccountType, AccountBalance, SmsId,MaturityDate,NoOfMonth,Interest,Month,Year,Amount,InterestPercent,Dates)values('" + txtcustomerid.Text + "','" + txtbr.Text + "','" + txtofficer.Text + "','" + txtAcountNo.Text + "','" + txtpageno.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + txtsms.Text + "','" + txtfee.Text + "','" + txtpostedby.Text + "','" + txtaccounttype.Text + "','" + 0 + "','" + value + "','" + txtmaturity.Text + "','" + txtmonth.Text + "','" + val + "','" + mthNumber + "','" + Yr + "','" + txtmoney.Text + "','" + txtloan.Text + "','" + Feb + "')";


                                                                    command2 = new SqlCommand(sql, cnn);
                                                                    adapter.InsertCommand = new SqlCommand(sql, cnn);
                                                                    adapter.InsertCommand.ExecuteNonQuery();

                                                                    command2.Dispose();
                                                                    cnn.Close();
                                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successful Transact');", true);

                                                                    connetionString10 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                                    cnn10 = new SqlConnection(connetionString10);
                                                                    cnn10.Open();
                                                                    string sql1dd = "Select * from NewCustomerSMS where AccountNo ='" + txtAcountNo.Text + "' ";
                                                                    comand10 = new SqlCommand(sql1dd, cnn10);
                                                                    SqlDataAdapter da1dd = new SqlDataAdapter(comand10);
                                                                    DataTable dt1dd = new DataTable();
                                                                    da1dd.Fill(dt1dd);
                                                                    if (dt1dd.Rows.Count > 0)
                                                                    {

                                                                        //------------------------------Update NewCustomerSMS----------------------------------------------
                                                                        var sty = (from s in db.NewCustomerSMs where s.AccountNo == txtAcountNo.Text select s).First();
                                                                        sty.PageNo = txtpageno.Text;
                                                                        db.SubmitChanges();
                                                                    }
                                                                    else { }
                                                                }
                                                            }
                                                            else { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('AccountNo does not Exist');", true); }                                                       
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('This is for Creation of Buck Fixed and Target Account & Loan');", true);
                                                    }

                                                    //---------------------------------------------------------------------------------------
                                                    SqlConnection conwsBA = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                                    conwsBA.Open();
                                                    SqlCommand cmdwsBA = new SqlCommand("Select * from Deposite where AccountNo='" + txtAcountNo.Text + "'", conwsBA);
                                                    SqlDataAdapter dawsBA = new SqlDataAdapter(cmdwsBA);
                                                    DataTable dtwsBA = new DataTable();
                                                    dawsBA.Fill(dtwsBA);
                                                    if (dtwsBA.Rows.Count > 0)
                                                    {}
                                                    else
                                                    {
                                                        if (txtaccounttype.Text == "Loan Account" || txtaccounttype.Text == "Target Account Yaba" || txtaccounttype.Text == "Target Account Ikeja" || txtaccounttype.Text == "Target Account Ikorodu" || txtaccounttype.Text == "Target Account Aja" || txtaccounttype.Text == "Target Account X" || txtaccounttype.Text == "Target Account Y" || txtaccounttype.Text == "Target Account Z" || txtaccounttype.Text == "Buck Fixed Account Yaba" || txtaccounttype.Text == "Buck Fixed Account Ikeja" || txtaccounttype.Text == "Buck Fixed Account Ikorodu" || txtaccounttype.Text == "Buck Fixed Account Aja" || txtaccounttype.Text == "Buck Fixed Account X" || txtaccounttype.Text == "Buck Fixed Account Y" || txtaccounttype.Text == "Buck Fixed Account Z")                                           
                                                         {}
                                                         else
                                                         {
                                                             //------------------------------Update NewAcount----------------------------------------------
                                                            var sty2 = (from s in db.NewAcounts where s.AccountNo == float.Parse(txtAcountNo.Text) select s).First();
                                                            sty2.AccountBalance = -5;
                                                            db.SubmitChanges();
                                                         }
                                                    }

                                                    SqlConnection conwWG = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                                    conwWG.Open();
                                                    SqlCommand cmdwWG = new SqlCommand("Select * from NewCustomer where accountno='" + txtAcountNo.Text + "'", conwWG);
                                                    SqlDataAdapter dawWG = new SqlDataAdapter(cmdwWG);
                                                    DataTable dtwWG = new DataTable();
                                                    dawWG.Fill(dtwWG);
                                                    if (dtwWG.Rows.Count > 0)
                                                    {

                                                        //-----------------------------------------Loan--------------------------------------------
                                                        if (txtaccounttype.Text == "Loan Account")
                                                        {
                                                            var sty = new LoanInterest
                                                            {

                                                                NoOfMonth = txtmonth.Text,
                                                                LoanAmount = "0",
                                                                MaturityDate = txtmaturity.Text,
                                                                Interest = "0",
                                                                ContractNo = txtAcountNo.Text,
                                                                CustomerName = null,
                                                                ManagementFee = "0",
                                                                Month = null,
                                                                AccountBalance = "0",
                                                                AccountType = "Loan Account",


                                                            };
                                                            db.LoanInterests.InsertOnSubmit(sty);
                                                            db.SubmitChanges();
                                                        }

                                                        //-----------------------------------------Buck Fixed Account--------------------------------------------
                                                        if (txtaccounttype.Text == "Buck Fixed Account Yaba" || txtaccounttype.Text == "Buck Fixed Account Ikeja" || txtaccounttype.Text == "Buck Fixed Account Ikorodu" || txtaccounttype.Text == "Buck Fixed Account Aja" || txtaccounttype.Text == "Buck Fixed Account X" || txtaccounttype.Text == "Buck Fixed Account Y" || txtaccounttype.Text == "Buck Fixed Account Z")
                                                        {
                                                            var sty = new BuckFixedSM
                                                            {

                                                                customerid = txtcustomerid.Text,
                                                                msg = txtaccounttype.Text,
                                                                accountno = txtAcountNo.Text,
                                                                phoneno = null,
                                                                depositebalance = 0,
                                                                date = DateTime.Now.ToString("yyyy-MM-dd"),
                                                                depositecollect = 0,
                                                                smsCharge = "5",
                                                                sms = "0",


                                                            };
                                                            db.BuckFixedSMs.InsertOnSubmit(sty);
                                                            db.SubmitChanges();

                                                            var styD = new BuckFixedSMS1
                                                            {

                                                                customerid = txtcustomerid.Text,
                                                                msg = txtaccounttype.Text,
                                                                accountno = txtAcountNo.Text,
                                                                phoneno = null,
                                                                depositebalance = 0,
                                                                date = DateTime.Now.ToString("yyyy-MM-dd"),
                                                                depositecollect = 0,
                                                                smsid = null,


                                                            };
                                                            db.BuckFixedSMS1s.InsertOnSubmit(styD);
                                                            db.SubmitChanges();
                                                        }

                                                        if (txtaccounttype.Text == "Target Account Yaba" || txtaccounttype.Text == "Target Account Ikeja" || txtaccounttype.Text == "Target Account Ikorodu" || txtaccounttype.Text == "Target Account Aja" || txtaccounttype.Text == "Target Account X" || txtaccounttype.Text == "Target Account Y" || txtaccounttype.Text == "Target Account Z")
                                                        {
                                                            var sty = new BuckFixedSM
                                                            {

                                                                customerid = txtcustomerid.Text,
                                                                msg = txtaccounttype.Text,
                                                                accountno = txtAcountNo.Text,
                                                                phoneno = null,
                                                                depositebalance = 0,
                                                                date = DateTime.Now.ToString("yyyy-MM-dd"),
                                                                depositecollect = 0,
                                                                smsCharge = "5",
                                                                sms = "0",

                                                            };
                                                            db.BuckFixedSMs.InsertOnSubmit(sty);
                                                            db.SubmitChanges();

                                                            var styD = new BuckFixedSMS1
                                                            {

                                                                customerid = txtcustomerid.Text,
                                                                msg = txtaccounttype.Text,
                                                                accountno = txtAcountNo.Text,
                                                                phoneno = null,
                                                                depositebalance = 0,
                                                                date = DateTime.Now.ToString("yyyy-MM-dd"),
                                                                depositecollect = 0,
                                                                smsid = null,


                                                            };
                                                            db.BuckFixedSMS1s.InsertOnSubmit(styD);
                                                            db.SubmitChanges();
                                                        }

                                                        if (txtaccounttype.Text == "Soft Saving Yaba" || txtaccounttype.Text == "Soft Saving Ikeja" || txtaccounttype.Text == "Soft Saving Ikorodu" || txtaccounttype.Text == "Soft Saving Aja" || txtaccounttype.Text == "Soft Saving X" || txtaccounttype.Text == "Soft Saving Y" || txtaccounttype.Text == "Soft Saving Z" || txtaccounttype.Text == "Flexible Yaba" || txtaccounttype.Text == "Flexible Ikeja" || txtaccounttype.Text == "Flexible Ikorodu" || txtaccounttype.Text == "Flexible Aja" || txtaccounttype.Text == "Flexible X" || txtaccounttype.Text == "Flexible Y" || txtaccounttype.Text == "Flexible Z")
                                                        {
                                                            //-----------------------------------------SMS--------------------------------------------
                                                            var styt = new WeeklySM
                                                            {

                                                                customerid = null,
                                                                msg = null,
                                                                accountno = txtAcountNo.Text,
                                                                phoneno = null,
                                                                depositebalance = 0,
                                                                date = null,
                                                                depositecollect = 0,
                                                                smsid = null,

                                                            };
                                                            db.WeeklySMs.InsertOnSubmit(styt);
                                                            db.SubmitChanges();


                                                            //-----------------------------------------SMS--------------------------------------------
                                                            var stytb = new WeeklySMS1
                                                            {

                                                                customerid = null,
                                                                msg = null,
                                                                accountno = txtAcountNo.Text,
                                                                phoneno = null,
                                                                depositebalance = 0,
                                                                date = null,
                                                                depositecollect = 0,
                                                                smCharge = "0",


                                                            };
                                                            db.WeeklySMS1s.InsertOnSubmit(stytb);
                                                            db.SubmitChanges();

                                                        }
                                                        else { }
                                                    
                                                    var styl = new FreezAcount
                                                    {
                                                        FreezAccountNo = txtAcountNo.Text,
                                                        AccountType = txtaccounttype.Text,
                                                    };
                                                    db.FreezAcounts.InsertOnSubmit(styl);
                                                    db.SubmitChanges();

                                            }
                                            else { }

                                                }
                                                else
                                                {
                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Date Has Not Been Open OR You Selected The Wrong Branch');", true);
                                                }
                                            }

                                         
                                        }
                                    }
                    
                    }
                }
            }
         }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                Label1.Text = Session["USER_ID"].ToString();
                string DCase = Session["USER_ID"].ToString();

             SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                conw.Open();
                SqlCommand cmdw = new SqlCommand("Select * from Tmt3 where Branch='" + DCase + "'", conw);
                SqlDataAdapter daw = new SqlDataAdapter(cmdw);
                DataTable dtw = new DataTable();
                daw.Fill(dtw);
                if (dtw.Rows.Count > 0)
                {

                    //-------------------------------------Read--------------------------------------------
                    string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    using (SqlConnection conns = new SqlConnection(constrings))
                    {
                        using (SqlCommand cmdts = new SqlCommand("SELECT id, Date FROM Tmt WHERE Branch = '" + DCase + "'"))
                        {
                            cmdts.CommandType = CommandType.Text;
                            cmdts.Connection = conns;
                            conns.Open();

                            using (SqlDataReader sdrr = cmdts.ExecuteReader())
                            {
                                sdrr.Read();
                                string Dater = sdrr["Date"].ToString();
                                if (Dater == txtdate.Text && txtbr.Text == DCase)
                                {
                                    string connetionString;
                                    SqlConnection cnn;
                                    SqlCommand comand;
                                    //String path;


                                    connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    cnn = new SqlConnection(connetionString);
                                    cnn.Open();
                                    string sql = "Select * from NewAcount where CustomerId='" + txtcustomerid.Text + "'";
                                    comand = new SqlCommand(sql, cnn);
                                    SqlDataAdapter da = new SqlDataAdapter(comand);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    if (dt.Rows.Count > 0)
                                    {
                                       Double val = Double.Parse(txtloan.Text.ToString()) * Double.Parse(txtmoney.Text.ToString());


                                        //--------------update------------------------------------------------------------------------
                                        var sty = (from s in db.NewAcounts where s.CustomerId == txtcustomerid.Text select s).First();

                                        sty.CustomerId = txtcustomerid.Text;
                                        sty.Branch = txtbr.SelectedItem.Text;
                                        sty.FieldOfficer = txtofficer.SelectedItem.Text;

                                        sty.AccountNo = float.Parse(txtAcountNo.Text);
                                        sty.PageNumber = float.Parse(txtpageno.Text);
                                        sty.Date = txtdate.Text;
                                        sty.PhoneNo = txtsms.Text;
                                        sty.BankCharge = txtfee.Text;
                                        sty.PostedBy = txtpostedby.Text;
                                        sty.AccountType = txtaccounttype.SelectedItem.Text;
                                        sty.MaturityDate = txtmaturity.Text;
                                        sty.NoOfMonth = txtmonth.Text;
                                        sty.Amount = txtmoney.Text;
                                        sty.Interest = val.ToString();
                                      

                                        db.SubmitChanges();
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
                                       // LoadData();

                                        SqlConnection conwsBWb = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                        conwsBWb.Open();
                                        SqlCommand cmdwsBWb = new SqlCommand("Select * from Contracts where AccountNo='" + txtAcountNo.Text + "'", conwsBWb);
                                        SqlDataAdapter dawsBWb = new SqlDataAdapter(cmdwsBWb);
                                        DataTable dtwsBWb = new DataTable();
                                        dawsBWb.Fill(dtwsBWb);
                                        if (dtwsBWb.Rows.Count > 0)
                                        {
                                            //----------------------------update LoanContrat---------------------------------
                                            var stuniC = (from s in db.Contracts where s.AccountNo == txtAcountNo.Text select s).First();
                                            stuniC.Interest = txtloan.ToString();
                                            stuniC.InterestValue = val.ToString();
                                            db.SubmitChanges();
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Customer ID is required to Search for Updated');", true);
                                    }
                                }
                              
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Batch is Close! Date Has Not Been Open');", true);
                                }
                             }

                            conns.Close();
                        }
                    }
                }
           } 
        }
        void LoadData()
        {
            var styU = (from s in db.NewAcounts where s.CustomerId == txtcustomerid.Text select s);
            GridView1.DataSource = styU;
            GridView1.DataBind();
        }


        protected void Button8_Click(object sender, EventArgs e)
        {

            if (Session["USER_ID"] != null)
            {
                Label1.Text = Session["USER_ID"].ToString();
                string DCase = Session["USER_ID"].ToString();

                SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                conw.Open();
                SqlCommand cmdw = new SqlCommand("Select * from Tmt3 where Branch='" + txtbr.Text + "'", conw);
                SqlDataAdapter daw = new SqlDataAdapter(cmdw);
                DataTable dtw = new DataTable();
                daw.Fill(dtw);
                if (dtw.Rows.Count > 0)
                {

                    //-------------------------------------Read--------------------------------------------
                    string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    using (SqlConnection conns = new SqlConnection(constrings))
                    {
                        using (SqlCommand cmdts = new SqlCommand("SELECT id, Date FROM Tmt WHERE Branch = '" + txtbr.Text + "'"))
                        {
                            cmdts.CommandType = CommandType.Text;
                            cmdts.Connection = conns;
                            conns.Open();

                            using (SqlDataReader sdrr = cmdts.ExecuteReader())
                            {
                                sdrr.Read();
                                // string Dater = sdrr["Date"].ToString();

                           
                                    string connetionString;
                                    SqlConnection cnn;
                                    SqlCommand comand;
                                    //String path;


                                    connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    cnn = new SqlConnection(connetionString);
                                    cnn.Open();
                                    string sql = "Select * from NewAcount where AccountNo='" + txtAcountNo.Text + "'";
                                    comand = new SqlCommand(sql, cnn);
                                    SqlDataAdapter da = new SqlDataAdapter(comand);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    if (dt.Rows.Count > 0)
                                    {
                                        string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        using (SqlConnection con = new SqlConnection(constr))
                                        {
                                            SqlCommand cmd = new SqlCommand("SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, BankCharge, PostedBy, AccountBalance,AccountType,Coment,MaturityDate,NoOfMonth,Interest,InterestPercent,Amount FROM NewAcount WHERE AccountNo = '" + txtAcountNo.Text + "'", con);
                                            {
                                                cmd.CommandType = System.Data.CommandType.Text;
                                                cmd.Connection = con;
                                                con.Open();

                                                cmd.CommandType = System.Data.CommandType.Text;
                                                cmd.ExecuteNonQuery();
                                                DataTable dt1 = new DataTable();
                                                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                                                da1.Fill(dt1);


                                                con.Close();

                                                con.Open();

                                                using (SqlDataReader sdr1 = cmd.ExecuteReader())
                                                {
                                                    sdr1.Read();

                                                    
                                                    txtcustomerid.Text = sdr1["CustomerId"].ToString();
                                                    txtbr.SelectedItem.Text = sdr1["Branch"].ToString();
                                                    txtofficer.SelectedItem.Text = sdr1["FieldOfficer"].ToString();
                                                    txtAcountNo.Text = sdr1["AccountNo"].ToString();
                                                    txtpageno.Text = sdr1["PageNumber"].ToString();
                                                    txtdate.Text = sdr1["Date"].ToString();
                                                    txtsms.Text = sdr1["PhoneNo"].ToString();
                                                    txtfee.Text = sdr1["BankCharge"].ToString();
                                                    txtpostedby.Text = sdr1["PostedBy"].ToString();
                                                    txtaccounttype.SelectedItem.Text = sdr1["AccountType"].ToString();
                                                    txtmaturity.Text = sdr1["MaturityDate"].ToString();
                                                    txtmonth.Text = sdr1["NoOfMonth"].ToString();
                                                    txtloan.SelectedItem.Text = sdr1["InterestPercent"].ToString();
                                                    txtmoney.Text = sdr1["Amount"].ToString();
                                                    Lab1.Text = sdr1["AccountBalance"].ToString() + "NGN";
                                                    

                                                }
                                                con.Close();
                                                // LoadData();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('AccountNo is required for Searching');", true);
                                    }
                            }

                            conns.Close();
                        }
                    }

                }
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                Label1.Text = Session["USER_ID"].ToString();
                string DCase = Session["USER_ID"].ToString();

                SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                conw.Open();
                SqlCommand cmdw = new SqlCommand("Select * from Tmt where Branch ='" + DCase + "'", conw);
                SqlDataAdapter daw = new SqlDataAdapter(cmdw);
                DataTable dtw = new DataTable();
                daw.Fill(dtw);
                if (dtw.Rows.Count > 0)
                {

                    //-------------------------------------Read--------------------------------------------
                    string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    using (SqlConnection conns = new SqlConnection(constrings))
                    {
                        using (SqlCommand cmdts = new SqlCommand("SELECT id, Date FROM Tmt WHERE Branch = '" + DCase + "'"))
                        {
                            cmdts.CommandType = CommandType.Text;
                            cmdts.Connection = conns;
                            conns.Open();

                            using (SqlDataReader sdrr = cmdts.ExecuteReader())
                            {
                                sdrr.Read();
                                string Dater = sdrr["Date"].ToString();
                                if (Dater == txtdate.Text && txtbr.Text == DCase)
                                {
                                    string connetionString;
                                    SqlConnection cnn;
                                    SqlCommand comand;
                                    //String path;


                                    connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    cnn = new SqlConnection(connetionString);
                                    cnn.Open();
                                    string sql = "Select * from NewAcount where AccountNo='" + txtAcountNo.Text + "'";
                                    comand = new SqlCommand(sql, cnn);
                                    SqlDataAdapter da = new SqlDataAdapter(comand);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    if (dt.Rows.Count > 0)
                                    {

                                        //--------------update------------------------------------------------------------------------
                                        var sty = (from s in db.NewAcounts where s.AccountNo == float.Parse(txtAcountNo.Text) select s).First();

                                        sty.AccountBalance = 0;
                                        sty.AccountType = "Freeze Account";


                                        db.SubmitChanges();
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Freez');", true);
                                        // LoadData();
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Customer ID is required to Search for Updated');", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Batch is Close! Date Has Not Been Open');", true);
                                }
                            }

                            conns.Close();
                        }
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
             
            SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conw.Open();
            SqlCommand cmdw = new SqlCommand("Select * from FreezAcount where FreezAccountNo='" + txtAcountNo.Text + "'", conw);
            SqlDataAdapter daw = new SqlDataAdapter(cmdw);
            DataTable dtw = new DataTable();
            daw.Fill(dtw);
            if (dtw.Rows.Count > 0)
            {
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT id, FreezAccountNo, AccountType, AccountBalance FROM FreezAcount WHERE FreezAccountNo = '" + txtAcountNo.Text + "'"))
                    {
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();

                            string bal = sdrr["AccountBalance"].ToString();
                            string AcctType = sdrr["AccountType"].ToString();

                            //----------------------------update NewAcount---------------------------------
                            var stiny = (from s in db.NewAcounts where s.AccountNo == float.Parse(txtAcountNo.Text) select s).First();
                            stiny.AccountBalance = float.Parse(bal);
                            stiny.AccountType = AcctType;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully UnFreez');", true);

                            db.SubmitChanges();
                        }

                        conns.Close();
                    }
                }
            }
 
        }

          protected void Button1_Click(object sender, EventArgs e)
        {

            Session.Remove("USER_ID");
            Session.RemoveAll();
            Response.Redirect("NewCustomerLogin.aspx");

        }


      
        protected void Button4_Click(object sender, EventArgs e)
        {
            
            SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conw.Open();
            SqlCommand cmdw = new SqlCommand("Select * from DormantAccount where AccountNo='" +  txtAcountNo.Text+ "'", conw);
            SqlDataAdapter daw = new SqlDataAdapter(cmdw);
            DataTable dtw = new DataTable();
            daw.Fill(dtw);
            if (dtw.Rows.Count > 0)
            {
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, BankCharge, PostedBy, AccountBalance,AccountType FROM DormantAccount WHERE AccountNo = '" + txtAcountNo.Text + "'"))
                    {
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();
                            string id = sdrr["id"].ToString();
                            string CustomerId = sdrr["CustomerId"].ToString();
                            string Branch = sdrr["Branch"].ToString();
                            string FieldOfficer = sdrr["FieldOfficer"].ToString();
                            string AccountNo = sdrr["AccountNo"].ToString();
                            string PageNumber = sdrr["PageNumber"].ToString();
                            string Date = sdrr["Date"].ToString();
                            string PhoneNo = sdrr["PhoneNo"].ToString();
                            string BankCharge = sdrr["BankCharge"].ToString();
                            string PostedBy = sdrr["PostedBy"].ToString();
                            string AccountBalance = sdrr["AccountBalance"].ToString();
                            string AccountType = sdrr["AccountType"].ToString();

                            //----------------------------------Update to Table------------------------------------
                            string connetionString;
                            SqlConnection cnn;
                            SqlCommand comand;
                            //String path;


                            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            cnn = new SqlConnection(connetionString);
                            cnn.Open();
                            string sql = "Select * from DormantAccount where AccountNo='" + txtAcountNo.Text + "'";
                            comand = new SqlCommand(sql, cnn);
                            SqlDataAdapter da = new SqlDataAdapter(comand);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {

                                //--------------update------------------------------------------------------------------------
                                var sty = (from s in db.NewAcounts where s.AccountNo == float.Parse(txtAcountNo.Text) select s).First();

                                sty.CustomerId = CustomerId;
                                sty.Branch = Branch;
                                sty.FieldOfficer = FieldOfficer;

                                sty.AccountNo = float.Parse(AccountNo);
                                sty.PageNumber = float.Parse(PageNumber);
                                sty.Date = Date;
                                sty.PhoneNo = PhoneNo;
                                sty.BankCharge = BankCharge;
                                sty.PostedBy = PostedBy;
                                sty.AccountType = AccountType;
                                sty.AccountBalance = float.Parse(AccountBalance);

                                db.SubmitChanges();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('DormantAccount Retrieve Successfully');", true);


                                //--------------------------------DELETE FROM DORMANT------------------------------------------------
                                string connetionStrings;
                                SqlConnection cnns;
                                SqlCommand comands;
                                //String path;


                                connetionStrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                cnns = new SqlConnection(connetionStrings);
                                cnns.Open();
                                string sqls = "Select * from DormantAccount where AccountNo='" + txtAcountNo.Text + "'";
                                comands = new SqlCommand(sqls, cnns);
                                SqlDataAdapter das = new SqlDataAdapter(comands);
                                DataTable dts = new DataTable();
                                das.Fill(dts);
                                if (dts.Rows.Count > 0)
                                {

                                    var styy = (from s in db.DormantAccounts where s.AccountNo == txtAcountNo.Text select s).First();
                                    db.DormantAccounts.DeleteOnSubmit(styy);
                                    db.SubmitChanges();

                                }
                                else
                                {
                                    // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please AccountNo is Not Dormant Account');", true);

                                }

                            }
                            else
                            {
                                // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('AccountNo is required to Search for Updated');", true);
                            }

                        }

                        conns.Close();
                    }
                }
            }
            else
            {

            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (txtcustomerid.Text == "" || txtbr.Text == "" || txtofficer.Text == "" || txtAcountNo.Text == "" || txtpageno.Text == "" || txtsms.Text == "" || txtfee.Text == "" || txtpostedby.Text == "" || txtaccounttype.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('All field are required');", true);
            }
            else
            {
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                    conw.Open();
                    SqlCommand cmdw = new SqlCommand("Select * from Tmt where Branch='" + DCase + "'", conw);
                    SqlDataAdapter daw = new SqlDataAdapter(cmdw);
                    DataTable dtw = new DataTable();
                    daw.Fill(dtw);
                    if (dtw.Rows.Count > 0)
                    {

                        //-------------------------------------Read--------------------------------------------
                        string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        using (SqlConnection conns = new SqlConnection(constrings))
                        {
                            using (SqlCommand cmdts = new SqlCommand("SELECT id, Date FROM Tmt WHERE Branch = '" + DCase + "'"))
                            {
                                cmdts.CommandType = CommandType.Text;
                                cmdts.Connection = conns;
                                conns.Open();

                                using (SqlDataReader sdrr = cmdts.ExecuteReader())
                                {
                                    sdrr.Read();
                                    string Dater = sdrr["Date"].ToString();
                                    if (Dater == txtdate.Text && txtbr.Text == DCase)
                                    {
                                        if (txtaccounttype.Text == "Buck Fixed Account Yaba" || txtaccounttype.Text == "Buck Fixed Account Ikeja" || txtaccounttype.Text == "Buck Fixed Account Ikorodu" || txtaccounttype.Text == "Buck Fixed Account Aja" || txtaccounttype.Text == "Buck Fixed Account X" || txtaccounttype.Text == "Buck Fixed Account Y" || txtaccounttype.Text == "Buck Fixed Account Z" || txtaccounttype.Text == "Target Account Yaba" || txtaccounttype.Text == "Target Account Ikeja" || txtaccounttype.Text == "Target Account Ikorodu" || txtaccounttype.Text == "Target Account Aja" || txtaccounttype.Text == "Target Account X" || txtaccounttype.Text == "Target Account Y" || txtaccounttype.Text == "Target Account Z" || txtaccounttype.Text == "Loan Account Yaba" || txtaccounttype.Text == "Loan Account Ikeja" || txtaccounttype.Text == "Loan Account Ikorodu" || txtaccounttype.Text == "Loan Account Aja" || txtaccounttype.Text == "Loan Account X" || txtaccounttype.Text == "Loan Account Y" || txtaccounttype.Text == "Loan Account Z")
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('This is For Soft Saving and Flexible Account Creation');", true);
                                        }
                                        else
                                        {  //-------------------------------check page exit or use with another accountno---------------
                                            string connetionString10;
                                            SqlConnection cnn10;
                                            SqlCommand comand10;
                                            //String path;

                                            connetionString10 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            cnn10 = new SqlConnection(connetionString10);
                                            cnn10.Open();
                                            string sql1 = "Select * from NewAcount where PageNumber='" + txtpageno.Text + "' ";
                                            comand10 = new SqlCommand(sql1, cnn10);
                                            SqlDataAdapter da1 = new SqlDataAdapter(comand10);
                                            DataTable dt1 = new DataTable();
                                            da1.Fill(dt1);
                                            if (dt1.Rows.Count > 0)
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('PageNumber has Already been Used by Another Customer');", true);

                                            }
                                            else
                                            {
                                                SqlConnection conwW = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                                conwW.Open();
                                                SqlCommand cmdwW = new SqlCommand("Select * from NewCustomer where accountno='" + txtAcountNo.Text + "'", conwW);
                                                SqlDataAdapter dawW = new SqlDataAdapter(cmdwW);
                                                DataTable dtwW = new DataTable();
                                                dawW.Fill(dtwW);
                                                if (dtwW.Rows.Count > 0)
                                                {
                                                    int monthNumber = int.Parse(DateTime.Now.ToString("MM"));
                                                    String mthNumber = new DateTimeFormatInfo().GetMonthName(monthNumber);
                                                    String Yr = DateTime.Now.ToString("MM/yyyy");
                                                    String YDate1 = DateTime.Now.ToString("dd");

                                                    if (mthNumber == "Febuary")
                                                    {  //----------------------------------insert to Table------------------------------------
                                                        string connetionString;
                                                        SqlConnection cnn;
                                                        String YDate = DateTime.Now.ToString("dd");
                                                        String Feb = "0";

                                                        connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";

                                                        cnn = new SqlConnection(connetionString);
                                                        cnn.Open();


                                                        SqlCommand command;
                                                        SqlDataAdapter adapter = new SqlDataAdapter();
                                                        String sql = "";
                                                        int value = 2;
                                                        String Null = "Null";

                                                        sql = "Insert into NewAcount(CustomerId,Branch,FieldOfficer,AccountNo,PageNumber,Date,PhoneNo,BankCharge,PostedBy,AccountType,AccountBalance,AccountBalance1,SmsId,MaturityDate,NoOfMonth,Interest,Month,Year,Dates,Amount)values('" + txtcustomerid.Text + "','" + txtbr.Text + "','" + txtofficer.Text + "','" + txtAcountNo.Text + "','" + txtpageno.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + txtsms.Text + "','" + txtfee.Text + "','" + txtpostedby.Text + "','" + txtaccounttype.Text + "','" + 0 + "',,'" + 0 + "','" + value + "','" + Null + "','" + Null + "','" + 0 + "','" + mthNumber + "','" + Yr + "','" + Feb + "','" + 0 + "')";


                                                        command = new SqlCommand(sql, cnn);
                                                        adapter.InsertCommand = new SqlCommand(sql, cnn);
                                                        adapter.InsertCommand.ExecuteNonQuery();

                                                        command.Dispose();
                                                        cnn.Close();
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successful Transact SoftSaving OR Felxible');", true);

                                                        connetionString10 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                        cnn10 = new SqlConnection(connetionString10);
                                                        cnn10.Open();
                                                        string sql1dd = "Select * from NewCustomerSMS where AccountNo ='" + txtAcountNo.Text + "' ";
                                                        comand10 = new SqlCommand(sql1dd, cnn10);
                                                        SqlDataAdapter da1dd = new SqlDataAdapter(comand10);
                                                        DataTable dt1dd = new DataTable();
                                                        da1dd.Fill(dt1dd);
                                                        if (dt1dd.Rows.Count > 0)
                                                        {

                                                            //------------------------------Update NewCustomerSMS----------------------------------------------
                                                            var sty = (from s in db.NewCustomerSMs where s.AccountNo == txtAcountNo.Text select s).First();
                                                            sty.PageNo = txtpageno.Text;
                                                            db.SubmitChanges();
                                                        }
                                                        else { }


                                                    }
                                                    else if (mthNumber == "April" || mthNumber == "June" || mthNumber == "September" || mthNumber == "November")
                                                    {  //----------------------------------insert to Table------------------------------------
                                                        string connetionString;
                                                        SqlConnection cnn;
                                                        String Feb = "0";



                                                        connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";

                                                        cnn = new SqlConnection(connetionString);
                                                        cnn.Open();


                                                        SqlCommand command2;
                                                        SqlDataAdapter adapter = new SqlDataAdapter();
                                                        String sql = "";
                                                        int value = 2;
                                                        // Double val = Double.Parse(txtloan.Text) * Double.Parse(txtmoney.Text);
                                                        string Null = "null";

                                                        sql = "Insert into NewAcount(CustomerId,Branch,FieldOfficer,AccountNo,PageNumber,Date,PhoneNo,BankCharge,PostedBy,AccountType,AccountBalance,SmsId,MaturityDate,NoOfMonth,Interest,Month,Year,Dates, Amount)values('" + txtcustomerid.Text + "','" + txtbr.Text + "','" + txtofficer.Text + "','" + txtAcountNo.Text + "','" + txtpageno.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + txtsms.Text + "','" + txtfee.Text + "','" + txtpostedby.Text + "','" + txtaccounttype.Text + "','" + 0 + "','" + value + "','" + Null + "','" + Null + "','" + 0 + "','" + mthNumber + "','" + Yr + "','" + Feb + "' ,'" + 0 + "')";


                                                        command2 = new SqlCommand(sql, cnn);
                                                        adapter.InsertCommand = new SqlCommand(sql, cnn);
                                                        adapter.InsertCommand.ExecuteNonQuery();

                                                        command2.Dispose();
                                                        cnn.Close();
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successful Transact');", true);

                                                        connetionString10 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                        cnn10 = new SqlConnection(connetionString10);
                                                        cnn10.Open();
                                                        string sql1dd = "Select * from NewCustomerSMS where AccountNo ='" + txtAcountNo.Text + "' ";
                                                        comand10 = new SqlCommand(sql1dd, cnn10);
                                                        SqlDataAdapter da1dd = new SqlDataAdapter(comand10);
                                                        DataTable dt1dd = new DataTable();
                                                        da1dd.Fill(dt1dd);
                                                        if (dt1dd.Rows.Count > 0)
                                                        {

                                                            //------------------------------Update NewCustomerSMS----------------------------------------------
                                                            var sty = (from s in db.NewCustomerSMs where s.AccountNo == txtAcountNo.Text select s).First();
                                                            sty.PageNo = txtpageno.Text;
                                                            db.SubmitChanges();
                                                        }
                                                        else { }
                                                    }
                                                    else
                                                    {  //----------------------------------insert to Table------------------------------------
                                                        string connetionString;
                                                        SqlConnection cnn;
                                                        String Feb = "29";

                                                        connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";

                                                        cnn = new SqlConnection(connetionString);
                                                        cnn.Open();


                                                        SqlCommand command2;
                                                        SqlDataAdapter adapter = new SqlDataAdapter();
                                                        String sql = "";
                                                        int value = 2;
                                                        // Double val = Double.Parse(txtloan.Text.ToString()) * Double.Parse(txtmoney.Text.ToString());
                                                        string Null = "null";

                                                        sql = "Insert into NewAcount(CustomerId,Branch,FieldOfficer,AccountNo,PageNumber,Date,PhoneNo,BankCharge,PostedBy,AccountType,AccountBalance,SmsId,MaturityDate,NoOfMonth,Interest,Month,Year,Dates,Amount)values('" + txtcustomerid.Text + "','" + txtbr.Text + "','" + txtofficer.Text + "','" + txtAcountNo.Text + "','" + txtpageno.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + txtsms.Text + "','" + txtfee.Text + "','" + txtpostedby.Text + "','" + txtaccounttype.Text + "','" + 0 + "','" + value + "','" + Null + "','" + Null + "','" + 0 + "','" + mthNumber + "','" + Yr + "','" + Feb + "','" + 0 + "')";


                                                        command2 = new SqlCommand(sql, cnn);
                                                        adapter.InsertCommand = new SqlCommand(sql, cnn);
                                                        adapter.InsertCommand.ExecuteNonQuery();

                                                        command2.Dispose();
                                                        cnn.Close();
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successful Transact');", true);

                                                        connetionString10 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                        cnn10 = new SqlConnection(connetionString10);
                                                        cnn10.Open();
                                                        string sql1dd = "Select * from NewCustomerSMS where AccountNo ='" + txtAcountNo.Text + "' ";
                                                        comand10 = new SqlCommand(sql1dd, cnn10);
                                                        SqlDataAdapter da1dd = new SqlDataAdapter(comand10);
                                                        DataTable dt1dd = new DataTable();
                                                        da1dd.Fill(dt1dd);
                                                        if (dt1dd.Rows.Count > 0)
                                                        {

                                                            //------------------------------Update NewCustomerSMS----------------------------------------------
                                                            var sty = (from s in db.NewCustomerSMs where s.AccountNo == txtAcountNo.Text select s).First();
                                                            sty.PageNo = txtpageno.Text;
                                                            db.SubmitChanges();
                                                        }
                                                        else { }
                                                    }

                                                    //---------------------------------------------------------------------------------------
                                                    SqlConnection conwsBA = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                                    conwsBA.Open();
                                                    SqlCommand cmdwsBA = new SqlCommand("Select * from Deposite where AccountNo='" + txtAcountNo.Text + "'", conwsBA);
                                                    SqlDataAdapter dawsBA = new SqlDataAdapter(cmdwsBA);
                                                    DataTable dtwsBA = new DataTable();
                                                    dawsBA.Fill(dtwsBA);
                                                    if (dtwsBA.Rows.Count > 0)
                                                    { }
                                                    else
                                                    {
                                                        if (txtaccounttype.Text == "Loan Account" || txtaccounttype.Text == "Target Account Yaba" || txtaccounttype.Text == "Target Account Ikeja" || txtaccounttype.Text == "Target Account Ikorodu" || txtaccounttype.Text == "Target Account Aja" || txtaccounttype.Text == "Target Account X" || txtaccounttype.Text == "Target Account Y" || txtaccounttype.Text == "Target Account Z" || txtaccounttype.Text == "Buck Fixed Account Yaba" || txtaccounttype.Text == "Buck Fixed Account Ikeja" || txtaccounttype.Text == "Buck Fixed Account Ikorodu" || txtaccounttype.Text == "Buck Fixed Account Aja" || txtaccounttype.Text == "Buck Fixed Account X" || txtaccounttype.Text == "Buck Fixed Account Y" || txtaccounttype.Text == "Buck Fixed Account Z")
                                                        { }
                                                        else
                                                        {
                                                            //------------------------------Update NewAcount----------------------------------------------
                                                            var sty2 = (from s in db.NewAcounts where s.AccountNo == float.Parse(txtAcountNo.Text) select s).First();
                                                            sty2.AccountBalance = -5;
                                                            db.SubmitChanges();
                                                        }
                                                    }
                                                }
                                                else { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('AccountNo does not Exist');", true); }                                                                              
                                             }
                                        }

                                        SqlConnection conwWG = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                        conwWG.Open();
                                        SqlCommand cmdwWG = new SqlCommand("Select * from NewCustomer where accountno='" + txtAcountNo.Text + "'", conwWG);
                                        SqlDataAdapter dawWG = new SqlDataAdapter(cmdwWG);
                                        DataTable dtwWG = new DataTable();
                                        dawWG.Fill(dtwWG);
                                        if (dtwWG.Rows.Count > 0)
                                        {
                                            //-----------------------------------------Loan--------------------------------------------
                                            if (txtaccounttype.Text == "Loan Account Yaba" || txtaccounttype.Text == "Loan Account Ikeja" || txtaccounttype.Text == "Loan Account Ikorodu" || txtaccounttype.Text == "Loan Account Aja" || txtaccounttype.Text == "Loan Account X" || txtaccounttype.Text == "Loan Account Y" || txtaccounttype.Text == "Loan Account Z")
                                            {
                                                var sty = new LoanInterest
                                                {

                                                    NoOfMonth = null,
                                                    LoanAmount = "0",
                                                    MaturityDate = txtmaturity.Text,
                                                    Interest = "0",
                                                    ContractNo = txtAcountNo.Text,
                                                    CustomerName = null,
                                                    ManagementFee = "0",
                                                    Month = null,
                                                    AccountBalance = "0",


                                                };
                                                db.LoanInterests.InsertOnSubmit(sty);
                                                db.SubmitChanges();
                                            }

                                            //-----------------------------------------Loan--------------------------------------------

                                            var styt = new WeeklySM
                                            {

                                                customerid = null,
                                                msg = null,
                                                accountno = txtAcountNo.Text,
                                                phoneno = null,
                                                depositebalance = 0,
                                                date = null,
                                                depositecollect = 0,
                                                smsid = null,

                                            };
                                            db.WeeklySMs.InsertOnSubmit(styt);
                                            db.SubmitChanges();

                                            //-----------------------------------------Loan--------------------------------------------
                                            var stytf = new WeeklySMS1
                                            {

                                                customerid = null,
                                                msg = null,
                                                accountno = txtAcountNo.Text,
                                                phoneno = null,
                                                depositebalance = 0,
                                                date = null,
                                                depositecollect = 0,
                                                smCharge = "0",

                                            };
                                            db.WeeklySMS1s.InsertOnSubmit(stytf);
                                            db.SubmitChanges();



                                            var styl = new FreezAcount
                                            {
                                                FreezAccountNo = txtAcountNo.Text,
                                            };
                                            db.FreezAcounts.InsertOnSubmit(styl);
                                            db.SubmitChanges();
                                        }
                                        else { }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Date Has Not Been Open/ Select Your BRANCH');", true);
                                }
                            }

                                conns.Close();
                            }
                        }
                    }
                }
            }
        }
        public static string GetLast7DateString()
        {
            
            DateTime currentDate = DateTime.Now;
            return String.Join(",", Enumerable.Range(0, 7)
                                             .Select(x => currentDate.AddDays(-x).ToString("dd-MM-yyyy"))
                                             .ToList());
        }
        string opLast7Days = GetLast7DateString();
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (txtdays.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Put in Value PLS');", true);
                              
            }else{
                int value = int.Parse(txtdays.Text.ToString());
                DateTime currentDate = DateTime.Now;
                String vab = String.Join(",", Enumerable.Range(0, value)
                                                  .Select(x => currentDate.AddDays(+x).ToString("dd-MM-yyyy"))
                                                  .ToList());
                string opLast7Days = GetLast7DateString();

                String alartMsg = "Pick The Last Date as Maturity Date" + " " + " FirstDate-->>" + vab + "<<--LastDate";
                String script = "alert('" + alartMsg + "');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            
            }
          
          
        }

        protected void Button7_Click1(object sender, EventArgs e)
        {
            if (txtmoney.Text == "" || txtaccounttype.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Put in Value PLS');", true);

            }
            else
            {
            Double MoneyVal = double.Parse(txtmoney.Text) * double.Parse(txtloan.Text);

            int MoneyRead = int.Parse(MoneyVal.ToString()) + int.Parse(txtmoney.Text);
            int MoneyReads = int.Parse(txtmoney.Text) / int.Parse(txtday.Text);
            int MoneyReady = MoneyReads * 5;
            int ActualVal = MoneyReads / int.Parse(txtmonth.Text) + 1;
            int FinalRead = ActualVal * int.Parse(txtday.Text);

            txtfee.Text = "0";
            Lab2.Text = "Daily Payment" + " :" + MoneyReads.ToString()+ "NGN|";
            //Lab02.Text = "Interest" + " :" + MoneyVal.ToString() + "NGN|";
            Lab03.Text = "Weekly Payment" + " :" + MoneyReady.ToString() + "NGN";
        }
           
        }
    }
}