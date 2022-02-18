d<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accounting.aspx.cs" Inherits="BankA.Accounting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<style>

    input[type=Date] {
    width: 100%;
    padding: 2px 20px;
    margin: 8px 0;
    border: none;
	background-color:#FFFFFF;
    border-bottom: 1px solid #0099FF;
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
    border-bottom: 1px solid #0099FF;
	font-size:16px;
	font-family:"Courier New", Courier, monospace;
	color:#0066FF;
}
  
</style>
     <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Accounting | Dashboard</title>
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
            <h5 class="m-0 text-dark">Accounting(Unit)</h5>
          </div><!-- /.col -->
   

   
    <!-- Right navbar links -->
    <ul class="navbar-nav ml-auto">
      <!-- Messages Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="">
          <i class="far fa-comments" style="position:absolute; width:200px; top:9px; right:150px;"> <asp:Label ID="Label1" runat="server" Font-Size="Larger"></asp:Label> </i>
          <span class="badge badge-danger navbar-badge"></span>
          </a>
         <div style="position:absolute; background-color:White; top:5px; right:0px;"> <asp:Button ID="Button2" runat="server" Text="LogOut" Font-Size="Small" BackColor="White" BorderColor="White" Height="30px" Width="70px" ForeColor="BlueViolet" onclick="Button1_Click"></asp:Button>
        </div>
     
    </ul>
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
             <a href="" class="d-block"> <asp:Label ID="Label20" runat="server" Font-Size="Medium"></asp:Label></a>
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
                Accounting
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
                <a href="CustomerView.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Customer Biodata</p>
                </a>
              <li class="nav-item">
                <a href="DepositeChart.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Deposite Transaction</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="NewCustomerChart.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Customer Information</p>
                </a>
              </li >
              <li class="nav-item">
                <a href="CustomerCare.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Daily FieldOfficer Trans</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="AccountDefault.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Find FieldOfficer Amount</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="LoanAgreement1.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Loan Biodata</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="LoanChart.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Loan Transaction</p>
                </a>
              </li>
              <li class="nav-item">
                    <a href="TellerTill.aspx" class="nav-link">
                      <i class="far fa-circle nav-icon"></i>
                      <p style="color:Yellow;">Add TellerTill</p>
                   </a>
              </li>
            </ul>
          </li>
           <li class="nav-item has-treeview">
            <a href="" class="nav-link">
              <i class="nav-icon fas fa-chart-pie"></i>
              <p>
                Account-HRView
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
             <li class="nav-item has-treeview">
              <li class="nav-item">
                <a href="AccountHRview.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Staff Salary 1</p>
                </a>
              </li>
               <li class="nav-item">
                <a href="AccountHRpay.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Staff Salary 2</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="PrintChart.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Transaction Report</p>
                </a>
              </li>
                <li class="nav-item">
                <a href="MDview.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Download Document</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="File.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Upload Document</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="privateAccount.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p style="color:Yellow;">Private Document Admin</p>
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
              <li style="color:blue;">Welcome To Zealluck Resources[NIG] Limited!</li>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->

    <!-- Main content -->

         <table>
         <marquee>
                 <h1  style ="font-size:xx-large; color:Maroon; position:absolute; right:20px;">ACCOUNTING</h1>
                 <br /><br /><br /><br />  
                        <h2  style ="font-size:x-large; color:Orange;">ACCOUNTING<br /><label> <h2  style ="font-size:smaller; color:Olive;"><img src="zealluckLogo.PNG" height="200" width="200" /></h2></label><label>  <h2  style ="font-size:xx-large; color:Green;">DEPARTMNET</h2></label></h2>
                        </marquee>
      
        </table>
    
        
    
</div>
</div>

  </aside>
  <!-- /.control-sidebar -->
</div>

    </div>
    </form>
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


</body>
</html>
