<%@ Page Title="Home" Language="C#" MasterPageFile="~/site2.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Meshwar.admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
    .statistic {
  background-color: #fff;
  border-radius: 10px;
  box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.15);
  padding: 20px;
  text-align: center;
  transition: all 0.3s ease;
}

.statistic:hover {
  transform: translateY(-5px);
  box-shadow: 0px 8px 16px rgba(0, 0, 0, 0.2);
}

.card-title {
  font-weight: bold;
  margin-bottom: 10px;
}

.count {
  font-size: 32px;
  font-weight: bold;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     

  <div class="container">
  <div class="row" style="margin-top:30px">
    <div class="col-sm-6 col-md-6">
      <div class="card statistic">
                    <a href="ViewUsers.aspx" style="text-decoration:none">

        <div class="card-body" style="color:darkred">
         <i class="fa fa-user" style="font-size:24px"> <h5 class="card-title">Users</h5></i>
          <p class="card-text count"><%= ViewState["userCount"] %></p>
        </div></a>
      </div>
    </div>
    <div class="col-sm-6 col-md-6"  >
      <div class="card statistic">
          <a href="ViewDoctors.aspx" style="text-decoration:none">
        <div class="card-body" style="color:darkred">
        <i class="fa fa-user-md" style="font-size:24px">  <h5 class="card-title">Doctors</h5></i>
          <p class="card-text count"><%= ViewState["infoCount"] %></p>
        </div>
              </a>
      </div>
    </div>
      </div>

      <div class="row" style="margin-top:80px">
    <div class="col-sm-6 col-md-6" >
      <div class="card statistic">
                    <a href="ViewArticles.aspx" style="text-decoration:none">

        <div class="card-body" style="color:darkred">
       <i class="fa fa-file" style="font-size:24px">   <h5 class="card-title">Articles</h5></i>
          <p class="card-text count"><%= ViewState["articleCount"] %></p>
        </div>
                        </a>
      </div>
    </div>
    <div class="col-sm-6 col-md-6">
      <div class="card statistic">
                    <a href="ViewDomains.aspx" style="text-decoration:none">

        <div class="card-body"  style="color:darkred">
      <i class="fa fa-list-alt" style="font-size:24px">    <h5 class="card-title">Categories</h5></i>
            <p class="card-text count"><%= ViewState["categoryCount"] %></p>
        </div>
                        </a>
      </div>
    </div>
  </div>
      </div>
</div>

</asp:Content>
