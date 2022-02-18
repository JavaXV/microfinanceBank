<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractAgreement.aspx.cs" Inherits="BankA.ContractAgreement" %>

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
    border-bottom: 2px solid #0099FF;
	font-size:12px;
	font-family:"Courier New", Courier, monospace;
	color:#0066FF;
}
  
</style>
     <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>AdminLTE 3 | Dashboard</title>
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
  <nav class="main-header navbar navbar-expand navbar-white navbar-light">
    <!-- Left navbar links -->
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" data-widget="pushmenu" href="#" role="button"><i class="fas fa-bars"></i></a>
      </li>
      <li class="nav-item d-none d-sm-inline-block">
        <a href="index3.html" class="nav-link">Home</a>
      </li>
      <li class="nav-item d-none d-sm-inline-block">
        <a href="#" class="nav-link">Contact</a>
      </li>
    </ul>

    <!-- SEARCH FORM -->
    <form class="form-inline ml-3">
      <div class="input-group input-group-sm">
        <input class="form-control form-control-navbar" type="search" placeholder="Search" aria-label="Search">
        <div class="input-group-append">
          <button class="btn btn-navbar" type="submit">
            <i class="fas fa-search"></i>
          </button>
        </div>
      </div>
    </form>

    <!-- Right navbar links -->
    <ul class="navbar-nav ml-auto">
      <!-- Messages Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="#">
          <i class="far fa-comments"></i>
          <span class="badge badge-danger navbar-badge">3</span>
        </a>
        <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
          <a href="#" class="dropdown-item">
            <!-- Message Start -->
            <div class="media">
              <img src="dist/img/user1-128x128.jpg" alt="User Avatar" class="img-size-50 mr-3 img-circle">
              <div class="media-body">
                <h3 class="dropdown-item-title">
                  Brad Diesel
                  <span class="float-right text-sm text-danger"><i class="fas fa-star"></i></span>
                </h3>
                <p class="text-sm">Call me whenever you can...</p>
                <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i> 4 Hours Ago</p>
              </div>
            </div>
            <!-- Message End -->
          </a>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item">
            <!-- Message Start -->
            <div class="media">
              <img src="dist/img/user8-128x128.jpg" alt="User Avatar" class="img-size-50 img-circle mr-3">
              <div class="media-body">
                <h3 class="dropdown-item-title">
                  John Pierce
                  <span class="float-right text-sm text-muted"><i class="fas fa-star"></i></span>
                </h3>
                <p class="text-sm">I got your message bro</p>
                <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i> 4 Hours Ago</p>
              </div>
            </div>
            <!-- Message End -->
          </a>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item">
            <!-- Message Start -->
            <div class="media">
              <img src="dist/img/user3-128x128.jpg" alt="User Avatar" class="img-size-50 img-circle mr-3">
              <div class="media-body">
                <h3 class="dropdown-item-title">
                  Nora Silvester
                  <span class="float-right text-sm text-warning"><i class="fas fa-star"></i></span>
                </h3>
                <p class="text-sm">The subject goes here</p>
                <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i> 4 Hours Ago</p>
              </div>
            </div>
            <!-- Message End -->
          </a>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item dropdown-footer">See All Messages</a>
        </div>
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
    <a href="index3.html" class="brand-link">
      <img src="dist/img/AdminLTELogo.png" alt="AdminLTE Logo" class="brand-image img-circle elevation-3"
           style="opacity: .8">
      <span class="brand-text font-weight-light">AdminLTE 3</span>
    </a>

    <!-- Sidebar -->
    <div class="sidebar">
      <!-- Sidebar user panel (optional) -->
      <div class="user-panel mt-3 pb-3 mb-3 d-flex">
        <div class="image">
          <img src="dist/img/user2-160x160.jpg" class="img-circle elevation-2" alt="User Image">
        </div>
        <div class="info">
          <a href="#" class="d-block">Adebayo Adewale</a>
        </div>
      </div>

      <!-- Sidebar Menu -->
      <nav class="mt-2">
        <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
          <!-- Add icons to the links using the .nav-icon class
               with font-awesome or any other icon font library -->
          <li class="nav-item has-treeview menu-open">
            <a href="#" class="nav-link active">
              <i class="nav-icon fas fa-tachometer-alt"></i>
              <p>
                Administration
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="./index.html" class="nav-link active">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Register User</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="./index2.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Permission Seetting</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="./index3.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Users</p>
                </a>
              </li>
            </ul>
          </li>
          <li class="nav-item">
            <a href="pages/widgets.html" class="nav-link">
              <i class="nav-icon fas fa-th"></i>
              <p>
                Widgets
                <span class="right badge badge-danger">New</span>
              </p>
            </a>
          </li>
          <li class="nav-item has-treeview">
            <a href="#" class="nav-link">
              <i class="nav-icon fas fa-copy"></i>
              <p>
                Transaction
                <i class="fas fa-angle-left right"></i>
                <span class="badge badge-info right">6</span>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="pages/layout/top-nav.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Deposite</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="pages/layout/top-nav-sidebar.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Withdraw</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="pages/layout/boxed.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>New Customer</p>
                </a>
              </li>
             
            </ul>
          </li>
          <li class="nav-item has-treeview">
            <a href="#" class="nav-link">
              <i class="nav-icon fas fa-chart-pie"></i>
              <p>
                General Ledgers
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="pages/charts/chartjs.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Chart Of Withdraw</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="pages/charts/flot.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Chart Of Deposite</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="pages/charts/inline.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Account History</p>
                </a>
              </li>
            </ul>
          </li>
          <li class="nav-item has-treeview">
            <a href="#" class="nav-link">
              <i class="nav-icon fas fa-tree"></i>
              <p>
                General Report
                <i class="fas fa-angle-left right"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="pages/UI/general.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Financial Statement</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="pages/UI/icons.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Transaction Report</p>
                </a>
              </li>
             
            </ul>
          </li>
          <li class="nav-item has-treeview">
            <a href="#" class="nav-link">
              <i class="nav-icon fas fa-edit"></i>
              <p>
                Inventory
                <i class="fas fa-angle-left right"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="pages/forms/general.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Add Inventory</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="pages/forms/advanced.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>View Inventory</p>
                </a>
              </li>
           
            </ul>
          </li>
          <li class="nav-item has-treeview">
            <a href="#" class="nav-link">
              <i class="nav-icon fas fa-table"></i>
              <p>
                Loan Management
                <i class="fas fa-angle-left right"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="pages/tables/simple.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Loan Contract Agreement</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="pages/tables/data.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Loan Extension</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="pages/tables/jsgrid.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Loan Weekly SMS</p>
                </a>
              </li>
            </ul>
          </li>
         
          <li class="nav-item has-treeview">
            <a href="#" class="nav-link">
              <i class="nav-icon far fa-envelope"></i>
              <p>
                New Customer
                <i class="fas fa-angle-left right"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="pages/mailbox/mailbox.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Customer Bio-Data</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="pages/mailbox/compose.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Start Transaction</p>
                </a>
              </li>
             
            </ul>
          </li>
          <li class="nav-item has-treeview">
            <a href="#" class="nav-link">
              <i class="nav-icon fas fa-book"></i>
              <p>
                Pages
                <i class="fas fa-angle-left right"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="pages/examples/invoice.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Invoice</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="pages/examples/profile.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Profile</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="pages/examples/e-commerce.html" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>E-commerce</p>
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
      <div class="container-fluid" style="position:absolute; bg-maroon">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0 text-dark">Contract Agreement</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Zealluck</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>


         <table>
         
    
        <tr>
           <td  class="style3" style="left:260px; top:120px; position:absolute;  color:Black; font-size:small"><label>
               CustomerID:</label></td>
              <td class="style15" style="color:Black; left:500px; top:100px; position:absolute; font-size:small">
                <asp:TextBox ID="txtid" runat="server"  TextMode="Search" Width="410px" Height="32px"></asp:TextBox>
                  <asp:Button ID="Button6" runat="server" Text="search" 
        onclick="Button4_Click1" Height="41px" Width="146px" OnClientClick="OnClientClicked" />
                 
            </td> 
          </tr>          <tr>
                 <td class="style3" style="left:260px; top:150px; position:absolute;  color:Black; font-size:small"><label>Branch:</label></td>
                 <td class="style2" style="color:Black; left:500px; top:150px; position:absolute;  font-size:small"><asp:DropDownList ID="txtbranch"  TextMode="Search" Width="410px" Height="32px" runat="server">
                     <asp:ListItem>Select Branch</asp:ListItem>
                     <asp:ListItem>Ikeja Lagos</asp:ListItem>
                     <asp:ListItem>Ikorodu Lagos</asp:ListItem>
                     <asp:ListItem>Yaba Lagos</asp:ListItem>
                      <asp:ListItem>X Lagos</asp:ListItem>
                     <asp:ListItem>Y Lagos</asp:ListItem>
                     </asp:DropDownList></td>
             </tr>
               <tr>
                 <td class="style3" style="left:260px; top:190px; position:absolute;  color:Black; font-size:small"><label>Field Officer:</label></td>
                 <td class="style5" style="color:Black; left:500px; top:190px; position:absolute;  font-size:small">
                     <asp:DropDownList ID="txtofficer"  TextMode="Search"  Width="410px" Height="32px" runat="server">
                         <asp:ListItem>Select Officers</asp:ListItem>
                         <asp:ListItem>Tunji Bolade</asp:ListItem>
                     </asp:DropDownList>
                 </td>
             </tr>
             
        <tr>
           <td  class="style3" style="left:260px; top:237px; position:absolute;  color:Black; font-size:small"><label>
               Contract/AccountNo:</label></td>
              <td class="style15" style="color:Black; left:500px; top:225px; position:absolute; font-size:small">
                <asp:TextBox ID="TextBox1" runat="server"  TextMode="Search" Width="310px" Height="32px"></asp:TextBox>
            </td> 
          </tr>        
           <tr>
           <td  class="style3" style="left:260px; top:280px; position:absolute;  color:Black; font-size:small">
               CustomerName:</td>
              <td class="style15" style="color:Black; left:500px; top:270px; position:absolute; font-size:small">
                <asp:TextBox ID="TextBox2" runat="server"  TextMode="Search" Width="310px" Height="32px"></asp:TextBox>
                  </td> 
          </tr>        
              <tr>
           <td  class="style3" style="left:260px; top:320px; position:absolute;  color:Black; font-size:small"><label>
               Contract Date:</label></td>
              <td class="style15" style="color:Black; left:500px; top:310px; position:absolute; font-size:small">
                <asp:TextBox ID="TextBox3" runat="server"  TextMode="Search" Width="138px" 
                      Height="32px"></asp:TextBox>
            &nbsp;TO<asp:TextBox ID="TextBox13" runat="server"  TextMode="Search" Width="147px" 
                      Height="32px"></asp:TextBox>
            </td> 
          </tr> 
              <tr>
           <td  class="style3" style="left:260px; top:360px; position:absolute;  color:Black; font-size:small"><label>
               Maturity Date:</label></td>
              <td class="style15" style="color:Black; left:500px; top:350px; position:absolute; font-size:small">
                <asp:TextBox ID="TextBox4" runat="server"  TextMode="Search" Width="310px" Height="32px"></asp:TextBox>
            </td> 
          </tr>               
                <tr>
           <td  class="style3" style="left:260px; top:400px; position:absolute;  color:Black; font-size:small"><label>
               Loan Amount:</label></td>
              <td class="style15" style="color:Black; left:500px; top:390px; position:absolute; font-size:small">
                <asp:TextBox ID="TextBox5" runat="server"  TextMode="Search" Width="310px" Height="32px"></asp:TextBox>
            </td> 
          </tr>               
                 <tr>
           <td  class="style3" style="left:260px; top:440px; position:absolute;  color:Black; font-size:small">
               Approved <label>
               Date:</label></td>
              <td class="style15" style="color:Black; left:500px; top:430px; position:absolute; font-size:small">
                <asp:TextBox ID="TextBox6" runat="server"  TextMode="Search" Width="310px" Height="32px"></asp:TextBox>
            </td> 
          </tr>     
          <tr>
           <td  class="style3" style="left:260px; top:480px; position:absolute;  color:Black; font-size:small"><label>
               Mode Of Payment:</label></td>
              <td class="style15" style="color:Black; left:500px; top:470px; position:absolute; font-size:small">
                <asp:TextBox ID="TextBox7" runat="server"  TextMode="Search" Width="310px" Height="32px"></asp:TextBox>
            </td> 
          </tr>                         

               <tr>
           <td  class="style3" style="left:260px; top:520px; position:absolute;  color:Black; font-size:small"><label>
               Customer Address:</label></td>
              <td class="style15" style="color:Black; left:500px; top:510px; position:absolute; font-size:small">
                <asp:TextBox ID="TextBox8" runat="server"  TextMode="Search" Width="310px" Height="32px"></asp:TextBox>
            </td> 
          </tr>  
                 <tr>
           <td  class="style3" style="left:260px; top:560px; position:absolute;  color:Black; font-size:small"><label>
               Company/Individau Address:</label></td>
              <td class="style15" style="color:Black; left:500px; top:550px; position:absolute; font-size:small">
                <asp:TextBox ID="TextBox9" runat="server"  TextMode="Search" Width="310px" Height="32px"></asp:TextBox>
            </td> 
          </tr>       
             <tr>
                 <td class="style3" style="left:260px; top:600px; position:absolute;  color:Black; font-size:small"><label>
                     Purpose Of Loan:</label></td>
                 <td class="style2" style="color:Black; left:500px; top:592px; position:absolute;  font-size:small">
                <asp:TextBox ID="TextBox14" runat="server"  TextMode="Search" Width="310px" 
                         Height="32px"></asp:TextBox>
                 </td>
             </tr>
                 <tr>
           <td  class="style3" style="left:260px; top:640px; position:absolute;  color:Black; font-size:small"><label>
               PhoneNo:</label></td>
              <td class="style15" style="color:Black; left:500px; top:627px; position:absolute; font-size:small">
                <asp:TextBox ID="TextBox11" runat="server"  TextMode="Search" Width="310px" Height="32px"></asp:TextBox>
            </td> 
          </tr>                                                  
          <tr>
           <td  class="style3" style="left:260px; top:680px; position:absolute;  color:Black; font-size:small"><label>
               Interest:</label></td>
              <td class="style15" style="color:Black; left:500px; top:670px; position:absolute; font-size:small">
                  <asp:DropDownList ID="txtstatus"  TextMode="Search" Width="310px" Height="32px" runat="server">
                     <asp:ListItem>Select Status</asp:ListItem>
                     <asp:ListItem>Single</asp:ListItem>
                     <asp:ListItem>Married</asp:ListItem>
                     <asp:ListItem>Divorce</asp:ListItem>
                     </asp:DropDownList>
            </td> 
          </tr> 
          <tr>
           <td  class="style3" style="left:260px; top:720px; position:absolute;  color:Black; font-size:small"><label>
               Management Fee:</label></td>
              <td class="style15" style="color:Black; left:500px; top:710px; position:absolute; font-size:small">
                <asp:TextBox ID="TextBox12" runat="server"  TextMode="Search" Width="310px" Height="32px"></asp:TextBox>
            </td> 
           
          </tr>                           
               
               
                   <tr>
                  
            <td class="style4" style="color:Black; left:500px; top:750px; position:absolute; font-size:small">
               
               <asp:Button ID="displaymessage2" runat="server" Text="Create Acount" 
        onclick="Button1_Click1" Height="37px" Width="120px"   />
               <asp:Button ID="displaymessage3" runat="server" Text="update" 
        onclick="Button2_Click1" Height="37px" Width="90px"  />
               <asp:Button ID="displaymessage4" runat="server" Text="delete" 
        onclick="Button3_Click1" Height="37px" Width="90px"  />
                <asp:Button ID="displaymessage" runat="server" Text="Search" Height="37px" 
                    Width="90px" onclick="Button8_Click"  />
           </td>
           </tr>                     
                                                            
           
         <tr>
        <td class="style3" style="left:100px; top:800px; position:absolute;  color:Black; font-size:small"
          <asp:GridView ID="GridView1" runat="server" Width="1046px">
    
          </asp:GridView>
    </td>
   </tr>
          
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
