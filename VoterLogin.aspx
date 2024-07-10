<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VoterLogin.aspx.cs" Inherits="VoterLogin" %>

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
                        Voter Login</h1>
                </th>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Voter ID</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Password</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Login</asp:LinkButton>
                       <span style ="float :right ;">   <asp:HyperLink ID="HyperLink1" 
                    runat="server" NavigateUrl="~/VoterRegistration.aspx" >New Registration</asp:HyperLink></span>
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

