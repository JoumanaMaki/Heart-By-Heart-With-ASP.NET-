<%@ Page Title="Heart By Heart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Meshwar.frontEnd.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="https://fonts.googleapis.com/css2?family=Montserrat&display=swap" rel="stylesheet">
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Sigmar&display=swap" rel="stylesheet">

    <style>
        .carousel-caption h3,
.carousel-caption p,
.carousel-control-prev-icon,
.carousel-control-next-icon {
  color: darkred;
}

        .carousel-indicators button,
.carousel-control-prev-icon,
.carousel-control-next-icon {
  color: darkred;
  background-color: transparent;
  border-color: darkred;
}

.carousel-indicators button.active {
  background-color: darkred;
}

.carousel-control-prev:hover,
.carousel-control-next:hover {
  color: white;
  background-color: mistyrose;
  border-color: darkred;
}
.carousel-caption h3 {
    font-family: 'Sigmar', cursive;
  font-weight: bold;

}

.carousel-caption {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

   .newStyle2 {
            font-family: "Times New Roman", Times, serif;
            font-size: xx-large;
            color: #800000;
            font-weight: 600;
        }


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






        .newStyle3 {
            font-family: "Times New Roman", Times, serif;
            font-size: xx-large;
            color: #800000;
            font-weight: 600;
        }
        
        .newStyle4 {
            font-family: "Times New Roman", Times, serif;
            font-size: xx-large;
            font-weight: 600;
            color:mistyrose
        }

  .text-center {
    text-align: center;
  }


    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="carousel">
  <div class="carousel-indicators">
    <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
    <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
    <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
  </div>
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="images/doctor_carousel.jpg" style="opacity:0.5; " height="500px"class="d-block w-100" alt="...">
      <div class="carousel-caption d-flex align-items-center justify-content-center">
        <h3 class="text-center fw-bold">CONNECT WITH TOP DOCTORS</h3>
   <a href="Doctors.aspx" class="btn btn-danger mt-3" style="background-color:darkred">View Doctors</a>

      </div>
    </div>
    <div class="carousel-item">
      <img src="images/research.png" style="opacity:0.5;background-color: darkred" height="500px" class="d-block w-100" alt="...">
     <div class="carousel-caption d-flex align-items-center justify-content-center">
                <h3 class="text-center fw-bold">Read up-to-date Articles </h3>
          
      <a href="Articles.aspx" class="btn btn-danger mt-3" style="background-color:darkred">View Articles</a>
      </div>
    </div>
    <div class="carousel-item">
      <img src="images/reach.jpeg" style="opacity:0.5;background-color: darkred" height="500px" class="d-block w-100" alt="...">
    <div class="carousel-caption d-flex align-items-center justify-content-center">
                <h3 class="text-center fw-bold">Get Quick and Easy Access </h3>
<a href="SignUp.aspx" class="btn btn-danger mt-3" style="background-color:darkred">Become Premium</a>
      </div>
    </div>
  </div>
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>

    

<div style="background-color:darkred; padding:50px">
  <a href="Doctors.aspx" style="text-decoration:none">
    <h1 class="text-center" style="color:mistyrose"><span class="newStyle4">Doctors</span></h1>
  </a>

<div class="container" >
    <div class="row" >
        <asp:Repeater ID="DoctorsRepeater" runat="server">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="card">
                        <a href="doctor_detail?ID=<%# Eval("Id") %>" style="text-decoration:none; color:darkred" >
                            <img src="<%# Eval("image") %>" class="card-img-top" height="350px">
                     
                        <div class="card-body text-center">
                         
                                <h4 class="card-title"><%# Eval("firstname") %> <%# Eval("lastname") %></h4>    </a>
                            &nbsp;&nbsp;&nbsp;&nbsp;</a><h5 class="card-text"><%# Eval("Speciality") %></h5>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
    </div>

    <div class="container-fluid p-5 text-center" style="color:darkred;background-color:mistyrose; padding:20px">
  <h1>Premium DEAL</h1>
  <p>Become a premium user and unlock a world of possibilities! Our exclusive features are tailored to meet your every need, providing you with the ultimate experience. With our heart by heart approach, we are committed to providing you with unparalleled support and service.<br />
      Upgrade today and discover a world of benefits that will make your heart sing!</p> 

        <a href="SignUp.aspx" class="btn btn-danger mt-3" style="background-color:darkred">Become Premium</a>
</div>
  



<div class="container-fluid" style="background-color:darkred; padding:20px">
  <a href="Articles.aspx" style="text-decoration:none">
    <h1 class="text-center"><span class="newStyle4">Articles</span></h1>
  </a>

    <div class="row" >
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
    </div>
</asp:Content>
