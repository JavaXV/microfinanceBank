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
    public partial class AccountHRpay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displaymessage2.Enabled = false;
            Button4.Enabled = false;
            Button6.Enabled = false;
        }
        // call the linq
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button1_Click1(object sender, EventArgs e)
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
                            if (Session["USER_ID"] != null)
                            {
                                Label1.Text = Session["USER_ID"].ToString();
                                string DCase = Session["USER_ID"].ToString();

                                if (txtbr.Text == DCase)
                                {
                                    //--------------------------------------------------------------------------------------

                                    SqlConnection conwV = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                    conwV.Open();
                                    SqlCommand cmdwV = new SqlCommand("Select * from Staff where StaffName='" + txtstaff.Text + "'", conwV);
                                    SqlDataAdapter dawV = new SqlDataAdapter(cmdwV);
                                    DataTable dtwV = new DataTable();
                                    dawV.Fill(dtwV);
                                    if (dtwV.Rows.Count > 0)
                                    {
                                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('StaffName d');", true);
                                        string constringsg = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        using (SqlConnection connsg = new SqlConnection(constringsg))
                                        {
                                            using (SqlCommand cmdtsg = new SqlCommand("Select * from [dbo].[Staff] where StaffName='" + txtstaff.Text + "'"))
                                            {
                                                cmdtsg.CommandType = CommandType.Text;
                                                cmdtsg.Connection = connsg;
                                                connsg.Open();

                                                using (SqlDataReader sdrrg = cmdtsg.ExecuteReader())
                                                {
                                                    sdrrg.Read();
                                                    string Salry = sdrrg["Salary"].ToString();

                                                    //--------------------------------------------------------------------------------------
                                                    Double MonthBal = Double.Parse(txtbenefit.Text) - Double.Parse(txtneed.Text);
                                                    var styAW = new Payment
                                                    {
                                                        MonthlySalaryPayment = txtmonth.Text,
                                                        StaffName = txtstaff.Text,
                                                        Date = txtdate.Text,
                                                        Emergency = txtemergency.Text,
                                                        MonthlyBenefit = MonthBal.ToString(),
                                                        Allowance = txtallowance.Text,
                                                        EmergencyNeed = txtneed.Text,
                                                        Branch = txtbr.Text,
                                                        Year = DateTime.Now.ToString("MM/yyyy"),
                                                        Salary = Salry,
                                                    };
                                                    db.Payments.InsertOnSubmit(styAW);
                                                    db.SubmitChanges();
                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Staff InCluded in Payroll');", true);
                                                    Lab5.Text = "Staff enroll for" + " " + txtmonth.Text + "  " + "Paroll System ";





                                                }

                                                connsg.Close();
                                            }
                                        }
                                    }
                                    else { }

                                }
                                else { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Pls!!! Select Your Branch');", true); }
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from Payment where StaffName='" + txtstaff.Text + "'";
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
                        var sty = (from s in db.Payments where s.StaffName == txtstaff.Text select s).First();
                        db.Payments.DeleteOnSubmit(sty);
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("USER_ID");
            Session.RemoveAll();
            Response.Redirect("HRLogin.aspx");
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
            string sql = "Select * from Payment where StaffName='" + txtstaff.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT id, MonthlySalaryPayment, StaffName,Date,Emergency,MonthlyBenefit,Allowance,EmergencyNeed,Branch,Year FROM Payment WHERE StaffName = '" + txtstaff.Text + "'", con);
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
                            txtmonth.Text = sdr1["MonthlySalaryPayment"].ToString();
                            txtdate.Text = sdr1["Date"].ToString();
                            txtemergency.Text = sdr1["Emergency"].ToString();
                            txtbenefit.Text = sdr1["MonthlyBenefit"].ToString();
                            txtallowance.Text = sdr1["Allowance"].ToString();
                            txtneed.Text = sdr1["EmergencyNeed"].ToString();
                            txtbr.Text = sdr1["Branch"].ToString();
                            Lab5.Text = sdr1["Year"].ToString();
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

        protected void Button6_Click(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from Payment where StaffName='" + txtstaff.Text + "'";
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
                    Double MonthBal = Double.Parse(txtbenefit.Text) - Double.Parse(txtneed.Text);

                    if (txtbr.Text == DCase)
                    {
                        //--------------update------------------------------------------------------------------------

                        var sty = (from s in db.Payments where s.StaffName == txtstaff.Text select s).First();

                        sty.MonthlySalaryPayment = txtmonth.Text;
                        sty.StaffName = txtstaff.Text;
                        sty.Date = txtdate.Text;
                        sty.Emergency = txtemergency.Text;
                        sty.MonthlyBenefit = (MonthBal.ToString());
                        sty.Allowance = txtallowance.Text;
                        sty.EmergencyNeed = txtneed.Text;

                        db.SubmitChanges();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
                        //  LoadData();




                    }
                    else { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Pls!!! Select Your Branch');", true); }

                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Customer ID is required to Search for Updated');", true);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conws = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
            conws.Open();
            SqlCommand cmdws = new SqlCommand("Select * from [dbo].[Emergency] where StaffName='" + txtstaff.Text + "'", conws);
            SqlDataAdapter daws = new SqlDataAdapter(cmdws);
            DataTable dtws = new DataTable();
            daws.Fill(dtws);
            if (dtws.Rows.Count > 0)
            {
                //------------------------------------------------------------------------------------------
                //-------------------------------------HResources--------------------------------------------
                string constringsV = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constringsV))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT dbo.Staff.Salary from dbo.Staff WHERE dbo.Staff.StaffName='" + txtstaff.Text + "'"))
                    {
                        // using (SqlCommand cmdts = new SqlCommand("SELECT Staff.Salary, Emergency.EmergencyNeed FROM Staff INNER JOIN Emergency ON Staff.StaffName=StaffName.StaffName"))
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();

                            string Salry = sdrr["Salary"].ToString();

                            //--------------------------------------------------------------
                            //-------------------------------------HResources--------------------------------------------
                            string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            using (SqlConnection connsR = new SqlConnection(constrings))
                            {
                                using (SqlCommand cmdtsR = new SqlCommand("SELECT dbo.Emergency.EmergencyNeed, dbo.Emergency.Emergency from dbo.Emergency WHERE dbo.Emergency.StaffName='" + txtstaff.Text + "'"))
                                {
                                    // using (SqlCommand cmdts = new SqlCommand("SELECT Staff.Salary, Emergency.EmergencyNeed FROM Staff INNER JOIN Emergency ON Staff.StaffName=StaffName.StaffName"))
                                    cmdtsR.CommandType = CommandType.Text;
                                    cmdtsR.Connection = connsR;
                                    connsR.Open();

                                    using (SqlDataReader sdrrR = cmdtsR.ExecuteReader())
                                    {
                                        sdrrR.Read();


                                        string need = sdrrR["EmergencyNeed"].ToString();
                                        string Emerg = sdrrR["Emergency"].ToString();
                                        txtbenefit.Text = Salry;
                                        txtneed.Text = need;
                                        txtemergency.Text = Emerg;
                                        //--------------------------------------------------------------


                                        //--------------------------------------------------------------

                                    }

                                    connsR.Close();
                                }
                            }

                            //--------------------------------------------------------------

                        }

                        conns.Close();
                    }
                }



            }
            else
            {
                SqlConnection conwV = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                conwV.Open();
                SqlCommand cmdwV = new SqlCommand("Select * from Staff where StaffName='" + txtstaff.Text + "'", conwV);
                SqlDataAdapter dawV = new SqlDataAdapter(cmdwV);
                DataTable dtwV = new DataTable();
                dawV.Fill(dtwV);
                if (dtwV.Rows.Count > 0)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('StaffName d');", true);
                    string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    using (SqlConnection conns = new SqlConnection(constrings))
                    {
                        using (SqlCommand cmdts = new SqlCommand("Select * from [dbo].[Staff] where StaffName='" + txtstaff.Text + "'"))
                        {
                            // using (SqlCommand cmdts = new SqlCommand("SELECT Staff.Salary, Emergency.EmergencyNeed FROM Staff INNER JOIN Emergency ON Staff.StaffName=StaffName.StaffName"))
                            cmdts.CommandType = CommandType.Text;
                            cmdts.Connection = conns;
                            conns.Open();

                            using (SqlDataReader sdrr = cmdts.ExecuteReader())
                            {
                                sdrr.Read();
                                string Salry = sdrr["Salary"].ToString();
                                txtbenefit.Text = Salry;
                                txtneed.Text = "0";
                            }

                            conns.Close();
                        }
                    }
                }
                else { }

            }
        }
    }
}