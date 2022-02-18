<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerCare.aspx.cs" Inherits="BankA.CustomerCare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<style>

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
  <title>CustomerCareChart | Dashboard</title>
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
            <h5 class="m-0 text-dark">CustomerCareChart</h5>
          </div><!-- /.col -->
   

    <!-- Right navbar links -->
    <ul class="navbar-nav ml-auto">
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="AdminActivate.aspx">
          <i class="far fa-comments"></i>
          <span class="badge badge-danger navbar-badge">3</span>
        </a>
        <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
          <a href="AdminActivate.aspx" class="dropdown-item"></a>    
     
      </li>
      <!-- Notifications Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="#">
          <i class="far fa-bell"></i>
          <span class="badge badge-warning navbar-badge">15</span>
        </a>
        <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
          <span class="dropdown-item dropdown-header">15 Notifications</span>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item">
            <i class="fas fa-envelope mr-2"></i> 4 new messages
            <span class="float-right text-muted text-sm">3 mins</span>
          </a>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item">
            <i class="fas fa-users mr-2"></i> 8 friend requests
            <span class="float-right text-muted text-sm">12 hours</span>
          </a>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item">
            <i class="fas fa-file mr-2"></i> 3 new reports
            <span class="float-right text-muted text-sm">2 days</span>
          </a>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item dropdown-footer">See All Notifications</a>
        </div>
      </li>
      <li class="nav-item">
        <a class="nav-link" data-widget="control-sidebar" data-slide="true" href="#" role="button">
          <i class="fas fa-th-large"></i>
        </a>
      </li>
    </ul>
  </nav>
  <!-- /.navbar -->

  <!-- Main Sidebar Container -->
  <aside class="main-sidebar sidebar-dark-primary elevation-4">
    <!-- Brand Logo -->
  <a href="" class="brand-link">
      <img src="zealluckLogo.PNG" height="65px" width="65px" alt="AdminLTE Logo" "n-3"
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
          <a href="" class="d-block">Admin Control</a>
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
                  <p>Permit User</p>
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
           <td class="style3" style="left:200px; top:130px; position:absolute;  color:Black; font-size:medium"><label></label></td>
              <td class="style15" style="color:Black; top:140px; left:660px; position:absolute; font-size:small">
                <asp:TextBox ID="txtAccountNo" runat="server" placeholder="AccountNo" TextMode="Search" Width="125px" Height="35px"></asp:TextBox>
              </td> 

                <td class="style5" style="color:Black; left:792px; top:149px; position:absolute;  font-size:medium">                       
                     <asp:DropDownList ID="txtmonth"  TextMode="Search"  Width="122px" Height="34px" runat="server">
                         <asp:ListItem>Select Month</asp:ListItem>
                         <asp:ListItem>January</asp:ListItem>
                         <asp:ListItem>Febuary</asp:ListItem>
                         <asp:ListItem>March</asp:ListItem>
                         <asp:ListItem>Appril</asp:ListItem>
                         <asp:ListItem>May</asp:ListItem>

                         <asp:ListItem>June</asp:ListItem>
                         <asp:ListItem>July</asp:ListItem>
                         <asp:ListItem>August</asp:ListItem>
                         <asp:ListItem>September</asp:ListItem>
                         <asp:ListItem>October</asp:ListItem>
                         <asp:ListItem>November</asp:ListItem>
                         <asp:ListItem>December</asp:ListItem>
                     </asp:DropDownList></td>
          </tr>     
         
              

         <tr>
            <td class="style6" style="color:Black; position:absolute; left:922px; top:148px; font-size:small"><asp:TextBox ID="txtdate2"  TextMode="Date" Height="35px" runat="server" Width="208px"></asp:TextBox></td>
         </tr>
         <tr>
            <td class="style6" style="color:Black; position:absolute; left:1135px; top:148px; font-size:small"><asp:TextBox ID="txtdate3"  TextMode="Date" Height="35px" runat="server" Width="200px"></asp:TextBox></td>
         </tr>
               <tr>
            <td class="style6" style="color:Black; position:absolute; left:660px; top:190px; font-size:small">
                <asp:TextBox ID="txtall" TextMode="Search" value="All" Height="34px" 
                    runat="server" Width="130px"></asp:TextBox>
                <asp:TextBox ID="txtmonthyear" runat="server" placeholder="03/2021"  Height="34px"  Width="121px"></asp:TextBox>
                   </td>
       
          <tr>
               <p style="top:120px;  left:922px; position:absolute;">Deposite</p>
               <td class="style5" style="color:Black; left:922px; top:190px; position:absolute;  font-size:medium">                   
                    <asp:TextBox ID="txtofficerss"  Height="35px" TextMode="Search" placeholder="FieldOfficer-Name" runat="server" Width="205px"></asp:TextBox></td>

                     <p style="top:120px;  left:1135px; position:absolute;">Withdraw</p>
                     <td class="style5" style="color:Black; left:1135px; top:190px; position:absolute;  font-size:medium">                       
                     <asp:TextBox ID="txtofficers"  Height="35px" TextMode="Search" placeholder="FieldOfficer-Name" runat="server" Width="200px"></asp:TextBox></td>
                 &nbsp;&nbsp;
                  </tr>
             
             
          <tr  class="style4" style="color:Black;  left:550px; top:350px; font-size:medium">
                  
            <td>
               <br /> <br /> <br /><br /> 
               
               <asp:Button ID="displaymessage2" runat="server" Text="TranType Withdraw" 
        onclick="Button1_Click1" Height="43px" Width="145px"   />
               
               <asp:Button ID="displaymessage4" runat="server" Text="Dormant Account" 
        onclick="Button3_Click1" Height="43px" Width="144px"  />
                <asp:Button ID="Button2" runat="server" Text="All PhoneNo"  Height="43px" Width="114px" OnClick="Button2_Click" />
                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="TranType Deposite" 
                    Width="158px"  Height="43px" />
                <asp:Button ID="Button5" runat="server"  Width="122px"  Height="60px" 
                    Text="SMS Balance" onclick="Button51_Click" />
                <asp:DropDownList ID="DropDownList1" Height="60px" Width="169px"  
                    runat="server">
                    <asp:ListItem>Select AccountType</asp:ListItem>
                         <asp:ListItem>Soft Saving Yaba</asp:ListItem>
                         <asp:ListItem>Soft Saving Ikeja</asp:ListItem>
                         <asp:ListItem>Soft Saving Ikorodu</asp:ListItem>
                         <asp:ListItem>Soft Saving Aja</asp:ListItem>
                         <asp:ListItem>Soft Saving X</asp:ListItem>
                         <asp:ListItem>Soft Saving Y</asp:ListItem>
                         <asp:ListItem>Soft Saving Z</asp:ListItem>

                         <asp:ListItem>-------------------</asp:ListItem>
                         <asp:ListItem>Flexible Yaba</asp:ListItem>
                         <asp:ListItem>Flexible Ikeja</asp:ListItem>
                         <asp:ListItem>Flexible Ikorodu</asp:ListItem>
                         <asp:ListItem>Flexible Aja</asp:ListItem>
                               <asp:ListItem>Flexible X</asp:ListItem>
                         <asp:ListItem>Flexible Y</asp:ListItem>
                         <asp:ListItem>Flexible Z</asp:ListItem>
                         <asp:ListItem>-------------------</asp:ListItem>
                         <asp:ListItem>Buck Fixed Account Yaba</asp:ListItem>
                         <asp:ListItem>Buck Fixed Account Ikeja</asp:ListItem>
                         <asp:ListItem>Buck Fixed Account Ikorodu</asp:ListItem>
                         <asp:ListItem>Buck Fixed Account Aja</asp:ListItem>
                         <asp:ListItem>Buck Fixed Account X</asp:ListItem>
                         <asp:ListItem>Buck Fixed Account Y</asp:ListItem>
                         <asp:ListItem>Buck Fixed Account Z</asp:ListItem>
                       
                         <asp:ListItem>--------------------------</asp:ListItem>
                         <asp:ListItem>Target Account Yaba</asp:ListItem>
                         <asp:ListItem>Target Account Ikeja</asp:ListItem>
                         <asp:ListItem>Target Account Ikorodu</asp:ListItem>
                         <asp:ListItem>Target Account Aja</asp:ListItem>
                         <asp:ListItem>Target Account X</asp:ListItem>
                         <asp:ListItem>Target Account Y</asp:ListItem>
                         <asp:ListItem>Target Account Z</asp:ListItem>
                         <asp:ListItem>--------------------------</asp:ListItem>
                         <asp:ListItem>Loan Account Yaba</asp:ListItem>
                         <asp:ListItem>Loan Account Ikeja</asp:ListItem>
                         <asp:ListItem>Loan Account Ikorodu</asp:ListItem>
                         <asp:ListItem>Loan Account Aja</asp:ListItem>
                          <asp:ListItem>Loan Account X</asp:ListItem>
                         <asp:ListItem>Loan Account Y</asp:ListItem>
                         <asp:ListItem>Loan Account Z</asp:ListItem>
  </asp:DropDownList>
                <asp:Button ID="Button6" runat="server"  Width="82px"  Height="60px" 
                    Text="SMS Bal" onclick="Button59_Click" />
                <br />
                 
            <td>
               
               <br /><br /><br /><br />
          </td>
                  <td style="color:Blue; position:absolute; top:105px; color:Green; font-size:large; font-family:MS Sans Serif; left:300px;"> <p> <asp:Label ID="Lab2" BorderColor="green" CssClass="green" Height="120px" runat="server"></asp:Label></p></td> 
                  <td style="color:Blue; position:absolute;top:93px; color:Maroon; font-size:xx-large; font-family:Calibri Light; left:480px;">  <p> <asp:Label ID="Lab14" BorderColor="Maroon" CssClass="Maroon" Height="120px" runat="server"></asp:Label></p></td> 
        
           </tr>
             
   <td class="style3" style="left:253px; top:380px; position:absolute;  color:Maroon; font-size:medium; text-transform: none; font-style: normal; font-weight: lighter; font-family: Consolas; background-color: #CCFFCC;"
          <asp:GridView ID="GridView1" runat="server" Width="1090px">
    
          </asp:GridView>
        <asp:Label ID="Lab1" runat="server"></asp:Label>
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