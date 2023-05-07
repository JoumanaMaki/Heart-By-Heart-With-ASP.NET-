<%@ Page Title="View Doctors" Language="C#" MasterPageFile="~/site2.Master" AutoEventWireup="true" CodeBehind="ViewDoctors.aspx.cs" Inherits="Meshwar.admin.ViewDoctors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 161px;
        }
        .auto-style2 {
            width: 147px;
        }
        .img{
            width: 30px;
            height:30px;
        }

         .auto-style3 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="auto-style3">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4" Height="39px" Width="526px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
            <br />
            <br />
        </div>
    <div id="myDiv" runat="server"></div>



</asp:Content>
