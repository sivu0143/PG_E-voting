<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewNomineeDetails.aspx.cs" Inherits="AdminViewNomineeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><table border="1" width ="70%" align ="center" >
        <tr>
            <th colspan ="2">
                <h1 style ="line-height :50px; text-align :center ;" >
                     View Nominee Details</h1>
            </th>
        </tr>
        <tr>
        <td style ="text-align :right ;">Select Constituency</td>
        <Td style="text-align: left">
            <asp:DropDownList ID="DropDownList1" runat="server">
             
                                              <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Chennai</asp:ListItem>
                        <asp:ListItem>Madurai</asp:ListItem>
                        <asp:ListItem>Tenkasi</asp:ListItem>
                        <asp:ListItem>Trichy</asp:ListItem>
                        <asp:ListItem>Coimbatore</asp:ListItem>
                        <asp:ListItem>Nellai</asp:ListItem>
                        <asp:ListItem>Erode</asp:ListItem>
                        <asp:ListItem>Thanjavur</asp:ListItem>
                         <asp:ListItem>Thirunelveli</asp:ListItem>
                 
            </asp:DropDownList>
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
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
               BackColor="#CCCCCC" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                    CellSpacing="2" ForeColor="Black" Width="680px" 
                  
                       EmptyDataText="Record Not Found!!!" onrowcommand="GridView1_RowCommand" 
                        DataKeyNames="uname" >
                        <Columns >
                            <asp:BoundField DataField ="cname"  HeaderText ="Candidate Name"/>
                            <asp:BoundField DataField ="pname"  HeaderText ="Party Symbol Name"/>
                            <asp:BoundField DataField ="nfdate"  HeaderText ="Nomination Filling Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}"/>
                            <asp:ImageField DataImageUrlField ="cphoto" HeaderText ="Photo" DataImageUrlFormatString ="Image/{0}">
                            <ControlStyle Width ="100" Height ="100" />
                            </asp:ImageField>
                            <asp:ButtonField Text ="View Status" HeaderText ="View Status" CommandName ="vv" />

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
                </center>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan ="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table></center>
</asp:Content>

