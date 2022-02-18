<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminActivate.aspx.cs" Inherits="BankA.AdminActivate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<style>

input[type=MultiLine] {
    width: 100%;
    padding: 2px 20px;
    margin: 8px 0;
    border: none;
	background-color:#FFFFFF;
    border-bottom: 0px solid #0099FF;
	font-size:16px;
	font-family:"Courier New", Courier, monospace;
	color:#0066FF;
}
    input[type=password] {
    width: 100%;
    padding: 2px 20px;
    margin: 8px 0;
    border: none;
	background-color:#FFFFFF;
    border-bottom: 0px solid #0099FF;
	font-size:16px;
	font-family:"Courier New", Courier, monospace;
	color:#0066FF;
}

    input[type=Search] {
    width: 100%;
    padding: 2px 20px;
    margin: 8px 0;
    border: none;
	background-color:#FFFFFF;
    border-bottom: 0px solid #0099FF;
	font-size:16px;
	font-family:"Courier New", Courier, monospace;
	color:#0066FF;
}
  
</style>
     <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Admin | Dashboard</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Tempusdominus Bbootstrap 4 -->
  <link rel="stylesheet" href="plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- JQVMap -->
  <link rel="stylesheet" href="plugins/jqvmap/jqvmap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="dist/css/adminlte.min.css">
  <!-- overlayScrollbars -->
  <link rel="stylesheet" href="plugins/overlayScrollbars/css/OverlayScrollbars.min.css">
  <!-- Daterange picker -->
  <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker.css">
  <!-- summernote -->
  <link rel="stylesheet" href="plugins/summernote/summernote-bs4.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
