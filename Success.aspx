<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Success.aspx.cs" Inherits="Success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table border="1" width ="70%" align ="center" >
            <tr>
                <th>
                    <h1 style ="line-height :50px; text-align :center ;" >
                        You are Successfully Voted</h1>
                    <p style ="line-height :50px; text-align :center ;" >
                        <asp:Label ID="Label2" runat="server" Font-Size="Large" ForeColor="#CC3399"></asp:Label>
                    </p>
                </th>
            </tr>
            <tr>
                <td style ="text-align :center ;">
                    <asp:Image ID="Image1" runat="server" Height="278px" 
                        ImageUrl="~/ele/voters.jpg" Width="337px" />
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;">
                    <br /><asp:Label ID="Label3" runat="server" Text="Thank You" Font-Size="XX-Large" 
                        ForeColor="#CC0066"></asp:Label>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>

