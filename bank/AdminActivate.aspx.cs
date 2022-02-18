using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;

namespace BankA
{
    public partial class AdminActivate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                Label1.Text = Session["USER_ID"].ToString();
                DayOfWeek wk = DateTime.Today.DayOfWeek;
                Console.WriteLine(wk);
                string days = wk.ToString();
                Label4.Text = wk.ToString();

                //----------------------------------BuckFixed Account-------------------------------

                string constring = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    using (SqlCommand cmdt = new SqlCommand("SELECT id, SMSUpdate, SMSId FROM WeeklySME WHERE SMSId = '" + 3 + "'"))
                    {
                        cmdt.CommandType = CommandType.Text;
                        cmdt.Connection = conn;
                        conn.Open();

                        using (SqlDataReader sdrr = cmdt.ExecuteReader())
                        {
                            sdrr.Read();
                            string SMSRead = sdrr["SMSUpdate"].ToString();
                            string SMSid = sdrr["SMSId"].ToString();

                            if (days == SMSRead)
                            {
                                string yr = DateTime.Now.ToString("MM/yyyy");
                                string cons = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                SqlConnection cnz = new SqlConnection(cons);

                                SqlCommand cmdzs = new SqlCommand("SELECT MAX (id) FROM BuckFixedSMS", cnz);
                                cmdzs.CommandType = CommandType.Text;
                                cmdzs.Connection.Open();
                                SqlDataReader dr = cmdzs.ExecuteReader();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        string Lab = dr[0].ToString();

                                        int i = 1;
                                        while (i <= int.Parse(Lab))
                                        {
                                            SqlConnection conwsB = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                            conwsB.Open();
                                            SqlCommand cmdwsB = new SqlCommand("Select * from BuckFixedSMS where id='" + i + "'", conwsB);
                                            SqlDataAdapter dawsB = new SqlDataAdapter(cmdwsB);
                                            DataTable dtwsB = new DataTable();
                                            dawsB.Fill(dtwsB);
                                            if (dtwsB.Rows.Count > 0)
                                            {
                                                string constringsq = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                using (SqlConnection connsq = new SqlConnection(constringsq))
                                                {
                                                    using (SqlCommand cmdtsq = new SqlCommand("SELECT id, sms, msg, accountno FROM BuckFixedSMS WHERE id = '" + i + "' AND Year='" + yr + "'"))
                                                    {
                                                        cmdtsq.CommandType = CommandType.Text;
                                                        cmdtsq.Connection = connsq;
                                                        connsq.Open();

                                                        using (SqlDataReader sdrrq = cmdtsq.ExecuteReader())
                                                        {
                                                            sdrrq.Read();
                                                            string Asms = sdrrq["sms"].ToString();
                                                            string ANumber = sdrrq["accountno"].ToString();
                                                            string msgs = sdrrq["msg"].ToString();


                                                            Double CheckBal = (Double.Parse(Asms) + 5);

                                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                            SqlConnection connectionu = new SqlConnection(consst);
                                                            connectionu.Open();
                                                            string queu = "update dbo.BuckFixedSMS set sms=@CheckBal where accountno = '" + ANumber + "' AND Year='" + yr + "'";
                                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                                            cmd5.Parameters.AddWithValue("@CheckBal", CheckBal);
                                                            cmd5.ExecuteNonQuery();

                                                            connectionu.Close();

                                                            var styr = new SmsProfit
                                                            {
                                                                MonthYear = (DateTime.Now.ToString("MM/yyyy")),
                                                                AcctNo = ANumber,
                                                                SmsPrice = "5",
                                                                Date = DateTime.Now.ToString("yyyy"),
                                                                AcctType = msgs,


                                                            };
                                                            db.SmsProfits.InsertOnSubmit(styr);
                                                            db.SubmitChanges();

                                                            var styry = new YearlyProfit
                                                            {
                                                                Month = (DateTime.Now.ToString("MM")),
                                                                AccountNo = ANumber,
                                                                YearGain = "5",
                                                                Year = DateTime.Now.ToString("yyyy"),
                                                            };
                                                            db.YearlyProfits.InsertOnSubmit(styry);
                                                            db.SubmitChanges();

                                                        }

                                                        connsq.Close();
                                                    }
                                                }
                                                Label4.Text = days;
                                                // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly SMS Alert Charged for BuckFixed Account and Target Account Added');", true);

                                            }
                                            else
                                            { }


                                            i++;
                                        }
                                    }
                                }

                            }
                            else { }