</head>
<body class="hold-transition sidebar-mini layout-fixed">
    <form id="form1" runat="server">
    <div>
    

    <div class="wrapper">

  <!-- Navbar -->
  <nav class="main-header navbar navbar-expand navbar-white navbar-light" >
    <!-- Left navbar links -->
   
        <div class="col-sm-6">
            <h5 class="m-0 text-dark">Admin-Block</h5>
          </div><!-- /.col -->
   

    <ul class="navbar-nav ml-auto">
      <!-- Messages Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="">
          <i class="far fa-comments" style="position:absolute; width:200px; top:9px; right:250px;"> <asp:Label ID="Label1" runat="server" Font-Size="Larger"></asp:Label> </i>
          <span class="badge badge-danger navbar-badge"></span>
          </a>
         <div style="position:absolute; background-color:White; top:5px; right:0px;"> <asp:Button ID="Button1" runat="server" Text="LogOut" Font-Size="Small" BackColor="White" BorderColor="White" Height="30px" Width="70px" ForeColor="BlueViolet" onclick="Button1_Click"></asp:Button>
        </div>
     
    </ul>
  </nav>
  <!-- /.navbar -->

  <!-- Main Sidebar Container -->
  <aside class="main-sidebar sidebar-dark-primary elevation-4">
    <!-- Brand Logo -->
  <a href="" class="brand-link">
       <img src="zealluckLogo.PNG" height="65px" width="65px" alt="AdminLTE Logo" "
           style="opacity: .8">
      <span class="brand-text font-weight-light">ZEALLUCK</span>
    </a>

    <!-- Sidebar -->
    <div class="sidebar">
      <!-- Sidebar user panel (optional) -->
      <div class="user-panel mt-3 pb-3 mb-3 d-flex">
        <div class="image">
          <img src="imagery/admin.jpg" class="img-circle elevation-2" alt="User Image">
        </div>
        <div class="info">
          <a href="" class="d-block">Adebayo Adewale</a>
        </div>
      </div>

      <!-- Sidebar Menu -->
      <nav class="mt-2">
        <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
          <!-- Add icons to the links using the .nav-icon class
               with font-awesome or any other icon font library -->
          <li class="nav-item has-treeview menu-open">
            <a href="" class="nav-link active">
              <i class="nav-icon fas fa-tachometer-alt"></i>
              <p>
                Administration
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>
          </li>
          <li class="nav-item has-treeview">
            <a href="" class="nav-link">
              <i class="nav-icon fas fa-chart-pie"></i>
              <p>
                General Ledgers
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="WithdrawChart.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                    <p style="color:Yellow;">Withdraw Transaction</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="DepositeChart.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                     <p  style="color:Yellow;">Deposite Transaction</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="NewCustomerChart.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Customer Information</p>
                </a>
              </li>
                   <li class="nav-item">
                <a href="FieldOfficer.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Officer Daily Payment</p>
                </a>
              </li>
               <li class="nav-item">
                <a href="Tmt2.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Find Daily Payment</p>
                </a>
              </li>
                <li class="nav-item">
                <a href="AdminDashboard.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Debit Control</p>
                </a>
              </li>
               <li class="nav-item">
                <a href="MDauthentication1.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Staff Permission</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="CustomerView.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                    <p  style="color:Yellow;">Customer Biodata</p>

                </a>
              </li>
              <li class="nav-item">
                <a href="CustomerCare.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">FieldOfficer Daily Trans</p>
                </a>
              </li>
             
            </ul>
          </li>
          <li class="nav-item has-treeview">
            <a href="" class="nav-link">
              <i class="nav-icon fas fa-tree"></i>
              <p>
                General Report
                <i class="fas fa-angle-left right"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="PrintChart.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Transaction Report</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="MonthlyProfit.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Financial Report</p>
                </a>
              </li>
               <li class="nav-item">
                <a href="MDTmt.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">TMTransaction</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="LoanBioData.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Commercial Transfer</p>
                </a>
              </li>
               <li class="nav-item">
                <a href="File.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Upload Document</p>
                </a>
              </li>
               <li class="nav-item">
                <a href="MDview.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Download Document</p>
                </a>
              </li>
            </ul>
          </li>
          <li class="nav-item has-treeview">
            <a href="" class="nav-link">
              <i class="nav-icon far fa-envelope"></i>
              <p>
                Private Document
                <i class="fas fa-angle-left right"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="privateLoan.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Private LOAN</p>
                </a>
                </li>
                <li class="nav-item">
                    <a href="privateTMT.aspx" class="nav-link">
                      <i class="far fa-circle nav-icon"></i>
                      <p  style="color:Yellow;">Private TMT</p>
                   </a>
                </li>
                <li class="nav-item">
                    <a href="privateAccount.aspx" class="nav-link">
                      <i class="far fa-circle nav-icon"></i>
                      <p  style="color:Yellow;">Private ACCOUNT</p>
                   </a>
                </li>
            </ul>
          <li class="nav-item has-treeview">
            <a href="" class="nav-link">
              <i class="nav-icon fas fa-edit"></i>
              <p>
                Inventory
                <i class="fas fa-angle-left right"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="Inventory.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Add Inventory</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="ViewInventory.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">View Inventory</p>
                </a>
              </li>
           
            </ul>
          </li>
          <li class="nav-item has-treeview">
            <a href="" class="nav-link">
              <i class="nav-icon fas fa-table"></i>
              <p>
                Loan Management
                <i class="fas fa-angle-left right"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="ViewCollateral.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">View Loan Collateral</p>
                </a>
              </li>  
                <li class="nav-item">
                <a href="Guarantor.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">View Loan Guarantor</p>
                </a>
              </li>
               <li class="nav-item">
                <a href="LoanAgreement1.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                 <p  style="color:Yellow;">Loan Biodata</p>
                </a>
              </li>
                <li class="nav-item">
                <a href="LoanChart.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Loan Transaction</p>
                </a>
              </li>
            </ul>
          </li>
         
          <li class="nav-item has-treeview">
            <a href="" class="nav-link">
              <i class="nav-icon far fa-envelope"></i>
              <p>
                Teller Till
                <i class="fas fa-angle-left right"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="Tmt2.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p  style="color:Yellow;">Find Daily Payment</p>
                </a>
                </li>
                <li class="nav-item">
                    <a href="TillApproved.aspx" class="nav-link">
                      <i class="far fa-circle nav-icon"></i>
                      <p  style="color:Yellow;">Approve Till</p>
                   </a>
                </li>
            </ul>
          </li>
            
             
          
        
        </ul>
      </nav>
      <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
  </aside> 

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
         <li class="nav-item">
        <a class="nav-link" data-widget="pushmenu" href="#" role="button"><i class="fas fa-bars"></i></a>
      </li>
          <div class="col-sm-6">     
              <li style="color:blue;"><marquee>Welcome To Zealluck Resources[NIG] Limited!</marquee></li>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->

    <!-- Main content -->


         <table>

          
         <tr>
            <td class="style6" style="color:Black; position:absolute; left:715px; top:184px; font-size:small"><asp:TextBox ID="txtarea" placeholder="SMS Message To All Staff.." TextMode="MultiLine" Height="137px" runat="server" Width="502px"></asp:TextBox>
                <asp:TextBox ID="txtid" runat="server" placeholder="Enter AccountNo" Height="40px" Width="146px"></asp:TextBox>
              
            <br /><br />

              <asp:Button ID="Button5" runat="server" Height="52px" Width="130px"
                     Text="Send SMS To Staff" 
                    onclick="Button5_Click" />
            <asp:Button ID="Button4" runat="server" Height="52px" Width="141px"  
                    Text="Insert Staff PhoneNo" onclick="Button4_Click" />
            
                <asp:Button ID="Button9" runat="server"  Height="57px" Width="226px"  
                    Text="Delete Dormant Account" onclick="Button9_Click" />
            
            <td>
              
           
            </td>        
         </tr>
              <tr>
                 <td class="style3" style="left:790px; top:120px; position:absolute;  color:Black; font-size:medium"><label>
                     <asp:DropDownList ID="txtbranch"  Height="55px"  Width="116px" runat="server">
                     <asp:ListItem>Select Branch</asp:ListItem>
                     <asp:ListItem>Ikorodu Lagos</asp:ListItem>
                     <asp:ListItem>Yaba Lagos</asp:ListItem>
                     <asp:ListItem>Ikeja Lagos</asp:ListItem>
                      <asp:ListItem>Aja Lagos</asp:ListItem>

                     <asp:ListItem>X Lagos</asp:ListItem>
                     <asp:ListItem>Y Lagos</asp:ListItem>
                     <asp:ListItem>Z Lagos</asp:ListItem>
                     </asp:DropDownList>
                     </label></td>
                 <td class="style5" style="color:Black; left:590px; top:120px; position:absolute; font-size:large">
                     <asp:DropDownList ID="txtall" Height="55px" TextMode="time"  Width="195px" runat="server">
                         <asp:ListItem>Find All</asp:ListItem>
                         <asp:ListItem>All</asp:ListItem>
                         <asp:ListItem>Deposite</asp:ListItem>
                         <asp:ListItem>DepositeHead</asp:ListItem>
                         <asp:ListItem>Withdraw</asp:ListItem>
                         <asp:ListItem>CustomerCare</asp:ListItem>
                         <asp:ListItem>Admin</asp:ListItem>
                         <asp:ListItem>HResources</asp:ListItem>
                         <asp:ListItem>Loan</asp:ListItem>
                         <asp:ListItem>Accounting</asp:ListItem>
                         <asp:ListItem>TMTCheckRecord</asp:ListItem>
                         <asp:ListItem>TMTFieldOfficerChat</asp:ListItem>
                         <asp:ListItem>TMTDateControlLogin</asp:ListItem>
                     
                         
                     </asp:DropDownList>
                 </td>
             </tr>
               <tr>
            <td class="style6" style="color:Black; position:absolute; left:910px; top:111px; font-size:small"><asp:TextBox ID="txtusername" TextMode="Search" placeholder="UserName" Height="55px" runat="server" Width="155px"></asp:TextBox>
                <asp:Button ID="Button6" runat="server" Height="55px"  Width="79px"     Text="Move Staff" 
                    onclick="Button6_Click" />
                   <asp:Button ID="Button11" runat="server" Height="55px" Text="Post To Withdraw" 
                    onclick="Button11_Click" Width="119px" />
                   <asp:Button ID="Button12" runat="server"  Width="120px"  Height="55px" 
                    Text="Withdraw To Post" onclick="Button12_Click"/>
                   </td>
         </tr>
             
             
          <tr  class="style4" style="color:Black;  left:550px; top:350px; font-size:medium">
                  
            <td>
               
               
               <asp:Button ID="displaymessage2" runat="server" Text="Find User" 
        onclick="Button1_Click1" Height="37px" Width="104px"   />
               
               <asp:Button ID="displaymessage4" runat="server" Text="Activate" 
        onclick="Button3_Click1" Height="37px" Width="108px"  />
                <asp:Button ID="Button2" runat="server" Text="De-Activate"  Height="37px" Width="114px" OnClick="Button2_Click" />
                <br />
                 
            <td>
               
               
                <asp:Label ID="Lab2" runat="server"></asp:Label>
                <asp:Label ID="Label3" runat="server"></asp:Label>
           </td>
        
           </tr>
             


          <td class="style3" style="left:280px; top:440px; position:absolute;  color:Maroon; font-size:medium; text-transform: none; font-style: normal; font-weight: lighter; font-family: Consolas; background-color: #CCFFCC;"
         <asp:GridView ID="GridView1" runat="server" Width="1076px">
        
          </asp:GridView>
        <asp:Label ID="Lab1" runat="server"></asp:Label>
        <asp:Button ID="Button3" runat="server" Text="Delete User" onclick="Button3_Click" />
    </td>
   
          
        </table>
          
