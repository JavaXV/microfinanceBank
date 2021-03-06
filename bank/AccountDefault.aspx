<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountDefault.aspx.cs" Inherits="BankA.AccountDefault" %>

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
  <title>TMT | Dashboard</title>
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
            <h5 class="m-0 text-dark">TransactionMonitoryTeam</h5>
          </div><!-- /.col -->
   

    
    <!-- Right navbar links -->
    <ul class="navbar-nav ml-auto">
      <!-- Messages Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="">
          <i class="far fa-comments" style="position:absolute; width:200px; top:9px; right:150px;"> <asp:Label ID="Label1" runat="server" Font-Size="Larger"></asp:Label> </i>
          <span class="badge badge-danger navbar-badge"></span>
          </a>
         <div style="position:absolute; background-color:White; top:5px; right:0px; height: 30px; width: 70px;"> <asp:Button ID="Button3" runat="server" Text="LogOut" Font-Size="Small" BackColor="White" BorderColor="White" Height="30px" Width="70px" ForeColor="BlueViolet" onclick="Button1_Click"></asp:Button>
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
          <img src="20210807-141644.png" class="img-circle elevation-2" alt="User Image">
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
              <li style="color:blue;"><marquee>Welcome to Zealluck Resources[NIG] Limited</marquee></li>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->

    <!-- Main content -->


         <table>

         
                <tr>
                 <td class="style3" style="left:260px; top:134px; position:absolute;  color:Black; font-size:large"><label>Field Officer:</label></td>
                 <td class="style2" style="color:Black;  left:500px; top:134px; position:absolute; font-size:medium"><asp:DropDownList ID="txtofficer" Height="35px" TextMode="Search"  Width="350px" runat="server">
                     <asp:ListItem>Select Officer </asp:ListItem>
                    <asp:ListItem>TUNJI BOLAGI</asp:ListItem>
                         <asp:ListItem>IFEANYI OKOWA</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                     </asp:DropDownList></td>
             </tr>
    
                <tr>
                 <td class="style3" style="left:260px; top:180px; position:absolute;  color:Black; font-size:large"><label>All:</label></td>
                 <td class="style2" style="color:Black;  left:500px; top:180px; position:absolute; font-size:medium"><asp:DropDownList ID="txtall" Height="35px" TextMode="Search"  Width="350px" runat="server">
                     <asp:ListItem>Select </asp:ListItem>
                     <asp:ListItem>All</asp:ListItem>
                     </asp:DropDownList></td>
             </tr>
               <tr>
                 <td class="style3" style="left:260px; top:220px; position:absolute;  color:Black; font-size:large"><label>Approved Status:</label></td>
                 <td class="style5" style="color:Black; left:500px; top:220px; position:absolute; font-size:medium">
                     <asp:DropDownList ID="txtapproved" Height="35px" TextMode="Search"  Width="350px" runat="server">
                         <asp:ListItem>Select Approval</asp:ListItem>
                         <asp:ListItem>Approvedd</asp:ListItem>
                         <asp:ListItem>Pending</asp:ListItem>  
                         <asp:ListItem>Not-Approved</asp:ListItem> 
                      
                     </asp:DropDownList>
                 </td>
             </tr>

          <tr>
               <td class="style3" style="left:260px; top:271px; position:absolute;  color:Black; font-size:medium"><label>Date:</label></td>
               <td class="style6" style="color:Black;  left:500px; top:258px; position:absolute; font-size:medium"><asp:TextBox ID="txtdate"  Height="35px" TextMode="Date" runat="server" Width="349px"></asp:TextBox>    
               </td>         
         </tr>

         
          <tr>
               <td class="style3" style="left:260px; top:318px; position:absolute;  color:Black; font-size:medium"><label>Approved Date:</label></td>
               <td class="style6" style="color:Black;  left:500px; top:310px; position:absolute; font-size:medium"><asp:TextBox ID="txtapproveddate"  Height="35px" TextMode="Date" runat="server" Width="349px"></asp:TextBox>    
               </td>         
         </tr>
            <tr>
               <td class="style3" style="left:260px; top:372px; position:absolute;  color:Black; font-size:medium"><label>Approved By:</label></td>
               <td class="style6" style="color:Black;  left:500px; top:360px; position:absolute; font-size:medium"><asp:TextBox ID="txtapprovedby"  Height="35px" TextMode="Search" runat="server" Width="349px"></asp:TextBox>    
               </td>         
         </tr>
           <tr>
                 <td class="style3" style="left:260px; top:426px; position:absolute;  color:Black; font-size:medium"><label>Branch:</label></td>
                 <td class="style2" style="color:Black;  position:absolute; left:500px; top:422px; font-size:medium;"><asp:DropDownList ID="txtbranch" Height="35px" TextMode="Search"  Width="342px" runat="server">
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
                  
            <td class="style4" style="color:darkblue; left:500px;   top:180px; font-size:medium">
               <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br />  <br /> <br /> <br />  
               <asp:Button ID="displaymessage2" runat="server" Text="Approved" 
        onclick="Button1_Click1" Height="37px" Width="121px"  BorderStyle="Double" />
             
                <asp:Button ID="Button4" Height="37px" Width="144px" runat="server" 
                    Text="Search ALL" onclick="Button4_Click" />
             
                <asp:Button ID="Button5" runat="server" Height="37px" Width="149px"  
                    Text="Search FieldOfficer" onclick="Button5_Click" />
             
                 <asp:Button ID="Button6" runat="server" Text="Aproved All"  Height="37px" 
                    Width="186px" onclick="Button6_Click" />
             
                 <asp:Label ID="Lab5" runat="server"></asp:Label>
             
             
                      <br />
                <div style="position:absolute; left:100px; top:655px; color:Blue; font-size:x-large; font-family:Times New Roman TUR;">
                <label  style="font-size:medium;" ></label>
                <asp:Label ID="Lab2" runat="server"></asp:Label>
                </div>

                 <div style="position:absolute; left:1100px; top:655px; color:Green; font-size:x-large; font-family:Times New Roman TUR;">
                <label  style="font-size:medium;" ></label>
                <asp:Label ID="Lab4" runat="server"></asp:Label>
                </div>
                
                <div style="position:absolute; left:440px; top:655px; color:Orange; font-size:x-large; font-family:Times New Roman TUR;">
                <label style="font-size:medium;"></label>
                <asp:Label ID="Lab3" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label4" runat="server"></asp:Label>
             
                </div>

                <div style="position:absolute; left:800px; top:655px; color:Blue; font-size:x-large; font-family:Times New Roman TUR;">
                <label  style="font-size:medium;" ></label>
                <asp:Label ID="Lab31" runat="server"></asp:Label>
                </div>
             
               
             
           </td>
           </tr>



        <td class="style3" style="left:100px; top:700px; position:absolute;  color:Maroon; font-size:medium; text-transform: none; font-style: normal; font-weight: lighter; font-family: Consolas; background-color: #CCFFCC;"
          <asp:GridView ID="GridView1" runat="server" Width="1206px">
    
    </asp:GridView>
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