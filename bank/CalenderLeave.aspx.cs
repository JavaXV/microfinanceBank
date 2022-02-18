using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BankA
{
    public partial class CalenderLeave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["USER_ID"] != null)
            {
                Label1.Text = Session["USER_ID"].ToString();
            }
            else { Response.Redirect("HRLogin.aspx"); }
             
            txtyear.Text = DateTime.Now.ToString("MM/yyyy");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("USER_ID");
            Session.RemoveAll();
            Response.Redirect("HRLogin.aspx");
        }
        // call the linq
         DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button4_Click(object sender, EventArgs e)
        {
            string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            using (SqlConnection conns = new SqlConnection(constrings))
            {
                using (SqlCommand cmdts = new SqlCommand("SELECT id, date, No FROM block WHERE No = '" + 2 + "'"))
                {
                    cmdts.CommandType = CommandType.Text;
                    cmdts.Connection = conns;
                    conns.Open();

                    using (SqlDataReader sdrr = cmdts.ExecuteReader())
                    {
                        sdrr.Read();
                        string Dater = sdrr["date"].ToString();
                        if (Dater == DateTime.Now.ToString("yyyy-MM-dd"))
                        {

                            DataTable dtd = new DataTable();
                            string consd = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            string myqueryd = "SELECT id, NoOfLeave, StaffName, LeaveMonth FROM [dbo].[Leave] where StaffName = '" + txtstaff.Text + "'";
                            //string myqueryd = "SELECT * FROM Deposite ORDER BY Deposite DESC ";
                            SqlConnection cnzd = new SqlConnection(consd);
                            SqlCommand cmdd = new SqlCommand();
                            cmdd.CommandText = myqueryd;
                            cmdd.Connection = cnzd;
                            SqlDataAdapter dad = new SqlDataAdapter(cmdd);
                            dad.SelectCommand = cmdd;

                            dad.Fill(dtd);
                            GridView1.DataSource = dtd;
                            GridView1.DataBind();
                            cnzd.Close();

                            var result = dtd.AsEnumerable()
                                .Sum(x => Convert.ToInt32(x["NoOfLeave"]));
                            Lab2.Text = result.ToString();
                            //Lab3.Text = result.ToString();
                            int AtDt = int.Parse(result.ToString());


                            if (Session["USER_ID"] != null)
                            {
                                Label1.Text = Session["USER_ID"].ToString();
                                string DCase = Session["USER_ID"].ToString();
                                //-------------------------------------------------
                                if (txtbr.Text == DCase)
                                {
                                            SqlConnection conws = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                            conws.Open();
                                            SqlCommand cmdws = new SqlCommand("Select * from Staff where StaffName='" + txtstaff.Text + "'", conws);
                                            SqlDataAdapter daws = new SqlDataAdapter(cmdws);
                                            DataTable dtws = new DataTable();
                                            daws.Fill(dtws);
                                            if (dtws.Rows.Count > 0)
                                            {
                                                
                                                //-------------------------------------bank charge--------------------------------------------
                                                string constringsA = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                using (SqlConnection connsA = new SqlConnection(constringsA))
                                                {
                                                    using (SqlCommand cmdtsA = new SqlCommand("SELECT id, StaffName, StaffPosition FROM Staff WHERE StaffName = '" + txtstaff.Text + "'"))
                                                    {
                                                        cmdtsA.CommandType = CommandType.Text;
                                                        cmdtsA.Connection = connsA;
                                                        connsA.Open();

                                                        using (SqlDataReader sdrrA = cmdtsA.ExecuteReader())
                                                        {
                                                            sdrrA.Read();
                                                            string bals = sdrrA["StaffPosition"].ToString();
                                                        
                                                            //-----------------------------------------------------
                                                            
                                    if (AtDt == 14 && txtyear.Text == DateTime.Now.ToString("yyyy"))
                                    {

                                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('You Have Finish Your 14 days Leave For The Whole Year');", true);
                                        String alartMsg = txtstaff.Text + " " + "You Have Finish Your 14 days(Permanent) Leave For The Whole Year!";
                                        String script = "alert('" + alartMsg + "');";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                                    }
                                    else if(AtDt == 7 && bals == "Temporary")
                                    {  //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('You Have Finish Your 14 days Leave For The Whole Year');", true);
                                        String alartMsg = txtstaff.Text + " " + "You Have Finish Your 7 days(Temporary) Leave For The Whole Year!";
                                        String script = "alert('" + alartMsg + "');";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                                    }
                                    else
                                    {
                                        var styAW = new Leave
                                        {

                                            StaffName = txtstaff.Text,
                                            LeaveDate = txtdate.Text,
                                            LeaveRange = txtranges.Text,
                                            LeaveReason = txtreason.Text,
                                            LeaveResume = txtresume.Text,
                                            LeaveMonth = txtmonth.Text,
                                            ActiveStatus = txtactive.Text,
                                            NoOfLeave = txtranges.Text,
                                            Year = txtyear.Text,
                                            Branch = txtbr.Text,

                                        };
                                        db.Leaves.InsertOnSubmit(styAW);
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Staff Leave Successful');", true);
                                        db.SubmitChanges();
                                        //--------------------------------------------------------------------------------
                                        if (txtstaff.Text == "")
                                        { }
                                        else
                                        {
                                            var syt = (from s in db.Staffs where s.StaffName == txtstaff.Text select s).First();
                                            syt.ActiveStatus = txtstaff.Text + "  " + "Not-Active On Leave" + " " + txtranges.Text;
                                            db.SubmitChanges();
                                        }  
                                    }
                                    //-----------------------------14 DAYS-------------------------------------------------------
                              
                                    }
                                                            //-----------------------------------------------------
                                                      
                                                        }

                                                        connsA.Close();
                                                    }
                                                }
                                                
                                            }
                                            else
                                            {ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Pls!!! Select Your Branch');", true); }
                                            
                                }
                            
                        }
                        else { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Pls!!! Admin Need To Open Date');", true); }

                    }
                    conns.Close();
                }
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from Leave where StaffName='" + txtstaff.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    if (txtbr.Text == DCase)
                    {
                        var sty = (from s in db.Leaves where s.StaffName == txtstaff.Text select s).First();
                        db.Leaves.DeleteOnSubmit(sty);
                        db.SubmitChanges();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff Deleted');", true);
                        //  LoadData();
                    }
                    else { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Pls!!! Select Your Branch');", true); }

                }

            }
            else
            {

                // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('StaffName is required for Deleting');", true);

            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from Leave where StaffName='" + txtstaff.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT id, StaffName,LeaveDate,LeaveRange,LeaveReason,LeaveResume,LeaveMonth,ActiveStatus,Year,Branch FROM Leave WHERE StaffName = '" + txtstaff.Text + "'", con);
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = con;
                        con.Open();

                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.ExecuteNonQuery();
                        DataTable dt1 = new DataTable();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        da1.Fill(dt1);
                        // DataList1.DataSource = dt1;
                        // DataList1.DataBind();

                        con.Close();

                        con.Open();

                        using (SqlDataReader sdr1 = cmd.ExecuteReader())
                        {
                            sdr1.Read();

                            txtstaff.Text = sdr1["StaffName"].ToString();
                            txtdate.Text = sdr1["LeaveDate"].ToString();
                            txtranges.Text = sdr1["LeaveRange"].ToString();
                            txtreason.Text = sdr1["LeaveReason"].ToString();
                            txtresume.Text = sdr1["LeaveResume"].ToString();
                            txtmonth.Text = sdr1["LeaveMonth"].ToString();
                            txtactive.Text = sdr1["ActiveStatus"].ToString();
                            txtyear.Text = sdr1["Year"].ToString();
                            txtbr.Text = sdr1["Branch"].ToString();

                        }


                        con.Close();
                    }
                }
            }
            else
            {
                // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('StaffName is required for Searching');", true);
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from Leave where StaffName='" + txtstaff.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    if (txtbr.Text == DCase)
                    {

                        //--------------update------------------------------------------------------------------------
                        var sty = (from s in db.Leaves where s.StaffName == txtstaff.Text select s).First();


                        sty.StaffName = txtstaff.Text;
                        sty.LeaveDate = txtdate.Text;
                        sty.LeaveRange = txtranges.Text;
                        sty.LeaveReason = txtreason.Text;
                        sty.LeaveResume = txtresume.Text;
                        sty.LeaveMonth = txtmonth.Text;
                        sty.ActiveStatus = txtactive.Text;
                        sty.Year = txtyear.Text;

                        db.SubmitChanges();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);

                        //------------------------------Update Status----------------------------------------------
                        var styy = (from s in db.Staffs where s.StaffName == txtstaff.Text select s).First();
                        styy.ActiveStatus = txtactive.Text;
                        db.SubmitChanges();
                    }
                    else { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Pls!!! Select Your Branch');", true); }

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('StaffName is required to Search for Updated');", true);
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {

            //--------------------------------------------------------------------------------
            if (txtstaff.Text == "")
            { }
            else
            {
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    if (txtbr.Text == DCase)
                    {
                        var styAW = new Leave
                        {

                            StaffName = txtstaff.Text,
                            LeaveDate = txtdate.Text,
                            LeaveRange = txtranges.Text,
                            LeaveReason = txtreason.Text,
                            LeaveResume = txtresume.Text,
                            LeaveMonth = txtmonth.Text,
                            ActiveStatus = txtactive.Text,
                            NoOfLeave = "0",
                            Year = txtyear.Text,
                            Branch = txtbr.Text,

                        };
                        db.Leaves.InsertOnSubmit(styAW);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Staff Leave Successful but Payment is Involve');", true);
                        db.SubmitChanges();
                        //-------------------------------------------------------
                        var syt = (from s in db.Staffs where s.StaffName == txtstaff.Text select s).First();
                        syt.ActiveStatus = txtactive.Text;
                        db.SubmitChanges();

                        //-------------------------------------------------------------------------

                        string connetionString;
                        SqlConnection cnn;
                        SqlCommand comand;
                        //String path;


                        connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                        cnn = new SqlConnection(connetionString);
                        cnn.Open();
                        string sql = "Select * from Leave where StaffName='" + txtstaff.Text + "'";
                        comand = new SqlCommand(sql, cnn);
                        SqlDataAdapter da = new SqlDataAdapter(comand);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string constringsB = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            using (SqlConnection conns = new SqlConnection(constringsB))
                            {
                                using (SqlCommand cmdts = new SqlCommand("SELECT Staff.Salary FROM Staff WHERE dbo.Staff.StaffName='" + txtstaff.Text + "'"))
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
                                        //------------------------------------------------------------------------------
                                        string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        using (SqlConnection connsT = new SqlConnection(constrings))
                                        {
                                            using (SqlCommand cmdtsT = new SqlCommand("SELECT Payment.MonthlyBenefit FROM Payment WHERE dbo.Payment.StaffName='" + txtstaff.Text + "'"))
                                            {
                                                //  "SELECT dbo.Customer.SMSAlertPhoneNumbers, dbo.AccountBalance.Balance from dbo.Customer INNER JOIN dbo.AccountBalance ON dbo.Customer.CustomerId = dbo.AccountBalance.CustomerId WHERE dbo.AccountBalance.AccountNumber='"+accountNo+"'"; 

                                                // using (SqlCommand cmdts = new SqlCommand("SELECT Staff.Salary, Emergency.EmergencyNeed FROM Staff INNER JOIN Emergency ON Staff.StaffName=StaffName.StaffName"))
                                                cmdtsT.CommandType = CommandType.Text;
                                                cmdtsT.Connection = connsT;
                                                connsT.Open();

                                                using (SqlDataReader sdrrT = cmdtsT.ExecuteReader())
                                                {
                                                    sdrrT.Read();
                                                   // string Salry = sdrrT["Salary"].ToString();
                                                    string PayT = sdrrT["MonthlyBenefit"].ToString();

                                                    int DailyEquivalent = int.Parse(Salry) / 21;
                                                    float one = int.Parse(Salry);
                                                    float two = int.Parse(DailyEquivalent.ToString());

                                                    float FinalSalary = (float.Parse(PayT) - two);
                                                    Lab5.Text = PayT.ToString();
                                                    Lab6.Text = FinalSalary.ToString();
                                                    // Lab5.Text  = (one) - (two);

                                                    //-------------------------Update Staff Salary--------------------------------------
                                                    var sy = (from s in db.Payments where s.StaffName == txtstaff.Text select s).First();
                                                    sy.MonthlyBenefit = FinalSalary.ToString();
                                                    db.SubmitChanges();
                                                }

                                                connsT.Close();
                                            }
                                        }
                                       
                                    }

                                    conns.Close();
                                }
                            }
                  
                        }
                        else { }
                    }
                    else { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Pls!!! Select Your Branch');", true); }

                }

            }
        }
    }
}