</div>
</div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
   <strong>Copyright &copy; <asp:Label ID="Label2" runat="server"></asp:Label><asp:Label ID="Label4" runat="server"></asp:Label> <a href="">Developer Laboratory</a>.</strong>
    All rights reserved.
    <div class="float-right d-none d-sm-inline-block">
      <b>Developer</b> Ogu Christian Uzodinma
    </div>
  </footer>

  <!-- Control Sidebar -->
  <aside class="control-sidebar control-sidebar-dark">
    <!-- Control sidebar content goes here -->
  </aside>
  <!-- /.control-sidebar -->
</div>
<!-- ./wrapper -->

<!-- jQuery -->
<script src="plugins/jquery/jquery.min.js"></script>
<!-- jQuery UI 1.11.4 -->
<script src="plugins/jquery-ui/jquery-ui.min.js"></script>
<!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
<script>
    $.widget.bridge('uibutton', $.ui.button)
</script>
<!-- Bootstrap 4 -->
<script src="plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- ChartJS -->
<script src="plugins/chart.js/Chart.min.js"></script>
<!-- Sparkline -->
<script src="plugins/sparklines/sparkline.js"></script>
<!-- JQVMap -->
<script src="plugins/jqvmap/jquery.vmap.min.js"></script>
<script src="plugins/jqvmap/maps/jquery.vmap.usa.js"></script>
<!-- jQuery Knob Chart -->
<script src="plugins/jquery-knob/jquery.knob.min.js"></script>
<!-- daterangepicker -->
<script src="plugins/moment/moment.min.js"></script>
<script src="plugins/daterangepicker/daterangepicker.js"></script>
<!-- Tempusdominus Bootstrap 4 -->
<script src="plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>
<!-- Summernote -->
<script src="plugins/summernote/summernote-bs4.min.js"></script>
<!-- overlayScrollbars -->
<script src="plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
<!-- AdminLTE App -->
<script src="dist/js/adminlte.js"></script>
<!-- AdminLTE dashboard demo (This is only for demo purposes) -->
<script src="dist/js/pages/dashboard.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="dist/js/demo.js"></script>

    </div>
    </form>
</body>
</html>

