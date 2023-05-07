﻿<%@ Page Title="Article Details" Language="C#" MasterPageFile="~/site2.Master" AutoEventWireup="true" CodeBehind="Article_details.aspx.cs" Inherits="Meshwar.admin.Article_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.6.0/css/bootstrap.min.css" integrity="sha512-jnkxPuhN85xxH9FeW8Rvdy/rKN7/E1JiFhGXGk8E3qLq5x5RWa9tRe+tB8AnEgrPfQGQ2Ae1uiLb1xlHvSpM+A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
	<!-- Fontawesome CSS -->
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" integrity="sha512-dK7V8RbMFTBo7VitM95+jnDz7YQ3hbB1V+sBwNgzLZV7RJiOeHl7fO9XKy+6ixH1+bT0kegjTW24pUCZM6HOfQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />
	<!-- Custom CSS -->
	<style type="text/css">
		body {
			background-color: #f8f9fa;
			color: #343a40;
			font-family: Arial, sans-serif;
			font-size: 16px;
			line-height: 1.5;
			margin: 0;
			padding: 0;
		}
		h1 {
			font-size: 2.5rem;
			font-weight: 600;
			margin-top: 1rem;
			margin-bottom: 1rem;
		}
		table {
			background-color: #fff;
			border: 1px solid #dee2e6;
			border-collapse: collapse;
			margin: 2rem auto;
			max-width: 80%;
			width: 600px;
		}
		table th,
		table td {
			padding: 0.75rem;
			vertical-align: middle;
		}
		table th {
			background-color: #343a40;
			color: #fff;
			font-weight: 600;
			text-align: center;
			vertical-align: middle;
		}
		table img {
			display: block;
			margin: 0 auto;
			max-width: 100%;
			height: auto;
		}
	    .auto-style1 {
            height: 26px;
        }
		td{
			text-align:center;
		}
	    .table-hover {
            color: #800000;
            font-family: Cambria;
            font-weight: 600;
        }
	
	    .newStyle1 {
            color: #BD2130;
            font-family: "Bahnschrift SemiLight SemiConde";
            font-size: x-large;
            font-weight: 700;
            font-style: inherit;
            font-variant: small-caps;
            text-transform: capitalize;
        }
	    .newStyle2 {
            color: #BD2130;
            font-family: Cambria, Cochin, Georgia, Times, "Times New Roman", serif;
            font-weight: 800;
            font-size: x-large;
        }
        .newStyle3 {
            font-family: Verdana, Geneva, Tahoma, sans-serif;
            font-size: x-large;
            font-weight: 600;
            color: #BD2130;
        }
        .newStyle4 {
            font-family: "Trebuchet MS", "Lucida Sans Unicode", "Lucida Grande", "Lucida Sans", Arial, sans-serif;
            font-size: x-large;
            font-weight: 700;
            font-style: normal;
            font-variant: normal;
            text-transform: none;
            color: #BD2130;
        }
	</style>





</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container" style="margin: 0 auto; display: flex;">
  <div style="flex: 1;">
    <table class="table-hover" style="background-color:mistyrose; border-radius:10%;width:100%">
      <tr>
        <td>ID:</td>
        <td><asp:Label ID="lblId" runat="server" BorderStyle="Dotted"></asp:Label></td>
      </tr>
      <tr>
        <td class="auto-style1">Title:</td>
        <td class="auto-style1"><asp:Label ID="lbTitle" runat="server"></asp:Label> <asp:Label ID="lblLastName" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td>Abstract:</td>
        <td><asp:Label ID="lbAbstract" runat="server" Text="Label"></asp:Label></td>
      </tr>
      <tr>
        <td>Coworkers:</td>
        <td><asp:Label ID="lbCoworkers" runat="server" Text="Label"></asp:Label></td>
      </tr>
      <tr>
        <td>Date:</td>
        <td><asp:Label ID="lbDate" runat="server" Text="Label"></asp:Label></td>
      </tr>
       
      <tr>
        <td>Domain:</td>
        <td><asp:Label ID="lbDomain" runat="server" Text="Label"></asp:Label></td>
      </tr>

         <tr>
        <td>Article Link:</td>
        <td><asp:HyperLink ID="pdfLink" runat="server" Target="_blank"> </asp:HyperLink></td>
      </tr>
    </table>
  </div>
    
</div>


</asp:Content>
