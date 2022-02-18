﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountHRview.aspx.cs" Inherits="BankA.AccountHRview" %>

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
    border-bottom: 0px solid #0099FF;
	font-size:12px;
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
	color:Black;
}
  
</style>
     <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>HR-Payment Payroll | Dashboard</title>
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
            <h5 class="m-0 text-dark">HR-Payment Payroll</h5>
            <asp:Label ID="Lab5" runat="server"></asp:Label>
          </div><!-- /.col -->
   

    
    <!-- Right navbar links -->
    <ul class="navbar-nav ml-auto">
      <!-- Messages Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="">
          <i class="far fa-comments" style="position:absolute; width:200px; top:9px; right:150px;"> <asp:Label ID="Label1" runat="server" Font-Size="Larger"></asp:Label> </i>
          <span class="badge badge-danger navbar-badge"></span>
          </a>
         <div style="position:absolute; background-color:White; top:5px; right:0px; width: 70px;"> <asp:Button ID="Button3" runat="server" Text="LogOut" Font-Size="Small" BackColor="White" BorderColor="White" Height="30px" Width="70px" ForeColor="BlueViolet" onclick="Button1_Click"></asp:Button>
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
          <img src="imagery/uche.png" class="img-circle elevation-2" alt="User Image">
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
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="AdminLogin1.aspx" class="nav-link active">
                  <i class="far fa-circle nav-icon"></i>
                  <p>User Permission</p>
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
              <li style="color:blue;"><marquee>Zealluck Resources[NIG] Limited</marquee></li>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->

    <!-- Main content -->


         <table>

         
                <tr>
                 <td class="style3" style="left:260px; top:134px; position:absolute;  color:Black; font-size:large"><label>Month Salary Payment:</label></td>
                 <td class="style2" style="color:Black;  left:500px; top:134px; position:absolute; font-size:medium"><asp:DropDownList ID="txtmonth" Height="55px" TextMode="Search"  Width="330px" runat="server">
                         <asp:ListItem>Select Month </asp:ListItem>
                         <asp:ListItem>January</asp:ListItem>
                         <asp:ListItem>Febuary</asp:ListItem>
                         <asp:ListItem>March</asp:ListItem>
                         <asp:ListItem>April</asp:ListItem>
                         <asp:ListItem> May</asp:ListItem>

                         <asp:ListItem>June</asp:ListItem>
                         <asp:ListItem>July</asp:ListItem>
                         <asp:ListItem>August</asp:ListItem>
                         <asp:ListItem>September</asp:ListItem>
                         <asp:ListItem> October</asp:ListItem>
                         
                         <asp:ListItem>November</asp:ListItem>
                         <asp:ListItem>December</asp:ListItem>
                        
                     </asp:DropDownList>
                  <asp:TextBox ID="TextBox1" runat="server"  Height="55px" Width="73px"></asp:TextBox>
                     <asp:Label ID="Label2" runat="server" Text="No oF Days OR Year"></asp:Label>
                    </td>
             </tr>

               <tr>
           <td  class="style3" style="left:260px; top:211px; position:absolute;  color:Black; font-size:medium">
              <label>StaffName:</label> </td>
              <td class="style15" style="color:Black; left:500px; top:200px; position:absolute; font-size:medium">
                <asp:TextBox ID="txtstaff" runat="server" TextMode="Search" Width="330px" Height="35px"></asp:TextBox>
                  <asp:Button ID="Button5" runat="server"  Height="35px" Text="Calculate" 
                      onclick="Button5_Click" />
            </td> 
          </tr>        
             
                <tr>
                 <td class="style3" style="left:260px; top:260px; position:absolute;  color:Black; font-size:medium"><label>Branch:</label></td>
                 <td class="style2" style="color:Black; left:500px; top:257px; position:absolute; font-size:medium"><asp:DropDownList ID="txtbr" Height="35px" TextMode="Search"  Width="330px" runat="server">
                     <asp:ListItem>Select Branch</asp:ListItem>
                     <asp:ListItem>Ikeja Lagos</asp:ListItem>
                     <asp:ListItem>Ikorodu Lagos</asp:ListItem>
                     <asp:ListItem>Yaba Lagos</asp:ListItem>
                      <asp:ListItem>Aja Lagos</asp:ListItem>
                     <asp:ListItem>X Lagos</asp:ListItem>
                     <asp:ListItem>Y Lagos</asp:ListItem>
                     <asp:ListItem>Z Lagos</asp:ListItem>
                     </asp:DropDownList></td>
             </tr>
         
             
       
          <tr>
                  
            <td class="style4" style="color:darkblue; left:500px;   top:280px; font-size:medium">
               <br /> <br /> <br /> <br /> <br /> <br /> 
               <asp:Button ID="displaymessage2" runat="server" Text="View Payroll" 
        onclick="Button1_Click1" Height="50px" Width="167px"  BorderStyle="Double" />
             
           
                <asp:Button ID="Button1" runat="server" Text="14 Days Leave" 
        onclick="Button1_Click2" Height="50px" Width="199px"  BorderStyle="Double" />

      
                 <asp:Button ID="Button4" runat="server" Height="50px" Width="240px"  
                    Text="14 Days Off" onclick="Button4_Click" />

                           <asp:Label Font-Size="X-Large" ID="Label5" runat="server" Text="Label"></asp:Label>


      
                 <br />
                

                <div style="position:absolute; left:530px; top:680px; color:Blue; font-size:large; font-family:Arial Black;">
                <label  style="font-size:medium;" ></label>
                </div>

                
             
           </td>
           </tr>


       <td class="style3" style="left:260px; top:459px; position:absolute;  color:Maroon; font-size:medium; text-transform: none; font-style: normal; font-weight: lighter; font-family: Consolas; background-color: #CCFFCC;"
          <asp:GridView ID="GridView1" runat="server" Width="1046px">
    
          </asp:GridView>
        <asp:Label ID="Lab1" runat="server"></asp:Label>
        <asp:Label ID="Label3" runat="server"></asp:Label>
    </td>
   
    <br /><br /><br /><br />
    </td>
   
          
        </table>
          
</div>
</div>
 
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