                            //----------------------------------Weekly Felible and Softsaving Account-------------------------------
                            if (days == SMSRead)
                            {
                                string yr = DateTime.Now.ToString("MM/yyyy");
                                string cons = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                SqlConnection cnz = new SqlConnection(cons);

                                SqlCommand cmdzs = new SqlCommand("SELECT MAX (id) FROM WeeklySMS", cnz);
                                cmdzs.CommandType = CommandType.Text;
                                cmdzs.Connection.Open();
                                SqlDataReader dr = cmdzs.ExecuteReader();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        string Lab = dr[0].ToString();

                                        int i = 1;
                                        while (i <= int.Parse(Lab))
                                        {
                                            SqlConnection conwsB = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                            conwsB.Open();
                                            SqlCommand cmdwsB = new SqlCommand("Select * from WeeklySMS where id='" + i + "'", conwsB);
                                            SqlDataAdapter dawsB = new SqlDataAdapter(cmdwsB);
                                            DataTable dtwsB = new DataTable();
                                            dawsB.Fill(dtwsB);
                                            if (dtwsB.Rows.Count > 0)
                                            {
                                                string constringsq = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                using (SqlConnection connsq = new SqlConnection(constringsq))
                                                {
                                                    using (SqlCommand cmdtsq = new SqlCommand("SELECT id, msg, accountno FROM WeeklySMS WHERE id = '" + i + "'"))
                                                    {
                                                        cmdtsq.CommandType = CommandType.Text;
                                                        cmdtsq.Connection = connsq;
                                                        connsq.Open();

                                                        using (SqlDataReader sdrrq = cmdtsq.ExecuteReader())
                                                        {
                                                            sdrrq.Read();
                                                            string ANumber = sdrrq["accountno"].ToString();
                                                            string msgs = sdrrq["msg"].ToString();

                                                            //-----------------------NewAcount------------------------------------
                                                            string constringsqc = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                            using (SqlConnection connsqc = new SqlConnection(constringsqc))
                                                            {
                                                                using (SqlCommand cmdtsqc = new SqlCommand("SELECT id, AccountBalance,AccountNo FROM NewAcount WHERE AccountNo = '" + ANumber + "'"))
                                                                {
                                                                    cmdtsqc.CommandType = CommandType.Text;
                                                                    cmdtsqc.Connection = connsqc;
                                                                    connsqc.Open();

                                                                    using (SqlDataReader sdrrqc = cmdtsqc.ExecuteReader())
                                                                    {
                                                                        sdrrqc.Read();

                                                                        string bals2 = sdrrqc["AccountBalance"].ToString();
                                                                        string accNo2 = sdrrqc["AccountNo"].ToString();

                                                                        //------------------------------Update Weekly SMS----------------------------------------------
                                                                        int CheckBal = int.Parse(bals2) - 5;
                                                                        Label2.Text = CheckBal.ToString();
                                                                        string value1 = CheckBal.ToString();
                                                                        string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                                        SqlConnection connectionu = new SqlConnection(consst);
                                                                        connectionu.Open();
                                                                        string queu = "update dbo.NewAcount set AccountBalance=@value1 where AccountNo = '" + ANumber + "'";
                                                                        System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                                                        cmd5.Parameters.AddWithValue("@value1", value1);
                                                                        cmd5.ExecuteNonQuery();

                                                                        connectionu.Close();

                                                                        //-----------------------insert-----------------------------m

                                                                        var styr = new SmsProfit
                                                                        {
                                                                            MonthYear = (DateTime.Now.ToString("MM/yyyy")),
                                                                            AcctNo = ANumber,
                                                                            SmsPrice = "5",
                                                                            Date = DateTime.Now.ToString("yyyy"),
                                                                            AcctType = msgs,


                                                                        };
                                                                        db.SmsProfits.InsertOnSubmit(styr);
                                                                        db.SubmitChanges();

                                                                        var styry = new YearlyProfit
                                                                        {
                                                                            Month = (DateTime.Now.ToString("MM")),
                                                                            AccountNo = ANumber,
                                                                            YearGain = "5",
                                                                            Year = DateTime.Now.ToString("yyyy"),
                                                                        };
                                                                        db.YearlyProfits.InsertOnSubmit(styry);
                                                                        db.SubmitChanges();


                                                                    }

                                                                    connsqc.Close();
                                                                }
                                                            }

                                                            //========================================

                                                        }

                                                        connsq.Close();
                                                    }
                                                }
                                                Label4.Text = days;
                                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly SMS Alert Charged Added and Reducted');", true);

                                            }
                                            else
                                            { }


                                            i++;
                                        }
                                    }
                                }

                            }
                            else { }

                            //------------------------------------Update------------------------------------------------------------------
                            string value1s = "STOP2";
                            string conssts = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            SqlConnection connectionus = new SqlConnection(conssts);
                            connectionus.Open();
                            string queus = "update dbo.WeeklySME set SMSUpdate=@value1s where SMSId=3";
                            System.Data.SqlClient.SqlCommand cmd5s = new System.Data.SqlClient.SqlCommand(queus, connectionus);
                            cmd5s.Parameters.AddWithValue("@value1s", value1s);
                            cmd5s.ExecuteNonQuery();
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                            connectionus.Close();


                            if(days == "Monday")
                            {
                                //------------------------------Update Weekly SMS----------------------------------------------
                                var sty = (from s in db.WeeklySMEs where s.SMSId == 3 select s).First();
                                sty.SMSUpdate = "Friday";
                                db.SubmitChanges();
                            }
                            else { }


                        }
                    }
                    conn.Close();
                }  
            }
            else { Response.Redirect("AdminLogin1.aspx"); }
         
        }
        // call the linq
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conw.Open();
            SqlCommand cmdw = new SqlCommand("Select * from block where No='" + 4 + "'", conw);
            SqlDataAdapter daw = new SqlDataAdapter(cmdw);
            DataTable dtw = new DataTable();
            daw.Fill(dtw);
            if (dtw.Rows.Count > 0)
            {

                //-------------------------------------bank charge--------------------------------------------
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT id, date, No FROM block WHERE No = '" + 4 + "'"))
                    {
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();
                            string Dater = sdrr["date"].ToString();
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {   
                                 
                                if (Session["USER_ID"] != null)
                                {
                                    Label1.Text = Session["USER_ID"].ToString();
                                    string DCase = Session["USER_ID"].ToString();

                                                                                
                                    //---------------------------------------------HResources----------------------------------------------
                                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                                    string sqlqueryyda = "SELECT id, Username, Password, Active, Everyone, Branch FROM [dbo].[DepositeUser] where Everyone = '" + txtall.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                                    sqlconnyda.Open();
                                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                                    DataTable dtyyda = new DataTable();
                                    sdyyda.Fill(dtyyda);
                                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                                    if (sduyda.Read())
                                    {
                                        GridView1.DataSource = dtyyda;
                                        GridView1.DataBind();
                                    }
                                    else
                                    {
                                        Lab1.Text = "No Record";
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                            }
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                if (Session["USER_ID"] != null)
                                {
                                    Label1.Text = Session["USER_ID"].ToString();
                                    string DCase = Session["USER_ID"].ToString();

                                    //---------------------------------------------HResources----------------------------------------------
                                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                                    string sqlqueryyda = "SELECT id, Username, Password, Active, Everyone, Branch FROM [dbo].[WithdrawUser] where Everyone = '" + txtall.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                                    sqlconnyda.Open();
                                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                                    DataTable dtyyda = new DataTable();
                                    sdyyda.Fill(dtyyda);
                                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                                    if (sduyda.Read())
                                    {
                                        GridView1.DataSource = dtyyda;
                                        GridView1.DataBind();
                                    }
                                    else
                                    {
                                        Lab1.Text = "No Record";
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                            }
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                if (Session["USER_ID"] != null)
                                {
                                    Label1.Text = Session["USER_ID"].ToString();
                                    string DCase = Session["USER_ID"].ToString();

                                    //---------------------------------------------HResources----------------------------------------------
                                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                                    string sqlqueryyda = "SELECT id, Username, Password, Active, Everyone, Branch FROM [dbo].[CustomerCareUser] where Everyone = '" + txtall.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                                    sqlconnyda.Open();
                                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                                    DataTable dtyyda = new DataTable();
                                    sdyyda.Fill(dtyyda);
                                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                                    if (sduyda.Read())
                                    {
                                        GridView1.DataSource = dtyyda;
                                        GridView1.DataBind();
                                    }
                                    else
                                    {
                                        Lab1.Text = "No Record";
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                            }
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
            //---------------------------------------------ADMIN----------------------------------------------
            string constrydh = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconnydh = new SqlConnection(constrydh);
            string sqlqueryydh = "SELECT id, Username, Password, Active, Everyone FROM [dbo].[AdminUser] where Everyone = '" + txtall.Text + "'";
            SqlCommand sqlcommydh = new SqlCommand(sqlqueryydh, sqlconnydh);
            sqlconnydh.Open();
            SqlDataAdapter sdyydh = new SqlDataAdapter(sqlcommydh);
            DataTable dtyydh = new DataTable();
            sdyydh.Fill(dtyydh);
            SqlDataReader sduydh = sqlcommydh.ExecuteReader();
            if (sduydh.Read())
            {
                GridView1.DataSource = dtyydh;
                GridView1.DataBind();
            }
            else
            {
                Lab1.Text = "No Record";
            }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                            }
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                if (Session["USER_ID"] != null)
                                {
                                    Label1.Text = Session["USER_ID"].ToString();
                                    string DCase = Session["USER_ID"].ToString(); 

                                    //---------------------------------------------HResources----------------------------------------------
                                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                                    string sqlqueryyda = "SELECT id, Username, Password, Active, Everyone, Branch FROM [dbo].[HResourcesUser] where Everyone = '" + txtall.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                                    sqlconnyda.Open();
                                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                                    DataTable dtyyda = new DataTable();
                                    sdyyda.Fill(dtyyda);
                                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                                    if (sduyda.Read())
                                    {
                                        GridView1.DataSource = dtyyda;
                                        GridView1.DataBind();
                                    }
                                    else
                                    {
                                        Lab1.Text = "No Record";
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                            }
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                if (Session["USER_ID"] != null)
                                {
                                    Label1.Text = Session["USER_ID"].ToString();
                                    string DCase = Session["USER_ID"].ToString();

                                    //---------------------------------------------HResources----------------------------------------------
                                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                                    string sqlqueryyda = "SELECT id, Username, Password, Active, Everyone, Branch FROM [dbo].[LoanUser] where Everyone = '" + txtall.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                                    sqlconnyda.Open();
                                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                                    DataTable dtyyda = new DataTable();
                                    sdyyda.Fill(dtyyda);
                                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                                    if (sduyda.Read())
                                    {
                                        GridView1.DataSource = dtyyda;
                                        GridView1.DataBind();
                                    }
                                    else
                                    {
                                        Lab1.Text = "No Record";
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                            }
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                if (Session["USER_ID"] != null)
                                {
                                    Label1.Text = Session["USER_ID"].ToString();
                                    string DCase = Session["USER_ID"].ToString();

                                    //---------------------------------------------HResources----------------------------------------------
                                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                                    string sqlqueryyda = "SELECT id, Username, Password, Active, Everyone, Branch FROM [dbo].[TMTCheckRecordUser] where Everyone = '" + txtall.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                                    sqlconnyda.Open();
                                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                                    DataTable dtyyda = new DataTable();
                                    sdyyda.Fill(dtyyda);
                                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                                    if (sduyda.Read())
                                    {
                                        GridView1.DataSource = dtyyda;
                                        GridView1.DataBind();
                                    }
                                    else
                                    {
                                        Lab1.Text = "No Record";
                                    }
                                }
                            }
                              else
                              {
                                  ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                              }
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                if (Session["USER_ID"] != null)
                                {
                                    Label1.Text = Session["USER_ID"].ToString();
                                    string DCase = Session["USER_ID"].ToString();

                                    //---------------------------------------------HResources----------------------------------------------
                                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                                    string sqlqueryyda = "SELECT id, Username, Password, Active, Everyone, Branch FROM [dbo].[TMTDateControlLoginUser] where Everyone = '" + txtall.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                                    sqlconnyda.Open();
                                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                                    DataTable dtyyda = new DataTable();
                                    sdyyda.Fill(dtyyda);
                                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                                    if (sduyda.Read())
                                    {
                                        GridView1.DataSource = dtyyda;
                                        GridView1.DataBind();
                                    }
                                    else
                                    {
                                        Lab1.Text = "No Record";
                                    }
                                }
                            }
                              else
                              {
                                  ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                              }
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                if (Session["USER_ID"] != null)
                                {
                                    Label1.Text = Session["USER_ID"].ToString();
                                    string DCase = Session["USER_ID"].ToString();

                                    //---------------------------------------------HResources----------------------------------------------
                                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                                    string sqlqueryyda = "SELECT id, Username, Password, Active, Everyone, Branch FROM [dbo].[TMTFieldOfficeChatUser] where Everyone = '" + txtall.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                                    sqlconnyda.Open();
                                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                                    DataTable dtyyda = new DataTable();
                                    sdyyda.Fill(dtyyda);
                                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                                    if (sduyda.Read())
                                    {
                                        GridView1.DataSource = dtyyda;
                                        GridView1.DataBind();
                                    }
                                    else
                                    {
                                        Lab1.Text = "No Record";
                                    }
                                }
                            }
                              else
                              {
                                  ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                              }
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                if (Session["USER_ID"] != null)
                                {
                                    Label1.Text = Session["USER_ID"].ToString();
                                    string DCase = Session["USER_ID"].ToString();

                                    //---------------------------------------------HResources----------------------------------------------
                                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                                    string sqlqueryyda = "SELECT id, Username, Password, Active, Everyone, Branch FROM [dbo].[AccountingUser] where Everyone = '" + txtall.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                                    sqlconnyda.Open();
                                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                                    DataTable dtyyda = new DataTable();
                                    sdyyda.Fill(dtyyda);
                                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                                    if (sduyda.Read())
                                    {
                                        GridView1.DataSource = dtyyda;
                                        GridView1.DataBind();
                                    }
                                    else
                                    {
                                        Lab1.Text = "No Record";
                                    }
                                }
                            }
                              else
                              {
                                  ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                              }
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                if (Session["USER_ID"] != null)
                                {
                                    Label1.Text = Session["USER_ID"].ToString();
                                    string DCase = Session["USER_ID"].ToString();

                                    //---------------------------------------------HResources----------------------------------------------
                                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                                    string sqlqueryyda = "SELECT id, Username, Password, Active, Everyone, Branch FROM [dbo].[DepositeUser1] where Everyone = '" + txtall.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                                    sqlconnyda.Open();
                                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                                    DataTable dtyyda = new DataTable();
                                    sdyyda.Fill(dtyyda);
                                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                                    if (sduyda.Read())
                                    {
                                        GridView1.DataSource = dtyyda;
                                        GridView1.DataBind();
                                    }
                                    else
                                    {
                                        Lab1.Text = "No Record";
                                    }
                                }
                            }
                              else
                              {
                                  ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                              }
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                if (Session["USER_ID"] != null)
                                {
                                    Label1.Text = Session["USER_ID"].ToString();
                                    string DCase = Session["USER_ID"].ToString();

                                    //---------------------------------------------HResources----------------------------------------------
                                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                                    string sqlqueryyda = "SELECT id, Username, Password, Active, Everyone, Branch FROM [dbo].[WithdrawUser] where Everyone = '" + txtall.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                                    sqlconnyda.Open();
                                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                                    DataTable dtyyda = new DataTable();
                                    sdyyda.Fill(dtyyda);
                                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                                    if (sduyda.Read())
                                    {
                                        GridView1.DataSource = dtyyda;
                                        GridView1.DataBind();
                                    }
                                    else
                                    {
                                        Lab1.Text = "No Record";
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                            }
                        }
                    }
                    conns.Close();
                }

            }
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conw.Open();
            SqlCommand cmdw = new SqlCommand("Select * from block where No='" + 4 + "'", conw);
            SqlDataAdapter daw = new SqlDataAdapter(cmdw);
            DataTable dtw = new DataTable();
            daw.Fill(dtw);
            if (dtw.Rows.Count > 0)
            {

                //-------------------------------------bank charge--------------------------------------------
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT id, date, No FROM block WHERE No = '" + 4 + "'"))
                    {
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();
                            string Dater = sdrr["date"].ToString();
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                //-------------------------------------------------Deposite------------------------------------------------
                                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                con.Open();
                                SqlCommand cmd = new SqlCommand("Select * from DepositeUser where Active='" + txtusername.Text + "'", con);
                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    if (txtusername.Text == "")
                                    {
                                        Lab1.Text = " All Feld are Required";
                                    }
                                    else
                                    {
                            

                                        if (Session["USER_ID"] != null)
                                        {
                                            Label1.Text = Session["USER_ID"].ToString();
                                            string DCase = Session["USER_ID"].ToString();

                                            string value1 = txtusername.Text;
                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            SqlConnection connectionu = new SqlConnection(consst);
                                            connectionu.Open();
                                            string queu = "update dbo.DepositeUser set Password=@value1 where Active= '" + txtusername.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                            cmd5.Parameters.AddWithValue("@value1", txtusername.Text);
                                            cmd5.ExecuteNonQuery();
                                            Lab1.Text = txtusername.Text + " User Account Activated";
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);


                                            connectionu.Close();
                                        }
                                        

                                    }
                                }
                                else
                                {
                                    //Lab1.Text = "InValid Username doesn't Exist";
                                  
                                }
                                //-------------------------------------------------Withdraw------------------------------------------------
                                SqlConnection conA = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                conA.Open();
                                SqlCommand cmdA = new SqlCommand("Select * from WithdrawUser where Active='" + txtusername.Text + "'", conA);
                                SqlDataAdapter daA = new SqlDataAdapter(cmdA);
                                DataTable dtA = new DataTable();
                                daA.Fill(dtA);
                                if (dtA.Rows.Count > 0)
                                {
                                    if (txtusername.Text == "")
                                    {
                                        Lab1.Text = " All Feld are Required";
                                    }
                                    else
                                    {
                          
                                        if (Session["USER_ID"] != null)
                                        {
                                            Label1.Text = Session["USER_ID"].ToString();
                                            string DCase = Session["USER_ID"].ToString();

                                            string value1 = txtusername.Text;
                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            SqlConnection connectionu = new SqlConnection(consst);
                                            connectionu.Open();
                                            string queu = "update dbo.WithdrawUser set Password=@value1 where Active= '" + txtusername.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                            cmd5.Parameters.AddWithValue("@value1", txtusername.Text);
                                            cmd5.ExecuteNonQuery();
                                            Lab1.Text = txtusername.Text + " User Account Activated";
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);


                                            connectionu.Close();
                                        }
         

                                    }
                                }
                                else
                                {
                                   // Lab1.Text = "InValid Username doesn't Exist";
                                }
                                //-------------------------------------------------CustomerCare------------------------------------------------
                                SqlConnection conB = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                conB.Open();
                                SqlCommand cmdB = new SqlCommand("Select * from CustomerCareUser where Active='" + txtusername.Text + "'", conB);
                                SqlDataAdapter daB = new SqlDataAdapter(cmdB);
                                DataTable dtB = new DataTable();
                                daB.Fill(dtB);
                                if (dtB.Rows.Count > 0)
                                {
                                    if (txtusername.Text == "")
                                    {
                                        Lab1.Text = " All Feld are Required";
                                    }
                                    else
                                    {
                    
                                        if (Session["USER_ID"] != null)
                                        {
                                            Label1.Text = Session["USER_ID"].ToString();
                                            string DCase = Session["USER_ID"].ToString();

                                            string value1 = txtusername.Text;
                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            SqlConnection connectionu = new SqlConnection(consst);
                                            connectionu.Open();
                                            string queu = "update dbo.CustomerCareUser set Password=@value1 where Active= '" + txtusername.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                            cmd5.Parameters.AddWithValue("@value1", txtusername.Text);
                                            cmd5.ExecuteNonQuery();
                                            Lab1.Text = txtusername.Text + " User Account Activated";
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);


                                            connectionu.Close();
                                        }
         
                                    }
                                }
                                else
                                {
                                  //  Lab1.Text = "InValid Username doesn't Exist";

                                }
                                //-------------------------------------------------Loan------------------------------------------------
                                SqlConnection conC = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                conC.Open();
                                SqlCommand cmdC = new SqlCommand("Select * from LoanUser where Active='" + txtusername.Text + "'", conC);
                                SqlDataAdapter daC = new SqlDataAdapter(cmdC);
                                DataTable dtC = new DataTable();
                                daC.Fill(dtC);
                                if (dtC.Rows.Count > 0)
                                {
                                    if (txtusername.Text == "")
                                    {
                                        Lab1.Text = " All Feld are Required";
                                    }
                                    else
                                    {
                 
                                        if (Session["USER_ID"] != null)
                                        {
                                            Label1.Text = Session["USER_ID"].ToString();
                                            string DCase = Session["USER_ID"].ToString();

                                            string value1 = txtusername.Text;
                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            SqlConnection connectionu = new SqlConnection(consst);
                                            connectionu.Open();
                                            string queu = "update dbo.LoanUser set Password=@value1 where Active= '" + txtusername.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                            cmd5.Parameters.AddWithValue("@value1", txtusername.Text);
                                            cmd5.ExecuteNonQuery();
                                            Lab1.Text = txtusername.Text + " User Account Activated";
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);


                                            connectionu.Close();
                                        }
         
                                    }
                                }
                                else
                                {
                                   // Lab1.Text = "InValid Username doesn't Exist";
                                }
                                //-------------------------------------------------HResources------------------------------------------------
                                SqlConnection conH = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                conH.Open();
                                SqlCommand cmdH = new SqlCommand("Select * from HResourcesUser where Active='" + txtusername.Text + "'", conH);
                                SqlDataAdapter daH = new SqlDataAdapter(cmdH);
                                DataTable dtH = new DataTable();
                                daH.Fill(dtH);
                                if (dtH.Rows.Count > 0)
                                {
                                    if (txtusername.Text == "")
                                    {
                                        Lab1.Text = " All Feld are Required";
                                    }
                                    else
                                    {
                                        if (Session["USER_ID"] != null)
                                        {
                                            Label1.Text = Session["USER_ID"].ToString();
                                            string DCase = Session["USER_ID"].ToString();

                                            string value1 = txtusername.Text;
                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            SqlConnection connectionu = new SqlConnection(consst);
                                            connectionu.Open();
                                            string queu = "update dbo.HResourcesUser set Password=@value1 where Active= '" + txtusername.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                            cmd5.Parameters.AddWithValue("@value1", txtusername.Text);
                                            cmd5.ExecuteNonQuery();
                                            Lab1.Text = txtusername.Text + " User Account Activated";
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);


                                            connectionu.Close();
                                        }
                                    }
                                }
                                else
                                {
                                    //Lab1.Text = "InValid Username doesn't Exist";
                                }
                                //-------------------------------------------------TMTCheckRecord------------------------------------------------
                                SqlConnection conD = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                conD.Open();
                                SqlCommand cmdD = new SqlCommand("Select * from TMTCheckRecordUser where Active='" + txtusername.Text + "'", conD);
                                SqlDataAdapter daD = new SqlDataAdapter(cmdD);
                                DataTable dtD = new DataTable();
                                daD.Fill(dtD);
                                if (dtD.Rows.Count > 0)
                                {
                                    if (txtusername.Text == "")
                                    {
                                        Lab1.Text = " All Feld are Required";
                                    }
                                    else
                                    {
                                            if (Session["USER_ID"] != null)
                                        {
                                            Label1.Text = Session["USER_ID"].ToString();
                                            string DCase = Session["USER_ID"].ToString();

                                            string value1 = txtusername.Text;
                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            SqlConnection connectionu = new SqlConnection(consst);
                                            connectionu.Open();
                                            string queu = "update dbo.TMTCheckRecordUser set Password=@value1 where Active= '" + txtusername.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                            cmd5.Parameters.AddWithValue("@value1", txtusername.Text);
                                            cmd5.ExecuteNonQuery();
                                            Lab1.Text = txtusername.Text + " User Account Activated";
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);


                                            connectionu.Close();
                                        }
         
                                    }
                                }
                                else
                                {
                                   // Lab1.Text = "InValid Username doesn't Exist";
                                }
                                //-------------------------------------------------TMTFieldOfficer------------------------------------------------
                                SqlConnection conF = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                conF.Open();
                                SqlCommand cmdF = new SqlCommand("Select * from TMTFieldOfficeChatUser where Active='" + txtusername.Text + "'", conF);
                                SqlDataAdapter daF = new SqlDataAdapter(cmdF);
                                DataTable dtF = new DataTable();
                                daF.Fill(dtF);
                                if (dtF.Rows.Count > 0)
                                {
                                    if (txtusername.Text == "")
                                    {
                                        Lab1.Text = " All Feld are Required";
                                    }
                                    else
                                    {
                                       
                                        if (Session["USER_ID"] != null)
                                        {
                                            Label1.Text = Session["USER_ID"].ToString();
                                            string DCase = Session["USER_ID"].ToString();

                                            string value1 = txtusername.Text;
                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            SqlConnection connectionu = new SqlConnection(consst);
                                            connectionu.Open();
                                            string queu = "update dbo.TMTFieldOfficeChatUser set Password=@value1 where Active= '" + txtusername.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                            cmd5.Parameters.AddWithValue("@value1", txtusername.Text);
                                            cmd5.ExecuteNonQuery();
                                            Lab1.Text = txtusername.Text + " User Account Activated";
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);


                                            connectionu.Close();
                                        }
         
                                    }
                                }
                                else
                                {
                                   // Lab1.Text = "InValid Username doesn't Exist";
                                }
                                //-------------------------------------------------TMTDataControlLogin------------------------------------------------
                                SqlConnection conE = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                conE.Open();
                                SqlCommand cmdE = new SqlCommand("Select * from TMTDateControlLoginUser where Active='" + txtusername.Text + "'", conE);
                                SqlDataAdapter daE = new SqlDataAdapter(cmdE);
                                DataTable dtE = new DataTable();
                                daE.Fill(dtE);
                                if (dtE.Rows.Count > 0)
                                {
                                    if (txtusername.Text == "")
                                    {
                                        Lab1.Text = " All Feld are Required";
                                    }
                                    else
                                    {
                                       
                                        if (Session["USER_ID"] != null)
                                        {
                                            Label1.Text = Session["USER_ID"].ToString();
                                            string DCase = Session["USER_ID"].ToString();

                                            string value1 = txtusername.Text;
                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            SqlConnection connectionu = new SqlConnection(consst);
                                            connectionu.Open();
                                            string queu = "update dbo.TMTDateControlLoginUser set Password=@value1 where Active= '" + txtusername.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                            cmd5.Parameters.AddWithValue("@value1", txtusername.Text);
                                            cmd5.ExecuteNonQuery();
                                            Lab1.Text = txtusername.Text + " User Account Activated";
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);


                                            connectionu.Close();
                                        }
         
                                    }
                                }
                                else
                                {
                                   // Lab1.Text = "InValid Username doesn't Exist";
                                }
                                //-------------------------------------------------DepositeUser1------------------------------------------------
                                SqlConnection conED = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                conED.Open();
                                SqlCommand cmdED = new SqlCommand("Select * from DepositeUser1 where Active='" + txtusername.Text + "'", conED);
                                SqlDataAdapter daED = new SqlDataAdapter(cmdED);
                                DataTable dtED = new DataTable();
                                daED.Fill(dtED);
                                if (dtED.Rows.Count > 0)
                                {
                                    if (txtusername.Text == "")
                                    {
                                        Lab1.Text = " All Feld are Required";
                                    }
                                    else
                                    {
                                       
                                        if (Session["USER_ID"] != null)
                                        {
                                            Label1.Text = Session["USER_ID"].ToString();
                                            string DCase = Session["USER_ID"].ToString();

                                            string value1 = txtusername.Text;
                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            SqlConnection connectionu = new SqlConnection(consst);
                                            connectionu.Open();
                                            string queu = "update dbo.DepositeUser1 set Password=@value1 where Active= '" + txtusername.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                            cmd5.Parameters.AddWithValue("@value1", txtusername.Text);
                                            cmd5.ExecuteNonQuery();
                                            Lab1.Text = txtusername.Text + " User Account Activated";
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                                            connectionu.Close();
                                        }

                                    }
                                }
                                else
                                {
                                    // Lab1.Text = "InValid Username doesn't Exist";
                                }
                                //-------------------------------------------------AccountingUsers------------------------------------------------
                                SqlConnection conAC = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                conAC.Open();
                                SqlCommand cmdAC = new SqlCommand("Select * from AccountingUser where Active='" + txtusername.Text + "'", conAC);
                                SqlDataAdapter daAC = new SqlDataAdapter(cmdAC);
                                DataTable dtAC = new DataTable();
                                daAC.Fill(dtAC);
                                if (dtAC.Rows.Count > 0)
                                {
                                    if (txtusername.Text == "")
                                    {
                                        Lab1.Text = " All Feld are Required";
                                    }
                                    else
                                    {
                                       
                                        if (Session["USER_ID"] != null)
                                        {
                                            Label1.Text = Session["USER_ID"].ToString();
                                            string DCase = Session["USER_ID"].ToString();

                                            string value1 = txtusername.Text;
                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            SqlConnection connectionu = new SqlConnection(consst);
                                            connectionu.Open();
                                            string queu = "update dbo.AccountingUser set Password=@value1 where Active= '" + txtusername.Text + "' AND Branch = '" + txtbranch.Text + "'";
                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                            cmd5.Parameters.AddWithValue("@value1", txtusername.Text);
                                            cmd5.ExecuteNonQuery();
                                            Lab1.Text = txtusername.Text + " User Account Activated";
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                                            connectionu.Close();
                                        }
                                    }
                                }
                                else
                                {
                                    // Lab1.Text = "InValid Username doesn't Exist";
                                }


                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                            }
                        }
                    }
                    conns.Close();
                }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
              SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conw.Open();
            SqlCommand cmdw = new SqlCommand("Select * from block where No='" + 4 + "'", conw);
            SqlDataAdapter daw = new SqlDataAdapter(cmdw);
            DataTable dtw = new DataTable();
            daw.Fill(dtw);
            if (dtw.Rows.Count > 0)
            {

                //-------------------------------------bank charge--------------------------------------------
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT id, date, No FROM block WHERE No = '" + 4 + "'"))
                    {
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();
                            string Dater = sdrr["date"].ToString();
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from DepositeUser where Username='" + txtusername.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //-----------------------------------Deposite--------------------------------------
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    string value1 = " Not-Activate";
                    string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    SqlConnection connectionu = new SqlConnection(consst);
                    connectionu.Open();
                    string queu = "update dbo.DepositeUser set Password=@value1 where Username= '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                    System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                    cmd5.Parameters.AddWithValue("@value1", value1);
                    cmd5.ExecuteNonQuery();
                    Lab1.Text = txtusername.Text + " User Account Not Activated";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                    connectionu.Close();
                }
         
            }
            SqlConnection conY = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conY.Open();
            SqlCommand cmdY = new SqlCommand("Select * from WithdrawUser where Username='" + txtusername.Text + "'", conY);
            SqlDataAdapter daY = new SqlDataAdapter(cmdY);
            DataTable dtY = new DataTable();
            daY.Fill(dtY);
            if (dtY.Rows.Count > 0)
            {
                //----------------------------------------withdraw--------------------------------
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    string value1 = " Not-Activate";
                    string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    SqlConnection connectionu = new SqlConnection(consst);
                    connectionu.Open();
                    string queu = "update dbo.WithdrawUser set Password=@value1 where Username= '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                    System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                    cmd5.Parameters.AddWithValue("@value1", value1);
                    cmd5.ExecuteNonQuery();
                    Lab1.Text = txtusername.Text + " User Account Not Activated";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                    connectionu.Close();
                }
            }
            SqlConnection conW = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conW.Open();
            SqlCommand cmdW = new SqlCommand("Select * from CustomerCareUser where Username='" + txtusername.Text + "'", conW);
            SqlDataAdapter daW = new SqlDataAdapter(cmdW);
            DataTable dtW = new DataTable();
            daW.Fill(dtW);
            if (dtW.Rows.Count > 0)
            {
                //-----------------------------------CustomerCare--------------------------------------
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    string value1 = " Not-Activate";
                    string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    SqlConnection connectionu = new SqlConnection(consst);
                    connectionu.Open();
                    string queu = "update dbo.CustomerCareUser set Password=@value1 where Username= '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                    System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                    cmd5.Parameters.AddWithValue("@value1", value1);
                    cmd5.ExecuteNonQuery();
                    Lab1.Text = txtusername.Text + " User Account Not Activated";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                    connectionu.Close();
                }
            }
            SqlConnection conV = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conV.Open();
            SqlCommand cmdV = new SqlCommand("Select * from HResourcesUser where Username='" + txtusername.Text + "'", conV);
            SqlDataAdapter daV = new SqlDataAdapter(cmdV);
            DataTable dtV = new DataTable();
            daV.Fill(dtV);
            if (dtV.Rows.Count > 0)
            {
                //-----------------------------------HResources--------------------------------------
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    string value1 = " Not-Activate";
                    string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    SqlConnection connectionu = new SqlConnection(consst);
                    connectionu.Open();
                    string queu = "update dbo.HResourcesUser set Password=@value1 where Username= '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                    System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                    cmd5.Parameters.AddWithValue("@value1", value1);
                    cmd5.ExecuteNonQuery();
                    Lab1.Text = txtusername.Text + " User Account Not Activated";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                    connectionu.Close();
                }
            }
            SqlConnection conX = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conX.Open();
            SqlCommand cmdX = new SqlCommand("Select * from LoanUser where Username='" + txtusername.Text + "'", conX);
            SqlDataAdapter daX = new SqlDataAdapter(cmdX);
            DataTable dtX = new DataTable();
            daX.Fill(dtX);
            if (dtX.Rows.Count > 0)
            {
                //-----------------------------------Loan--------------------------------------
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    string value1 = " Not-Activate";
                    string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    SqlConnection connectionu = new SqlConnection(consst);
                    connectionu.Open();
                    string queu = "update dbo.LoanUser set Password=@value1 where Username= '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                    System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                    cmd5.Parameters.AddWithValue("@value1", value1);
                    cmd5.ExecuteNonQuery();
                    Lab1.Text = txtusername.Text + " User Account Not Activated";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                    connectionu.Close();
                }
            }
            SqlConnection conS = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conS.Open();
            SqlCommand cmdS = new SqlCommand("Select * from TMTCheckRecordUser where Username='" + txtusername.Text + "'", conS);
            SqlDataAdapter daS = new SqlDataAdapter(cmdS);
            DataTable dtS = new DataTable();
            daS.Fill(dtS);
            if (dtS.Rows.Count > 0)
            {
                //-----------------------------------TMTCheckRecord--------------------------------------
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    string value1 = " Not-Activate";
                    string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    SqlConnection connectionu = new SqlConnection(consst);
                    connectionu.Open();
                    string queu = "update dbo.TMTCheckRecordUser set Password=@value1 where Username= '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                    System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                    cmd5.Parameters.AddWithValue("@value1", value1);
                    cmd5.ExecuteNonQuery();
                    Lab1.Text = txtusername.Text + " User Account Not Activated";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                    connectionu.Close();
                }
            }
            SqlConnection conF = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conF.Open();
            SqlCommand cmdF = new SqlCommand("Select * from TMTFieldOfficeChatUser where Username='" + txtusername.Text + "'", conF);
            SqlDataAdapter daF = new SqlDataAdapter(cmdF);
            DataTable dtF = new DataTable();
            daF.Fill(dtF);
            if (dtF.Rows.Count > 0)
            {
                //-----------------------------------TMTFieldOfficer--------------------------------------
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    string value1 = " Not-Activate";
                    string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    SqlConnection connectionu = new SqlConnection(consst);
                    connectionu.Open();
                    string queu = "update dbo.TMTFieldOfficeChatUser set Password=@value1 where Username= '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                    System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                    cmd5.Parameters.AddWithValue("@value1", value1);
                    cmd5.ExecuteNonQuery();
                    Lab1.Text = txtusername.Text + " User Account Not Activated";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                    connectionu.Close();
                }
            }
            SqlConnection conK = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conK.Open();
            SqlCommand cmdK = new SqlCommand("Select * from TMTDateControlLoginUser where Username='" + txtusername.Text + "'", conK);
            SqlDataAdapter daK = new SqlDataAdapter(cmdK);
            DataTable dtK = new DataTable();
            daK.Fill(dtK);
            if (dtK.Rows.Count > 0)
            {
                //-----------------------------------TMTDateControlLogin--------------------------------------
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    string value1 = " Not-Activate";
                    string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    SqlConnection connectionu = new SqlConnection(consst);
                    connectionu.Open();
                    string queu = "update dbo.TMTDateControlLoginUser set Password=@value1 where Username= '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                    System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                    cmd5.Parameters.AddWithValue("@value1", value1);
                    cmd5.ExecuteNonQuery();
                    Lab1.Text = txtusername.Text + " User Account Not Activated";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                    connectionu.Close();
                }
            }
            SqlConnection conKS = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conKS.Open();
            SqlCommand cmdKS = new SqlCommand("Select * from DepositeUser1 where Username='" + txtusername.Text + "'", conKS);
            SqlDataAdapter daKS = new SqlDataAdapter(cmdKS);
            DataTable dtKS = new DataTable();
            daKS.Fill(dtKS);
            if (dtKS.Rows.Count > 0)
            {
                //-----------------------------------DepositeUser1--------------------------------------
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    string value1 = " Not-Activate";
                    string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    SqlConnection connectionu = new SqlConnection(consst);
                    connectionu.Open();
                    string queu = "update dbo.DepositeUser1 set Password=@value1 where Username= '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                    System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                    cmd5.Parameters.AddWithValue("@value1", value1);
                    cmd5.ExecuteNonQuery();
                    Lab1.Text = txtusername.Text + " User Account Not Activated";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                    connectionu.Close();
                }
            }
            SqlConnection conJ = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conJ.Open();
            SqlCommand cmdJ = new SqlCommand("Select * from AccountingUser where Username='" + txtusername.Text + "'", conJ);
            SqlDataAdapter daJ = new SqlDataAdapter(cmdJ);
            DataTable dtJ = new DataTable();
            daJ.Fill(dtJ);
            if (dtJ.Rows.Count > 0)
            {
                //-----------------------------------Acounting--------------------------------------
            
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    string value1 = " Not-Activate";
                    string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    SqlConnection connectionu = new SqlConnection(consst);
                    connectionu.Open();
                    string queu = "update dbo.AccountingUser set Password=@value1 where Username= '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                    System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                    cmd5.Parameters.AddWithValue("@value1", value1);
                    cmd5.ExecuteNonQuery();
                    Lab1.Text = txtusername.Text + " User Account Not Activated";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                    connectionu.Close();
                }
            }
            else {
                
                // Lab1.Text = "InValid Username doesn't Exist";

            }
           }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                            }
                        }
                    }
                    conns.Close();
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            Session.Remove("USER_ID");
            Session.RemoveAll();
            Response.Redirect("AdminLogin1.aspx");
        }
       protected void Button4_Click(object sender, EventArgs e)
        {
             SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conw.Open();
            SqlCommand cmdw = new SqlCommand("Select * from block where No='" + 4 + "'", conw);
            SqlDataAdapter daw = new SqlDataAdapter(cmdw);
            DataTable dtw = new DataTable();
            daw.Fill(dtw);
            if (dtw.Rows.Count > 0)
            {

                //-------------------------------------bank charge--------------------------------------------
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT id, date, No FROM block WHERE No = '" + 4 + "'"))
                    {
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();
                            string Dater = sdrr["date"].ToString();
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
            if (txtarea.Text == "")
            {
                Lab1.Text = " Pls Input Staff PhoneNo";
            }
            else
            {
                var styr = new StaffSM
                {
                    PhoneNo = txtarea.Text,
                    Date = DateTime.Now.ToString("dd/MM/yyyy"),

                };

                db.StaffSMs.InsertOnSubmit(styr);
                db.SubmitChanges();
                Lab1.Text = " Staff PhoneNo Added";
            }

              }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                            }
                        }
                    }
                    conns.Close();
                }

            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conw.Open();
            SqlCommand cmdw = new SqlCommand("Select * from block where No='" + 4 + "'", conw);
            SqlDataAdapter daw = new SqlDataAdapter(cmdw);
            DataTable dtw = new DataTable();
            daw.Fill(dtw);
            if (dtw.Rows.Count > 0)
            {

                //-------------------------------------bank charge--------------------------------------------
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT id, date, No FROM block WHERE No = '" + 4 + "'"))
                    {
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();
                            string Dater = sdrr["date"].ToString();
                            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                            {

              //----------------------read highest ID----------------------------------------------------
                            string cons = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            SqlConnection cnz = new SqlConnection(cons);

                            SqlCommand cmdzs = new SqlCommand("SELECT MAX (id) FROM StaffSMS ", cnz);
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


                                        string constringsa = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        using (SqlConnection connsa = new SqlConnection(constringsa))
                                        {
                                            using (SqlCommand cmdtsa = new SqlCommand("SELECT id, PhoneNo FROM StaffSMS WHERE id = '" +i+ "'"))
                                            {
                                                cmdtsa.CommandType = CommandType.Text;
                                                cmdtsa.Connection = connsa;
                                                connsa.Open();

                                                using (SqlDataReader sdrraY = cmdtsa.ExecuteReader())
                                                {
                                                    sdrraY.Read();
                                                    string recipients = sdrraY["PhoneNo"].ToString();
                                                   

                                                    //---------------------------------------SMS--------------------------------------------------                                                    

                                                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://app.multitexter.com/v2/app/sms");
                                                    httpWebRequest.ContentType = "application/json";
                                                    httpWebRequest.Method = "POST";
                                                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
                                                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                                                    //---------------------------------------------
                                                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                                    {
                                                        string msg;
                                                        string email = "Zealluckres@gmail.com";
                                                        string password = "Zealluck@123";
                                                        string sender_name = "ZEALLUCK";
                                                        string forcednd = "1";
                                                   
                                                        string json = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"message\":\"" + txtarea.Text + "\",\"sender_name\":\"" + sender_name + "\",\"recipients\":\"" + recipients + "\",\"forcednd\":\"" + forcednd + "\"}";
                                                        streamWriter.Write(json);
                                                        streamWriter.Flush();
                                                        streamWriter.Close();
                                                    }
                                                    //----------------------------send SMS---------------------------------------

                                                    System.Net.WebRequest request;

                                                   
                                                    // request = System.Net.WebRequest.Create(reqUrl);
                                                    if (txtarea.Text != "")
                                                    {
                                                        // request.GetResponse();

                                                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                                        {
                                                            var result = streamReader.ReadToEnd();
                                                            Console.WriteLine(result);
                                                        }
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('SMS Sent To Staff');", true);


                                                    }
                                                    else
                                                    { }


                                                }

                                                connsa.Close();
                                            }
                                        }

                                        i++;
                                    }
                                }
                            }
                 }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
                            }
                        }
                    }
                    conns.Close();
                }

            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
                string connetionString;
                SqlConnection cnn;
                SqlCommand comand;
                //String path;

                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();



                connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                string sql = "Select * from CustomerCareUser where Username='" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                comand = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    //--------------------------delete-----------------------------------------------------------
                  
                        string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        SqlConnection cn2 = new SqlConnection(cons2s);
                        cn2.Open();
                        SqlCommand command;
                        SqlDataAdapter adap = new SqlDataAdapter();
                        string sqset = "";
                        sqset = "delete from dbo.CustomerCareUser where Username = '" + txtusername.Text + "' AND Branch = '" + DCase +"'";
                        command = new SqlCommand(sqset, cn2);

                        adap.DeleteCommand = new SqlCommand(sqset, cn2);
                        adap.DeleteCommand.ExecuteNonQuery();

                        command.Dispose();
                        cn2.Close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Staff lOGIN ACCOUNT Deleted');", true);

                    }
                
                }
              else
                {
                    // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Username doesn't exist');", true);

                }

                    //--------------------------------------------------------------------------------------------------------------
                string connetionStringV;
                SqlConnection cnnV;
                SqlCommand comandV;

                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    connetionStringV = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    cnnV = new SqlConnection(connetionStringV);
                    cnnV.Open();
                    string sqlV = "Select * from DepositeUser where Username='" + txtusername.Text + "'  AND Branch = '" + DCase + "'";
                    comandV = new SqlCommand(sqlV, cnnV);
                    SqlDataAdapter daV = new SqlDataAdapter(comandV);
                    DataTable dtV = new DataTable();
                    daV.Fill(dtV);
                    if (dtV.Rows.Count > 0)
                    {
                        //--------------------------delete-----------------------------------------------------------

                        string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        SqlConnection cn2 = new SqlConnection(cons2s);
                        cn2.Open();
                        SqlCommand command;
                        SqlDataAdapter adap = new SqlDataAdapter();
                        string sqset = "";
                        sqset = "delete from dbo.DepositeUser where Username = '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                        command = new SqlCommand(sqset, cn2);

                        adap.DeleteCommand = new SqlCommand(sqset, cn2);
                        adap.DeleteCommand.ExecuteNonQuery();

                        command.Dispose();
                        cn2.Close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Staff lOGIN ACCOUNT Deleted');", true);
                    }
                }
                else
                {
                    // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Username doesn't exist');", true);

                }
                    //--------------------------------------------------------------------------------------------------------------
                string connetionStringN;
                SqlConnection cnnN;
                SqlCommand comandN;

                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();


                    connetionStringN = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    cnnN = new SqlConnection(connetionStringN);
                    cnnN.Open();
                    string sqlN = "Select * from DepositeUser1 where Username='" + txtusername.Text + "'  AND Branch = '" + DCase + "'";
                    comandN = new SqlCommand(sqlN, cnnN);
                    SqlDataAdapter daN = new SqlDataAdapter(comandN);
                    DataTable dtN = new DataTable();
                    daN.Fill(dtN);
                    if (dtN.Rows.Count > 0)
                    {
                        //--------------------------delete-----------------------------------------------------------

                        string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        SqlConnection cn2 = new SqlConnection(cons2s);
                        cn2.Open();
                        SqlCommand command;
                        SqlDataAdapter adap = new SqlDataAdapter();
                        string sqset = "";
                        sqset = "delete from dbo.DepositeUser1 where Username = '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                        command = new SqlCommand(sqset, cn2);

                        adap.DeleteCommand = new SqlCommand(sqset, cn2);
                        adap.DeleteCommand.ExecuteNonQuery();

                        command.Dispose();
                        cn2.Close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Staff lOGIN ACCOUNT Deleted');", true);
                    }
                }
                else
                {
                    // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Username doesn't exist');", true);

                }
                     //--------------------------------------------------------------------------------------------------------------
                string connetionStringNN;
                SqlConnection cnnNN;
                SqlCommand comandNN;

                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();


                    connetionStringNN = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    cnnNN = new SqlConnection(connetionStringNN);
                    cnnNN.Open();
                    string sqlNN = "Select * from HResourcesUser where Username='" + txtusername.Text + "'  AND Branch = '" + DCase + "'";
                    comandNN = new SqlCommand(sqlNN, cnnNN);
                    SqlDataAdapter daNN = new SqlDataAdapter(comandNN);
                    DataTable dtNN = new DataTable();
                    daNN.Fill(dtNN);
                    if (dtNN.Rows.Count > 0)
                    {
                        //--------------------------delete-----------------------------------------------------------

                        string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        SqlConnection cn2 = new SqlConnection(cons2s);
                        cn2.Open();
                        SqlCommand command;
                        SqlDataAdapter adap = new SqlDataAdapter();
                        string sqset = "";
                        sqset = "delete from dbo.HResourcesUser where Username = '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                        command = new SqlCommand(sqset, cn2);

                        adap.DeleteCommand = new SqlCommand(sqset, cn2);
                        adap.DeleteCommand.ExecuteNonQuery();

                        command.Dispose();
                        cn2.Close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Staff lOGIN ACCOUNT Deleted');", true);
                    }
                }
                else
                {
                    // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Username doesn't exist');", true);

                }
                     //--------------------------------------------------------------------------------------------------------------
                string connetionStringM;
                SqlConnection cnnM;
                SqlCommand comandM;

                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();


                    connetionStringM = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    cnnM = new SqlConnection(connetionStringM);
                    cnnM.Open();
                    string sqlM = "Select * from LoanUser where Username='" + txtusername.Text + "'  AND Branch = '" + DCase + "'";
                    comandM = new SqlCommand(sqlM, cnnM);
                    SqlDataAdapter daM = new SqlDataAdapter(comandM);
                    DataTable dtM = new DataTable();
                    daM.Fill(dtM);
                    if (dtM.Rows.Count > 0)
                    {
                        //--------------------------delete-----------------------------------------------------------

                        string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        SqlConnection cn2 = new SqlConnection(cons2s);
                        cn2.Open();
                        SqlCommand command;
                        SqlDataAdapter adap = new SqlDataAdapter();
                        string sqset = "";
                        sqset = "delete from dbo.LoanUser where Username = '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                        command = new SqlCommand(sqset, cn2);

                        adap.DeleteCommand = new SqlCommand(sqset, cn2);
                        adap.DeleteCommand.ExecuteNonQuery();

                        command.Dispose();
                        cn2.Close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Staff lOGIN ACCOUNT Deleted');", true);
                    }
                }
                else
                {
                    // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Username doesn't exist');", true);

                }

                     //--------------------------------------------------------------------------------------------------------------
                string connetionStringP;
                SqlConnection cnnP;
                SqlCommand comandP;
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();


                    connetionStringP = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    cnnP = new SqlConnection(connetionStringP);
                    cnnP.Open();
                    string sqlP = "Select * from TMTCheckRecordUser where Username='" + txtusername.Text + "'  AND Branch = '" + DCase + "'";
                    comandP = new SqlCommand(sqlP, cnnP);
                    SqlDataAdapter daP = new SqlDataAdapter(comandP);
                    DataTable dtP = new DataTable();
                    daP.Fill(dtP);
                    if (dtP.Rows.Count > 0)
                    {
                        //--------------------------delete-----------------------------------------------------------

                        string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        SqlConnection cn2 = new SqlConnection(cons2s);
                        cn2.Open();
                        SqlCommand command;
                        SqlDataAdapter adap = new SqlDataAdapter();
                        string sqset = "";
                        sqset = "delete from dbo.TMTCheckRecordUser where Username = '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                        command = new SqlCommand(sqset, cn2);

                        adap.DeleteCommand = new SqlCommand(sqset, cn2);
                        adap.DeleteCommand.ExecuteNonQuery();

                        command.Dispose();
                        cn2.Close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Staff lOGIN ACCOUNT Deleted');", true);
                    }
                }
                else
                {
                    // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Username doesn't exist');", true);

                }

                     //--------------------------------------------------------------------------------------------------------------
                string connetionStringJ;
                SqlConnection cnnJ;
                SqlCommand comandJ;
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();


                    connetionStringJ = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    cnnJ = new SqlConnection(connetionStringJ);
                    cnnJ.Open();
                    string sqlJ = "Select * from TMTDateControlLoginUser where Username='" + txtusername.Text + "'  AND Branch = '" + DCase + "'";
                    comandJ = new SqlCommand(sqlJ, cnnJ);
                    SqlDataAdapter daJ = new SqlDataAdapter(comandJ);
                    DataTable dtJ = new DataTable();
                    daJ.Fill(dtJ);
                    if (dtJ.Rows.Count > 0)
                    {
                        //--------------------------delete-----------------------------------------------------------

                        string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        SqlConnection cn2 = new SqlConnection(cons2s);
                        cn2.Open();
                        SqlCommand command;
                        SqlDataAdapter adap = new SqlDataAdapter();
                        string sqset = "";
                        sqset = "delete from dbo.TMTDateControlLoginUser where Username = '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                        command = new SqlCommand(sqset, cn2);

                        adap.DeleteCommand = new SqlCommand(sqset, cn2);
                        adap.DeleteCommand.ExecuteNonQuery();

                        command.Dispose();
                        cn2.Close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Staff lOGIN ACCOUNT Deleted');", true);
                    }
                }
                else
                {
                    // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Username doesn't exist');", true);

                }

                     //--------------------------------------------------------------------------------------------------------------
                string connetionStringL;
                SqlConnection cnnL;
                SqlCommand comandL;
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();


                    connetionStringL = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    cnnL = new SqlConnection(connetionStringL);
                    cnnL.Open();
                    string sqlL = "Select * from TMTFieldOfficeChatUser where Username='" + txtusername.Text + "'  AND Branch = '" + DCase + "'";
                    comandL = new SqlCommand(sqlL, cnnL);
                    SqlDataAdapter daL = new SqlDataAdapter(comandL);
                    DataTable dtL = new DataTable();
                    daL.Fill(dtL);
                    if (dtL.Rows.Count > 0)
                    {
                        //--------------------------delete-----------------------------------------------------------

                        string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        SqlConnection cn2 = new SqlConnection(cons2s);
                        cn2.Open();
                        SqlCommand command;
                        SqlDataAdapter adap = new SqlDataAdapter();
                        string sqset = "";
                        sqset = "delete from dbo.TMTFieldOfficeChatUser where Username = '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                        command = new SqlCommand(sqset, cn2);

                        adap.DeleteCommand = new SqlCommand(sqset, cn2);
                        adap.DeleteCommand.ExecuteNonQuery();

                        command.Dispose();
                        cn2.Close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Staff lOGIN ACCOUNT Deleted');", true);
                    }
                }
                else
                {
                    // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Username doesn't exist');", true);

                }

                     //--------------------------------------------------------------------------------------------------------------
                string connetionStringQ;
                SqlConnection cnnQ;
                SqlCommand comandQ;
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();


                    connetionStringQ = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    cnnQ = new SqlConnection(connetionStringQ);
                    cnnQ.Open();
                    string sqlQ = "Select * from WithdrawUser where Username='" + txtusername.Text + "'  AND Branch = '" + DCase + "'";
                    comandQ = new SqlCommand(sqlQ, cnnQ);
                    SqlDataAdapter daQ = new SqlDataAdapter(comandQ);
                    DataTable dtQ = new DataTable();
                    daQ.Fill(dtQ);
                    if (dtQ.Rows.Count > 0)
                    {
                        //--------------------------delete-----------------------------------------------------------

                        string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        SqlConnection cn2 = new SqlConnection(cons2s);
                        cn2.Open();
                        SqlCommand command;
                        SqlDataAdapter adap = new SqlDataAdapter();
                        string sqset = "";
                        sqset = "delete from dbo.WithdrawUser where Username = '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                        command = new SqlCommand(sqset, cn2);

                        adap.DeleteCommand = new SqlCommand(sqset, cn2);
                        adap.DeleteCommand.ExecuteNonQuery();

                        command.Dispose();
                        cn2.Close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Staff lOGIN ACCOUNT Deleted');", true);
                    }
                }
                else
                {
                    // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Username doesn't exist');", true);

                }

                     //--------------------------------------------------------------------------------------------------------------
                string connetionStringU;
                SqlConnection cnnU;
                SqlCommand comandU;
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();


                    connetionStringU = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    cnnU = new SqlConnection(connetionStringU);
                    cnnU.Open();
                    string sqlU = "Select * from AccountingUser where Username='" + txtusername.Text + "'  AND Branch = '" + DCase + "'";
                    comandU = new SqlCommand(sqlU, cnnU);
                    SqlDataAdapter daU = new SqlDataAdapter(comandU);
                    DataTable dtU = new DataTable();
                    daU.Fill(dtU);
                    if (dtU.Rows.Count > 0)
                    {
                        //--------------------------delete-----------------------------------------------------------

                        string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        SqlConnection cn2 = new SqlConnection(cons2s);
                        cn2.Open();
                        SqlCommand command;
                        SqlDataAdapter adap = new SqlDataAdapter();
                        string sqset = "";
                        sqset = "delete from dbo.AccountingUser where Username = '" + txtusername.Text + "' AND Branch = '" + DCase + "'";
                        command = new SqlCommand(sqset, cn2);

                        adap.DeleteCommand = new SqlCommand(sqset, cn2);
                        adap.DeleteCommand.ExecuteNonQuery();

                        command.Dispose();
                        cn2.Close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Staff lOGIN ACCOUNT Deleted');", true);
                    }
                }
                else
                {
                    // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Username doesn't exist');", true);

                }
            
               
               
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from DepositeUser where Username='" + txtusername.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                //----------------------------Staff Movement---------------------------------
                var stunic = (from s in db.DepositeUsers where s.Username == txtusername.Text select s).First();
                stunic.Branch = txtbranch.Text;
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Moved');", true);
            }
            else { }

            SqlConnection conb = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conb.Open();
            SqlCommand cmdb = new SqlCommand("Select * from WithdrawUser where Username='" + txtusername.Text + "'", conb);
            SqlDataAdapter dab = new SqlDataAdapter(cmdb);
            DataTable dtb = new DataTable();
            dab.Fill(dtb);
            if (dtb.Rows.Count > 0)
            {

                //----------------------------Staff Movement---------------------------------
                var stuniv = (from s in db.WithdrawUsers where s.Username == txtusername.Text select s).First();
                stuniv.Branch = txtbranch.Text;
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Moved');", true);
            }
            else { }


            SqlConnection conbc = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conbc.Open();
            SqlCommand cmdbc = new SqlCommand("Select * from CustomerCareUser where Username='" + txtusername.Text + "'", conbc);
            SqlDataAdapter dabc = new SqlDataAdapter(cmdbc);
            DataTable dtbc = new DataTable();
            dabc.Fill(dtbc);
            if (dtbc.Rows.Count > 0)
            {
                //----------------------------Staff Movement---------------------------------
                var stunix = (from s in db.CustomerCareUsers where s.Username == txtusername.Text select s).First();
                stunix.Branch = txtbranch.Text;
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Moved');", true);
            }
            else { }

            SqlConnection onbc = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            onbc.Open();
            SqlCommand mdbc = new SqlCommand("Select * from HResourcesUser where Username='" + txtusername.Text + "'", onbc);
            SqlDataAdapter abc = new SqlDataAdapter(mdbc);
            DataTable tbc = new DataTable();
            abc.Fill(tbc);
            if (tbc.Rows.Count > 0)
            {

                //----------------------------Staff Movement---------------------------------
                var stuniw = (from s in db.HResourcesUsers where s.Username == txtusername.Text select s).First();
                stuniw.Branch = txtbranch.Text;
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Moved');", true);
            }
            else { }


            SqlConnection onbcc = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            onbcc.Open();
            SqlCommand mdbcc = new SqlCommand("Select * from LoanUser where Username='" + txtusername.Text + "'", onbcc);
            SqlDataAdapter abcc = new SqlDataAdapter(mdbcc);
            DataTable tbcc = new DataTable();
            abcc.Fill(tbcc);
            if (tbcc.Rows.Count > 0)
            {
                //----------------------------Staff Movement---------------------------------
                var stunie = (from s in db.LoanUsers where s.Username == txtusername.Text select s).First();
                stunie.Branch = txtbranch.Text;
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Moved');", true);
            }
            else { }


            SqlConnection vonbcc = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            vonbcc.Open();
            SqlCommand vmdbcc = new SqlCommand("Select * from DepositeUser1 where Username='" + txtusername.Text + "'", vonbcc);
            SqlDataAdapter vabcc = new SqlDataAdapter(vmdbcc);
            DataTable vtbcc = new DataTable();
            vabcc.Fill(vtbcc);
            if (vtbcc.Rows.Count > 0)
            {

                //----------------------------Staff Movement---------------------------------
                var stunir = (from s in db.DepositeUser1s where s.Username == txtusername.Text select s).First();
                stunir.Branch = txtbranch.Text;
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Moved');", true);
            }
            else { }


            SqlConnection conba = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conba.Open();
            SqlCommand cmdba = new SqlCommand("Select * from TMTCheckRecordUser where Username='" + txtusername.Text + "'", conba);
            SqlDataAdapter daba = new SqlDataAdapter(cmdba);
            DataTable dtba = new DataTable();
            daba.Fill(dtba);
            if (dtba.Rows.Count > 0)
            {
                //----------------------------Staff Movement---------------------------------
            var stunit = (from s in db.TMTCheckRecordUsers where s.Username == txtusername.Text select s).First();
            stunit.Branch = txtbranch.Text;
            db.SubmitChanges();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Moved');", true);
            }
            else { }

          
            SqlConnection conbL = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conbL.Open();
            SqlCommand cmdbL = new SqlCommand("Select * from TMTDateControlLoginUser where Username='" + txtusername.Text + "'", conbL);
            SqlDataAdapter dabL = new SqlDataAdapter(cmdbL);
            DataTable dtbL = new DataTable();
            dabL.Fill(dtbL);
            if (dtbL.Rows.Count > 0)
            {
                //----------------------------Staff Movement---------------------------------
                var stuniy = (from s in db.TMTDateControlLoginUsers where s.Username == txtusername.Text select s).First();
                stuniy.Branch = txtbranch.Text;
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Moved');", true);
            }
            else { }

            SqlConnection conbLL = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conbLL.Open();
            SqlCommand cmdbLL = new SqlCommand("Select * from TMTFieldOfficeChatUser where Username='" + txtusername.Text + "'", conbLL);
            SqlDataAdapter dabLL = new SqlDataAdapter(cmdbLL);
            DataTable dtbLL = new DataTable();
            dabLL.Fill(dtbLL);
            if (dtbLL.Rows.Count > 0)
            {

                //----------------------------Staff Movement---------------------------------
                var stunip = (from s in db.TMTFieldOfficeChatUsers where s.Username == txtusername.Text select s).First();
                stunip.Branch = txtbranch.Text;
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Moved');", true);
                            
           
            }
            else { }

            SqlConnection onbLL = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            onbLL.Open();
            SqlCommand mdbLL = new SqlCommand("Select * from AccountingUser where Username='" + txtusername.Text + "'", onbLL);
            SqlDataAdapter abLL = new SqlDataAdapter(mdbLL);
            DataTable tbLL = new DataTable();
            abLL.Fill(tbLL);
            if (tbLL.Rows.Count > 0)
            {

                //----------------------------Staff Movement---------------------------------
                var stunip = (from s in db.AccountingUsers where s.Username == txtusername.Text select s).First();
                stunip.Branch = txtbranch.Text;
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Moved');", true);


            }
            else { }
          
           
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            //------------------ADD BRANCH-------------------------------
            if (txtarea.Text == "")
            { }
            else
            {
                var styr = new AddBranch
                {
                    Branch = txtarea.Text,
                    Admin = "Admin",
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),

                };
                db.AddBranches.InsertOnSubmit(styr);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Branch Added');", true);
            }
         


            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    //---------------------------------------------HResources----------------------------------------------
                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                    string sqlqueryyda = "SELECT id, Branch, Admin, Date FROM [dbo].[AddBranch] where Admin = '" + txtid.Text + "'";
                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                    sqlconnyda.Open();
                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                    DataTable dtyyda = new DataTable();
                    sdyyda.Fill(dtyyda);
                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                    if (sduyda.Read())
                    {
                        GridView1.DataSource = dtyyda;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Lab1.Text = "No Record";
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            //---------------------ADD ACCOUNTTYPE---------------------------------------
            if (txtarea.Text == "")
            { }
            else
            {
                var styr = new AccountType
                {
                    AcctType = txtarea.Text,
                    Admin = "Admin",
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),

                };
                db.AccountTypes.InsertOnSubmit(styr);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('AccountType Added');", true);
            }

            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    //---------------------------------------------HResources----------------------------------------------
                    string constryda = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    SqlConnection sqlconnyda = new SqlConnection(constryda);
                    string sqlqueryyda = "SELECT id, AcctType, Admin, Date FROM [dbo].[AccountType] where Admin = '" + txtid.Text + "'";
                    SqlCommand sqlcommyda = new SqlCommand(sqlqueryyda, sqlconnyda);
                    sqlconnyda.Open();
                    SqlDataAdapter sdyyda = new SqlDataAdapter(sqlcommyda);
                    DataTable dtyyda = new DataTable();
                    sdyyda.Fill(dtyyda);
                    SqlDataReader sduyda = sqlcommyda.ExecuteReader();
                    if (sduyda.Read())
                    {
                        GridView1.DataSource = dtyyda;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Lab1.Text = "No Record";
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('MDirector Just Sign you Out!');", true);
            }

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            //------------------DELETE ACCOUNTTYPE-----------------------------
            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from DormantAccount where AccountNo='" + txtarea.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                //--------------------------delete-----------------------------------------------------------

                string cons2sy = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                SqlConnection cn2y = new SqlConnection(cons2sy);
                cn2y.Open();
                SqlCommand commandy;
                SqlDataAdapter adapy = new SqlDataAdapter();
                string sqsety = "";
               // sqsety = "delete from dbo.AccountType where id = '" + txtid.Text + "'";
                sqsety = "Select * from DormantAccount where AccountNo='" + txtid.Text + "'";
                commandy = new SqlCommand(sqsety, cn2y);

                adapy.DeleteCommand = new SqlCommand(sqsety, cn2y);
                adapy.DeleteCommand.ExecuteNonQuery();

                commandy.Dispose();
                cn2y.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' DormantAccount Deleted');", true);


            }
            else
            {
                // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('AccountNo doesn't exist');", true);

            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            //------------------DELETE BRANCH--------------------------------

            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from AddBranch where id='" + txtid.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                //--------------------------delete-----------------------------------------------------------

                string cons2sy = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                SqlConnection cn2y = new SqlConnection(cons2sy);
                cn2y.Open();
                SqlCommand commandy;
                SqlDataAdapter adapy = new SqlDataAdapter();
                string sqsety = "";
                sqsety = "delete from dbo.AddBranch where id = '"+ txtid.Text +"'";
                commandy = new SqlCommand(sqsety, cn2y);

                adapy.DeleteCommand = new SqlCommand(sqsety, cn2y);
                adapy.DeleteCommand.ExecuteNonQuery();

                commandy.Dispose();
                cn2y.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Transaction Deleted');", true);
             

            }
            else
            {
                // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff ID doesn't exist');", true);

            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            SqlConnection conwsB = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conwsB.Open();
            SqlCommand cmdwsB = new SqlCommand("Select * from DepositeUser where Username='" + txtusername.Text + "'", conwsB);
            SqlDataAdapter dawsB = new SqlDataAdapter(cmdwsB);
            DataTable dtwsB = new DataTable();
            dawsB.Fill(dtwsB);
            if (dtwsB.Rows.Count > 0)
            {
                
                //-------------------------------------bank charge--------------------------------------------
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT id,Username,Password,Active,Everyone,Branch FROM DepositeUser WHERE Username = '" + txtusername.Text + "'"))
                    {
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();
                            string bals1 = sdrr["Username"].ToString();
                            string bals2 = sdrr["Password"].ToString();
                            string Acts = sdrr["Active"].ToString();
                            string bals3 = sdrr["Everyone"].ToString();
                            string bals4 = sdrr["Branch"].ToString();

                            var styr = new WithdrawUser
                            {
                                Username = bals1,
                                Password = bals2,
                                Active = Acts,
                                Everyone = "Withdraw",
                                Branch   = bals4,

                            };
                            db.WithdrawUsers.InsertOnSubmit(styr);
                            db.SubmitChanges();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Moved from Deposite To withdraw');", true);

           
                        }

                        conns.Close();
                    }
                }


                //--------------delete-------------------------------------------
                
                string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                SqlConnection cn2 = new SqlConnection(cons2s);
                cn2.Open();
                SqlCommand command;
                SqlDataAdapter adap = new SqlDataAdapter();
                string sqset = "";
                sqset = "delete from dbo.DepositeUser WHERE Username = '" + txtusername.Text + "'";
                command = new SqlCommand(sqset, cn2);

                adap.DeleteCommand = new SqlCommand(sqset, cn2);
                adap.DeleteCommand.ExecuteNonQuery();

                command.Dispose();
                cn2.Close();
                                      
                
            }
            else
            {   

               
            }
            
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            SqlConnection conwsB = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conwsB.Open();
            SqlCommand cmdwsB = new SqlCommand("Select * from WithdrawUser where Username='" + txtusername.Text + "'", conwsB);
            SqlDataAdapter dawsB = new SqlDataAdapter(cmdwsB);
            DataTable dtwsB = new DataTable();
            dawsB.Fill(dtwsB);
            if (dtwsB.Rows.Count > 0)
            {

                //-------------------------------------bank charge--------------------------------------------
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT id,Username,Password,Active,Everyone,Branch FROM WithdrawUser WHERE Username = '" + txtusername.Text + "'"))
                    {
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();
                            string bals1 = sdrr["Username"].ToString();
                            string bals2 = sdrr["Password"].ToString();
                            string Acts  = sdrr["Active"].ToString();
                            string bals3 = sdrr["Everyone"].ToString();
                            string bals4 = sdrr["Branch"].ToString();

                            var styrw = new DepositeUser
                            {
                                Username = bals1,
                                Password = bals2,
                                Active = Acts,
                                Everyone = "Deposite",
                                Branch = bals4,

                            };
                            db.DepositeUsers.InsertOnSubmit(styrw);
                            db.SubmitChanges();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Moved from withdraw To Deposite');", true);

                        }

                        conns.Close();
                    }
                }

                //--------------delete-------------------------------------------
                
                string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                SqlConnection cn2 = new SqlConnection(cons2s);
                cn2.Open();
                SqlCommand command;
                SqlDataAdapter adap = new SqlDataAdapter();
                string sqset = "";
                sqset = "delete from dbo.WithdrawUser WHERE Username = '" + txtusername.Text + "'";
                command = new SqlCommand(sqset, cn2);

                adap.DeleteCommand = new SqlCommand(sqset, cn2);
                adap.DeleteCommand.ExecuteNonQuery();

                command.Dispose();
                cn2.Close();
                 
            }
            else
            { }
        }
    }
}