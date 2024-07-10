<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserViewVotingStatus.aspx.cs" Inherits="UserViewVotingStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <table border="1" width ="70%" align="center" >
            <tr>
                <th colspan ="2"  >
                    <h1>
                        Voting Status</h1>
                </th>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Enter Your Transaction ID</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">View</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                  <center> 
                      <asp:DetailsView ID="DetailsView1" runat="server" Height="276px" 
                          Width="343px"  EmptyDataText ="Record Not Found!!!" AutoGenerateRows ="False" 
                          BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                          CellPadding="4" CellSpacing="2" ForeColor="Black" >
                      <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <Fields >
                  <asp:BoundField DataField ="uname" HeaderText ="Nominee Name" />
                  <asp:BoundField DataField ="pname" HeaderText ="Party Name" />
                  <asp:BoundField DataField ="state" HeaderText ="State" />
                  <asp:BoundField DataField ="cons" HeaderText ="Constituency" />
                  <asp:BoundField DataField ="status" HeaderText ="Status" />
                  </Fields>
                      <FooterStyle BackColor="#CCCCCC" />
                      <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                      <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                      <RowStyle BackColor="White" HorizontalAlign="Left" />
                    </asp:DetailsView>
                    </center> 
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
   
</asp:Content>

