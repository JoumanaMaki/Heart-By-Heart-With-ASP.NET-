<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Meshwar.frontEnd.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

       <style type="text/css">
        .newStyle1 {
            font-family: "Times New Roman", Times, serif;
            font-size: x-large;
            color: #800000;
            font-weight: 700;
        }

        .container-login {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;

}
        .newStyle2 {
            font-family: "Times New Roman", Times, serif;
            font-size: x-large;
            font-weight: 700;
            color: #800000;
        }
        .newStyle3 {
            font-weight: 600;
            font-family: "Times New Roman", Times, serif;
            font-size: x-large;
            color: #800000;
        }
        .newStyle4 {
            color: #800000;
            font-weight: 700;
            font-size: large;
            font-family: "Times New Roman", Times, serif;
        }
        .newStyle5 {
            color: #DC3545;
            font-weight: 800;
            font-size: xx-large;
        }
        .newStyle6 {
            font-family: Verdana, Geneva, Tahoma, sans-serif;
            font-size: xx-large;
            font-weight: 600;
            color: #800000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-login" style="background-color:mistyrose; padding:20px; margin-top:20px; ">
 
   <h1> <span class="newStyle6">Sign Up</span></h1>
    <asp:Label ID="lblStatus" runat="server" Text="Label" CssClass="newStyle5" Visible="False"></asp:Label>
        <br /><br />
        <div>
            <label><span class="newStyle2">Username</span>:</label>
            <asp:TextBox ID="txtUsername" runat="server" BorderColor="#990000" BorderStyle="Double" Height="36px" Width="228px"></asp:TextBox>
        </div>
        <br />
        <br />
        <div>
            <label><span class="newStyle2">Gender</span>:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:RadioButton ID="RadioButton1" runat="server" CssClass="newStyle4" checked Text="Male" GroupName="Gender"/>
                <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" GroupName="Gender" CssClass="newStyle4" />
              <br /> 
        </div>
        <br /><br />
        <div>
            <label><span class="newStyle2">Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></label>
&nbsp;<asp:TextBox ID="txtEmail" runat="server" BorderColor="#990000" BorderStyle="Double" Height="36px" Width="228px"></asp:TextBox>
        </div>
        <br /><br />
        <div>
            <label> <span class="newStyle2">Password:&nbsp;&nbsp;&nbsp; </span></label>
            &nbsp;<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" BorderColor="#990000" BorderStyle="Double" Height="36px" Width="228px"></asp:TextBox>
        </div><br /><br />
        <div>
            
         <label><span class="newStyle2">Profile Picture:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></label>
&nbsp;<asp:FileUpload ID="fileUpload" runat="server" BackColor="#990000" ForeColor="#FFCCCC" />
            </div>
        <div><br /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Sign Up" OnClick="btnLogin_Click" BackColor="#990000" ForeColor="#FFCCCC" Height="49px" Width="122px" />
        </div>

    


&nbsp &nbsp &nbsp&nbsp&nbsp&nbsp<h6> Already Have an Account? <a href="LogIn.aspx">Login</a></h6>
</div>


</asp:Content>
