<%@ Page Title="View Users" Language="C#" MasterPageFile="~/site2.Master" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="Meshwar.admin.ViewUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            text-align: right;
            margin-top:30px
        }
        .auto-style5 {
            text-align: center;
            color: #800000;
            font-size: xx-large;
            font-weight: 600;
            font-family: Georgia, "Times New Roman", Times, serif;
        }
        .newStyle1 {
            color: #800000;
            font-size: large;
            font-weight: 600;
            font-family: Georgia, "Times New Roman", Times, serif;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="auto-style5"> &nbsp;</h1>
    <h1 class="auto-style5"> Users</h1>
    <div id="myDiv" runat="server" class="auto-style2">
        </div>
</asp:Content>
