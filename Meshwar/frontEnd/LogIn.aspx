<%@ Page Title="LogIn" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Meshwar.frontEnd.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .newStyle6 {
            font-size: xx-large;
            color: #990000;
            font-weight: 700;
            font-family: "Times New Roman", Times, serif;
        }
        
        .newStyle2 {
            font-family: "Times New Roman", Times, serif;
            font-size: x-large;
            font-weight: 700;
            color: #800000;
        }
        
        .container-login {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;

}
        .auto-style1 {
            width: 89px;
        }
        .auto-style2 {
            direction: rtl;
            font-family: "Times New Roman", Times, serif;
            font-weight: bold;
            font-size: x-large;
            color: #800000;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-login" style="background-color:mistyrose; padding:20px; margin-top:20px; ">
 
   <h1> <span class="newStyle6">LogIn</span></h1>
    <asp:Label ID="lblStatus" runat="server" Text="Label" CssClass="newStyle5" Visible="False"></asp:Label>
        <br /><br />
      <div>
          <label> <span class="newStyle2">Email: </span></label>
            <asp:TextBox ID="txtEmail" runat="server" BorderColor="#990000" BorderStyle="Double" Height="36px" Width="228px"></asp:TextBox>
       </div>
        <br /><br />
        <div>
            <label> <span class="newStyle2">Password: 
            </span></label>
          <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" BorderColor="#990000" BorderStyle="Double" Height="36px" Width="228px"></asp:TextBox>
        </div><br /><br />
        <div>
            
    
            <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" BackColor="#990000" ForeColor="#FFCCCC" Height="49px" Width="122px" />
        </div>

    


&nbsp &nbsp &nbsp&nbsp&nbsp&nbsp<h6> Don't Have an Account? <a href="SignUp.aspx">Sign Up</a></h6>

<br />
&nbsp &nbsp &nbsp&nbsp&nbsp&nbsp<h6><a href="LogOut.aspx">Log Out</a></h6>


</div>

</asp:Content>
