<%@ Page Title="Edit Domain" Language="C#" MasterPageFile="~/site2.Master" AutoEventWireup="true" CodeBehind="Edit_domain.aspx.cs" Inherits="Meshwar.admin.Edit_domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
<style type="text/css">
        .newStyle1 {
            font-family: Verdana, Geneva, Tahoma, sans-serif;
            font-size: x-large;
            font-weight: 700;
            font-style: normal;
            color: #842029;
        }
        .auto-style5 {
            font-family: Verdana, Geneva, Tahoma, sans-serif;
            font-size: xx-large;
            font-weight: 700;
            font-style: normal;
            color: #842029;
        }
        tr{
            padding:10%
        }
        .auto-style7 {
            width: 59%;
            height: 661px;
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
        height: 64px;
    }
    .auto-style21 {
        height: 34px;
    }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <div id="table-container">
    <table id="form1" style="background-color:mistyrose; margin:30px;padding:10px;border-radius:20%; height: 363px; width: 46%;" class="auto-style7">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <tr>
               <td colspan="2" class="auto-style20" style="padding:20px"><strong class="auto-style5">Add Domains</strong></td>
        </tr>
   

     <tr>
            <td class="auto-style21"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Domain:</strong></td>
            <td class="auto-style21">
                  <br />
                <asp:TextBox ID="txtDomain" runat="server" Height="38px" BorderColor="#990000" BorderStyle="Double" Width="349px"></asp:TextBox>
                <br />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter your domain" ControlToValidate="txtDomain" ForeColor="#990000"></asp:RequiredFieldValidator>
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
