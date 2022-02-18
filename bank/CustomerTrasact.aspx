<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerTrasact.aspx.cs" Inherits="BankA.CustomerTrasact" %>

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
            <h5 class="m-0 text-dark">NewCustomer</h5><p style="font-family:'Century Gothic'; font-size:large">AccountBal:<asp:Label ID="Lab1" Font-Size="XX-Large" runat="server"></asp:Label></p>
          </div><!-- /.col -->
   

    
    <!-- Right navbar links -->
    <ul class="navbar-nav ml-auto">
      <!-- Messages Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="">
          <i class="far fa-comments" style="position:absolute; width:200px; top:9px; right:150px;"> <asp:Label ID="Label1" runat="server" Font-Size="Larger"></asp:Label> </i>
          <span class="badge badge-danger navbar-badge"></span>
          </a>
         <div style="position:absolute; background-color:White; top:5px; right:0px;"> <asp:Button ID="Button3" runat="server" Text="LogOut" Font-Size="Small" BackColor="White" BorderColor="White" Height="30px" Width="70px" ForeColor="BlueViolet" onclick="Button1_Click"></asp:Button>
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
           <td class="style3" style="left:260px; top:158px; position:absolute;  color:Black; font-size:large"><label>Customer Id:</label></td>
              <td class="style15" style="color:Black; font-size:small">
                <asp:TextBox ID="txtcustomerid" runat="server"  TextMode="Search" Width="349px" Height="35px"></asp:TextBox>
                 
            </td> 
          </tr>     
                <tr>
                 <td class="style3" style="left:260px; top:203px; position:absolute;  color:Black; font-size:large"><label>Branch:</label></td>
                 <td class="style2" style="color:Black; font-size:medium"><asp:DropDownList ID="txtbr" Height="35px" TextMode="Search"  Width="350px" runat="server">
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
                 <td class="style3" style="left:260px; top:244px; position:absolute;  color:Black; font-size:large"><label>Field Officer:</label></td>
                 <td class="style5" style="color:Black; font-size:medium">
                     <asp:DropDownList ID="txtofficer" Height="35px" TextMode="Search"  Width="350px" runat="server">
                         <asp:ListItem>Select Officers</asp:ListItem>
                         <asp:ListItem>TUNJI BOLAGI</asp:ListItem>
                         <asp:ListItem>IFEANYI OKOWA</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>

                         <asp:ListItem>ABAZIE CHIOMA VIVIAN</asp:ListItem>
                         <asp:ListItem>ABIOLA OLOLADE TOBI</asp:ListItem>
                         <asp:ListItem>ACHIMUGU HELEN ALADI</asp:ListItem>
                         <asp:ListItem>ADEBAYO WALE HZONE6</asp:ListItem>
                         <asp:ListItem>ADEBOWALE SAHEED OLARENWAJU</asp:ListItem>
                         <asp:ListItem>ADEBOYE FAIDAT BUKOLA</asp:ListItem>
                         <asp:ListItem>ADEGBOLA TOBI EMMANUEL</asp:ListItem>
                         <asp:ListItem>ADISA HABEEBULLAHI</asp:ListItem>
                         <asp:ListItem>AGBAI ONYINYE CHIDIOGO</asp:ListItem>
                         <asp:ListItem>AGWAZIE OGECHUKWU EUCHERIA</asp:ListItem>
                         <asp:ListItem>AHAIWE FAVOUR NNEOMA</asp:ListItem>
                         <asp:ListItem>AKANMU ODUNAYO MARTHA</asp:ListItem>
                         <asp:ListItem>AKOJA BEATRICE MOYINOLUWA</asp:ListItem>
                         <asp:ListItem>AKPAN ROSELINE EDWARD</asp:ListItem>
                         <asp:ListItem>ALUKO AKINYEMI</asp:ListItem>
                         <asp:ListItem>AMAECHI CHIBUZOR JENNIFER</asp:ListItem>
                         <asp:ListItem>AMAEFULE JOVITA CHIDIMMA</asp:ListItem>
                         <asp:ListItem>AMBALI BALIKIS OLAYINKA</asp:ListItem>
                         <asp:ListItem>ANOFUECHI CHINYERE E</asp:ListItem>
                         <asp:ListItem>ANYANWUOCHA CHIGOZIE</asp:ListItem>
                         <asp:ListItem>ANYAOGU OLUCHI</asp:ListItem>
                         <asp:ListItem>ANYIAM CHRISTIANA</asp:ListItem>
                         <asp:ListItem>AZU IFEGWU AZU</asp:ListItem>
                         <asp:ListItem>AZUAKOLAM IFEANYI CYNTHIA</asp:ListItem>
                         <asp:ListItem>AZUBUIKE OZIOMA HEREIT</asp:ListItem>
                         <asp:ListItem>BALOGUN SULAIMAN OLARENWAJU</asp:ListItem>
                         <asp:ListItem>BANKOLE JOSEPH OLAWALE</asp:ListItem>
                         <asp:ListItem>BASSEY ESTHER ETOWA</asp:ListItem>
                         <asp:ListItem>BASSEY INIOBONG GODSTIME</asp:ListItem>
                         <asp:ListItem>BELLO WASIU HZONE1</asp:ListItem>
                         <asp:ListItem>BELONWU EARNESTINA CHINASA</asp:ListItem>
                         <asp:ListItem>BENSON AMANKA SHARON</asp:ListItem>
                         <asp:ListItem>BINUYO FEMI OLUWASEYI</asp:ListItem>
                         <asp:ListItem>BRIGHT UZOCHUKWU</asp:ListItem>

                         <asp:ListItem>BUHARI BARIU ADEBAYO</asp:ListItem>
                         <asp:ListItem>CHIKA IFEOMA JENNIFER</asp:ListItem>
                         <asp:ListItem>CHIMA LEONARD IKECHUKWU</asp:ListItem>
                         <asp:ListItem>CHUKWU FLORENCE UZOMA</asp:ListItem>
                         <asp:ListItem>CHUKWUDI FAITH NANCY</asp:ListItem>
                         <asp:ListItem>CHUKWUDI MICHEAL HZONE7</asp:ListItem>
                         <asp:ListItem>CHUKWUDOLUE UCHENNA MAUREEN</asp:ListItem>
                         <asp:ListItem>CHUKWUDUM IFEOMA GLORIA</asp:ListItem>
                         <asp:ListItem>CHUKWUEDO NNEAMAKA SAAFRA</asp:ListItem>
                         <asp:ListItem>CHUKWUKA CHINOMSO</asp:ListItem>
                         <asp:ListItem>DADA RONKE BOLANLE</asp:ListItem>
                         <asp:ListItem>DAIRO SOLOMON TEMITOPE</asp:ListItem>
                         <asp:ListItem>DIKE BLESSING AMUCHECHUKWU</asp:ListItem>
                         <asp:ListItem>DIOGU BLESSING</asp:ListItem>
                         <asp:ListItem>EBEKUNWANNE MARYJANE EZINNE</asp:ListItem>
                         <asp:ListItem>EBOH CHINONSO UDOCHUKWU</asp:ListItem>
                         <asp:ListItem>EBONINE OBIANUJU</asp:ListItem>
                         <asp:ListItem>EDET EMEM HELEN</asp:ListItem>
                         <asp:ListItem>EDET ROSE CHYRISANTUS</asp:ListItem>

                         <asp:ListItem>EZEUGWU PRISCA </asp:ListItem>
                         <asp:ListItem>EZIEBO NKECHI</asp:ListItem>
                         <asp:ListItem>EZUBELU FAITH IFUNANYA</asp:ListItem>
                         <asp:ListItem>FAGBOHUN DARE JOHNSON</asp:ListItem>
                         <asp:ListItem>FASHOLA IDAYAT MOSUNMMOLA</asp:ListItem>
                         <asp:ListItem>FASIPE JUMOKE ANUOLUWAPO</asp:ListItem>
                         <asp:ListItem>FEBABOR PRINCE</asp:ListItem>
                         <asp:ListItem>FEYITIMI GBOYEGA SAMUEL</asp:ListItem>
                         <asp:ListItem>FOLAWUNMI ESTHER FUNKE</asp:ListItem>
                         <asp:ListItem>FRIDAY GLORY ITORO</asp:ListItem>
                         <asp:ListItem>GABRIEL FAUSTUNA ULUMMA</asp:ListItem>
                         <asp:ListItem>GODKNOWS IHUOMA RUTH</asp:ListItem>
                         <asp:ListItem>GODWIN GIFT</asp:ListItem>
                         <asp:ListItem>HAMMED SHERIFF OLATUNJI</asp:ListItem>
                         <asp:ListItem>HAMZAT SEKINAT MOTUNRAYO</asp:ListItem>
                         <asp:ListItem>HARUNA ABDULRAHMAN</asp:ListItem>
                         <asp:ListItem>HASSAN NUSIRAT</asp:ListItem>
                         <asp:ListItem>HOTONU OLUWATOYIN MODUPE</asp:ListItem>
                         <asp:ListItem>IBANGA DONA EKAETTE</asp:ListItem>

                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>TUNJI BOLAGI</asp:ListItem>
                         <asp:ListItem>IFEANYI OKOWA</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>TUNJI BOLAGI</asp:ListItem>
                         <asp:ListItem>IFEANYI OKOWA</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>TUNJI BOLAGI</asp:ListItem>
                         <asp:ListItem>IFEANYI OKOWA</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>TUNJI BOLAGI</asp:ListItem>
                         <asp:ListItem>IFEANYI OKOWA</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>TUNJI BOLAGI</asp:ListItem>
                         <asp:ListItem>IFEANYI OKOWA</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>TUNJI BOLAGI</asp:ListItem>
                         <asp:ListItem>IFEANYI OKOWA</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>TUNJI BOLAGI</asp:ListItem>
                         <asp:ListItem>IFEANYI OKOWA</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>TUNJI BOLAGI</asp:ListItem>
                         <asp:ListItem>IFEANYI OKOWA</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>TUNJI BOLAGI</asp:ListItem>
                         <asp:ListItem>IFEANYI OKOWA</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                         <asp:ListItem>TUNJI BOLAGI</asp:ListItem>
                         <asp:ListItem>IFEANYI OKOWA</asp:ListItem>
                         <asp:ListItem>ENITAN KOLAWOLE</asp:ListItem>
                         <asp:ListItem>MUHAMMED RASHEED</asp:ListItem>
                         <asp:ListItem>OMOBOLANLE FUMMI</asp:ListItem>
                     </asp:DropDownList>
                 </td>
             </tr>

          <tr>
               <td class="style3" style="left:260px; top:290px; position:absolute;  color:Black; font-size:large"><label>AcountNo:</label></td>
               <td class="style6" style="color:Black; font-size:small"><asp:TextBox ID="txtAcountNo" TextMode="Search" Height="35px" runat="server" Width="349px"></asp:TextBox>
                   <asp:Button ID="Button4" runat="server"  Height="60px" Width="119px" 
                       Text="Dormant_Retrieve" onclick="Button4_Click" />
                   <asp:TextBox ID="txtdays" runat="server" Height="60px" Width="58px"></asp:TextBox>
                   <asp:Button ID="Button6" runat="server" Height="60px" Text="Confirm" 
                       onclick="Button6_Click" />
               </td>
                   
             </tr>
             <tr>
              <td class="style3" style="left:260px; top:341px; position:absolute;  color:Black; font-size:large"><label>PageNumber:</label></td>
              <td class="style7" style="color:Black; font-size:small"><asp:TextBox ID="txtpageno" Height="35px" runat="server" TextMode="Search" Width="349px"></asp:TextBox></td>
             </tr>
              <tr>
            <td class="style3" style="left:260px; top:395px; position:absolute;  color:Black; font-size:medium"><label>Date:</label></td>
            <td class="style8" style="color:Black; font-size:small"><asp:TextBox ID="txtdate" placeholder=" System Automatic generate Date" Height="35px" runat="server" TextMode="Date" Width="349px"></asp:TextBox></td>
             </tr>
            
            
             <tr>
                 <td class="style3" style="left:260px; top:439px; position:absolute;  color:Black; font-size:large"><label>
                     Comment :</label></td>
                 <td class="style10" style="color:Black; font-size:medium">
                     <asp:TextBox ID="txtsms" runat="server" Height="45px" TextMode="MultiLine" Width="349px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
              <td class="style3" style="left:260px; top:499px; position:absolute;  color:Black; font-size:large"><label>
                  Target & BuckFixed 
                  &amp; Loan Acct/ Slip Charge :</label></td>
              <td class="style11" style="color:Black; font-size:small"><asp:TextBox ID="txtfee" Height="35px" TextMode="Search" runat="server" Width="349px"></asp:TextBox>
                     </td>
             </tr>
              
             <tr>
                 <td class="style3" style="left:260px; top:565px; position:absolute;  color:Black; font-size:large"><label>PostedBy :</label></td>
                 <td class="style16" style="color:Black; font-size:small"><asp:TextBox ID="txtpostedby" Height="35px" runat="server" TextMode="Search" Width="349px"></asp:TextBox>  
                     
             </tr>

               <tr>
                 <td class="style3" style="left:260px; top:610px; position:absolute;  color:Black; font-size:large"><label>AccountType / select Day, Weeks, Month:</label></td>
                 <td class="style5" style="color:Black; font-size:medium">
                     <asp:DropDownList ID="txtaccounttype" Height="35px" TextMode="Search"  Width="350px" runat="server">
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
                         <asp:ListItem>Loan Account</asp:ListItem>
                       
                   <asp:ListItem>------select Day, Weeks, Month-------</asp:ListItem>
                         <asp:ListItem>7</asp:ListItem>
                         <asp:ListItem>14</asp:ListItem>
                         <asp:ListItem>21</asp:ListItem>
                         <asp:ListItem>28</asp:ListItem>
                         <asp:ListItem>30</asp:ListItem>
                         
                     </asp:DropDownList>
                     
                     <asp:Button ID="Button5" runat="server" Text="SoftSaving & Flexible" 
                         Width="181px" Height="60px" onclick="Button5_Click" />
                     
                 </td>
             </tr>
           <tr>
                 <td class="style3" style="left:260px; top:672px; position:absolute;  color:Black; font-size:large"><label>Maturity Date :</label></td>
                 <td class="style16" style="color:Black; font-size:small"><asp:TextBox ID="txtmaturity" Height="35px" runat="server" TextMode="Date" Width="349px"></asp:TextBox>  
                     
                     <asp:TextBox ID="txtday" placeholder="NoOfDays" runat="server" Height="40" Width="69px"></asp:TextBox>
                     
             </tr>
              <tr>
                 <td class="style3" style="left:260px; top:725px; position:absolute;  color:Black; font-size:large"><label>No Of Month :</label></td>
                 <td class="style16" style="color:Black; font-size:small"><asp:TextBox ID="txtmonth" Height="35px" runat="server" TextMode="Search" Width="349px"></asp:TextBox>  
                     
                <asp:Label ID="Lab2" runat="server" ForeColor="Blue" Font-Size="Large"></asp:Label><asp:Label ID="Lab02" runat="server" ForeColor="green" Font-Size="Large"></asp:Label><asp:Label ID="Lab03" runat="server" ForeColor="purple" Font-Size="Large"></asp:Label>
                     
             </tr>

              <tr>
           <td  class="style3" style="left:260px; top:782px; position:absolute;  color:Black; font-size:large"><label>
               Interest Fee:</label></td>
              <td class="style15" style="color:Black;  font-size:medium">
                     <asp:DropDownList ID="txtloan"  TextMode="Search"  Width="350px" 
                      Height="32px" runat="server">
                         <asp:ListItem>Select Interest</asp:ListItem>
                         <asp:ListItem>0.01</asp:ListItem>
                         <asp:ListItem>0.02</asp:ListItem>
                         <asp:ListItem>0.03</asp:ListItem>
                         <asp:ListItem>0.04</asp:ListItem>
                         <asp:ListItem>0.08</asp:ListItem>
                         <asp:ListItem>0.05</asp:ListItem>
                         <asp:ListItem>0.06</asp:ListItem>
                    <asp:ListItem>-------------</asp:ListItem>
                         <asp:ListItem>0.07</asp:ListItem>
                         <asp:ListItem>0.10</asp:ListItem>
                         <asp:ListItem>0.15</asp:ListItem>
                         <asp:ListItem>0.20</asp:ListItem>
                         <asp:ListItem>0.25</asp:ListItem>
                         <asp:ListItem>0.30</asp:ListItem>
                         <asp:ListItem>0.35</asp:ListItem>
                         <asp:ListItem>0.40</asp:ListItem>
                         <asp:ListItem>0.50</asp:ListItem>
                     </asp:DropDownList>
                     <asp:TextBox ID="txtmoney" runat="server" Height="60px" Width="100px"></asp:TextBox>
                     <asp:Button ID="Button7" runat="server" Height="60px" Width="105px" 
                         Text="Calculate" onclick="Button7_Click1" />
                 </td> 
           
          </tr>     

          <tr>
                  
            <td class="style4" style="color:darkblue; left:550px; top:800px; font-size:medium">
               <br />
               <asp:Button ID="displaymessage2" runat="server" Text="Transact" 
        onclick="Button1_Click1" Height="37px" Width="106px"  BorderStyle="Double" />
               <asp:Button ID="displaymessage3" runat="server" Text="Update" 
        onclick="Button2_Click1" Height="37px" Width="91px"  BorderStyle="Double"/>
                <asp:Button ID="displaymessage" runat="server" Text="Search" Height="37px" 
                    Width="93px" onclick="Button8_Click"  BorderStyle="Double"/>
                <asp:Button ID="Button1" runat="server" Height="37px" Width="122px" 
                    Text="Freez Account" onclick="Button7_Click" BorderStyle="Double"/>
                <asp:Button ID="Button2" runat="server" Height="37px" Width="157px"  
                    Text="UnFreez Account" onclick="Button2_Click" BorderStyle="Double"/>
           </td>
           </tr>

      <td class="style3" style="left:140px; top:750px; position:absolute;  color:Maroon; font-size:medium; text-transform: none; font-style: normal; font-weight: lighter; font-family: Consolas; background-color: #CCFFCC;"
          <asp:GridView ID="GridView1" runat="server" Width="1046px">
    
    </asp:GridView>
    </td>
   
          
        </table>
          
</div>
</div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <strong>Copyright &copy; 2021 <a href="">Developer Laboratory</a>.</strong>
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
