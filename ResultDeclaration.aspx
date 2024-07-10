<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ResultDeclaration.aspx.cs" Inherits="ResultDeclaration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table border="1"  width ="70%">
            <tr>
                <th colspan="2">
                    <h1>
                        Result Declared</h1>
                </th>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                Select State</td>
                <td class="style1">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                   >
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>TamilNadu</asp:ListItem>
                        <asp:ListItem>Kerala</asp:ListItem>
                        <asp:ListItem>Andra</asp:ListItem>
                        <asp:ListItem>Karnadaga</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                Election Date</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align :center ; ">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Declared</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>

