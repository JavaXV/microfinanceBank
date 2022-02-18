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

namespace BankA
{
    public partial class CustomerDashboard2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // LoadData();

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
           
        }
        // call the linq
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlConnection conwsBA = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conwsBA.Open();
            SqlCommand cmdwsBA = new SqlCommand("Select * from NewCustomer where accountno='" + txtaccountno.Text + "'", conwsBA);
            SqlDataAdapter dawsBA = new SqlDataAdapter(cmdwsBA);
            DataTable dtwsBA = new DataTable();
            dawsBA.Fill(dtwsBA);
            if (dtwsBA.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Account ALready Exist');", true);
            }
            else if (txtwork.Text == "" || txtbr.Text == "" || txtofficer.Text == "" || txtcustomerid.Text == "" || txtgende.Text == "" || txtnationality.Text == "" || txtdate.Text == "" || txtstat.Text == "" || txtbirth.Text == "" || txtname.Text == "" || txtaccountno.Text == "" || txtphoneno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('All field are required');", true);
            }
            else
            {
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

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
                                if (Dater == txtdate.Text)
                                {


                                    //----------------------------------insert to Table------------------------------------
                                    string connetionString;
                                    SqlConnection cnn;
                                    string path;

                                    connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";

                                    cnn = new SqlConnection(connetionString);
                                    cnn.Open();

                                   // FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/imagery/" + FileUpload1.FileName.ToString());
                                    // path = "imagery/" + FileUpload1.FileName.ToString();


                                    SqlCommand command;
                                    SqlDataAdapter adapter = new SqlDataAdapter();
                                    String sql = "";
                                    int Value = 2;

                                    sql = "Insert into NewCustomer(occupation,branch,fieldofficer,customerid,gender,nationality,date,selfemploy,dateofbirth,customername,address,phoneno,status,state,email,accountno,SmsId)values('" + txtwork.Text + "','" + txtbr.Text + "','" + txtofficer.Text + "','" + txtcustomerid.Text + "','" + txtgende.Text + "','" + txtnationality.Text + "','" + txtdate.Text + "','" + txtlga1.Text + "','" + txtbirth.Text + "','" + txtname.Text + "','" + txtaddress.Text + "','" + txtphoneno.Text + "','" + txtstatu.Text + "','" + txtstat.Text + "','" + txtemail.Text + "','" + txtaccountno.Text + "','" + Value + "')";


                                    command = new SqlCommand(sql, cnn);
                                    adapter.InsertCommand = new SqlCommand(sql, cnn);
                                    adapter.InsertCommand.ExecuteNonQuery();

                                    command.Dispose();
                                    cnn.Close();
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Account Success fully Created');", true);

                                    //----------------------New ACCOUNT CRAETION SMS----------------------------------------------
                                   
                                    //---------------------------------------------
                                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://app.multitexter.com/v2/app/sms");
                                    httpWebRequest.ContentType = "application/json";
                                    httpWebRequest.Method = "POST";
                                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
                                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                                    string msg;
                                    //---------------------------------------------
                                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                    {
                                        string email = "Zealluckres@gmail.com";
                                        string password = "Zealluck@123";
                                        string sender_name = "ZEALLUCK";
                                        string recipients = txtphoneno.Text;
                                        string forcednd = "1";
                                        msg = "Dear" + " " + txtname.Text + " " + " Your New account has been created  |  AccountNo:" + txtaccountno.Text + " Date:" +" " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " |FDBCK?CALL 018983973";
                                  
                                        string json = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"message\":\"" + msg + "\",\"sender_name\":\"" + sender_name + "\",\"recipients\":\"" + recipients + "\",\"forcednd\":\"" + forcednd + "\"}";
                                        streamWriter.Write(json);
                                        streamWriter.Flush();
                                        streamWriter.Close();
                                    }
                                    //--------------------------------------------------------------------------
                                   
                                    System.Net.WebRequest request;
                                   // msg = "Dear" + txtname.Text + " Your New account has been created  | AccountNo:" + txtaccountno.Text + " Date:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " |FDBCK?CALL 018983973";
                                    // msg = "Welcome To Zealluck Bank! Your AccountNo is:" + txtaccountno.Text + " Date:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " FDBCK?CALL 018983973";
                                   // String reqUrl = "http://justsms.com.ng/index.php?option=com_spc&comm=spc_api&username=zealluck&password=zealluck@biz.&sender=ZEALLUCK&recipient=" + txtphoneno.Text + "&message=" + msg + "&";


                                    //request = System.Net.WebRequest.Create(reqUrl);
                                    if (txtphoneno.Text != "")
                                    {
                                        // request.GetResponse();
                                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                        {
                                            var result = streamReader.ReadToEnd();
                                            Console.WriteLine(result);
                                        }

                                        //-----------------------insert-----------------------------

                                        var styr = new SMSAlertProfit
                                        {
                                            Month = (DateTime.Now.ToString("MM")),
                                            AccountNo = txtaccountno.Text,
                                            Profit = "5",
                                            Year = DateTime.Now.ToString("yyyy"),
                                            

                                        };
                                        db.SMSAlertProfits.InsertOnSubmit(styr);
                                        db.SubmitChanges();

                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('SMS For Account Creation Send');", true);


                                        var styrW = new NewCustomerSM
                                        {
                                            Month = (DateTime.Now.ToString("MM")),
                                            AccountNo = txtaccountno.Text,
                                            Profit = "5",
                                            Year = DateTime.Now.ToString("yyyy"),
                                            PageNo = "0",

                                        };
                                        db.NewCustomerSMs.InsertOnSubmit(styrW);
                                        db.SubmitChanges();

                                    }
                                    else
                                    { }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Batch is Close!/ Select Your Branch');", true);
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
            var styU = (from s in db.NewCustomers where s.accountno == txtaccountno.Text select s);
            GridView1.DataSource = styU;
            GridView1.DataBind();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from NewCustomer where customerid='" + txtcustomerid.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                //--------------update------------------------------------------------------------------------
                var sty = (from s in db.NewCustomers where s.customerid == txtcustomerid.Text select s).First();

                sty.occupation = txtwork.Text;
                sty.branch = txtbr.Text;
                sty.fieldofficer = txtofficer.SelectedItem.Text;
                sty.customerid = txtcustomerid.Text;
                sty.gender = txtgende.SelectedItem.Text;
                sty.nationality = txtnationality.Text;
                sty.date = txtdate.Text;
                sty.selfemploy = txtlga1.Text;
                sty.dateofbirth = txtbirth.Text;
                sty.customername = txtname.Text;

                sty.address = txtaddress.Text;
                sty.phoneno = txtphoneno.Text;
                sty.status = txtstatu.Text;
                sty.state = txtstat.Text;
                sty.email = txtemail.Text;
                sty.accountno = txtaccountno.Text;
                // sty.propic = Double.Parse(txtbalance.Text);

                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
              //  LoadData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Customer ID is required to Search for Updated');", true);
            }
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from NewCustomer where customerid='" + txtcustomerid.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                var sty = (from s in db.NewCustomers where s.customerid == txtcustomerid.Text select s).First();
                db.NewCustomers.DeleteOnSubmit(sty);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Customer Account Deleted');", true);
              //  LoadData();

            }
            else
            {

                // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Customer ID is required for Deleting');", true);

            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from NewCustomer where accountno='" + txtaccountno.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT id, occupation, branch, fieldofficer, customerid, gender, nationality, date, selfemploy, dateofbirth, customername, address, phoneno, status, state, email, accountno, propic FROM NewCustomer WHERE accountno = '" + txtaccountno.Text + "'", con);
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = con;
                        con.Open();

                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.ExecuteNonQuery();
                        DataTable dt1 = new DataTable();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        da1.Fill(dt1);
                       // DataList3.DataSource = dt1;
                       // DataList3.DataBind();

                        con.Close();

                        con.Open();

                        using (SqlDataReader sdr1 = cmd.ExecuteReader())
                        {
                            sdr1.Read();

                            txtwork.Text = sdr1["occupation"].ToString();
                            txtbr.SelectedItem.Text = sdr1["branch"].ToString();
                            txtofficer.SelectedItem.Text = sdr1["fieldofficer"].ToString();
                            txtcustomerid.Text = sdr1["customerid"].ToString();
                            txtgende.SelectedItem.Text = sdr1["gender"].ToString();
                            txtnationality.Text = sdr1["nationality"].ToString();
                            txtdate.Text = sdr1["date"].ToString();
                            txtlga1.Text = sdr1["selfemploy"].ToString();
                            txtbirth.Text = sdr1["dateofbirth"].ToString();
                            txtname.Text = sdr1["customername"].ToString();

                            txtaddress.Text = sdr1["address"].ToString();
                            txtphoneno.Text = sdr1["phoneno"].ToString();
                            txtstatu.SelectedItem.Text = sdr1["status"].ToString();

                            txtstat.Text = sdr1["state"].ToString();
                            txtemail.Text = sdr1["email"].ToString();
                            txtaccountno.Text = sdr1["accountno"].ToString();
                        }


                       // txtofficer.DataSource = cmd.ExecuteReader();
                       // txtofficer.DataTextField = "fieldofficer";
                       // txtofficer.DataValueField = "id";
                       // txtofficer.DataBind();


                        con.Close();
                    }
                }
            }
            else
            {
                // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('AccountNo is required for Searching');", true);
            }
            //---------------------------------------------------------------------------------------------------------------

            string connetionStringd;
            SqlConnection cnnd;
            SqlCommand comandd;
            //String path;


            connetionStringd = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnnd = new SqlConnection(connetionStringd);
            cnnd.Open();
            string sqld = "Select * from Signature where AccountNo='" + txtaccountno.Text + "'";
            comandd = new SqlCommand(sqld, cnnd);
            SqlDataAdapter dad = new SqlDataAdapter(comandd);
            DataTable dtd = new DataTable();
            dad.Fill(dtd);
            if (dtd.Rows.Count > 0)
            {
                string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("Select * from Signature where AccountNo = '" + txtaccountno.Text + "'", con);
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = con;
                        con.Open();

                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.ExecuteNonQuery();

                        //-----------------------------------------------------------------------------------------
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);

                        //---------------------------------------------------------------------------------------


                        DataList2.DataSource = dt1;
                        DataList2.DataBind();

                        con.Close();

                        con.Open();

                        using (SqlDataReader sdr1 = cmd.ExecuteReader())
                        {
                            sdr1.Read();

                            txtaccountno.Text = sdr1["AccountNo"].ToString();
                        }

                        con.Close();
                    }
                }
            }
            else
            {
                // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('AccountNo is required for Searching');", true);
            }

            //---------------------------------------------------------------------------------------------------------------

            string connetionStringdW;
            SqlConnection cnndW;
            SqlCommand comanddW;
            //String path;


            connetionStringdW = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnndW = new SqlConnection(connetionStringdW);
            cnndW.Open();
            string sqldW = "Select * from UploadPic where AccountNo='" + txtaccountno.Text + "'";
            comanddW = new SqlCommand(sqldW, cnndW);
            SqlDataAdapter dadW = new SqlDataAdapter(comanddW);
            DataTable dtdW = new DataTable();
            dadW.Fill(dtdW);
            if (dtdW.Rows.Count > 0)
            {
                string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("Select * from UploadPic where AccountNo = '" + txtaccountno.Text + "'", con);
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = con;
                        con.Open();

                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.ExecuteNonQuery();

                        //-----------------------------------------------------------------------------------------
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);

                        //---------------------------------------------------------------------------------------


                        DataList3.DataSource = dt1;
                        DataList3.DataBind();

                        con.Close();

                        con.Open();

                        using (SqlDataReader sdr1 = cmd.ExecuteReader())
                        {
                            sdr1.Read();

                            txtaccountno.Text = sdr1["AccountNo"].ToString();
                        }

                        con.Close();
                    }
                }
            }
            else
            {
                // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('AccountNo is required for Searching');", true);
            }
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Random random1 = new Random();
            txtaccountno.Text = (Convert.ToString(random1.Next(100000, 200000)));
            txtcustomerid.Text = (Convert.ToString(random1.Next(1000, 2000)));


        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            Session.Remove("USER_ID");
            Session.RemoveAll();
            Response.Redirect("NewCustomerLogin.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            if (txtaccountno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('All field are required');", true);

            }
            else
            {
                //----------------------------------insert to Table------------------------------------
                string connetionString;
                SqlConnection cnn;
                string path;

                connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";

                cnn = new SqlConnection(connetionString);
                cnn.Open();

                FileUpload2.SaveAs(Request.PhysicalApplicationPath + "/imagery/" + FileUpload2.FileName.ToString());
                path = "imagery/" + FileUpload2.FileName.ToString();


                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";
                int Value = 2;

                //  sql = "Insert into NewCustomer(occupation,branch,fieldofficer,customerid,gender,nationality,date,selfemploy,dateofbirth,customername,address,phoneno,status,state,email,accountno,SmsId,propic)values('" + txtwork.Text + "','" + txtbr.Text + "','" + txtofficer.Text + "','" + txtcustomerid.Text + "','" + txtgende.Text + "','" + txtnationality.Text + "','" + txtdate.Text + "','" + txtemploy.Text + "','" + txtbirth.Text + "','" + txtname.Text + "','" + txtaddress.Text + "','" + txtphoneno.Text + "','" + txtstatu.Text + "','" + txtstate.Text + "','" + txtemail.Text + "','" + txtaccountno.Text + "','" + Value + "', '" + path.ToString() + "')";
                sql = "Insert into Signature(AccountNo,Propic)values('" + txtaccountno.Text + "', '" + path.ToString() + "')";

                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                cnn.Close();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Account Success fully Created');", true);

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        
            SqlConnection conwsB = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conwsB.Open();
            SqlCommand cmdwsB = new SqlCommand("Select * from State where State='" + txtstat.Text + "'", conwsB);
            SqlDataAdapter dawsB = new SqlDataAdapter(cmdwsB);
            DataTable dtwsB = new DataTable();
            dawsB.Fill(dtwsB);
            if (dtwsB.Rows.Count > 0)
            {

                string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                SqlConnection sqlconn = new SqlConnection(constr);
                string sqlquery = "SELECT id, Lga FROM [dbo].[State] where State = '" + txtstat.Text + "'  ORDER BY Lga ASC ";
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
            else
            { }
       
        }

        protected void Button5_Click1(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from Signature where AccountNo='" + txtaccountno.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                var sty = (from s in db.Signatures where s.AccountNo == txtaccountno.Text select s).First();
                db.Signatures.DeleteOnSubmit(sty);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Signature Deleted');", true);
                //   LoadData();
            }
            else
            { }
        }

      
        protected void Button6_Click(object sender, EventArgs e)
        {

            if (txtaccountno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('All field are required');", true);

            }
            else
            {
                //----------------------------------insert to Table------------------------------------
                string connetionString;
                SqlConnection cnn;
                string path;

                connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";

                cnn = new SqlConnection(connetionString);
                cnn.Open();

                FileUpload3.SaveAs(Request.PhysicalApplicationPath + "/imagery/" + FileUpload3.FileName.ToString());
                path = "imagery/" + FileUpload3.FileName.ToString();


                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";
                int Value = 2;

                //  sql = "Insert into NewCustomer(occupation,branch,fieldofficer,customerid,gender,nationality,date,selfemploy,dateofbirth,customername,address,phoneno,status,state,email,accountno,SmsId,propic)values('" + txtwork.Text + "','" + txtbr.Text + "','" + txtofficer.Text + "','" + txtcustomerid.Text + "','" + txtgende.Text + "','" + txtnationality.Text + "','" + txtdate.Text + "','" + txtemploy.Text + "','" + txtbirth.Text + "','" + txtname.Text + "','" + txtaddress.Text + "','" + txtphoneno.Text + "','" + txtstatu.Text + "','" + txtstate.Text + "','" + txtemail.Text + "','" + txtaccountno.Text + "','" + Value + "', '" + path.ToString() + "')";
                sql = "Insert into UploadPic(AccountNo,Propic)values('" + txtaccountno.Text + "', '" + path.ToString() + "')";

                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                cnn.Close();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Account Success fully Created');", true);

            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from UploadPic where AccountNo='" + txtaccountno.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                var sty = (from s in db.UploadPics where s.AccountNo == txtaccountno.Text select s).First();
                db.UploadPics.DeleteOnSubmit(sty);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Image Deleted');", true);
                //   LoadData();
            }
            else
            { }
        }

        protected void Button9_Click1(object sender, EventArgs e)
        {
            String path = "Admin";
            SqlConnection conwsB = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conwsB.Open();
            SqlCommand cmdwsB = new SqlCommand("Select * from State where id ='" + txtid.Text + "'", conwsB);
            SqlDataAdapter dawsB = new SqlDataAdapter(cmdwsB);
            DataTable dtwsB = new DataTable();
            dawsB.Fill(dtwsB);
            if (dtwsB.Rows.Count > 0)
            {
                    
                //-------------------------------------bank charge--------------------------------------------
                string constringsY = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection connsY = new SqlConnection(constringsY))
                {
                    using (SqlCommand cmdtsY = new SqlCommand("SELECT id, Lga, State FROM State WHERE id='" + txtid.Text + "'"))
                    {
                        cmdtsY.CommandType = CommandType.Text;
                        cmdtsY.Connection = connsY;
                        connsY.Open();

                        using (SqlDataReader sdrr = cmdtsY.ExecuteReader())
                        {
                            sdrr.Read();
                         
                            String Depo = sdrr["Lga"].ToString();
                            txtlga1.Text = Depo.ToString();
                           
                            
                                              
                        }

                        connsY.Close();
                    }
                }
                
            }
            else
            { }

        }

      
    }
}