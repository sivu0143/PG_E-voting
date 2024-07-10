<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCandidateDetails.aspx.cs" Inherits="ViewCandidateDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <center> <table border="1" width ="70%" align ="center" >
        <tr>
            <th>
                <h1 style ="line-height :50px; text-align :center ;" >
&nbsp;Profile Details</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :center ;">
                <center><asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="459px" 
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
                                                                  <asp:BoundField DataField ="status" HeaderText ="Status" />

                
                </Fields>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle HorizontalAlign="Left" BackColor="White" />
                </asp:DetailsView></center>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table></center>
</asp:Content>

