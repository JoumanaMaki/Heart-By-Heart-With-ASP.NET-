<%@ Page Title="Add Article" Language="C#" MasterPageFile="~/site2.Master" AutoEventWireup="true" CodeBehind="AddArticles.aspx.cs" Inherits="Meshwar.admin.AddArticles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-size: x-large;
            height: 59px;
        }
        .newStyle1 {
            color: #990000;
        }
        .auto-style3 {
            width: 329px;
            height: 49px;
            text-align: center;
        }
        .auto-style4 {
            height: 49px;
        }
        .auto-style8 {
            width: 329px;
            text-align: center;
            height: 47px;
        }
        .auto-style9 {
            height: 47px;
        }
        .auto-style10 {
            width: 329px;
            height: 48px;
            text-align: center;
        }
        .auto-style11 {
            height: 48px;
        }
        .newStyle2 {
            color: #8B0000;
        }
        .newStyle3 {
            color: #8B0000;
        }
        .newStyle4 {
            color: #8B0000;
        }
        .newStyle5 {
            color: #8B0000;
        }
        .newStyle6 {
            color: #8B0000;
        }
        .auto-style12 {
            text-align: center;
        }
        .auto-style13 {
            width: 60%;
            height: 506px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="background-color:mistyrose;margin-top:20px;padding:10px;margin-left:20%;border-radius:10%" class="auto-style13">
             <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

        
        <tr>
            <td class="auto-style1" colspan="2">
                <h1><strong class="newStyle1">Add Articles</strong></h1>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"><strong class="newStyle2">Title:</strong></td>
            <td class="auto-style9">
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                   <br />    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter your title" ControlToValidate="txtTitle" ForeColor="#990000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"><strong class="newStyle3">Abstract:</strong></td>
            <td class="auto-style9">
                <asp:TextBox ID="txtAbstract" runat="server"></asp:TextBox>
                   <br />    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter your abstract" ControlToValidate="txtAbstract" ForeColor="#990000"></asp:RequiredFieldValidator>
            </td>
        </tr>
                    <td class="auto-style8"><strong class="newStyle3">Domain:</strong></td>
     <td> <asp:DropDownList ID="DropDownList1" runat="server">
       
        </asp:DropDownList></td>  
        <tr>
            <td class="auto-style10"><strong class="newStyle4">Name of the coworkers:</strong></td>
            <td class="auto-style11">
                <asp:TextBox ID="txtNames" runat="server"></asp:TextBox>
                   <br />    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter you Last Name" ControlToValidate="txtNames" ForeColor="#990000"></asp:RequiredFieldValidator>
            </td>
        </tr>


         <tr>
            <td class="auto-style11"><strong class="newStyle4">Premium:</strong></td>
            <td class="auto-style12">
              <br />  <asp:RadioButton ID="RadioButton1" runat="server" checked Text="Yes" GroupName="Premium"/>
                <asp:RadioButton ID="RadioButton2" runat="server" Text="No" GroupName="Premium" />
              <br />   
                </td>
        </tr>
        <tr>
            <td class="auto-style3"><strong class="newStyle5">Release date:</strong></td>
            <td class="auto-style4">
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#990000" Height="200px" Width="220px">
                    <DayHeaderStyle BackColor="#FFCCCC" ForeColor="#990000" Height="1px" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="auto-style10"><strong class="newStyle6">PDF file:</strong></td>
            <td class="auto-style11">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                   <br />    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter your cv" ControlToValidate="FileUpload1" ForeColor="#990000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12" colspan="2">
                <asp:Button ID="btnSubmit" runat="server" BackColor="#990000" ForeColor="White" Text="Add" Width="82px" OnClick="btnSubmit_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
            </td>
        </tr>
        </table>
</asp:Content>
