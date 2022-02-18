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
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button1_Click1(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from NewAcount where AccountNo='" + txtAccountNo.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //-------------------------------------bank charge--------------------------------------------
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT id, PageNumber, AccountBalance, AccountNo FROM NewAcount WHERE AccountNo='" + txtAccountNo.Text + "'"))
                    {
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();
                            string bals = sdrr["AccountBalance"].ToString();


                            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            cnn = new SqlConnection(connetionString);
                            cnn.Open();
                            string sql2 = "Select * from Deposite WHERE AccountNo='" + txtAccountNo.Text + "' AND Date='" + txtdate2.Text + "' ";
                            comand = new SqlCommand(sql2, cnn);
                            SqlDataAdapter da2 = new SqlDataAdapter(comand);
                            DataTable dt2 = new DataTable();
                            da2.Fill(dt2);
                            if (dt2.Rows.Count > 0)
                            {
             

                            //-------------------------------------bank charge--------------------------------------------
                            string constringsY = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            using (SqlConnection connsY = new SqlConnection(constringsY))
                            {
                                using (SqlCommand cmdtsY = new SqlCommand("SELECT id, Deposite, Date, FieldOfficer, AccountBalance, AccountNo FROM Deposite WHERE AccountNo='" + txtAccountNo.Text + "' AND id='"+txtid.Text+"' ORDER BY Date DESC "))
                                {
                                    cmdtsY.CommandType = CommandType.Text;
                                    cmdtsY.Connection = connsY;
                                    connsY.Open();

                                    using (SqlDataReader sdrrY = cmdtsY.ExecuteReader())
                                    {
                                        sdrrY.Read();
                                        string Depo = sdrrY["Deposite"].ToString();
                                        txtofficer0.SelectedItem.Text = Depo;

                                        Double val = Double.Parse(bals) - Double.Parse(Depo);
                                        txtofficer0.SelectedItem.Text = Depo;

                                        //----------------------------update NewAcount---------------------------------
                                        string value1 = val.ToString();
                                        string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        SqlConnection connectionu = new SqlConnection(consst);
                                        connectionu.Open();
                                        string queu = "update dbo.NewAcount set AccountBalance=@value1 where AccountNo = '" + txtAccountNo.Text + "'";
                                        System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                        cmd5.Parameters.AddWithValue("@value1", value1);
                                        cmd5.ExecuteNonQuery();

                                        connectionu.Close();

                                        //----------------------------------------------------------------------------------

                                        //----------------------------update WeeklySMS1---------------------------------
                                        string value13 = val.ToString();
                                        string consst3 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        SqlConnection connectionu3 = new SqlConnection(consst3);
                                        connectionu3.Open();
                                        string queu3 = "update dbo.WeeklySMS1 set depositecollect=@value13 where accountno = '" + txtAccountNo.Text + "'";
                                        System.Data.SqlClient.SqlCommand cmd53 = new System.Data.SqlClient.SqlCommand(queu3, connectionu3);
                                        cmd53.Parameters.AddWithValue("@value13", value13);
                                        cmd53.ExecuteNonQuery();

                                        connectionu3.Close();
                                        //-------------------------------------Read WeeklySMS---------------------------------
                                         SqlConnection conwsBWB = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                            conwsBWB.Open();
                                            SqlCommand cmdwsBWB = new SqlCommand("Select * from WeeklySMS where accountno='" + txtAccountNo.Text + "'", conwsBWB);
                                            SqlDataAdapter dawsBWB = new SqlDataAdapter(cmdwsBWB);
                                            DataTable dtwsBWB = new DataTable();
                                            dawsBWB.Fill(dtwsBWB);
                                            if (dtwsBWB.Rows.Count > 0)
                                            {
                                                string constringsx = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                using (SqlConnection connsx = new SqlConnection(constringsx))
                                                {
                                                    using (SqlCommand cmdtsx = new SqlCommand("SELECT id,depositebalance, depositecollect FROM WeeklySMS WHERE accountno = '" + txtAccountNo.Text + "'"))
                                                    {
                                                        cmdtsx.CommandType = CommandType.Text;
                                                        cmdtsx.Connection = connsx;
                                                        connsx.Open();

                                                        using (SqlDataReader sdrrx = cmdtsx.ExecuteReader())
                                                        {
                                                            sdrrx.Read();
                                                            string depoCol = sdrrx["depositebalance"].ToString();
                                                            Double valCol = Double.Parse(depoCol) - Double.Parse(Depo);

                                                            //----------------------------update WeeklySMS---------------------------------
                                                            string value12 = val.ToString();
                                                            string consst2 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                            SqlConnection connectionu2 = new SqlConnection(consst2);
                                                            connectionu2.Open();
                                                            string queu2 = "update dbo.WeeklySMS set depositecollect=@value12,depositebalance=@valCol where accountno = '" + txtAccountNo.Text + "'";
                                                            System.Data.SqlClient.SqlCommand cmd52 = new System.Data.SqlClient.SqlCommand(queu2, connectionu2);
                                                            cmd52.Parameters.AddWithValue("@value12", value12);
                                                            cmd52.Parameters.AddWithValue("@valCol", valCol);
                                                            cmd52.ExecuteNonQuery();

                                                            connectionu2.Close();
                                                        }

                                                        connsx.Close();
                                                    }
                                                }
                                              
                                            }
                                            else { }
                                        //----------------------------------------------------------------------------------

                                            //-------------------------------------Read BuckSMS---------------------------------
                                            SqlConnection conwsBWBa = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                            conwsBWBa.Open();
                                            SqlCommand cmdwsBWBa = new SqlCommand("Select * from BuckFixedSMS1 where accountno='" + txtAccountNo.Text + "'", conwsBWBa);
                                            SqlDataAdapter dawsBWBa = new SqlDataAdapter(cmdwsBWBa);
                                            DataTable dtwsBWBa = new DataTable();
                                            dawsBWBa.Fill(dtwsBWBa);
                                            if (dtwsBWBa.Rows.Count > 0)
                                            {
                                                string constringsx = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                using (SqlConnection connsx = new SqlConnection(constringsx))
                                                {
                                                    using (SqlCommand cmdtsx = new SqlCommand("SELECT id,depositecollect FROM BuckFixedSMS1 WHERE accountno='" + txtAccountNo.Text + "'"))
                                                    {
                                                        cmdtsx.CommandType = CommandType.Text;
                                                        cmdtsx.Connection = connsx;
                                                        connsx.Open();

                                                        using (SqlDataReader sdrrx = cmdtsx.ExecuteReader())
                                                        {
                                                            sdrrx.Read();
                                                            string depoCol = sdrrx["depositecollect"].ToString();
                                                            Double valCol = Double.Parse(depoCol) - Double.Parse(Depo);

                                                            //----------------------------update BuckFixedSMS1---------------------------------
                                                            string value14 = val.ToString();
                                                            string consst341 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                            SqlConnection connectionu341 = new SqlConnection(consst341);
                                                            connectionu341.Open();
                                                            string queu341 = "update dbo.BuckFixedSMS1 set depositebalance=@value14,depositecollect=@valCol where accountno = '" + txtAccountNo.Text + "'";
                                                            System.Data.SqlClient.SqlCommand cmd5341 = new System.Data.SqlClient.SqlCommand(queu341, connectionu341);
                                                            cmd5341.Parameters.AddWithValue("@value14", value14);
                                                            cmd5341.Parameters.AddWithValue("@valCol", valCol);
                                                            cmd5341.ExecuteNonQuery();

                                                            connectionu341.Close();
                                                        }

                                                        connsx.Close();
                                                    }
                                                }
                                                //----------------------------------------------------------------------------------
                                                string constringsxu = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                using (SqlConnection connsx = new SqlConnection(constringsxu))
                                                {
                                                    using (SqlCommand cmdtsx = new SqlCommand("SELECT id,depositecollect FROM BuckFixedSMS WHERE accountno = '" + txtAccountNo.Text + "'"))
                                                    {
                                                        cmdtsx.CommandType = CommandType.Text;
                                                        cmdtsx.Connection = connsx;
                                                        connsx.Open();

                                                        using (SqlDataReader sdrrx = cmdtsx.ExecuteReader())
                                                        {
                                                            sdrrx.Read();
                                                            string depoCol = sdrrx["depositecollect"].ToString();
                                                            Double valCol = Double.Parse(depoCol) - Double.Parse(Depo);

                                                            //----------------------------update BuckFixedSMS---------------------------------
                                                            string value134 = val.ToString();
                                                            string consst34 = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                            SqlConnection connectionu34 = new SqlConnection(consst34);
                                                            connectionu34.Open();
                                                            string queu34 = "update dbo.BuckFixedSMS set depositebalance=@value134,depositecollect=@valCol where accountno = '" + txtAccountNo.Text + "'";
                                                            System.Data.SqlClient.SqlCommand cmd534 = new System.Data.SqlClient.SqlCommand(queu34, connectionu34);
                                                            cmd534.Parameters.AddWithValue("@value134", value134);
                                                            cmd534.Parameters.AddWithValue("@valCol", valCol);
                                                            cmd534.ExecuteNonQuery();

                                                            connectionu34.Close();


                                                        }

                                                        connsx.Close();
                                                    }
                                                }
                                            }
                                            else { }


                                     
                                     
                                        //-------------------read-------------------------------------------------------

                                        //-------------------------------------bank charge--------------------------------------------
                                        string constringsYB = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        using (SqlConnection connsYB = new SqlConnection(constringsYB))
                                        {
                                            using (SqlCommand cmdtsYB = new SqlCommand("SELECT id, FieldOfficer, CashInHand1, Date1 FROM AcctFixed WHERE FieldOfficer = '" + txtofficers.Text + "'"))
                                            {
                                                cmdtsYB.CommandType = CommandType.Text;
                                                cmdtsYB.Connection = connsYB;
                                                connsYB.Open();

                                                using (SqlDataReader sdrrYB = cmdtsYB.ExecuteReader())
                                                {
                                                    sdrrYB.Read();
                                                    string CashIn = sdrrYB["CashInHand1"].ToString();
                                                    txtofficer0.SelectedItem.Text = Depo;

                                                    //Double valB = Double.Parse(CashIn) - Double.Parse(Depo);

                                                    //----------------------------update NewAcount---------------------------------
                                                  //  var stuB = (from s in db.AcctFixeds where s.FieldOfficer == txtofficer.Text select s).First();
                                                   // stuB.CashInHand1 = valB.ToString();
                                                   // db.SubmitChanges();

                                               
                                                    //-----------------------------Update WeeklySMS-------------------------------------------

                                                }

                                                connsYB.Close();
                                            }
                                        }
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Transaction 1 Removed Pls Procced To Transaction 2');", true);



                                        //-------------------------------------------------------------------------------------------
                                        string connetionStringV;
                                        SqlConnection cnnV;
                                        SqlCommand comandV;
                                        //String path;


                                        connetionStringV = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                        cnnV = new SqlConnection(connetionStringV);
                                        cnnV.Open();
                                        string sqlV = "SELECT id, Deposite, AccountNo FROM Contracts WHERE AccountNo = '" + txtAccountNo.Text + "'";
                                        comandV = new SqlCommand(sqlV, cnnV);
                                        SqlDataAdapter daV = new SqlDataAdapter(comandV);
                                        DataTable dtV = new DataTable();
                                        daV.Fill(dtV);
                                        if (dtV.Rows.Count > 0)
                                        {

                                            //-------------------------------------bank charge--------------------------------------------
                                            string constringsB = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            using (SqlConnection connsYB = new SqlConnection(constringsB))
                                            {
                                                using (SqlCommand cmdtsYB = new SqlCommand("SELECT id, Deposite, AccountNo FROM Contracts WHERE AccountNo = '" + txtAccountNo.Text + "'"))
                                                {
                                                    cmdtsYB.CommandType = CommandType.Text;
                                                    cmdtsYB.Connection = connsYB;
                                                    connsYB.Open();

                                                    using (SqlDataReader sdrrYB = cmdtsYB.ExecuteReader())
                                                    {
                                                        sdrrYB.Read();
                                                        string depo = sdrrYB["Deposite"].ToString();

                                                        Double valB = Double.Parse(depo) - Double.Parse(Depo);
                                                        //----------------------------update LoanContrat---------------------------------
                                                        var stuniev = (from s in db.Contracts where s.AccountNo == txtAccountNo.Text select s).First();
                                                        stuniev.Deposite = valB.ToString();
                                                        db.SubmitChanges();

                                                    }

                                                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Transaction Removed Completely');", true);
                                                    connsYB.Close();
                                                }
                                            }

                                        }



                                    }

                                    connsY.Close();
                                }
                            }
                        }else{}

                            //---------------------------------------------------------------------------



                        }

                        conns.Close();
                    }
                }

                                                                    //----------------------------------Transaction Message------------------------

                
                                                                SqlConnection conwsBm = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                                                conwsBm.Open();
                                                                SqlCommand cmdwsBm = new SqlCommand("Select * from Deposite WHERE AccountNo='" + txtAccountNo.Text + "' AND id='" + txtid.Text  + "'", conwsBm);
                                                                SqlDataAdapter dawsBm = new SqlDataAdapter(cmdwsBm);
                                                                DataTable dtwsBm = new DataTable();
                                                                dawsBm.Fill(dtwsBm);
                                                                if (dtwsBm.Rows.Count > 0)
                                                                {


                                                                    //--------------------------delete from Acount-----------------------------------------------------------

                                                                    string cons2s = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                                    SqlConnection cn2 = new SqlConnection(cons2s);
                                                                    cn2.Open();
                                                                    SqlCommand command;
                                                                    SqlDataAdapter adap = new SqlDataAdapter();
                                                                    string sqset = "";
                                                                    sqset = "delete from dbo.Deposite WHERE AccountNo='" + txtAccountNo.Text + "' AND id='" + txtid.Text + "'";
                                                                    command = new SqlCommand(sqset, cn2);

                                                                    adap.DeleteCommand = new SqlCommand(sqset, cn2);
                                                                    adap.DeleteCommand.ExecuteNonQuery();

                                                                    command.Dispose();
                                                                    cn2.Close();
                                                                }
                                                                else { }


                                                                SqlConnection conwsBmL = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                                                                conwsBmL.Open();
                                                                SqlCommand cmdwsBmL = new SqlCommand("Select * from Transactions WHERE AccountNo='" + txtAccountNo.Text + "' AND id='" + txtid.Text + "'", conwsBmL);
                                                                SqlDataAdapter dawsBmL = new SqlDataAdapter(cmdwsBmL);
                                                                DataTable dtwsBmL = new DataTable();
                                                                dawsBmL.Fill(dtwsBmL);
                                                                if (dtwsBmL.Rows.Count > 0)
                                                                {


                                                                    //--------------------------delete from Transaction-----------------------------------------------------------

                                                                    string cons2sE = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                                                    SqlConnection cn2E = new SqlConnection(cons2sE);
                                                                    cn2E.Open();
                                                                    SqlCommand commandE;
                                                                    SqlDataAdapter adapE = new SqlDataAdapter();
                                                                    string sqsetE = "";
                                                                    sqsetE = "delete from dbo.Transactions WHERE AccountNo='" + txtAccountNo.Text + "' AND id='" + txtid.Text + "'";
                                                                    commandE = new SqlCommand(sqsetE, cn2E);

                                                                    adapE.DeleteCommand = new SqlCommand(sqsetE, cn2E);
                                                                    adapE.DeleteCommand.ExecuteNonQuery();

                                                                    commandE.Dispose();
                                                                    cn2E.Close();
                                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Transaction Removed Successfully Completed');", true);

                                                                }
                                                                else { }

            }
            else
            {
                // Response.Write("<script>alert('Please PhoneNo doesn't not Exist')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please AccountNo doesn't exist');", true);

            }
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
          
            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;
            //-------------------------------------------------ACCOUNTNO-------------------------
            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from NewAcount where AccountNo='" + txtAccountNo.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //-------------------------------------bank charge--------------------------------------------
                string constrings = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection conns = new SqlConnection(constrings))
                {
                    using (SqlCommand cmdts = new SqlCommand("SELECT id, PageNumber, AccountBalance, AccountNo FROM NewAcount WHERE AccountNo='" + txtAccountNo.Text + "'"))
                    {
                        cmdts.CommandType = CommandType.Text;
                        cmdts.Connection = conns;
                        conns.Open();

                        using (SqlDataReader sdrr = cmdts.ExecuteReader())
                        {
                            sdrr.Read();
                            string bals = sdrr["AccountBalance"].ToString();

                            //-------------------------------------------------------

                            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            cnn = new SqlConnection(connetionString);
                            cnn.Open();
                            string sql2 = "Select * from Withdraw WHERE AccountNo='" + txtAccountNo.Text + "' AND Date='" + txtdate2.Text + "' ";
                            comand = new SqlCommand(sql2, cnn);
                            SqlDataAdapter da2 = new SqlDataAdapter(comand);
                            DataTable dt2 = new DataTable();
                            da2.Fill(dt2);
                            if (dt2.Rows.Count > 0)
                            {


                                //-------------------------------------bank charge--------------------------------------------
                                string constringsY = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                using (SqlConnection connsY = new SqlConnection(constringsY))
                                {
                                    using (SqlCommand cmdtsY = new SqlCommand("SELECT id, Withdraw, FieldOfficer, AccountBalance, AccountNo FROM Withdraw WHERE AccountNo='" + txtAccountNo.Text + "' AND id='" + txtid.Text + "'"))
                                    {
                                        cmdtsY.CommandType = CommandType.Text;
                                        cmdtsY.Connection = connsY;
                                        connsY.Open();

                                        using (SqlDataReader sdrrY = cmdtsY.ExecuteReader())
                                        {
                                            sdrrY.Read();
                                            string Depo = sdrrY["Withdraw"].ToString();
                                            txtofficer0.SelectedItem.Text = Depo;

                                            Double val = Double.Parse(bals) + Double.Parse(Depo);
                                            Double valSMS = (val + 5);

                                            txtofficer0.SelectedItem.Text = Depo;

                                            //----------------------------update NewAcount---------------------------------
                                            string value1 = valSMS.ToString();
                                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                            SqlConnection connectionu = new SqlConnection(consst);
                                            connectionu.Open();
                                            string queu = "update dbo.NewAcount set AccountBalance=@value1 where AccountNo = '" + txtAccountNo.Text + "'";
                                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                                            cmd5.Parameters.AddWithValue("@value1", value1);
                                            cmd5.ExecuteNonQuery();

                                            connectionu.Close();
                                        }
                                        connsY.Close();
                                    }
                                }
                            }


                            SqlConnection conwsBmL = new SqlConnection(@"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True");
                            conwsBmL.Open();
                            SqlCommand cmdwsBmL = new SqlCommand("Select * from Withdraw WHERE AccountNo='" + txtAccountNo.Text + "' AND id='" + txtid.Text + "'", conwsBmL);
                            SqlDataAdapter dawsBmL = new SqlDataAdapter(cmdwsBmL);
                            DataTable dtwsBmL = new DataTable();
                            dawsBmL.Fill(dtwsBmL);
                            if (dtwsBmL.Rows.Count > 0)
                            {


                                //--------------------------delete from Transaction-----------------------------------------------------------

                                string cons2sE = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                                SqlConnection cn2E = new SqlConnection(cons2sE);
                                cn2E.Open();
                                SqlCommand commandE;
                                SqlDataAdapter adapE = new SqlDataAdapter();
                                string sqsetE = "";
                                sqsetE = "delete from dbo.Withdraw WHERE AccountNo='" + txtAccountNo.Text + "' AND id='" + txtid.Text + "'";
                                commandE = new SqlCommand(sqsetE, cn2E);

                                adapE.DeleteCommand = new SqlCommand(sqsetE, cn2E);
                                adapE.DeleteCommand.ExecuteNonQuery();

                                commandE.Dispose();
                                cn2E.Close();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Withdaw Transaction Removed Successfully Completed');", true);

                            }
                            else { }

                        }
                        cnn.Close();
                    }
                }
            }
            else { }

            //------------------------------------------------------------------------------------------
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
            string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy FROM [dbo].[Deposite] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficers.Text + "'  ORDER BY Date DESC ";
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
            string sqlquerym = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Deposite, PostedBy FROM [dbo].[Deposite] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficers.Text + "'  ORDER BY Date DESC ";

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
          
            string connetionString;
            SqlConnection cnn;
            SqlCommand comand;
            //String path;


            connetionString = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Select * from AcctFixed where FieldOfficer='" + txtofficers.Text + "'";
            comand = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(comand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                
                //-------------------------------------bank charge--------------------------------------------
                string constringsYB = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                using (SqlConnection connsYB = new SqlConnection(constringsYB))
                {
                    using (SqlCommand cmdtsYB = new SqlCommand("SELECT id, FieldOfficer, CashInHand1, Date1 FROM AcctFixed WHERE FieldOfficer = '" + txtofficers.Text + "' AND Date1='" + txtdate2.Text + "'"))
                    {
                        cmdtsYB.CommandType = CommandType.Text;
                        cmdtsYB.Connection = connsYB;
                        connsYB.Open();

                        using (SqlDataReader sdrrYB = cmdtsYB.ExecuteReader())
                        {
                            sdrrYB.Read();
                            string CashIn = sdrrYB["CashInHand1"].ToString();

                            Double valB = Double.Parse(CashIn) - Double.Parse(txtofficer0.Text);

                            //----------------------------update AcctFixed---------------------------------
                       
                            string consst = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
                            SqlConnection connectionu = new SqlConnection(consst);
                            connectionu.Open();
                            string queu = "update dbo.AcctFixed set CashInHand1=@valB where FieldOfficer = '" + txtofficers.Text + "' AND Date1 = '" + txtdate2.Text + "'";
                            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand(queu, connectionu);
                            cmd5.Parameters.AddWithValue("@valB", valB);
                            cmd5.ExecuteNonQuery();

                            connectionu.Close();

                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Transaction Removed Completely');", true);


                        connsYB.Close();
                    }
                }
                
            }
            else
            { }

     
                        

            
        }

        protected void Button33_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(constr);
            string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Withdraw, PostedBy FROM [dbo].[Withdraw] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficers.Text + "'  ORDER BY Date DESC ";
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
            string sqlquerym = "SELECT id, CustomerId, Branch, FieldOfficer, AccountNo, PageNumber, Date, PhoneNo, ChartNo, Withdraw, PostedBy FROM [dbo].[Withdraw] where Date ='" + txtdate2.Text + "' and FieldOfficer = '" + txtofficers.Text + "'  ORDER BY Date DESC ";

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
            //Lab2.Text = " Total Deposite:" + " " + result.ToString();

            Lab2.Text = " Total Withdraw:" + " :";
            Lab14.Text = result.ToString("#,##0.00") + "NGN";


        }
    }
}