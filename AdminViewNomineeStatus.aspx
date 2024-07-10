<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewNomineeStatus.aspx.cs" Inherits="AdminViewNomineeStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><table align="center" border="1" width="60%"  >
        <tr>
            <th colspan ="2">
                  <h1  style =" text-align :center ;">
                      &nbsp;</h1>
                  <h1  style =" text-align :center ;">
                    View
                      Candidate Status</h1>
                  <p  style =" text-align :center ;">
                      &nbsp;</p>
            </th>
        </tr>
        <tr>
            <td colspan ="2">
                <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="459px" 
                    AutoGenerateRows ="False" EmptyDataText="Record Not Found!!!" 
                    BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                    CellPadding="4" CellSpacing="2" ForeColor="Black" >
                    <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <Fields >
                <asp:BoundField DataField ="cname" HeaderText ="Candidate Name" />
                    <asp:BoundField DataField ="fname" HeaderText ="Father Name" />
                        <asp:BoundField DataField ="cnumber" HeaderText ="Contact Number" />
                            <asp:BoundField DataField ="gender" HeaderText ="Gender" />
                                <asp:BoundField DataField ="dob" HeaderText ="Date of Birth" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                                    <asp:BoundField DataField ="state" HeaderText ="State" />
                                        <asp:BoundField DataField ="cons" HeaderText ="Constituency" />
                                            <asp:BoundField DataField ="crecord" HeaderText ="Criminal Records" />
                                                <asp:BoundField DataField ="aincome" HeaderText ="Annual Income" />
                                                    <asp:BoundField DataField ="passets" HeaderText ="Property Assets" />
                                                        <asp:BoundField DataField ="address" HeaderText ="Address" />
                                                            <asp:BoundField DataField ="pname" HeaderText ="Party Symbol" />
                                                                <asp:BoundField DataField ="nfdate" HeaderText ="Nomination Filling Date" />
                                                                <asp:BoundField DataField ="uname" HeaderText ="User Name" />
                                                                <asp:ImageField DataImageUrlField ="symbol" DataImageUrlFormatString ="Image/{0}" HeaderText ="Symbol">
                                                                <ControlStyle Width ="100" Height ="100" />
                                                                </asp:ImageField>

                                                                <asp:ImageField DataImageUrlField ="cphoto" DataImageUrlFormatString ="Image/{0}" HeaderText ="Photo">
                                                                <ControlStyle Width ="100" Height ="100" />
                                                                </asp:ImageField>

                
                </Fields>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle HorizontalAlign="Left" BackColor="White" />
                </asp:DetailsView>
            </td>
        </tr>
        <tr>
        <td style ="text-align :right ;">Status
        </td> 
        <td style="text-align: left">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" 
                AutoPostBack="True" 
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                RepeatDirection="Horizontal">
                <asp:ListItem>Accept</asp:ListItem>
                <asp:ListItem>Reject</asp:ListItem>
            </asp:RadioButtonList>
            </td>
        </tr>

        <tr>
            <td colspan ="2" style ="text-align :center ;">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table></center>
</asp:Content>



