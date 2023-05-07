<%@ Page Title="View Domains" Language="C#" MasterPageFile="~/site2.Master" AutoEventWireup="true" CodeBehind="ViewDomains.aspx.cs" Inherits="Meshwar.admin.ViewDomains" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .newStyle1 {
            color: #800000;
            font-weight: 600;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="auto-style1"> <span class="newStyle1">Domains</span></h1>
    <div id="myDiv" runat="server" class="auto-style2" style="margin-top:50px">
        </div>

</asp:Content>
