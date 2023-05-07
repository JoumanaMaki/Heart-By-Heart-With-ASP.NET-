<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Meshwar.admin.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
   
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>Login - Admin</title>
	<style>
		body {
			background-color: #f9c4d2;
			font-family: Arial, sans-serif;
		}
		.form-div{
			display:flex;
			justify-content:center;
			margin-top:30px;
		}
		form{
			width:50%;
		}
		.container {
			margin: auto;
			max-width: 500px;
			padding: 10px;
			background-color: white;
			border-radius: 5px;
			box-shadow: 0 0 10px rgba(0,0,0,0.2);
		}
		.logo {
			display: block;
			margin: auto;
			max-width: 200px;
			padding: 10px;
		}
		input[type=text], input[type=password] {
			width: 80%;
			padding: 10px;
			margin: 9px 0 15px 0;
			margin-left:30px;
			border: none;
			background: #f1f1f1;
			border-radius: 5px;
		}
		.button-login {
			background-color: #ff69b4;
			color: white;
			padding: 10px 20px;
			margin: 8px 0;
			border: none;
			border-radius: 5px;
			cursor: pointer;
			width: 100%;
			font-size: 16px;
		}
		button:hover {
			background-color: #ff4785;
		}
		.cancelbtn {
			background-color: #f44336;
		}
		.imgcontainer {
			text-align: center;
			margin: 24px 0 12px 0;
		}
		.imgcontainer img {
			width: 20%;
			border-radius: 50%;
		}
		.container label {
			float: left;
			font-size: 16px;
		}
		.container span {
			float: right;
			font-size: 16px;
		}
		.container::after {
			content: "";
			clear: both;
			display: table;
		}
		@media screen and (max-width: 600px) {
			.container {
				max-width: 100%;
			}
		}
	    .auto-style1 {
            max-width: 100%;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
            text-align: center;
            margin: auto;
            padding: 10px;
            background-color: white;
        }
	    .newStyle1 {
            font-size: medium;
            font-weight: 600;
            color: #FFFFFF;
        }
	</style>
</head>
<body>
	<div class="form-div">
    <form runat="server">
		<div class="auto-style1">
			<div class="imgcontainer">
				<img src="images/HBH.png" alt="Logo">
				<br />
					<strong>
					<asp:Label ID="lbmessage" runat="server" ForeColor="#CC3300"></asp:Label>
				</strong>
				<br />
				<br />
			</div>
		
			<label for="username"><b>Username</b></label><br />
			<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
			<label for="password" ><b>Password</b></label><br />
			<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ToolTip="*"></asp:TextBox>
			<br />
			<asp:Button ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click" BackColor="#FF99CC" BorderColor="#FF99CC" BorderStyle="None" BorderWidth="20px" Width="300px" Height="30px" ForeColor="White"  CssClass="newStyle1"  />
		</div>
	</form>
		</div>
</body>

</html>
