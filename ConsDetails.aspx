<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsDetails.aspx.cs" Inherits="ConsDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table border="1" width ="70%" align ="center" >
            <tr>
                <th colspan ="2">
                    <h1 style ="line-height :50px; text-align :center ;" >
                     Polling Details</h1>
                </th>
            </tr>
            <tr>
            <td style ="text-align :right ; ">State</td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>

            <tr>
            <td style ="text-align :right ; ">Constituency
                    </td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan ="2">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
               BackColor="#CCCCCC" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                    CellSpacing="2" ForeColor="Black" Width="544px" 
                     DataKeyNames="UName,PName" 
                       EmptyDataText="Record Not Found!!!" onrowcommand="GridView1_RowCommand"  >
                            <Columns >
                              <asp:BoundField DataField ="cname" HeaderText ="Candidate Name" />
                               <asp:BoundField DataField ="pname" HeaderText ="Party Name" />
                               <asp:ImageField DataImageUrlField ="symbol" HeaderText ="Party Symbol" DataImageUrlFormatString ="Image/{0}">
                               <ControlStyle Width ="100" Height ="100" />
                               </asp:ImageField>
                               <asp:ButtonField Text ="Vote Here" HeaderText ="Vote Here" CommandName ="vh" />


                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
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

