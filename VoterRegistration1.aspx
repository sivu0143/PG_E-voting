<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VoterRegistration1.aspx.cs" Inherits="VoterRegistration1" %>

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
                        Voter Registration Details</h1>
                </th>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Voter ID</td>
                <td class="style1">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Face Recognization</td>
                <td class="style1">
                    <asp:Image ID="Image1" runat="server" Height="150px" Width="150px" />
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    QR Image</td>
                <td class="style1">
                    <asp:Image ID="Image2" runat="server" Height="150px" Width="150px" />
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    QR Image Location</td>
                <td class="style1">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/VoterLogin.aspx" >Login</asp:HyperLink>
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

