<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Meshwar.frontEnd.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron text-center">

    <img src="images/contactUs.jpg" width="100%"/>
     </div>

    <div class="container" style="width:100%; padding:30px;background-color:mistyrose; margin-top: 0px;">
  <div class="row">
        <h4 class="text-center"style="color:darkred; margin-left:50px"> You are most welcomed to send a message</h4>
      <div class="col-6">
    
      <br />
      <br />
      <table >
   
     <tr> 
         <td class="auto-style4">Full Name: &nbsp;</td>
  <td class="auto-style5">     <asp:TextBox ID="TextBox1" runat="server" Height="55px" Width="371px"></asp:TextBox></td> 
</tr> 

            <tr> 
         <td class="auto-style2"><asp:Label ID="Label2" runat="server" Text="Email"></asp:Label> :&nbsp;&nbsp; </td>
  <td class="auto-style3">     <asp:TextBox ID="TextBox2" runat="server" Height="51px" Width="374px"></asp:TextBox></td> 
</tr> 

            <tr> 
         <td class="auto-style1"><asp:Label ID="Label3" runat="server" Text="Message"></asp:Label> :&nbsp;&nbsp;&nbsp; </td>
  <td class="auto-style6">
      <asp:TextBox ID="TextBox3" runat="server" Height="52px" Width="373px"></asp:TextBox> 
      </td> 
</tr> 
          <tr>
              <td colspan="2">

              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" BackColor="#990000" BorderColor="#990000" ForeColor="#FFCCCC" Height="55px" OnClick="Button2_Click" Text="Save" Width="127px" />

              </td>
          </tr>
        </table>
          </div>

      <div class="col-6">
           <br />
          <br />
          <br />
          <div class="row">
              <div class="col-1 ms-auto">
         <i class='fas fa-phone' style='font-size:20px;color:darkred'> </i>
             </div>
                 <div class="col-8" style='font-size:20px;color:darkred'>
                     <h4> 71/887230</h4>
                     </div>
        </div>
          <br />
          <br />
          <br />
           <div class="row">
              <div class="col-1 ms-auto">
         <i class='fas fa-envelope' style='font-size:20px;color:darkred'> </i>
             </div>
                 <div class="col-8" style='font-size:20px;color:darkred'>
                     <h4> info@hbh.com</h4>
                     </div>
        </div>

            <br />
          <br />
          <br />
           <div class="row">
              <div class="col-1 ms-auto">
         <i class='fas fa-map-marker' style='font-size:20px;color:darkred'> </i>
             </div>
                 <div class="col-8" style='font-size:20px;color:darkred'>
                     <h4> Saida, Lebanon</h4>
                     </div>
        </div>

      </div>
  </div>
</div>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <script src="https://kit.fontawesome.com/yourcode.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" integrity="sha512-4C4HsGd70UpyKyoJgjOuyiXkKjZLLDfgFiBLgyOzHwVjK6FyU6bzQqc6/tR57JkQ9WiaJZ7M72Z0Yh5wKxUp3w==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://kit.fontawesome.com/a076d05399.js" crossorigin="anonymous"></script>
    <style type="text/css">
        .newStyle1 {
            font-family: Castellar;
            color: #FFE4E1;
            font-weight: 700;
            font-size: x-large;
        }
        .newStyle2 {
            font-family: Georgia, "Times New Roman", Times, serif;
            font-size: x-large;
            color: #FFE4E1;
            font-weight: 600;
        }
        .auto-style1 {
            font-family: Georgia, "Times New Roman", Times, serif;
            font-size: x-large;
            color: #FFE4E1;
            font-weight: 600;
            text-align: right;
            color:darkred;
            width: 337px;
            height: 96px;
        }
        .auto-style2 {
            font-family: Georgia, "Times New Roman", Times, serif;
            font-size: x-large;
            color: #FFE4E1;
            font-weight: 600;
            text-align: right;
            color: darkred;
            width: 337px;
            height: 83px;
        }
        .auto-style3 {
            height: 83px;
        }
        .auto-style4 {
            font-family: Georgia, "Times New Roman", Times, serif;
            font-size: x-large;
            color: #FFE4E1;
            font-weight: 600;
            text-align: right;
            color: darkred;
            width: 337px;
            height: 97px;
        }
        .auto-style5 {
            height: 97px;
        }
        .auto-style6 {
            height: 96px;
        }
    </style>
</asp:Content>

