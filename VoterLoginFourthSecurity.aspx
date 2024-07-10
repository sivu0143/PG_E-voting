<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VoterLoginFourthSecurity.aspx.cs" Inherits="VoterLoginFourthSecurity" %>

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
                        OTP Verification</h1>
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
                    OTP</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Verification</asp:LinkButton>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style ="float : right ;"><asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Get OTP</asp:LinkButton></span>
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

