<%@ Page Title="Doctors" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" Inherits="Meshwar.frontEnd.Doctors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .newStyle2 {
            font-family: "Times New Roman", Times, serif;
            font-size: xx-large;
            color: #800000;
            font-weight: 600;
        }
          .auto-style3 {
            text-align: right;
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <h1 class="text-center"> <span class="newStyle2">Doctors </span> </h1>
      
    <div class="auto-style3">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4" Height="39px" Width="526px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" BackColor="#009900" BorderColor="#009900" ForeColor="#FFFFCC" />
            <br />
            <br />
        </div>
<div class="container">
    <div class="row">
        <asp:Repeater ID="DoctorsRepeater" runat="server">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="card  m-3">
                        <a href="doctor_detail?ID=<%# Eval("Id") %>" style="text-decoration:none; color:darkred" >
                            <img src="<%# Eval("image") %>" class="card-img-top " height="350px">
                     
                        <div class="card-body text-center">
                         
                                <h5 class="card-title"><%# Eval("firstname") %> <%# Eval("lastname") %></h5>    </a>
                            &nbsp;</a><p class="card-text"><%# Eval("Speciality") %></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
</asp:Content>
