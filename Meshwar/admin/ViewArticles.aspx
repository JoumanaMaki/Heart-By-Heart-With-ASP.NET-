<%@ Page Title="View Articles" Language="C#" MasterPageFile="~/site2.Master" AutoEventWireup="true" CodeBehind="ViewArticles.aspx.cs" Inherits="Meshwar.admin.ViewArticles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            text-align: right;
        }
        .auto-style4 {
            margin-top: 0;
            margin-bottom: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="auto-style2">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4" Height="39px" Width="526px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
            <br />
            <br />
        </div>
        <div id="myDiv" runat="server" class="auto-style2">
        </div>
</asp:Content>
