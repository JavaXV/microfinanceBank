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
    public partial class ContractAgreementChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displaymessage4.Enabled = false;
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Button3_Click1(object sender, EventArgs e)
        {
            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(constr);
            string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, ManagementFee, CustomerName, ContractDate1, ContractDate2, MaturityDate, LoanAmount, ApprovedDate, ModeOfPayment, CustomerAddress, TypeOfBusiness, CompanyAddress, PurposeOfLoan, PhoneNo, Interest, AccountType, AccountNo FROM [dbo].[Contracts] where Date = '" + txtdate1.Text + "'";
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

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(constr);
           string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, ManagementFee, CustomerName, ContractDate1, ContractDate2, MaturityDate, LoanAmount, ApprovedDate, ModeOfPayment, CustomerAddress, TypeOfBusiness, CompanyAddress, PurposeOfLoan, PhoneNo, Interest, AccountType, AccountNo FROM [dbo].[Contracts] where ContractDate1 between '" + txtdate1.Text + "' and '" + txtdate2.Text + "'";

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=DESKTOP-URMGVCS\SQLEXPRESS;Initial Catalog=PrudentBankSQL;Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(constr);
            string sqlquery = "SELECT id, CustomerId, Branch, FieldOfficer, ManagementFee, CustomerName, ContractDate1, ContractDate2, MaturityDate, LoanAmount, ApprovedDate, ModeOfPayment, CustomerAddress, TypeOfBusiness, CompanyAddress, PurposeOfLoan, PhoneNo, Interest, AccountType, AccountNo FROM [dbo].[Contracts] where AccountNo = '" + txtaccountno.Text + "'";
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
    }
}