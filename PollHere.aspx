<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PollHere.aspx.cs" Inherits="PollHere" %>

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
        <table border="1" width ="70%">
            <tr>
                <th colspan ="2"  >
                    <h1>
                        Voting Page</h1>
                </th>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Voter ID</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Voter Name</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    State</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                   Constituency
                    </td>
                <td class="style1">
                    <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Poll Page</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>

