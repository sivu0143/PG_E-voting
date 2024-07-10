<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VoterViewOurDetails.aspx.cs" Inherits="VoterViewOurDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table border="1" width ="70%" align ="center" >
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
                             <asp:BoundField DataField ="vid"  HeaderText ="Voter ID"/>
                                <asp:BoundField DataField ="vname"  HeaderText ="Voter Name"/>
                                 <asp:BoundField DataField ="fname"  HeaderText ="Father Name"/>
                                     <asp:BoundField DataField ="dob"  HeaderText ="Date Of Birth" HtmlEncode ="false"/>
                                     <asp:BoundField DataField ="gender"  HeaderText ="Gender"/>
                                     <asp:BoundField DataField ="cno"  HeaderText ="Contact Number"/>
                                     <asp:BoundField DataField ="state"  HeaderText ="State"/>
                                     <asp:BoundField DataField ="cons"  HeaderText ="Constiuency"/>
                                      <asp:BoundField DataField ="address"  HeaderText ="Address"/>
                                <asp:BoundField DataField ="rdate"  HeaderText ="Registration Date" HtmlEncode ="false" />
                                <asp:ImageField DataImageUrlField ="photo" HeaderText ="Photo" DataImageUrlFormatString ="TImage/{0}">
                                    <ControlStyle Width ="100" Height ="100" />
                                </asp:ImageField>

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
        </table>
    </center>
</asp:Content>

