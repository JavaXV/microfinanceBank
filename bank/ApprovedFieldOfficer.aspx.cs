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
    public partial class ApprovedFieldOfficer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  txtapproveddate.Enabled = false;
         //   txtapproveddate.Text = DateTime.Now.ToString("yyyy-MM-dd");


            if (Session["USER_ID"] != null)
            {
                Label1.Text = Session["USER_ID"].ToString();
            }
            else { Response.Redirect("DepositeLoginHead.aspx"); }
        }
        // call the linq
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                Label1.Text = Session["USER_ID"].ToString();
                string DCase = Session["USER_ID"].ToString();

                SqlConnection conw = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                conw.Open();
                SqlCommand cmdw = new SqlCommand("Select * from Tmt2 where Branch='" + DCase + "'", conw);
                SqlDataAdapter daw = new SqlDataAdapter(cmdw);
                DataTable dtw = new DataTable();
                daw.Fill(dtw);
                if (dtw.Rows.Count > 0)
                {

                    //-------------------------------------bank charge--------------------------------------------
                    string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    using (SqlConnection conns = new SqlConnection(constrings))
                    {
                        using (SqlCommand cmdts = new SqlCommand("SELECT id, Date FROM Tmt2 WHERE Branch = '" + DCase + "'"))
                        {
                            cmdts.CommandType = CommandType.Text;
                            cmdts.Connection = conns;
                            conns.Open();

                            using (SqlDataReader sdrr = cmdts.ExecuteReader())
                            {
                                sdrr.Read();
                                string ValueDater = sdrr["Date"].ToString();

                                //-------------------------perform operation approved----------------------------------------
                                if (txtofficers.Text == "" || txtapproved.Text == "" || txtapproveddate.Text == "" || txtapprovedby.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('All Field Are Required');", true);
                                }
                                else
                                {
                                    if (DateTime.Now.ToString("yyyy-MM-dd") == ValueDater && txtbranch.Text == DCase)
                                    {
                                        string value1 = txtapproved.Text;
                                        string value2 = txtapproveddate.Text;
                                        string value3 = txtapprovedby.Text;

                                        string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        SqlConnection connectionu = new SqlConnection(consst);
                                        connectionu.Open();
                                        string queu = "update dbo.FieldOfficerAmount set Approved=@value1, ApproveDate=@value2, ApprovedBy=@value3  where Date='" + txtapproveddate.Text + "' AND FieldOfficer='" + txtofficers.Text + "' ";
                                        System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                        cmd5.Parameters.AddWithValue("@value1", value1);
                                        cmd5.Parameters.AddWithValue("@value2", value2);
                                        cmd5.Parameters.AddWithValue("@value3", value3);
                                        cmd5.ExecuteNonQuery();
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Approved');", true);

                                        connectionu.Close();
                                    }
                                    else if (txtdate.Text == ValueDater && txtbranch.Text == DCase)
                                    {
                                        string value1 = txtapproved.Text;
                                        string value2 = txtapproveddate.Text;
                                        string value3 = txtapprovedby.Text;

                                        string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        SqlConnection connectionu = new SqlConnection(consst);
                                        connectionu.Open();
                                        string queu = "update dbo.FieldOfficerAmount set Approved=@value1, ApproveDate=@value2, ApprovedBy=@value3  where Date='" + txtdate.Text + "' AND FieldOfficer='" + txtofficers.Text + "' ";
                                        System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                        cmd5.Parameters.AddWithValue("@value1", value1);
                                        cmd5.Parameters.AddWithValue("@value2", value2);
                                        cmd5.Parameters.AddWithValue("@value3", value3);
                                        cmd5.ExecuteNonQuery();
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Approved');", true);

                                        connectionu.Close();
                                    }
                                    else
                                    {

                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Batch is Close! Date is not Open or Pls Select Your Branch');", true);
                                    }

                                }
                            }

                            conns.Close();
                        }
                    }
                }

                else
                { }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (txtall.Text == "" || txtdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('All Field Are Required');", true);
            }
            else
            {

         //------------------------------------------------------------------------------------------------------------------------

                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();

                    string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                    using (SqlConnection conns = new SqlConnection(constrings))
                    {
                        using (SqlCommand cmdts = new SqlCommand("SELECT id, Date FROM Tmt2 WHERE Branch = '" + DCase + "'"))
                        {
                            cmdts.CommandType = CommandType.Text;
                            cmdts.Connection = conns;
                            conns.Open();

                            using (SqlDataReader sdrr = cmdts.ExecuteReader())
                            {
                                sdrr.Read();
                                string ValueDater = sdrr["Date"].ToString();
                                if (txtdate.Text == ValueDater && txtbranch.Text == DCase)
                                {
                                    DataTable dt = new DataTable();
                                    string cons = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    //String myquery = "select * from [dbo].[FieldOfficerAmount]";
                                    string myquery = "Select id, Branch, FieldOfficer, Date, CashInChat, CashInHand, Balance, AllOf, Approved, ApproveDate, ApprovedBy, Amount from [dbo].[FieldOfficerAmount] where AllOf = '" + txtall.Text + "' and  Date = '" + txtdate.Text + "'";

                                    SqlConnection cnz = new SqlConnection(cons);
                                    SqlCommand cmd = new SqlCommand();
                                    cmd.CommandText = myquery;
                                    cmd.Connection = cnz;
                                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                                    da.SelectCommand = cmd;

                                    da.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                    cnz.Close();

                                    var result = dt.AsEnumerable()
                                      .Sum(x => Convert.ToInt32(x["CashInChat"]));
                                    Lab2.Text = "CashInChat" + " :" + result.ToString("#,##0.00");


                                    var result3 = dt.AsEnumerable()
                                           .Sum(x => Convert.ToInt32(x["CashInHand"]));
                                    Lab3.Text = "CashInHand" + " :" + result3.ToString("#,##0.00");

                                    var result4 = dt.AsEnumerable()
                                          .Sum(x => Convert.ToInt32(x["Balance"]));
                                    Lab31.Text = "Balance" + " :" + result4.ToString("#,##0.00");


                                    var result3yW = dt.AsEnumerable()
                                           .Sum(x => Convert.ToInt32(x["Amount"]));
                                    Lab4.Text = "Amount" + " :" + result3yW.ToString("#,##0.00");




                                    //--------------------------------------------------------------------------------
                                    DataTable dtyX = new DataTable();
                                    string consyX = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                    //String myquery = "select * from [dbo].[FieldOfficerAmount]";
                                    string myqueryyX = "Select id, Branch, FieldOfficer, Date, CashInChat, CashInHand, Balance, AllOf, Amount from [dbo].[FieldOfficer] where AllOf = '" + txtall.Text + "' and  Date = '" + txtdate.Text + "'";

                                    SqlConnection cnzyX = new SqlConnection(consyX);
                                    SqlCommand cmdyX = new SqlCommand();
                                    cmdyX.CommandText = myqueryyX;
                                    cmdyX.Connection = cnzyX;
                                    SqlDataAdapter dayX = new SqlDataAdapter(cmdyX);
                                    dayX.SelectCommand = cmdyX;

                                    dayX.Fill(dtyX);
                                    // GridView1.DataSource = dtyX;
                                    // GridView1.DataBind();
                                    cnzyX.Close();

                                    var resultyX = dtyX.AsEnumerable()
                                        .Sum(x => Convert.ToInt32(x["Amount"]));

                                   // Lab3.Text = "Amount" + " " + resultyX.ToString() + "NGN";


                                    var resultyW = dtyX.AsEnumerable()
                                          .Sum(x => Convert.ToInt32(x["Amount"]));
                                    Lab4.Text = "Amount" + " :" + resultyW.ToString("#,##0.00");


                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Date is not Open or Pls Select Your Branch');", true);

                                }


                            }

                            conns.Close();
                        }
                    }
                }
        }
    }

        protected void Button5_Click(object sender, EventArgs e)
        {

            if (txtofficers.Text == "" || txtdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('All Field Are Required');", true);
            }
            else
            {

                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();
                
                //------------------------------------------------------------------------------------------------------------------------
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT id, Date FROM Tmt2 WHERE Branch = '" + DCase + "'"))
                    {
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();
                            string ValueDater = sdrr["Date"].ToString();
                            if (txtdate.Text == ValueDater && txtbranch.Text == DCase)
                            {
                                DataTable dty = new DataTable();
                                string consy = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                //String myquery = "select * from [dbo].[FieldOfficerAmount]";
                                string myqueryy = "Select id, Branch, FieldOfficer, Date, CashInChat, CashInHand, Balance, AllOf, Approved, ApproveDate, ApprovedBy, Amount from [dbo].[FieldOfficerAmount] where FieldOfficer = '" + txtofficers.Text + "' and  Date = '" + txtdate.Text + "'";

                                SqlConnection cnzy = new SqlConnection(consy);
                                SqlCommand cmdy = new SqlCommand();
                                cmdy.CommandText = myqueryy;
                                cmdy.Connection = cnzy;
                                SqlDataAdapter day = new SqlDataAdapter(cmdy);
                                day.SelectCommand = cmdy;

                                day.Fill(dty);
                                GridView1.DataSource = dty;
                                GridView1.DataBind();
                                cnzy.Close();

                                var result = dty.AsEnumerable()
                                       .Sum(x => Convert.ToInt32(x["CashInChat"]));
                                Lab2.Text = "CashInChat" + " :" + result.ToString("#,##0.00");


                                var result3 = dty.AsEnumerable()
                                       .Sum(x => Convert.ToInt32(x["CashInHand"]));
                                Lab3.Text = "CashInHand" + " :" + result3.ToString("#,##0.00");

                                var result4 = dty.AsEnumerable()
                                      .Sum(x => Convert.ToInt32(x["Balance"]));
                                Lab31.Text = "Balance" + " :" + result4.ToString("#,##0.00");


                                var result3yW = dty.AsEnumerable()
                                       .Sum(x => Convert.ToInt32(x["Amount"]));
                                Lab4.Text = "Amount" + " :" + result3yW.ToString("#,##0.00");



                                //--------------------------------SELECT------------------------------------------------
                                DataTable dtyX = new DataTable();
                                string consyX = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                //String myquery = "select * from [dbo].[FieldOfficerAmount]";
                                string myqueryyX = "Select id, Branch, FieldOfficer, Date, CashInChat, CashInHand, Balance, AllOf, Amount from [dbo].[FieldOfficer] where FieldOfficer = '" + txtofficers.Text + "' and  Date = '" + txtdate.Text + "'";

                                SqlConnection cnzyX = new SqlConnection(consyX);
                                SqlCommand cmdyX = new SqlCommand();
                                cmdyX.CommandText = myqueryyX;
                                cmdyX.Connection = cnzyX;
                                SqlDataAdapter dayX = new SqlDataAdapter(cmdyX);
                                dayX.SelectCommand = cmdyX;

                                dayX.Fill(dtyX);
                                // GridView1.DataSource = dtyX;
                                // GridView1.DataBind();
                                cnzyX.Close();

                                var resultyX = dtyX.AsEnumerable()
                                    .Sum(x => Convert.ToInt32(x["Amount"]));

                               // Lab6.Text = "Amount" + " " + resultyX.ToString() + "NGN";



                                Lab4.Text = "Amount" + " :" + resultyX.ToString("#,##0.00");



                                //--------------------------------ALL------------------------------------------------
                                DataTable dtyXW = new DataTable();
                                string consyXW = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                //String myquery = "select * from [dbo].[FieldOfficerAmount]";
                                string myqueryyXW = "Select id, Branch, FieldOfficer, Date, CashInChat, CashInHand, Balance, AllOf, Amount from [dbo].[FieldOfficer] where FieldOfficer = '" + txtofficers.Text + "' and  Date = '" + txtdate.Text + "'";

                                SqlConnection cnzyXW = new SqlConnection(consyXW);
                                SqlCommand cmdyXW = new SqlCommand();
                                cmdyXW.CommandText = myqueryyXW;
                                cmdyXW.Connection = cnzyXW;
                                SqlDataAdapter dayXW = new SqlDataAdapter(cmdyXW);
                                dayXW.SelectCommand = cmdyXW;

                                dayXW.Fill(dtyXW);
                                // GridView1.DataSource = dtyX;
                                // GridView1.DataBind();
                                cnzyXW.Close();

                                var resultyXW = dtyXW.AsEnumerable()
                                    .Sum(x => Convert.ToInt32(x["Amount"]));

                              //  Lab6.Text = "Amount" + " " + resultyXW.ToString() + "NGN";

                                Lab4.Text = "Amount" + " :" + resultyXW.ToString("#,##0.00");




                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Batch is Close! Date is not Open or Pls Select Your Branch');", true);

                            }


                        }

                        conns.Close();
                    }
                }
            }

            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            
                if (Session["USER_ID"] != null)
                {
                    Label1.Text = Session["USER_ID"].ToString();
                    string DCase = Session["USER_ID"].ToString();
                
             string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
             using (SqlConnection conns = new SqlConnection(constrings))
             {
                 using (SqlCommand cmdts = new SqlCommand("SELECT id, Date FROM Tmt2 WHERE Branch = '" + DCase + "'"))
                 {
                     cmdts.CommandType = CommandType.Text;
                     cmdts.Connection = conns;
                     conns.Open();

                     using (SqlDataReader sdrr = cmdts.ExecuteReader())
                     {
                         sdrr.Read();
                         string ValueDater = sdrr["Date"].ToString();
                         if (txtdate.Text == ValueDater && txtbranch.Text == DCase)
                         {
                             string value1 = txtapproved.Text;
                             string value2 = txtapproveddate.Text;
                             string value3 = txtapprovedby.Text;

                             string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                             SqlConnection connectionu = new SqlConnection(consst);
                             connectionu.Open();
                             string queu = "update dbo.FieldOfficerAmount set Approved=@value1, ApproveDate=@value2, ApprovedBy=@value3  where Date='" + txtdate.Text + "' AND AllOf='" + txtall.Text + "' ";
                             System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                             cmd5.Parameters.AddWithValue("@value1", value1);
                             cmd5.Parameters.AddWithValue("@value2", value2);
                             cmd5.Parameters.AddWithValue("@value3", value3);
                             cmd5.ExecuteNonQuery();
                             ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Approved All');", true);

                             connectionu.Close();
                         }
                         conns.Close();
                     }
                 }
             }
           }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Batch is Close! Date is not Open or Pls Select Your Branch');", true);

                }
         }
      }
    }
