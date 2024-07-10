<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ElectionDate.aspx.cs" Inherits="ElectionDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <center><table border="1"  width ="70%">

        <tr>
            <th colspan="2">
                <h1>
                    Set Election Date</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Select State</td>
 
            <td class="style1">
                <asp:DropDownList ID="DropDownList1" runat="server" 
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
                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td colspan="2" style="text-align :center ; ">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Submit</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Clear</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table></center>
          
</asp:Content>

