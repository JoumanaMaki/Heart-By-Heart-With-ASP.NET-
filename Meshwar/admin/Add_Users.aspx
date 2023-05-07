<%@ Page Title="Add Users" Language="C#" MasterPageFile="~/site2.Master" AutoEventWireup="true" CodeBehind="Add_Users.aspx.cs" Inherits="Meshwar.admin.Add_Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .newStyle1 {
            font-family: Verdana, Geneva, Tahoma, sans-serif;
            font-size: x-large;
            font-weight: 700;
            font-style: normal;
            color: #842029;
        }
        .auto-style3 {
            width: 527px;
            text-align: center;
            direction: rtl;
        }
        .auto-style4 {
            width: 391px;
            text-align: right;
            direction: rtl;
            color: #990000;
            font-size: large;
            height: 66px;
        }
        .auto-style5 {
            font-family: Verdana, Geneva, Tahoma, sans-serif;
            font-size: xx-large;
            font-weight: 700;
            font-style: normal;
            color: #842029;
        }
        .auto-style6 {
            font-size: 12pt;
            width: 463px;
            height: 66px;
        }
        tr{
            padding:10%
        }
        .auto-style7 {
            width: 59%;
            height: 661px;
        }
        .auto-style9 {
            width: 391px;
            text-align: right;
            color: #990000;
            font-size: large;
            height: 74px;
        }
        .auto-style10 {
            width: 463px;
            height: 74px;
        }
        .auto-style11 {
            width: 391px;
            text-align: right;
            color: #990000;
            font-size: large;
            height: 71px;
        }
        .auto-style12 {
            width: 463px;
            height: 71px;
        }
        .auto-style13 {
            width: 391px;
            text-align: right;
            color: #990000;
            font-size: large;
            height: 72px;
        }
        .auto-style14 {
            width: 463px;
            height: 72px;
        }
        .auto-style15 {
            width: 391px;
            text-align: right;
            color: #990000;
            font-size: large;
            height: 73px;
        }
        .auto-style16 {
            width: 463px;
            height: 73px;
        }
        .auto-style17 {
            width: 391px;
            text-align: right;
            color: #990000;
            font-size: large;
            height: 70px;
        }
        .auto-style18 {
            width: 463px;
            height: 70px;
        }
        #table-container {
    display: flex;
    justify-content: center;
    align-items: center;
}
        .auto-style19 {
            text-align: center;
            height: 68px;
        }
        .auto-style20 {
            width: 391px;
            text-align: center;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <div id="table-container">
    <table id="form1" style="background-color:mistyrose; margin:30px;padding:10px;border-radius:20%" class="auto-style7">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <tr>
               <td colspan="2" class="auto-style20" style="padding:20px"><strong class="auto-style5">Add Admins</strong></td>
        </tr>
        <tr>
            <td class="auto-style9"><strong>Username :</strong></td>
            <td class="auto-style10">
               <br />    <asp:TextBox ID="txtUsername" runat="server" BorderColor="#990000" BorderStyle="Double" Height="38px" Width="349px"></asp:TextBox>
              <br />     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter your  Name"  ControlToValidate="txtUsername" ForeColor="#990000"></asp:RequiredFieldValidator>
                </td>
        </tr>
      
        <tr>
            <td class="auto-style13"><strong>Email:</strong></td>
            <td class="auto-style14">
                <br />
                <asp:TextBox ID="txtEmail" runat="server" Height="38px" BorderColor="#990000" BorderStyle="Double" Width="349px"></asp:TextBox>
           <br />     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter your Email" ControlToValidate="txtEmail" ForeColor="#990000"></asp:RequiredFieldValidator> 
                </tr>
      
      
        <tr>
            <td class="auto-style11"><strong>Password:</strong></td>
            <td class="auto-style12">
              <br />     <asp:TextBox ID="txtPassword" runat="server" Height="38px" BorderColor="#990000" BorderStyle="Double" Width="349px" TextMode="Password" ToolTip="*"></asp:TextBox>
              <br />     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter your password" ControlToValidate="txtPassword" ForeColor="#990000"></asp:RequiredFieldValidator>
                </td>
        </tr>

          <tr>
            <td class="auto-style11"><strong>Gender:</strong></td>
            <td class="auto-style12">
              <br />  <asp:RadioButton ID="RadioButton1" runat="server" checked Text="Male" GroupName="Gender"/>
                <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" GroupName="Gender" />
              <br />    
                </td>
        </tr>
        <tr>
            <td class="auto-style4"><strong>Image</strong></td>
            <td class="auto-style6">
          <br />         <asp:FileUpload ID="FileUpload1" runat="server" />
                   <br />     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter your Photo" ControlToValidate="FileUpload1" ForeColor="#990000"></asp:RequiredFieldValidator>
            </td>
        </tr>
    
    <tr style="padding:10px"><td colspan="2" class="auto-style19">
        <asp:Button ID="btnSubmit" runat="server" BackColor="#990000" ForeColor="#FFCCCC" OnClick="btnSubmit_Click" Text="Save" Height="48px" Width="96px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="txtReset" runat="server" BackColor="#FF9999" BorderColor="#FF9999" ForeColor="#990000" Height="48px" OnClick="txtReset_Click" Text="Reset" Width="96px" type="reset"/>
        </td>
  </tr>
        </table>
        </div>
    


</asp:Content>
