<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PollingResults.aspx.cs" Inherits="PollingResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table border="1" width ="70%" align ="center" >
            <tr>
                <th colspan ="2">
                    <h1 style ="line-height :50px; text-align :center ;" >
&nbsp;Results</h1>
                </th>
            </tr>
            <tr>
                <td style ="text-align :right ; ">
                    State</td>
                <td style="text-align: left">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                       <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>TamilNadu</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ; ">
                    Constituency
                    </td>
                <td style="text-align: left">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ; " colspan="2">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">View</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan ="2">
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Winner" Font-Size="Large" 
                        ForeColor="#CC0066"></asp:Label>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan ="2">
                    <center><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
               BackColor="#CCCCCC" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                    CellSpacing="2" ForeColor="Black" Width="544px" 
                     DataKeyNames="UName,PName" 
                       EmptyDataText="Record Not Found!!!"   >
                        <Columns >
                            <asp:BoundField DataField ="uname" HeaderText ="Nominee Name" />
                            <asp:BoundField DataField ="pname" HeaderText ="Party Name" />
                            <asp:ImageField DataImageUrlField ="symbol" HeaderText ="Party Symbol" DataImageUrlFormatString ="Image/{0}">
                                <ControlStyle Width ="100" Height ="100" />
                            </asp:ImageField>
                       <asp:BoundField DataField ="noofvote" HeaderText ="No of Votes" />
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
                    </asp:GridView></center>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                  <br />
                    <asp:Label ID="Label3" runat="server" Text="Other Candidates" Font-Size="Large" 
                        ForeColor="#CC0066"></asp:Label>
                    <br />
                    <br />
                   </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                 <center>  <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns ="False" 
               BackColor="#CCCCCC" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                    CellSpacing="2" ForeColor="Black" Width="544px" 
                     DataKeyNames="UName,PName" 
                       EmptyDataText="Record Not Found!!!"   >
                        <Columns >
                            <asp:BoundField DataField ="uname" HeaderText ="Nominee Name" />
                            <asp:BoundField DataField ="pname" HeaderText ="Party Name" />
                            <asp:ImageField DataImageUrlField ="symbol" HeaderText ="Party Symbol" DataImageUrlFormatString ="Image/{0}">
                                <ControlStyle Width ="100" Height ="100" />
                            </asp:ImageField>
                       <asp:BoundField DataField ="noofvote" HeaderText ="No of Votes" />
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
                    </asp:GridView></center> 
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Label" ></asp:Label>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>

