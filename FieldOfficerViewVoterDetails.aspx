<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FieldOfficerViewVoterDetails.aspx.cs" Inherits="FieldOfficerViewVoterDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table border="1" width ="70%" align ="center" >
            <tr>
                <th colspan ="2">
                    <h1 style ="line-height :50px; text-align :center ;" >
                     View Voter Details</h1>
                </th>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Select Constituency</td>
                <Td style="text-align: left">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style ="text-align :center ;" colspan="2">
                    <center>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
               BackColor="#CCCCCC" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                    CellSpacing="2" ForeColor="Black" Width="680px" 
                  
                       EmptyDataText="Record Not Found!!!" onrowcommand="GridView1_RowCommand" 
                        DataKeyNames="vid" >
                            <Columns >
                                <asp:BoundField DataField ="vid"  HeaderText ="Voter ID"/>
                                <asp:BoundField DataField ="vname"  HeaderText ="Voter Name"/>
                                <asp:BoundField DataField ="rdate"  HeaderText ="Registration Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}"/>
                                <asp:ImageField DataImageUrlField ="photo" HeaderText ="Photo" DataImageUrlFormatString ="TImage/{0}">
                                    <ControlStyle Width ="100" Height ="100" />
                                </asp:ImageField>
                                <asp:ButtonField Text ="Selected" HeaderText ="Status" CommandName ="ss" />
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
        </table>
    </center>
</asp:Content>

