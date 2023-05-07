<%@ Page Title="Articles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="Meshwar.frontEnd.Articles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .article-card {
  background-color: #ffffff;
  border: 1px solid #e3e3e3;
  border-radius: 8px;
  box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);

  margin-left:60px;
  margin-bottom:30px
}

.article-card .card-title {
  color: darkred;
  text-decoration:underline;
  font-size: 18px;
  font-weight: bold;
  margin-bottom: 10px;
}

.article-card .card-text {
  color: #666666;
  font-size: 14px;
  margin-bottom: 5px;
}



  .card.article-card:hover {
        transform: translateY(-5px);
        transition: transform 0.2s ease-out;
    }


        .newStyle1 {
            color: #800000;
            font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
            font-size: x-large;
            font-weight: 700;
            font-style: normal;
            font-variant: normal;
            text-transform: capitalize;
        }






        .newStyle2 {
            font-family: "Times New Roman", Times, serif;
            font-size: xx-large;
            color: #800000;
            font-weight: 600;
        }






        .newStyle3 {
            font-family: "Times New Roman", Times, serif;
            font-size: large;
            font-weight: 600;
            color: #800000;
        }






    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="text-end">
           <span class="newStyle3">
           <strong>Filter By Speciality:</strong></span>

        <asp:DropDownList ID="ddlSpeciality" runat="server" Width="200px" Height="38px" AutoPostBack="True" OnSelectedIndexChanged="ddlSpeciality_SelectedIndexChanged">
                    
                </asp:DropDownList>
     
      </div>
   <h1 class="text-center"> <span class="newStyle2">Articles </span> </h1>
       <div class="row">
        <asp:Repeater ID="ArticlesRepeater" runat="server">
            <ItemTemplate>
                <div class="card article-card col-md-5">
                        <a href="article_detail?ID=<%# Eval("Id") %>" style="text-decoration:none">
                    <div class="card-body">
                     
                        <h1 class="card-title"><%# Eval("title") %></h1>
                        <br />
                        <h2 class="card-text " style="color:black; "> <%# Eval("coworkers") %></h2>
                        <h2 class="card-text"> <%# Eval("domain_name") %></h2>
                    </div>
                            </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
