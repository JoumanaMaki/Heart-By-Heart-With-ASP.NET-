<%@ Page Title="Verify OTP" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerifyOtp.aspx.cs" Inherits="Meshwar.frontEnd.VerifyOtp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       .container-login {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;

}

        .newStyle1 {
        color: #DC3545;
        font-family: "Times New Roman", Times, serif;
        font-size: large;
        font-weight: 700;
    }
    .newStyle2 {
        font-family: "Times New Roman", Times, serif;
        font-size: x-large;
        font-weight: 700;
        color: #800000;
    }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" Text="Label" Visible="False" CssClass="newStyle1"></asp:Label>
 
  <div class="container-login" style="background-color:mistyrose; padding:20px; margin-top:20px; ">
 
            <span class="newStyle2">
 
            <label>Enter OTP:</label></span>
            <asp:TextBox ID="txtOTP" runat="server" BorderColor="Maroon" BorderStyle="Double" Height="49px"></asp:TextBox>
            <br />
            <asp:Button ID="btnVerifyOTP" runat="server" Text="Verify OTP" OnClick="btnVerifyOTP_Click" BackColor="#990000" ForeColor="#FFCCCC" />
        </div>
    

</asp:Content>
