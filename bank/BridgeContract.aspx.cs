using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace BankA
{
    public partial class BridgeContract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // call the linq
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button1_Click1(object sender, EventArgs e)
        {
            //----------------------------------AUTHEMTIFICATION--------------------------------------------

            if (txtaccountno.Text == "" || txtdate.Text == "" || Textmonthremaining.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('All Field are Required');", true);

            }
            else
            {
                string connetionString10;
                SqlConnection cnn10;
                SqlCommand comand10;
                
                connetionString10 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                cnn10 = new SqlConnection(connetionString10);
                cnn10.Open();
                string sql1 = "Select * from BridgeContract where ContractNO='" + txtaccountno.Text + "' ";
                comand10 = new SqlCommand(sql1, cnn10);
                SqlDataAdapter da1 = new SqlDataAdapter(comand10);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Contract Number already been Default');", true);

                }
                else 
                {


                    string connetionString1;
                    SqlConnection cnn1;
                    SqlCommand comand1;
                    //String path;


                    connetionString1 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    cnn1 = new SqlConnection(connetionString1);
                    cnn1.Open();
                    string sql10 = "Select * from NewAcount where AccountNo='" + txtaccountno.Text + "' ";
                    comand1 = new SqlCommand(sql10, cnn1);
                    SqlDataAdapter da10 = new SqlDataAdapter(comand1);
                    DataTable dt10 = new DataTable();
                    da10.Fill(dt10);
                    if (dt10.Rows.Count > 0)
                    {
                        string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        using (SqlConnection conns = new SqlConnection(constrings))
                        {
                            using (SqlCommand cmdts = new SqlCommand("SELECT id,MaturityDate,BankCharge,AccountType,AccountBalance,AccountNo,NoOfMonth,Interest FROM NewAcount WHERE AccountNo  = '" + txtaccountno.Text + "'"))
                            {
                                cmdts.CommandType = CommandType.Text;
                                cmdts.Connection = conns;
                                conns.Open();

                                using (SqlDataReader sdr1 = cmdts.ExecuteReader())
                                {
                                    sdr1.Read();

                                    String MatureDate = sdr1["MaturityDate"].ToString();
                                    String InitialDeposite = sdr1["BankCharge"].ToString();
                                    String AcNo = sdr1["AccountNo"].ToString();
                                    String Bals = sdr1["AccountBalance"].ToString();
                                    String Month = sdr1["NoOfMonth"].ToString();
                                    String Intery = sdr1["Interest"].ToString();
                                    String txtaccounttype = sdr1["AccountType"].ToString();

                                    if (txtaccounttype == "Target Account Yaba" || txtaccounttype == "Target Account Ikeja" || txtaccounttype == "Target Account Ikorodu" || txtaccounttype == "Target Account Aja" || txtaccounttype == "Target Account X" || txtaccounttype == "Target Account Y" || txtaccounttype == "Target Account Z" || txtaccounttype == "Buck Fixed Account Yaba" || txtaccounttype == "Buck Fixed Account Ikeja" || txtaccounttype == "Buck Fixed Account Ikorodu" || txtaccounttype == "Buck Fixed Account Aja" || txtaccounttype == "Buck Fixed Account X" || txtaccounttype == "Buck Fixed Account Y" || txtaccounttype == "Buck Fixed Account Z")
                                    {

                                        if (MatureDate != txtdate.Text)
                                        {


                                            int moth = (int.Parse(DateTime.Now.ToString("MM")));
                                            Double Balance = (Double.Parse(Month)) - (Double.Parse(Textmonthremaining.Text));
                                            Double AddDefault = Double.Parse(InitialDeposite) * (Balance);

                                              if (txtaccounttype == "Target Account Yaba" || txtaccounttype == "Target Account Ikeja" || txtaccounttype == "Target Account Ikorodu" || txtaccounttype == "Target Account Aja" || txtaccounttype == "Target Account X" || txtaccounttype == "Target Account Y" || txtaccounttype == "Target Account Z" || txtaccounttype == "Buck Fixed Account Yaba" || txtaccounttype == "Buck Fixed Account Ikeja" || txtaccounttype == "Buck Fixed Account Ikorodu" || txtaccounttype == "Buck Fixed Account Aja" || txtaccounttype == "Buck Fixed Account X" || txtaccounttype == "Buck Fixed Account Y" || txtaccounttype == "Buck Fixed Account Z")
                                              {



                                                var styr = new TransactProfit2
                                                {

                                                    MonthProfit = AddDefault.ToString(),
                                                    Date = DateTime.Now.ToString("MM/yyyy"),
                                                    Month = DateTime.Now.ToString("MM"),
                                                    Year = DateTime.Now.ToString("yyyy"),
                                                    AccountNo = txtaccountno.Text,

                                                };
                                                db.TransactProfit2s.InsertOnSubmit(styr);
                                                db.SubmitChanges();

                                                //----------------------yearlyProfit------------------------
                                                var styry = new YearlyProfit
                                                {
                                                    Month = (DateTime.Now.ToString("MM")),
                                                    AccountNo = txtaccountno.Text,
                                                    YearGain = AddDefault.ToString(),
                                                    Year = DateTime.Now.ToString("yyyy"),
                                                };
                                                db.YearlyProfits.InsertOnSubmit(styry);
                                                db.SubmitChanges();


                                                Double OverAll = (Double.Parse(Bals) - AddDefault);
                                                Lab2.Text = OverAll.ToString("#,##0.00");
                                                //----------------------------update NewAcount---------------------------------
                                                var st = (from s in db.NewAcounts where s.AccountNo == float.Parse(AcNo) select s).First();
                                                st.AccountBalance = OverAll;

                                                var stu = (from s in db.NewAcounts where s.AccountNo == float.Parse(txtaccountno.Text) select s).First();
                                                stu.AccountBalance = (OverAll);
                                                db.SubmitChanges();

                                                //----------------------------update NewAcount---------------------------------
                                                var sty = (from s in db.NewAcounts where s.AccountNo == float.Parse(AcNo) select s).First();
                                                sty.MaturityDate = "Program Default";
                                                db.SubmitChanges();

                                                //----------------------------update BuckFixedSMS---------------------------------
                                                    SqlConnection conwsBx = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                                    conwsBx.Open();
                                                    SqlCommand cmdwsBx = new SqlCommand("Select * from BuckFixedSMS where accountno='" + txtaccountno.Text + "'", conwsBx);
                                                    SqlDataAdapter dawsBx = new SqlDataAdapter(cmdwsBx);
                                                    DataTable dtwsBx = new DataTable();
                                                    dawsBx.Fill(dtwsBx);
                                                    if (dtwsBx.Rows.Count > 0)
                                                    {
                                                       
                                                        //----------------------------update BuckFixedSMS---------------------------------
                                                        SqlConnection conwsBxB = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                                        conwsBxB.Open();
                                                        SqlCommand cmdwsBxB = new SqlCommand("Select * from BuckFixedSMS where accountno='" + txtaccountno.Text + "'", conwsBxB);
                                                        SqlDataAdapter dawsBxB = new SqlDataAdapter(cmdwsBxB);
                                                        DataTable dtwsBxB = new DataTable();
                                                        dawsBxB.Fill(dtwsBxB);
                                                        if (dtwsBxB.Rows.Count > 0)
                                                        {

                                                            string constring = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                            using (SqlConnection conn = new SqlConnection(constring))
                                                            {
                                                                using (SqlCommand cmdt = new SqlCommand("SELECT id, sms, FROM BuckFixedSMS WHERE accountno = '" + txtaccountno.Text + "'"))
                                                                {
                                                                    cmdt.CommandType = CommandType.Text;
                                                                    cmdt.Connection = conn;
                                                                    conn.Open();

                                                                    using (SqlDataReader sdrr = cmdt.ExecuteReader())
                                                                    {
                                                                        sdrr.Read();
                                                                        string SMSRead = sdrr["sms"].ToString();

                                                                        Double SmsCharge = (Double.Parse(Bals) - Double.Parse(SMSRead));
                                                                        //----------------------------update NewAcount---------------------------------
                                                                        var stb = (from s in db.NewAcounts where s.AccountNo == float.Parse(AcNo) select s).First();
                                                                        stb.AccountBalance = SmsCharge;
                                                                        db.SubmitChanges();
                                                                    }
                                                                }
                                                                conn.Close();
                                                            }

                                                        }
                                                    }
                                                    var stuller = (from s in db.BuckFixedSMs where s.accountno == txtaccountno.Text select s).First();
                                                    stuller.sms = "0";
                                                    db.SubmitChanges();

                                            }
/**
                                        string value1 = "ContractEnded" + "Date:  " + MatureDate;
                                        string consst = @"Data Source=DESKTOP-505LFHT\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        SqlConnection connectionu = new SqlConnection(consst);
                                        connectionu.Open();
                                        string queu = "update dbo.LoanInterest set Month=@value1 where ContractNo= '" + AcNo + "'";
                                        System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                        cmd5.Parameters.AddWithValue("@value1", value1);
                                        cmd5.ExecuteNonQuery();
                                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);
                                        connectionu.Close();

                                             **/
                                        }
                                        }
                                        else
                                        {    
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('This Transaction is Only meant for Buck and Target);", true);
                                        }

                                    
                                }

                                conns.Close();
                            }
                        }
                        var stuff = new BridgeContract
                        {
                            ContractBridge = txtdate.Text,
                            NoOfMonthRemaining = int.Parse(Textmonthremaining.Text),
                            ContractNo = txtaccountno.Text,

                        };


                        db.BridgeContracts.InsertOnSubmit(stuff);
                        db.SubmitChanges();
                    }
                    else
                    {
                        // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please AccountNo doesn't not Exist');", true);
                    }
                     
                } 
            }
               
            }
       
        protected void Button8_Click(object sender, EventArgs e)
        {

            //--------------------------------------------------------------------------------------------------------

            string connetionString1;
            SqlConnection cnn1;
            SqlCommand comand1;
            //String path;


            connetionString1 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn1 = new SqlConnection(connetionString1);
            cnn1.Open();
            string sql1 = "Select * from BridgeContract where ContractNO='" + txtaccountno.Text + "' ";
            comand1 = new SqlCommand(sql1, cnn1);
            SqlDataAdapter da1 = new SqlDataAdapter(comand1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {

                if (txtaccountno.Text == "")
                {
                  ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('ContractNo Field are Required');", true);
         
                }else
                {
                    var sty1 = (from s in db.BridgeContracts where s.ContractNo == txtaccountno.Text select s).First();


                    txtaccountno.Text = sty1.ContractNo;
                    txtdate.Text = sty1.ContractBridge;
                    Textmonthremaining.Text = sty1.NoOfMonthRemaining.ToString();
                    db.SubmitChanges();
              
                }
              
                //----------------------------------------------------------------------------------------------------------
               

            }
            else
            {
                // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please AccountNo doesn't not Exist');", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //----------------------------------AUTHEMTIFICATION--------------------------------------------

            if (txtaccountno.Text == "" || txtdate.Text == "" || Textmonthremaining.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('All Field are Required');", true);

            }
            else
            {
                string connetionString10;
                SqlConnection cnn10;
                SqlCommand comand10;
                //String path;


                connetionString10 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                cnn10 = new SqlConnection(connetionString10);
                cnn10.Open();
                string sql1 = "Select * from BridgeContract where ContractNO='" + txtaccountno.Text + "' ";
                comand10 = new SqlCommand(sql1, cnn10);
                SqlDataAdapter da1 = new SqlDataAdapter(comand10);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Contract Number already been Default');", true);
                }
                else
                {
                    string connetionString1;
                    SqlConnection cnn1;
                    SqlCommand comand1;
                    //String path;


                    connetionString1 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    cnn1 = new SqlConnection(connetionString1);
                    cnn1.Open();
                    string sql10 = "Select * from NewAcount where AccountNo='" + txtaccountno.Text + "' ";
                    comand1 = new SqlCommand(sql10, cnn1);
                    SqlDataAdapter da10 = new SqlDataAdapter(comand1);
                    DataTable dt10 = new DataTable();
                    da10.Fill(dt10);
                    if (dt10.Rows.Count > 0)
                    {
                        string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        using (SqlConnection conns = new SqlConnection(constrings))
                        {
                            using (SqlCommand cmdts = new SqlCommand("SELECT id,MaturityDate,BankCharge,AccountType,AccountBalance,AccountNo,NoOfMonth,Interest FROM NewAcount WHERE AccountNo  = '" + txtaccountno.Text + "'"))
                            {
                                cmdts.CommandType = CommandType.Text;
                                cmdts.Connection = conns;
                                conns.Open();

                                using (SqlDataReader sdr1 = cmdts.ExecuteReader())
                                {
                                    sdr1.Read();

                                    String MatureDate = sdr1["MaturityDate"].ToString();
                                    String InitialDeposite = sdr1["BankCharge"].ToString();
                                    String AcNo = sdr1["AccountNo"].ToString();
                                    String Bals = sdr1["AccountBalance"].ToString();
                                    String Month = sdr1["NoOfMonth"].ToString();
                                    String Intery = sdr1["Interest"].ToString();
                                    String txtaccounttype = sdr1["AccountType"].ToString();

                                     if (txtaccounttype == "Target Account Yaba" || txtaccounttype == "Target Account Ikeja" || txtaccounttype == "Target Account Ikorodu" || txtaccounttype == "Target Account Aja" || txtaccounttype == "Target Account X" || txtaccounttype == "Target Account Y" || txtaccounttype == "Target Account Z" || txtaccounttype == "Buck Fixed Account Yaba" || txtaccounttype == "Buck Fixed Account Ikeja" || txtaccounttype == "Buck Fixed Account Ikorodu" || txtaccounttype == "Buck Fixed Account Aja" || txtaccounttype == "Buck Fixed Account X" || txtaccounttype == "Buck Fixed Account Y" || txtaccounttype == "Buck Fixed Account Z")
                                     { 
                                    if (MatureDate != txtdate.Text)
                                    {
                                    
                                        int moth = (int.Parse(DateTime.Now.ToString("MM")));
                                        Double Balance = (Double.Parse(Month)) - (Double.Parse(Textmonthremaining.Text));
                                        Double AddDefault = Double.Parse(Intery) * (Balance);
                                        Double Default = Double.Parse(Bals) * (AddDefault);

                                        if (txtaccounttype == "Target Account Yaba" || txtaccounttype == "Target Account Ikeja" || txtaccounttype == "Target Account Ikorodu" || txtaccounttype == "Target Account Aja" || txtaccounttype == "Target Account X" || txtaccounttype == "Target Account Y" || txtaccounttype == "Target Account Z" || txtaccounttype == "Buck Fixed Account Yaba" || txtaccounttype == "Buck Fixed Account Ikeja" || txtaccounttype == "Buck Fixed Account Ikorodu" || txtaccounttype == "Buck Fixed Account Aja" || txtaccounttype == "Buck Fixed Account X" || txtaccounttype == "Buck Fixed Account Y" || txtaccounttype == "Buck Fixed Account Z")
                                        {

                                            var styr = new TransactProfit2
                                            {

                                                MonthProfit = Default.ToString(),
                                                Date = DateTime.Now.ToString("MM/yyyy"),
                                                Month = DateTime.Now.ToString("MM"),
                                                Year = DateTime.Now.ToString("yyyy"),
                                                AccountNo = txtaccountno.Text,


                                            };
                                            db.TransactProfit2s.InsertOnSubmit(styr);
                                            db.SubmitChanges();

                                            //----------------------yearlyProfit------------------------
                                            var styry = new YearlyProfit
                                            {
                                                Month = (DateTime.Now.ToString("MM")),
                                                AccountNo = txtaccountno.Text,
                                                YearGain = Default.ToString(),
                                                Year = DateTime.Now.ToString("yyyy"),
                                            };
                                            db.YearlyProfits.InsertOnSubmit(styry);
                                            db.SubmitChanges();

                                            Double OverAll = (Double.Parse(Bals) - Default);
                                            Lab2.Text = OverAll.ToString();

                                            //----------------------------update NewAcount---------------------------------
                                            var st = (from s in db.NewAcounts where s.AccountNo == float.Parse(AcNo) select s).First();
                                            st.AccountBalance = OverAll;

                                            //----------------------------update NewAcount---------------------------------
                                            var sty = (from s in db.NewAcounts where s.AccountNo == float.Parse(AcNo) select s).First();
                                            sty.MaturityDate = "Program Default";
                                            db.SubmitChanges();

                                            //----------------------------update BuckFixedSMS---------------------------------
                                            SqlConnection conwsBx = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                            conwsBx.Open();
                                            SqlCommand cmdwsBx = new SqlCommand("Select * from BuckFixedSMS where accountno='" + txtaccountno.Text + "'", conwsBx);
                                            SqlDataAdapter dawsBx = new SqlDataAdapter(cmdwsBx);
                                            DataTable dtwsBx = new DataTable();
                                            dawsBx.Fill(dtwsBx);
                                            if (dtwsBx.Rows.Count > 0)
                                            {
                                               
                                                string constring = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                using (SqlConnection conn = new SqlConnection(constring))
                                                {
                                                    using (SqlCommand cmdt = new SqlCommand("SELECT id, sms, FROM BuckFixedSMS WHERE accountno = '" + txtaccountno.Text + "'"))
                                                    {
                                                        cmdt.CommandType = CommandType.Text;
                                                        cmdt.Connection = conn;
                                                        conn.Open();

                                                        using (SqlDataReader sdrr = cmdt.ExecuteReader())
                                                        {
                                                            sdrr.Read();
                                                            string SMSRead = sdrr["sms"].ToString();

                                                            Double SmsCharge = (Double.Parse(Bals) -Double.Parse(SMSRead));
                                                            //----------------------------update NewAcount---------------------------------
                                                            var stb = (from s in db.NewAcounts where s.AccountNo == float.Parse(AcNo) select s).First();
                                                            stb.AccountBalance = SmsCharge;
                                                            db.SubmitChanges();                     
                                                        }
                                                    }
                                                    conn.Close();
                                                }


                                            }

                                            var stuller = (from s in db.BuckFixedSMs where s.accountno == txtaccountno.Text select s).First();
                                            stuller.sms = "0";
                                            db.SubmitChanges();

                                        }
/**
                                        string value1 = "ContractEnded" + "Date:  " + MatureDate;
                                        string consst = @"Data Source=DESKTOP-505LFHT\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        SqlConnection connectionu = new SqlConnection(consst);
                                        connectionu.Open();
                                        string queu = "update dbo.LoanInterest set Month=@value1 where ContractNo= '" + AcNo + "'";
                                        System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                        cmd5.Parameters.AddWithValue("@value1", value1);
                                        cmd5.ExecuteNonQuery();
                                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);
                                        connectionu.Close();
 **/
                                        }
                                        }
                                     else
                                     {
                                         ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('This Transaction is Only meant for Buck and Target);", true);
                                     }
                                    
                                }

                                conns.Close();
                            }
                        }
                        var stuff = new BridgeContract
                        {
                            ContractBridge = txtdate.Text,
                            NoOfMonthRemaining = int.Parse(Textmonthremaining.Text),
                            ContractNo = txtaccountno.Text,

                        };


                        db.BridgeContracts.InsertOnSubmit(stuff);
                        db.SubmitChanges();
                    }
                    else
                    {
                        // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please AccountNo doesn't not Exist');", true);
                    }

                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //-------------------------------delete account--------------------------------------
            if (txtaccountno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Accountno must be entered');", true);
            }
            else
            {


                string connetionString;
                SqlConnection cnn;
                SqlCommand comand;
                //String path;


                connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                string sql = "Select * from BridgeContract where ContractNo='" + txtaccountno.Text + "'";
                comand = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    var sty = (from s in db.BridgeContracts where s.ContractNo == txtaccountno.Text select s).First();
                    db.BridgeContracts.DeleteOnSubmit(sty);
                    db.SubmitChanges();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Transaction Deleted');", true);
                    //   LoadData();

                }
                else
                {
                    // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please Accountno doesn't exist');", true);

                }

            }
        } 
    }
}