using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.IO;
using System.Globalization;

namespace BankA
{
    public partial class Link : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //--------------------------------------SMS---------------------------
          
           // txtbranch.Text = wk.ToString();
            //---------------------------------------------------SMS ALERT SYSTEM------------------------------------------------------
            DataClasses1DataContext db = new DataClasses1DataContext();
            string constring = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (SqlCommand cmdt = new SqlCommand("SELECT id, SMSUpdate, SMSId FROM WeeklySME WHERE SMSId = '" + 4 + "'"))
                {
                    cmdt.CommandType = CommandType.Text;
                    cmdt.Connection = conn;
                    conn.Open();

                    using (SqlDataReader sdrr = cmdt.ExecuteReader())
                    {
                        sdrr.Read();
                        string SMSRead = sdrr["SMSUpdate"].ToString();
                        string SMSid = sdrr["SMSId"].ToString();


                        //-----------------------SEND WEEKLY SMS FOR DEPOSITE--------------------------------------------------

                        DateTime dt = DateTime.Today;
                        string day = dt.DayOfWeek.ToString();

                        if (day == SMSRead)
                        {

                            //----------------------read highest ID----------------------------------------------------
                            string cons = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            SqlConnection cnz = new SqlConnection(cons);

                            SqlCommand cmdzs = new SqlCommand("SELECT MAX (id) FROM WeeklySMS ", cnz);
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
                                        // Console.WriteLine("C# For Loop: Iteration {0}", i);

                                        // Action Send Pending SMS

                                        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                        con.Open();
                                        SqlCommand cmd = new SqlCommand("Select * from WeeklySMS where smsid='" + 2 + "'", con);
                                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                                        DataTable dt1 = new DataTable();
                                        da.Fill(dt1);
                                        if (dt1.Rows.Count > 0)
                                        {

                                            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            using (SqlConnection con0 = new SqlConnection(constr))
                                            {

                                                using (SqlCommand cmd0 = new SqlCommand("SELECT smsid, phoneno,depositebalance,depositecollect,accountno,id FROM WeeklySMS WHERE id ='" + i + "'"))
                                                {
                                                    cmd0.CommandType = CommandType.Text;
                                                    cmd0.Connection = con0;
                                                    con0.Open();

                                                    using (SqlDataReader sdr = cmd0.ExecuteReader())
                                                    {

                                                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                                                        sdr.Read();

                                                        string recipients = sdr["phoneno"].ToString();
                                                        string balance = sdr["depositebalance"].ToString();
                                                        string TotalBal = sdr["depositecollect"].ToString();
                                                        string accNo = sdr["accountno"].ToString();

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
                                                            msg = "Zealluck Bank! You make deposite of :" + balance + " " + " with AcountNo: " + accNo + " " + " From:  Monday  To :" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " |Bal:N" + TotalBal + " |FDBCK?CALL 018983973";

                                                            string json = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"message\":\"" + msg + "\",\"sender_name\":\"" + sender_name + "\",\"recipients\":\"" + recipients + "\",\"forcednd\":\"" + forcednd + "\"}";
                                                            streamWriter.Write(json);
                                                            streamWriter.Flush();
                                                            streamWriter.Close();
                                                        }
                                                        //----------------------------send SMS---------------------------------------

                                                        System.Net.WebRequest request;

                                                        // msg = "Welcome To Zealluck Bank! Your AccountNo is:" + txtaccountno.Text + " Date:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " FDBCK?CALL 018983973";
                                                        //  String reqUrl = " http://justsms.com.ng/index.php?option=com_spc&comm=spc_api&username=zealluck&password=zealluck@biz.&sender=@@ZEALLUCK@@&recipient=@@smsno@@&message=@@msg@@&";

                                                        // String reqUrl = "http://justsms.com.ng/index.php?option=com_spc&comm=spc_api&username=zealluck&password=zealluck@biz.&sender=ZEALLUCK&recipient=" + smsno + "&message=" + msg + "&";
                                                        // string url = "https://justsms.com.ng/index.php?option=com_spc&comm=spc_api&username=zealluck&password=zealluck@biz.&sender=@@ZEALLUCK@@&recipient=@@" + txtsms.Text + " @@&message=@@" + msg + "@@&";
                                                        //  String reqUrl = "{ \"password\":\"" + password + "\",\"message\":\"" + msg + "\",\"sender_name\":\"" + sender_name + "\",\"recipients\":\"" + smsno + "\"}";
                                                        // string reqUrl = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"message\":\"" + msg + "\",\"sender_name\":\"" + sender_name + "\",\"recipients\":\"" + recipients + "\",\"forcednd\":\"" + forcednd + "\"}";

                                                        // request = System.Net.WebRequest.Create(reqUrl);
                                                        if (accNo != "")
                                                        {
                                                            // request.GetResponse();

                                                            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                                            {
                                                                var result = streamReader.ReadToEnd();
                                                                Console.WriteLine(result);
                                                            }
                                                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);


                                                        }
                                                        else
                                                        { }


                                                        //-----------------------------------------------------------------------------


                                                        //-------------------------------------------------------------------------------
                                                        //-----------------------------BANK CHARGE---------------------------------------
                                                        /**
                                                        SqlConnection conws = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                                        conws.Open();
                                                        SqlCommand cmdws = new SqlCommand("Select * from WeeklySMS where smsid='" + 2 + "'", conws);
                                                        SqlDataAdapter daws = new SqlDataAdapter(cmdws);
                                                        DataTable dtws = new DataTable();
                                                        daws.Fill(dtws);
                                                        if (dtws.Rows.Count > 0)
                                                        {

                                                            //-------------------------------------bank charge--------------------------------------------
                                                            string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                            using (SqlConnection conns = new SqlConnection(constrings))
                                                            {

                                                                using (SqlCommand cmdts = new SqlCommand("SELECT id, phoneno,depositebalance,depositecollect,accountno FROM WeeklySMS WHERE id ='" + i + "'"))
                                                                {
                                                                    cmdts.CommandType = CommandType.Text;
                                                                    cmdts.Connection = conns;
                                                                    conns.Open();

                                                                    using (SqlDataReader sdrrH = cmdts.ExecuteReader())
                                                                    {
                                                                        sdrrH.Read();
                                                                        string bals = sdrrH["depositecollect"].ToString();
                                                                        string accNoo = sdrrH["accountno"].ToString();


                                                                        //-------------------------------------bank charge--------------------------------------------
                                                                        string constringsW = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                                        using (SqlConnection connsW = new SqlConnection(constringsW))
                                                                        {

                                                                            using (SqlCommand cmdtsW = new SqlCommand("SELECT id, AccountNo, AccountBalance, AccountType FROM NewAcount WHERE AccountNo ='" + accNo + "'"))
                                                                            {
                                                                                cmdtsW.CommandType = CommandType.Text;
                                                                                cmdtsW.Connection = connsW;
                                                                                connsW.Open();

                                                                                using (SqlDataReader sdrrHW = cmdtsW.ExecuteReader())
                                                                                {
                                                                                    sdrrHW.Read();
                                                                                    string bals2 = sdrrHW["AccountBalance"].ToString();
                                                                                    string accNo2 = sdrrHW["AccountNo"].ToString();


                                                                                    //-----------------------------------------------------------------
                                                                                    //------------------------------Update Weekly SMS----------------------------------------------
                                                                                    int CheckBal = int.Parse(bals2) - 5;
                                                                                    Label2.Text = CheckBal.ToString();
                                                                                    string value1 = CheckBal.ToString();
                                                                                    string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                                                    SqlConnection connectionu = new SqlConnection(consst);
                                                                                    connectionu.Open();
                                                                                    string queu = "update dbo.NewAcount set AccountBalance=@value1 where AccountNo = '" + accNoo + "'";
                                                                                    System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                                                                    cmd5.Parameters.AddWithValue("@value1", value1);
                                                                                    cmd5.ExecuteNonQuery();

                                                                                    connectionu.Close();
                                                                                    //-----------------------------------------------------------------

                                                                                    //-----------------------insert-----------------------------

                                                                                    var styr = new SMSAlertProfit
                                                                                    {
                                                                                        Month = (DateTime.Now.ToString("MM")),
                                                                                        AccountNo = accNoo,
                                                                                        Profit = "5",
                                                                                        Year = DateTime.Now.ToString("yyyy"),


                                                                                    };
                                                                                    db.SMSAlertProfits.InsertOnSubmit(styr);
                                                                                    db.SubmitChanges();


                                                                                    //-------------Update SMS ----------------------




                                                                                }

                                                                                connsW.Close();
                                                                            }
                                                                        }


                                                                        //--------------------------------------------------------------------------------

                                                                    }

                                                                    conns.Close();
                                                                }
                                                            }

                                                        }
                                                        else
                                                        { }
                                                        **/


                                                        //--------------------------------------------------------------------------------


                                                        string value1V = "STOP1";
                                                        string consstV = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                        SqlConnection connectionuV = new SqlConnection(consstV);
                                                        connectionuV.Open();
                                                        string queuV = "update dbo.WeeklySME set SMSUpdate=@value1 where SMSId=4";
                                                        System.Data.SqlClient.SqlCommand cmd5V = new System.Data.SqlClient.SqlCommand(queuV, connectionuV);
                                                        cmd5V.Parameters.AddWithValue("@value1", value1V);
                                                        cmd5V.ExecuteNonQuery();
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                                                        connectionuV.Close();


                                                        //---------------------------read buckfixed / target account----------------------------------

                                                        SqlConnection conwsB = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                                        conwsB.Open();
                                                        SqlCommand cmdwsB = new SqlCommand("Select * from BuckFixedSMS1 where id='" + i + "'", conwsB);
                                                        SqlDataAdapter dawsB = new SqlDataAdapter(cmdwsB);
                                                        DataTable dtwsB = new DataTable();
                                                        dawsB.Fill(dtwsB);
                                                        if (dtwsB.Rows.Count > 0)
                                                        {

                                                            //-------------------------------------bank charge--------------------------------------------
                                                            string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                            using (SqlConnection conns = new SqlConnection(constrings))
                                                            {
                                                                using (SqlCommand cmdts = new SqlCommand("SELECT id, msg, accountno, month, phoneno, depositecollect, depositebalance FROM BuckFixedSMS1 WHERE id = '" + i + "'"))
                                                                {
                                                                    cmdts.CommandType = CommandType.Text;
                                                                    cmdts.Connection = conns;
                                                                    conns.Open();

                                                                    using (SqlDataReader sdrrf = cmdts.ExecuteReader())
                                                                    {
                                                                        sdrrf.Read();
                                                                        string bals = sdrrf["depositebalance"].ToString();
                                                                        string DepoColl = sdrrf["depositecollect"].ToString();
                                                                        string NoSMS = sdrrf["phoneno"].ToString();
                                                                        string Accountno = sdrrf["accountno"].ToString();
                                                                        string AccType = sdrrf["msg"].ToString();
                                                                        string Mth = sdrrf["month"].ToString();
                                                                        string sender_name = "ZEALLUCK";


                                                                        //---------------------------------------SMS--------------------------------------------------                                                    

                                                                        var httpWebRequest1 = (HttpWebRequest)WebRequest.Create("https://app.multitexter.com/v2/app/sms");
                                                                        httpWebRequest1.ContentType = "application/json";
                                                                        httpWebRequest1.Method = "POST";
                                                                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
                                                                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                                                                        //---------------------------------------------
                                                                        using (var streamWriter = new StreamWriter(httpWebRequest1.GetRequestStream()))
                                                                        {
                                                                            string msg;
                                                                            string email = "Zealluckres@gmail.com";
                                                                            string password = "Zealluck@123";
                                                                            // string sender_names = "ZEALLUCK";
                                                                            string forcednd = "1";
                                                                            msg = "Zealluck Bank! Overall Deposite Is  :" + " " + bals + " " + " with AcountNo: " + Accountno + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " |Bal:N" + DepoColl + " " + "AccountType :" + AccType + " |FDBCK?CALL 018983973";

                                                                            string json = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"message\":\"" + msg + "\",\"sender_name\":\"" + sender_name + "\",\"recipients\":\"" + NoSMS + "\",\"forcednd\":\"" + forcednd + "\"}";
                                                                            streamWriter.Write(json);
                                                                            streamWriter.Flush();
                                                                            streamWriter.Close();
                                                                        }
                                                                        //----------------------------send SMS---------------------------------------

                                                                        System.Net.WebRequest request1;

                                                                        // msg = "Welcome To Zealluck Bank! Your AccountNo is:" + txtaccountno.Text + " Date:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " FDBCK?CALL 018983973";
                                                                        //  String reqUrl = " http://justsms.com.ng/index.php?option=com_spc&comm=spc_api&username=zealluck&password=zealluck@biz.&sender=@@ZEALLUCK@@&recipient=@@smsno@@&message=@@msg@@&";

                                                                        // String reqUrl = "http://justsms.com.ng/index.php?option=com_spc&comm=spc_api&username=zealluck&password=zealluck@biz.&sender=ZEALLUCK&recipient=" + smsno + "&message=" + msg + "&";
                                                                        // string url = "https://justsms.com.ng/index.php?option=com_spc&comm=spc_api&username=zealluck&password=zealluck@biz.&sender=@@ZEALLUCK@@&recipient=@@" + txtsms.Text + " @@&message=@@" + msg + "@@&";
                                                                        //  String reqUrl = "{ \"password\":\"" + password + "\",\"message\":\"" + msg + "\",\"sender_name\":\"" + sender_name + "\",\"recipients\":\"" + smsno + "\"}";
                                                                        // string reqUrl = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"message\":\"" + msg + "\",\"sender_name\":\"" + sender_name + "\",\"recipients\":\"" + recipients + "\",\"forcednd\":\"" + forcednd + "\"}";

                                                                        // request = System.Net.WebRequest.Create(reqUrl);
                                                                        if (Accountno != "")
                                                                        {
                                                                            // request.GetResponse();

                                                                            var httpResponse = (HttpWebResponse)httpWebRequest1.GetResponse();
                                                                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                                                            {
                                                                                var result = streamReader.ReadToEnd();
                                                                                Console.WriteLine(result);
                                                                            }
                                                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);


                                                                        }
                                                                        else
                                                                        { }


                                                                        //-------------Update SMS ----------------------

                                                                        //---------------------------------Update WeeklySMS------------
                                                                        /**
                                                                        SqlConnection conwsBx = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                                                        conwsBx.Open();
                                                                        SqlCommand cmdwsBx = new SqlCommand("Select * from BuckFixedSMS where id='" + i + "'", conwsBx);
                                                                        SqlDataAdapter dawsBx = new SqlDataAdapter(cmdwsBx);
                                                                        DataTable dtwsBx = new DataTable();
                                                                        dawsBx.Fill(dtwsBx);
                                                                        if (dtwsBx.Rows.Count > 0)
                                                                        {
                                                                            DateTimeFormatInfo mfi = new DateTimeFormatInfo();
                                                                            // Lab1.Text =  mfi.GetMonthName(8).ToString();

                                                                            int monthNumber = int.Parse(DateTime.Now.ToString("MM"));
                                                                            // Lab1.Text = new DateTimeFormatInfo().GetMonthName(DateTime.Now.ToString("MM"));

                                                                            CultureInfo ci = new CultureInfo("en-US");
                                                                            // Lab1.Text = DateTime.Now.ToString("MMMM", ci);

                                                                            // Lab1.Text = new DateTimeFormatInfo().GetMonthName(monthNumber);
                                                                            // Lab1.Text = DateTime.Now.ToString("MMMM", ci);


                                                                            String mthNumber = new DateTimeFormatInfo().GetMonthName(monthNumber);
                                                                            String Yr = DateTime.Now.ToString("MM/yyyy");


                                                                            //-------------------------------------bank charge--------------------------------------------
                                                                            string constringsx = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                                            using (SqlConnection connsx = new SqlConnection(constringsx))
                                                                            {
                                                                                using (SqlCommand cmdtsx = new SqlCommand("SELECT id, smsCharge,accountno, msg, month FROM BuckFixedSMS WHERE id = '" + i + "'"))
                                                                                {
                                                                                    cmdtsx.CommandType = CommandType.Text;
                                                                                    cmdtsx.Connection = connsx;
                                                                                    connsx.Open();

                                                                                    using (SqlDataReader sdrrx = cmdtsx.ExecuteReader())
                                                                                    {
                                                                                        sdrrx.Read();
                                                                                        string balCharge = sdrrx["smsCharge"].ToString();
                                                                                        string mth = sdrrx["month"].ToString();
                                                                                        string msg = sdrrx["msg"].ToString();

                                                                                        Double CheckBal = (Double.Parse(balCharge) + 5);

                                                                                        string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                                                        SqlConnection connectionu = new SqlConnection(consst);
                                                                                        connectionu.Open();
                                                                                        string queu = "update dbo.BuckFixedSMS set smsCharge=@CheckBal where accountno = '" + Accountno + "'";
                                                                                        System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                                                                        cmd5.Parameters.AddWithValue("@CheckBal", CheckBal);
                                                                                        cmd5.ExecuteNonQuery();

                                                                                        connectionu.Close();

                                                                                        //-----------------------insert-----------------------------m

                                                                                        var styr = new SmsProfit
                                                                                        {
                                                                                            MonthYear = (DateTime.Now.ToString("MM/yyyy")),
                                                                                            AcctNo = Accountno,
                                                                                            SmsPrice = "5",
                                                                                            Date = DateTime.Now.ToString("yyyy"),
                                                                                            AcctType = msg,


                                                                                        };
                                                                                        db.SmsProfits.InsertOnSubmit(styr);
                                                                                        db.SubmitChanges();



                                                                                    }

                                                                                    connsx.Close();
                                                                                }
                                                                            }

                                                                        }
                                                                        else
                                                                        { }
                                                                        **/

                                                                    }

                                                                    conns.Close();
                                                                }
                                                            }

                                                        }
                                                        else
                                                        { }

                                                        //-------------------------------------end------------------------------------------------------
                                                    }

                                                    con0.Close();

                                                }
                                            }
                                        }
                                        else
                                        { }
                                        i++;
                                    }
                                }
                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE SMS Send Ony On Monday');", true);
                        }

                    }
                }
                conn.Close();
            }
            //--------------------------------------------------------------------------------------
            string constringss = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            using (SqlConnection conns = new SqlConnection(constringss))
            {
                using (SqlCommand cmdts = new SqlCommand("SELECT id, SMSUpdate, SMSId FROM WeeklySME1 WHERE SMSId = '" + 4 + "'"))
                {
                    cmdts.CommandType = CommandType.Text;
                    cmdts.Connection = conns;
                    conns.Open();

                    using (SqlDataReader sdrry = cmdts.ExecuteReader())
                    {
                        DateTime dty = DateTime.Today;
                        string dayy = dty.DayOfWeek.ToString();

                        sdrry.Read();
                        string Update = sdrry["SMSUpdate"].ToString();
                        //------------------------- delect and start from zero----------------------------
                        if (dayy == Update)
                        {

                            //--------------------------delete-----------------------------------------------------------

                            string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            SqlConnection cn2 = new SqlConnection(cons2s);
                            cn2.Open();
                            SqlCommand command;
                            SqlDataAdapter adap = new SqlDataAdapter();
                            string sqset = "";
                            sqset = "delete from dbo.WeeklySMS";
                            command = new SqlCommand(sqset, cn2);

                            adap.DeleteCommand = new SqlCommand(sqset, cn2);
                            adap.DeleteCommand.ExecuteNonQuery();

                            command.Dispose();
                            cn2.Close();

                            //--------------------------delete-----------------------------------------------------------

                            string cons2sy = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            SqlConnection cn2y = new SqlConnection(cons2sy);
                            cn2y.Open();
                            SqlCommand commandy;
                            SqlDataAdapter adapy = new SqlDataAdapter();
                            string sqsety = "";
                            sqsety = "delete from dbo.BuckFixedSMS1";
                            commandy = new SqlCommand(sqsety, cn2y);

                            adapy.DeleteCommand = new SqlCommand(sqsety, cn2y);
                            adapy.DeleteCommand.ExecuteNonQuery();

                            commandy.Dispose();
                            cn2y.Close();



                            //------------------------start auto increment from one after deleting all table-------------

                            string conss = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            SqlConnection connection = new SqlConnection(conss);

                            //SqlConnection connection = new SqlConnection(GetConnectionString(connectionstringer));
                            string sqlStatement = "DBCC CHECKIDENT ('WeeklySMS', RESEED, 0)";
                            connection.Open();
                            SqlCommand cmder = new SqlCommand(sqlStatement, connection);
                            cmder.CommandType = CommandType.Text;
                            cmder.ExecuteNonQuery();
                            connection.Close();

                            //------------------------start auto increment from one after deleting all table-------------

                            string conssv = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            SqlConnection connectionv = new SqlConnection(conssv);

                            //SqlConnection connection = new SqlConnection(GetConnectionString(connectionstringer));
                            string sqlStatementv = "DBCC CHECKIDENT ('BuckFixedSMS1', RESEED, 0)";
                            connectionv.Open();
                            SqlCommand cmderv = new SqlCommand(sqlStatementv, connectionv);
                            cmderv.CommandType = CommandType.Text;
                            cmderv.ExecuteNonQuery();
                            connectionv.Close();
                            //------------------------------------Update------------------------------------------------------------------

                            string value1 = "STOP2";
                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            SqlConnection connectionu = new SqlConnection(consst);
                            connectionu.Open();
                            string queu = "update dbo.WeeklySME1 set SMSUpdate=@value1 where SMSId=4";
                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                            cmd5.Parameters.AddWithValue("@value1", value1);
                            cmd5.ExecuteNonQuery();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Weekly DEPOSITE STOP Till Monday again');", true);

                            connectionu.Close();


                        }

                    }

                    conns.Close();
                }

                //--------------------------------------------------------------------------------------------------
                DateTime dtyy = DateTime.Today;
                string dayday = dtyy.DayOfWeek.ToString();

                if (dayday == "Tuesday")
                {
                    // call the linq

                    //------------------------------Update Weekly SMS----------------------------------------------
                    var sty = (from s in db.WeeklySMEs where s.SMSId == 4 select s).First();
                    sty.SMSUpdate = "Monday";
                    db.SubmitChanges();
                    //------------------------------Update Weekly SMS----------------------------------------------
                    var styy = (from s in db.WeeklySME1s where s.SMSId == 4 select s).First();
                    styy.SMSUpdate = "Monday";
                    db.SubmitChanges();

                }

            }
            //---------------------------------------------------END SMS ALERT SYSTEM------------------------------------------------------


            DataClasses1DataContext dbY = new DataClasses1DataContext();
            //---------------------------Monthly OverAll Profit-------------------------------------------
            string constringsY = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            using (SqlConnection conns = new SqlConnection(constringsY))
            {
                using (SqlCommand cmdts = new SqlCommand("SELECT id, Endate, DateId FROM ZealTable WHERE DateId = '" + 3 + "'"))
                {
                    cmdts.CommandType = CommandType.Text;
                    cmdts.Connection = conns;
                    conns.Open();

                    using (SqlDataReader sdrr = cmdts.ExecuteReader())
                    {
                        sdrr.Read();

                        string RealDate = sdrr["Endate"].ToString();
                        //------------------------------------------------------------------------------------------------------------
                        // Lab1.Text = RealDate;

                        if (DateTime.Now.ToString("30/MM/yyyy") == sdrr["Endate"].ToString())
                        {
                            //-----------------Sum All The Profit------------------------------------------
                            //---------------------------Withdraw SMS Profit-------------------------------------------------
                            DataTable dt = new DataTable();
                            string cons = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            String myquery = "select * from [dbo].[Withdraw]";
                            SqlConnection cnz = new SqlConnection(cons);
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = myquery;
                            cmd.Connection = cnz;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.SelectCommand = cmd;

                            da.Fill(dt);
                            cnz.Close();

                            var result = dt.AsEnumerable()
                                    .Sum(x => Convert.ToInt32(x["SMSCharges"]));
                            //  Lab1.Text = result.ToString();
                            Double Youtube = Double.Parse(result.ToString());

                            /**
                            var orderedRows = from row in dt.AsEnumerable()
                                              let date = DateTime.ParseExact(row.Field<string>("Date"), "dd-mm-yyyy", null)
                                              orderby date
                                              select row;
                             **/


                            //---------------------------NewAcount SMS Profit-------------------------------------------------
                            DataTable dt1 = new DataTable();
                            string cons1 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            String myquery1 = "select * from [dbo].[NewAcount]";
                            SqlConnection cnz1 = new SqlConnection(cons1);
                            SqlCommand cmd1 = new SqlCommand();
                            cmd1.CommandText = myquery1;
                            cmd1.Connection = cnz1;
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                            da1.SelectCommand = cmd1;

                            da1.Fill(dt1);
                            cnz1.Close();

                            var result1 = dt1.AsEnumerable()
                                    .Sum(y => Convert.ToInt32(y["BankCharge"]));
                            //  Lab1.Text = result1.ToString();
                            Double Youtube1 = Double.Parse(result1.ToString());


                            //---------------------------Deposite profit-------------------------------------------------
                            DataTable dt2 = new DataTable();
                            string cons2 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            String myquery2 = "select * from [dbo].[Deposite]";
                            SqlConnection cnz2 = new SqlConnection(cons2);
                            SqlCommand cmd2 = new SqlCommand();
                            cmd2.CommandText = myquery2;
                            cmd2.Connection = cnz2;
                            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                            da2.SelectCommand = cmd2;

                            da2.Fill(dt2);
                            cnz2.Close();

                            var result2 = dt2.AsEnumerable()
                                    .Sum(z => Convert.ToInt32(z["SMSCharge"]));
                            // Lab1.Text = result2.ToString();
                            Double Youtube2 = Double.Parse(result2.ToString());

                            Double Total = ((Youtube) + (Youtube1) + (Youtube2));
                            // Lab1.Text = Total.ToString();

                            var styr = new TransactProfit
                            {
                                MonthProfit = Total.ToString(),
                                Date = DateTime.Now.ToString("MM/yyyy"),
                                Month = DateTime.Now.ToString("MM"),
                                Year = DateTime.Now.ToString("yyyy"),


                            };
                            dbY.TransactProfits.InsertOnSubmit(styr);
                            //----------------------------update ZealTable---------------------------------
                            var stuni = (from s in dbY.ZealTables where s.DateId == "3" select s).First();
                            stuni.Endate = DateTime.Now.ToString("0/MM/yyyy");

                            dbY.SubmitChanges();


                            //-----------------------------------------------------------------------------
                            if (DateTime.Now.ToString("dd/MM/yyyy") == DateTime.Now.ToString("29/MM/yyyy"))
                            {
                                //----------------------------update ZealTable---------------------------------
                                var suni = (from s in dbY.ZealTables where s.DateId == "3" select s).First();
                                suni.Endate = DateTime.Now.ToString("30/MM/yyyy");
                                dbY.SubmitChanges();
                            }


                        }

                    }

                    conns.Close();
                }
            }
            //------------------------------------END SMS-------------------------
            //Label1.Text = DateTime.Now.ToString("yyyy");
            //---------------------------------read to highest value--------------------
            string consK = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection cnzK = new SqlConnection(consK);

            SqlCommand cmdzsK = new SqlCommand("SELECT MAX (id) FROM Birthday ", cnzK);
            cmdzsK.CommandType = CommandType.Text;
            cmdzsK.Connection.Open();
            SqlDataReader drK = cmdzsK.ExecuteReader();
            if (drK.HasRows)
            {
                while (drK.Read())
                {

                    string Lab = drK[0].ToString();
                    // Lab1.Text = dr[0].ToString();

                    //--------------------------END------------------------------------------------------------
                    int i = 1;
                    while (i <= int.Parse(Lab))
                    {
                        string constringsK = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        using (SqlConnection connsK = new SqlConnection(constringsK))
                        {
                            using (SqlCommand cmdtsK = new SqlCommand("SELECT id,StaffName,Date1,PhoneNo,Number FROM Birthday WHERE id = '" + i + "'"))
                            {
                                cmdtsK.CommandType = CommandType.Text;
                                cmdtsK.Connection = connsK;
                                connsK.Open();

                                using (SqlDataReader sdrrK = cmdtsK.ExecuteReader())
                                {
                                    sdrrK.Read();

                                    string bDay = sdrrK["Date1"].ToString();
                                    string bStaff = sdrrK["StaffName"].ToString();
                                    string bPhone = sdrrK["PhoneNo"].ToString();
                                    string bNumber = sdrrK["Number"].ToString();

                                    if (DateTime.Now.ToString("MM-dd") == bDay)
                                    {

                                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Birthday Alert Enjoy');", true)

                                        // ScriptManager.RegisterStartupScript(new Page(), GetType(), "ServerControlScript", script, true);
                                        String alartMsg = "Today" + " " + DateTime.Now.ToString("yyyy") + "-" + bDay + " " + "The entire Zealluck staff is Congratulating!" + " " + bStaff + " " + "HAPPY BIRTHDAY and more year and blessing.";
                                        String script = "alert('" + alartMsg + "');";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);


                                    }

                                }

                                connsK.Close();
                            }
                        }
                        i++;
                    }
                }
            }

           
            //------------------------------------------Yearly Profit---------------------------------------------
            if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-28"))
            {
                //--------------------------------------------------------------------------------
                DataTable dt = new DataTable();
                string cons = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // String myquery = "select * from [dbo].[Withdraw]";
                string myquery = "SELECT id, MonthProfit, Date, Year, Month FROM [dbo].[TransactProfit] WHERE Month = '" + DateTime.Now.ToString("MM") + "' AND Year = '" + DateTime.Now.ToString("yyyy") + "' ";

                SqlConnection cnz = new SqlConnection(cons);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = myquery;
                cmd.Connection = cnz;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;

                da.Fill(dt);
                cnz.Close();

                var result1 = dt.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["MonthProfit"]));
                //Lab4.Text = result1.ToString() + "  " + "Profit  For " + txtdate.Text;
                // Double Youtube = Double.Parse(result.ToString());

                //--------------------------------------------------------------------------------
                DataTable dtW = new DataTable();
                string consW = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // String myquery = "select * from [dbo].[Withdraw]";
                string myqueryW = "SELECT id, Month, Profit, AccountNo, Year FROM [dbo].[SMSAlertProfit] WHERE Month = '" + DateTime.Now.ToString("MM") + "' AND Year = '" + DateTime.Now.ToString("yyyy") + "'";

                SqlConnection cnzW = new SqlConnection(consW);
                SqlCommand cmdW = new SqlCommand();
                cmdW.CommandText = myqueryW;
                cmdW.Connection = cnzW;
                SqlDataAdapter daW = new SqlDataAdapter(cmdW);
                daW.SelectCommand = cmdW;

                daW.Fill(dtW);
                cnzW.Close();

                var result2 = dtW.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["Profit"]));
                // Lab4.Text = result2.ToString() + "  " + "Profit  For " + " " + TextBox1.Text + " : " + "MONTH Of " + " " + DropDownList2.Text;
                // Double Youtube = Double.Parse(result.ToString());

                //--------------------------------------------------------------------------------
                DataTable dtA = new DataTable();
                string consA = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // String myquery = "select * from [dbo].[Withdraw]";
                string myqueryA = "SELECT id, Month, Profit, AccountNo, Year FROM [dbo].[InitailDeposite] WHERE Month = '" + DateTime.Now.ToString("MM") + "' AND Year = '" + DateTime.Now.ToString("MM") + "'";

                SqlConnection cnzA = new SqlConnection(consA);
                SqlCommand cmdA = new SqlCommand();
                cmdA.CommandText = myqueryA;
                cmdA.Connection = cnzA;
                SqlDataAdapter daA = new SqlDataAdapter(cmdA);
                daA.SelectCommand = cmdA;

                daA.Fill(dtA);
                cnzA.Close();

                var result3 = dtA.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["Profit"]));

                //-----------------------------------------------------------

                DataTable dtn = new DataTable();
                string consn = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // String myquery = "select * from [dbo].[Withdraw]";
                string myqueryn = "SELECT id, MonthProfit, Date  FROM [dbo].[TransactProfit2] where Date = '" + DateTime.Now.ToString("MM/yyyy") + "'";

                SqlConnection cnzn = new SqlConnection(cons);
                SqlCommand cmdn = new SqlCommand();
                cmdn.CommandText = myqueryn;
                cmdn.Connection = cnzn;
                SqlDataAdapter dan = new SqlDataAdapter(cmdn);
                dan.SelectCommand = cmdn;

                dan.Fill(dtn);
                cnzn.Close();

                var result011 = dt.AsEnumerable()
                       .Sum(x => Convert.ToInt32(x["MonthProfit"]));
             //   Lab4.Text = result011.ToString("#,##0.00") + "NGN" + "  " + "Profit  For " + txtdate.Text;

               

                string connetionString1;
                SqlConnection cnn1;
                SqlCommand comand1;
                //String path;


                connetionString1 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                cnn1 = new SqlConnection(connetionString1);
                cnn1.Open();
                string sql1 = "Select * from YearlyProfit where Date='" + DateTime.Now.ToString("MM/yyyy") + "' ";
                comand1 = new SqlCommand(sql1, cnn1);
                SqlDataAdapter da12 = new SqlDataAdapter(comand1);
                DataTable dt12 = new DataTable();
                da12.Fill(dt12);
                if (dt12.Rows.Count > 0)
                {
                    int FianalPr = result1 + result2 + result3 + result011;

                    var sty1 = (from s in db.YearlyProfits where s.Date == DateTime.Now.ToString("MM/yyyy") select s).First();
                    sty1.YearGain = FianalPr.ToString();
                    db.SubmitChanges();
                }
                else
                {
                    int FianalPr = result1 + result2 + result3 + result011;

                    var styr = new YearlyProfit
                    {

                        YearGain = FianalPr.ToString(),
                        Date = DateTime.Now.ToString("MM/yyyy"),
                        Month = DateTime.Now.ToString("MM"),
                        Year = DateTime.Now.ToString("yyyy"),
                        AccountNo = "042Abakaliki",

                    };
                    db.YearlyProfits.InsertOnSubmit(styr);
                    db.SubmitChanges();

                }

            }
            else if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-30"))
            {
                //--------------------------------------------------------------------------------
                //--------------------------------------------------------------------------------
                DataTable dt = new DataTable();
                string cons = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // String myquery = "select * from [dbo].[Withdraw]";
                string myquery = "SELECT id, MonthProfit, Date, Year, Month FROM [dbo].[TransactProfit] WHERE Month = '" + DateTime.Now.ToString("MM") + "' AND Year = '" + DateTime.Now.ToString("yyyy") + "' ";

                SqlConnection cnz = new SqlConnection(cons);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = myquery;
                cmd.Connection = cnz;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;

                da.Fill(dt);
                cnz.Close();

                var result1 = dt.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["MonthProfit"]));
                //Lab4.Text = result1.ToString() + "  " + "Profit  For " + txtdate.Text;
                // Double Youtube = Double.Parse(result.ToString());

                //--------------------------------------------------------------------------------
                DataTable dtW = new DataTable();
                string consW = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // String myquery = "select * from [dbo].[Withdraw]";
                string myqueryW = "SELECT id, Month, Profit, AccountNo, Year FROM [dbo].[SMSAlertProfit] WHERE Month = '" + DateTime.Now.ToString("MM") + "' AND Year = '" + DateTime.Now.ToString("yyyy") + "'";

                SqlConnection cnzW = new SqlConnection(consW);
                SqlCommand cmdW = new SqlCommand();
                cmdW.CommandText = myqueryW;
                cmdW.Connection = cnzW;
                SqlDataAdapter daW = new SqlDataAdapter(cmdW);
                daW.SelectCommand = cmdW;

                daW.Fill(dtW);
                cnzW.Close();

                var result2 = dtW.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["Profit"]));
                // Lab4.Text = result2.ToString() + "  " + "Profit  For " + " " + TextBox1.Text + " : " + "MONTH Of " + " " + DropDownList2.Text;
                // Double Youtube = Double.Parse(result.ToString());

                //--------------------------------------------------------------------------------
                DataTable dtA = new DataTable();
                string consA = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // String myquery = "select * from [dbo].[Withdraw]";
                string myqueryA = "SELECT id, Month, Profit, AccountNo, Year FROM [dbo].[InitailDeposite] WHERE Month = '" + DateTime.Now.ToString("MM") + "' AND Year = '" + DateTime.Now.ToString("MM") + "'";

                SqlConnection cnzA = new SqlConnection(consA);
                SqlCommand cmdA = new SqlCommand();
                cmdA.CommandText = myqueryA;
                cmdA.Connection = cnzA;
                SqlDataAdapter daA = new SqlDataAdapter(cmdA);
                daA.SelectCommand = cmdA;

                daA.Fill(dtA);
                cnzA.Close();

                var result3 = dtA.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["Profit"]));

                //-----------------------------------------------------------

                DataTable dtn = new DataTable();
                string consn = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // String myquery = "select * from [dbo].[Withdraw]";
                string myqueryn = "SELECT id, MonthProfit, Date  FROM [dbo].[TransactProfit2] where Date = '" + DateTime.Now.ToString("MM/yyyy") + "'";

                SqlConnection cnzn = new SqlConnection(cons);
                SqlCommand cmdn = new SqlCommand();
                cmdn.CommandText = myqueryn;
                cmdn.Connection = cnzn;
                SqlDataAdapter dan = new SqlDataAdapter(cmdn);
                dan.SelectCommand = cmdn;

                dan.Fill(dtn);
                cnzn.Close();

                var result011 = dt.AsEnumerable()
                       .Sum(x => Convert.ToInt32(x["MonthProfit"]));
                //   Lab4.Text = result011.ToString("#,##0.00") + "NGN" + "  " + "Profit  For " + txtdate.Text;



                string connetionString1;
                SqlConnection cnn1;
                SqlCommand comand1;
                //String path;


                connetionString1 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                cnn1 = new SqlConnection(connetionString1);
                cnn1.Open();
                string sql1 = "Select * from YearlyProfit where Date='" + DateTime.Now.ToString("MM/yyyy") + "' ";
                comand1 = new SqlCommand(sql1, cnn1);
                SqlDataAdapter da12 = new SqlDataAdapter(comand1);
                DataTable dt12 = new DataTable();
                da12.Fill(dt12);
                if (dt12.Rows.Count > 0)
                {
                    int FianalPr = result1 + result2 + result3 + result011;

                    var sty1 = (from s in db.YearlyProfits where s.Date == DateTime.Now.ToString("MM/yyyy") select s).First();
                    sty1.YearGain = FianalPr.ToString();
                    db.SubmitChanges();
                }
                else
                {
                    int FianalPr = result1 + result2 + result3 + result011;

                    var styr = new YearlyProfit
                    {

                        YearGain = FianalPr.ToString(),
                        Date = DateTime.Now.ToString("MM/yyyy"),
                        Month = DateTime.Now.ToString("MM"),
                        Year = DateTime.Now.ToString("yyyy"),
                        AccountNo = "042Abakaliki",

                    };
                    db.YearlyProfits.InsertOnSubmit(styr);
                    db.SubmitChanges();

                }
            }
            else if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-31"))
            {
                //--------------------------------------------------------------------------------
                //--------------------------------------------------------------------------------
                DataTable dt = new DataTable();
                string cons = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // String myquery = "select * from [dbo].[Withdraw]";
                string myquery = "SELECT id, MonthProfit, Date, Year, Month FROM [dbo].[TransactProfit] WHERE Month = '" + DateTime.Now.ToString("MM") + "' AND Year = '" + DateTime.Now.ToString("yyyy") + "' ";

                SqlConnection cnz = new SqlConnection(cons);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = myquery;
                cmd.Connection = cnz;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;

                da.Fill(dt);
                cnz.Close();

                var result1 = dt.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["MonthProfit"]));
                //Lab4.Text = result1.ToString() + "  " + "Profit  For " + txtdate.Text;
                // Double Youtube = Double.Parse(result.ToString());

                //--------------------------------------------------------------------------------
                DataTable dtW = new DataTable();
                string consW = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // String myquery = "select * from [dbo].[Withdraw]";
                string myqueryW = "SELECT id, Month, Profit, AccountNo, Year FROM [dbo].[SMSAlertProfit] WHERE Month = '" + DateTime.Now.ToString("MM") + "' AND Year = '" + DateTime.Now.ToString("yyyy") + "'";

                SqlConnection cnzW = new SqlConnection(consW);
                SqlCommand cmdW = new SqlCommand();
                cmdW.CommandText = myqueryW;
                cmdW.Connection = cnzW;
                SqlDataAdapter daW = new SqlDataAdapter(cmdW);
                daW.SelectCommand = cmdW;

                daW.Fill(dtW);
                cnzW.Close();

                var result2 = dtW.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["Profit"]));
                // Lab4.Text = result2.ToString() + "  " + "Profit  For " + " " + TextBox1.Text + " : " + "MONTH Of " + " " + DropDownList2.Text;
                // Double Youtube = Double.Parse(result.ToString());

                //--------------------------------------------------------------------------------
                DataTable dtA = new DataTable();
                string consA = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // String myquery = "select * from [dbo].[Withdraw]";
                string myqueryA = "SELECT id, Month, Profit, AccountNo, Year FROM [dbo].[InitailDeposite] WHERE Month = '" + DateTime.Now.ToString("MM") + "' AND Year = '" + DateTime.Now.ToString("MM") + "'";

                SqlConnection cnzA = new SqlConnection(consA);
                SqlCommand cmdA = new SqlCommand();
                cmdA.CommandText = myqueryA;
                cmdA.Connection = cnzA;
                SqlDataAdapter daA = new SqlDataAdapter(cmdA);
                daA.SelectCommand = cmdA;

                daA.Fill(dtA);
                cnzA.Close();

                var result3 = dtA.AsEnumerable()
                        .Sum(x => Convert.ToInt32(x["Profit"]));

                //-----------------------------------------------------------

                DataTable dtn = new DataTable();
                string consn = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                // String myquery = "select * from [dbo].[Withdraw]";
                string myqueryn = "SELECT id, MonthProfit, Date  FROM [dbo].[TransactProfit2] where Date = '" + DateTime.Now.ToString("MM/yyyy") + "'";

                SqlConnection cnzn = new SqlConnection(cons);
                SqlCommand cmdn = new SqlCommand();
                cmdn.CommandText = myqueryn;
                cmdn.Connection = cnzn;
                SqlDataAdapter dan = new SqlDataAdapter(cmdn);
                dan.SelectCommand = cmdn;

                dan.Fill(dtn);
                cnzn.Close();

                var result011 = dt.AsEnumerable()
                       .Sum(x => Convert.ToInt32(x["MonthProfit"]));
                //   Lab4.Text = result011.ToString("#,##0.00") + "NGN" + "  " + "Profit  For " + txtdate.Text;



                string connetionString1;
                SqlConnection cnn1;
                SqlCommand comand1;
                //String path;


                connetionString1 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                cnn1 = new SqlConnection(connetionString1);
                cnn1.Open();
                string sql1 = "Select * from YearlyProfit where Date='" + DateTime.Now.ToString("MM/yyyy") + "' ";
                comand1 = new SqlCommand(sql1, cnn1);
                SqlDataAdapter da12 = new SqlDataAdapter(comand1);
                DataTable dt12 = new DataTable();
                da12.Fill(dt12);
                if (dt12.Rows.Count > 0)
                {
                    int FianalPr = result1 + result2 + result3 + result011;

                    var sty1 = (from s in db.YearlyProfits where s.Date == DateTime.Now.ToString("MM/yyyy") select s).First();
                    sty1.YearGain = FianalPr.ToString();
                    db.SubmitChanges();
                }
                else
                {
                    int FianalPr = result1 + result2 + result3 + result011;

                    var styr = new YearlyProfit
                    {

                        YearGain = FianalPr.ToString(),
                        Date = DateTime.Now.ToString("MM/yyyy"),
                        Month = DateTime.Now.ToString("MM"),
                        Year = DateTime.Now.ToString("yyyy"),
                        AccountNo = "042Abakaliki",

                    };
                    db.YearlyProfits.InsertOnSubmit(styr);
                    db.SubmitChanges();

                }
            }

        }
        public void ShowMessageBox(string bStaff)
        {
            string script = "alert('" + bStaff + "');";
            ScriptManager.RegisterStartupScript(new Page(), GetType(), "ServerControlScript", script, true);
        }


    }
}