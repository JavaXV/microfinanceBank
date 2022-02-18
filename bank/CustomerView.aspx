<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerView.aspx.cs" Inherits="BankA.CustomerView" %>

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
  <title>NewCustomer | Dashboard</title>
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
            <h5 class="m-0 text-dark">NewCustomer</h5>
          </div><!-- /.col -->
   

   
    <!-- Right navbar links -->
    <ul class="navbar-nav ml-auto">
      <!-- Messages Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="">
          <i class="far fa-comments" style="position:absolute; width:200px; top:9px; right:150px;"> <asp:Label ID="Label1" runat="server" Font-Size="Larger"></asp:Label> </i>
          <span class="badge badge-danger navbar-badge"></span>
          </a>
         <div style="position:absolute; background-color:White; top:5px; right:0px;"> <asp:Button ID="Button2" runat="server" Text="LogOut" Font-Size="Small" BackColor="White" BorderColor="White" Height="30px" Width="70px" ForeColor="BlueViolet" onclick="Button5_Click"></asp:Button>
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
                <a href="AdminLogin1.aspx" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Permission Setting</p>
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
           <td  class="style3" style="left:260px; top:113px; position:absolute;  color:Black; font-size:medium"><label>
               Occupation:</label></td>
              <td class="style15" style="color:Black; left:500px; top:100px; position:absolute; font-size:small">
                <asp:TextBox ID="txtwork" runat="server"  TextMode="Search" Width="370px" Height="32px"></asp:TextBox>
              
                 
            </td> 
          </tr>      
              <tr>
                 <td class="style3" style="left:260px; top:153px; position:absolute;  color:Black; font-size:large"><label>Mode Of Payment:</label></td>
                 <td class="style2" style="color:Black; left:500px; top:146px; position:absolute; font-size:medium"><asp:DropDownList ID="txtbr" Height="35px" TextMode="Search"  Width="370px" runat="server">
                     <asp:ListItem>Select Payment Mode</asp:ListItem>
                     <asp:ListItem>Daily</asp:ListItem>
                     <asp:ListItem>Weekly</asp:ListItem>
                     <asp:ListItem>Monthly</asp:ListItem>
                     </asp:DropDownList></td>
             </tr>
               <tr>
                 <td class="style3" style="left:260px; top:195px; position:absolute;  color:Black; font-size:medium"><label>Self-Employed:</label></td>
                 <td class="style5" style="color:Black; left:500px; top:190px; position:absolute;  font-size:medium">
                     <asp:DropDownList ID="txtofficer"  TextMode="Search"  Width="370px" Height="32px" runat="server">
                         <asp:ListItem>Self-EmpLoyed Option</asp:ListItem>
                         <asp:ListItem>YES</asp:ListItem>
                         <asp:ListItem>NO</asp:ListItem>
                     </asp:DropDownList>
                 &nbsp;&nbsp;
                  <tr class="style01" style="right:40px; top:57px; position:absolute;">
                  <td class="style01" style="right:40px; top:47px; position:absolute;">

   <asp:DataList ID="DataList3" runat="server">
            <ItemTemplate>
               <table>
                 <tr>
                    
                    <td><img src="<%#Eval("propic")%>" height="250" width="230" /></td>
                    <br /><br />
                 </tr>
               
                 
               </table>
                
            </ItemTemplate>
            </asp:DataList>

            <asp:DataList ID="DataList2" runat="server">
            <ItemTemplate>
               <table>
                 <tr>
                    <td><img src="<%#Eval("Propic")%>" height="200" width="230" alt="IMG" /></td>
                 </tr> 
               </table>
                
            </ItemTemplate>
            </asp:DataList>
            
  </td>
  </tr>
                 </td>
             </tr>
             
        <tr>
           <td  class="style3" style="left:260px; top:237px; position:absolute;  color:Black; font-size:medium"><label>
               CustomerID:</label></td>
              <td class="style15" style="color:Black; left:500px; top:225px; position:absolute; font-size:small">
                <asp:TextBox ID="txtcustomerid" runat="server"  TextMode="Search" Width="370px" Height="32px"></asp:TextBox>
            </td> 
          </tr>       
                 
           <tr>
           <td  class="style3" style="left:260px; top:280px; position:absolute;  color:Black; font-size:medium">
               <label> Gender:</label></td>
             <td class="style2" style="color:Black; left:500px; top:270px; position:absolute; font-size:medium"><asp:DropDownList ID="txtgende" Height="35px" TextMode="Search"  Width="370px" runat="server">
                     <asp:ListItem>Select Gender</asp:ListItem>
                     <asp:ListItem>Male</asp:ListItem>
                     <asp:ListItem>Female</asp:ListItem>
                     </asp:DropDownList></td>
          </tr>        
              <tr>
           <td  class="style3" style="left:260px; top:320px; position:absolute;  color:Black; font-size:medium"><label>
               Nationality:</label></td>
              <td class="style15" style="color:Black; left:500px; top:304px; position:absolute; font-size:small">
                <asp:TextBox ID="txtnationality" runat="server"  TextMode="Search" Width="370px" Height="32px"></asp:TextBox>
            </td> 
          </tr> 
              <tr>
           <td  class="style3" style="left:260px; top:360px; position:absolute;  color:Black; font-size:medium"><label>
               Registration
               Date:</label></td>
              <td class="style15" style="color:Black; left:500px; top:350px; position:absolute; font-size:small">
                <asp:TextBox ID="txtdate" runat="server"  TextMode="Date" Width="370px" Height="32px"></asp:TextBox>
            </td> 
          </tr>               
                <tr>
           <td  class="style3" style="left:260px; top:400px; position:absolute;  color:Black; font-size:medium"><label>
               Customer LGA:</label></td>
              <td class="style15" style="color:Black; left:500px; top:386px; position:absolute; font-size:small">
                  <asp:DropDownList ID="txtlga" Height="35px" TextMode="Search"  Width="370px" 
                      runat="server">
                     <asp:ListItem>Select for LocalGovt</asp:ListItem>
                     </asp:DropDownList>
            </td> 
          </tr>               
                 <tr>
           <td  class="style3" style="left:260px; top:440px; position:absolute;  color:Black; font-size:medium"><label>
              Date Of Birth:</label></td>
              <td class="style15" style="color:Black; left:500px; top:430px; position:absolute; font-size:small">
                <asp:TextBox ID="txtbirth" runat="server"  TextMode="Date" Width="370px" Height="32px"></asp:TextBox>
            </td> 
          </tr>     
          <tr>
           <td  class="style3" style="left:260px; top:480px; position:absolute;  color:Black; font-size:medium"><label>
              Customer Name:</label></td>
              <td class="style15" style="color:Black; left:500px; top:466px; position:absolute; font-size:small">
                <asp:TextBox ID="txtname" runat="server"  TextMode="Search" Width="370px" Height="32px"></asp:TextBox>
            </td> 
          </tr>                         

               <tr>
           <td  class="style3" style="left:260px; top:520px; position:absolute;  color:Black; font-size:medium"><label>
              Customer Address:</label></td>
              <td class="style15" style="color:Black; left:500px; top:510px; position:absolute; font-size:small">
                <asp:TextBox ID="txtaddress" runat="server"  TextMode="Search" Width="370px" Height="32px"></asp:TextBox>
            </td> 
          </tr>  
                 <tr>
           <td  class="style3" style="left:260px; top:560px; position:absolute;  color:Black; font-size:medium"><label>
               PhoneNo/SMS-Alert:</label></td>
              <td class="style15" style="color:Black; left:500px; top:550px; position:absolute; font-size:small">
                <asp:TextBox ID="txtphoneno" runat="server"  TextMode="Search" Width="370px" Height="32px"></asp:TextBox>
                
            </td> 
          </tr>       
        
              <tr>
                 <td class="style3" style="left:260px; top:600px; position:absolute;  color:Black; font-size:large"><label>Marital Status:</label></td>
                 <td class="style2" style="color:Black; left:500px; top:594px; position:absolute; font-size:large"><asp:DropDownList ID="txtstatu" Height="35px" TextMode="Search"  Width="370px" runat="server">
                     <asp:ListItem>Select Status</asp:ListItem>
                     <asp:ListItem>Married</asp:ListItem>
                     <asp:ListItem>Single</asp:ListItem>
                     <asp:ListItem>Divorce</asp:ListItem>
                     </asp:DropDownList>
                     <asp:Button ID="Button4" runat="server"  Height="32px" Text="Serach-LGA" 
                         onclick="Button4_Click" Width="103px" />
                     &nbsp;Search LocalGovt
                </td>
             <tr>
           <td  class="style3" style="left:260px; top:640px; position:absolute;  color:Black; font-size:medium"><label>
              State Of Origin:</label></td>
              <td class="style15" style="color:Black; left:500px; top:636px; position:absolute; font-size:large">
                  <asp:DropDownList ID="txtstat" Height="35px" TextMode="Search"  Width="370px" 
                      runat="server">
                     <asp:ListItem>Select State</asp:ListItem>
                     <asp:ListItem>ABIA</asp:ListItem>
                     <asp:ListItem>ADAMAWA</asp:ListItem>
                     <asp:ListItem>AKWA IBOM</asp:ListItem>

                     <asp:ListItem>ANAMBRA</asp:ListItem>
                     <asp:ListItem>BAUCHI</asp:ListItem>
                     <asp:ListItem>BAYELSA</asp:ListItem>
                       <asp:ListItem>BENUE</asp:ListItem>
                     <asp:ListItem>BORNU</asp:ListItem>
                     <asp:ListItem>CROSS RIVER</asp:ListItem>
                       <asp:ListItem>DELTA</asp:ListItem>
                     <asp:ListItem>EBONYI</asp:ListItem>
                     <asp:ListItem>EDO</asp:ListItem>
                       <asp:ListItem>EKITI</asp:ListItem>
                     <asp:ListItem>ENUGU</asp:ListItem>
                     <asp:ListItem>GOMBE</asp:ListItem>
                       <asp:ListItem>IMO</asp:ListItem>
                     <asp:ListItem>JIGAWA</asp:ListItem>
                     <asp:ListItem>KADUNA</asp:ListItem>

                       <asp:ListItem>KANO</asp:ListItem>
                     <asp:ListItem>KATSINA</asp:ListItem>
                     <asp:ListItem>KOGI</asp:ListItem>
                       <asp:ListItem>LAGOS</asp:ListItem>
                     <asp:ListItem>NASARAWA</asp:ListItem>
                     <asp:ListItem>NIGER</asp:ListItem>
                       <asp:ListItem>OGUN</asp:ListItem>
                     <asp:ListItem>ONDO</asp:ListItem>
                     <asp:ListItem>OSUN</asp:ListItem>
                       <asp:ListItem>OYO</asp:ListItem>
                     <asp:ListItem>PLATEAU</asp:ListItem>
                     <asp:ListItem>RIVERS</asp:ListItem>
                       <asp:ListItem>SOKOTO</asp:ListItem>
                     <asp:ListItem>TARABA</asp:ListItem>
                     <asp:ListItem>YOBE</asp:ListItem>
                       <asp:ListItem>ZAMFARA</asp:ListItem>
                     <asp:ListItem>FCT</asp:ListItem>
                  
                     </asp:DropDownList>
                 
            </td> 
          </tr>                                                  
          <tr>
           <td  class="style3" style="left:260px; top:680px; position:absolute;  color:Black; font-size:medium"><label>
               Email Address:</label></td>
              <td class="style15" style="color:Black; left:500px; top:670px; position:absolute; font-size:small">
                <asp:TextBox ID="txtemail" runat="server"  TextMode="Search" Width="370px" Height="32px"></asp:TextBox>
               </tr> 
          <tr>
           <td  class="style3" style="left:260px; top:720px; position:absolute;  color:Black; font-size:medium"><label>
              AccountNo:</label></td>
              <td class="style15" style="color:Black; left:500px; top:710px; position:absolute; font-size:small">
                <asp:TextBox ID="txtaccountno" runat="server"  TextMode="Search" Width="370px" Height="32px"></asp:TextBox>
            </td> 
           
          </tr>                           
               
               
                   <tr>
                  
            <td class="style4" style="color:Black; left:500px; top:750px; position:absolute; font-size:medium">
               
               <asp:Button ID="displaymessage2" runat="server" Text="Create Acount" 
        onclick="Button1_Click1" Height="37px" Width="120px"   />
               <asp:Button ID="displaymessage3" runat="server" Text="update" 
        onclick="Button2_Click1" Height="37px" Width="90px"  />
               <asp:Button ID="displaymessage4" runat="server" Text="delete" 
        onclick="Button3_Click1" Height="37px" Width="90px"  />
                <asp:Button ID="displaymessage" runat="server" Text="Search" Height="37px" 
                    Width="90px" onclick="Button8_Click"  />

                   
                <asp:Button ID="Button1" runat="server" Height="37px" Width="262px" 
                    Text="Generate AccountNo/ Customer ID" onclick="Button1_Click" />

                   
           </td>
           </tr> 
           
           
        <td class="style3" style="color:Black; position:absolute; top:800px; left:83px; font-size:small"
            <asp:GridView ID="GridView1" runat="server" Width="1076px">
    
      <Columns>
       
      </Columns>
    </asp:GridView>
                    
                                                           
       
    </asp:GridView>
    </td>
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
