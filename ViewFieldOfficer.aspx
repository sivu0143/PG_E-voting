<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewFieldOfficer.aspx.cs" Inherits="ViewFieldOfficer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><table border="1" width ="70%" align ="center" >
        <tr>
            <th>
                 <h1 style ="line-height :50px; text-align :center ;" >
                     View Field Officer</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :center ;">
               <center>
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
               BackColor="#CCCCCC" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                    CellSpacing="2" ForeColor="Black" Width="544px" 
                       EmptyDataText="Record Not Found!!!" >
                    <Columns >
                       <asp:BoundField DataField ="Name"  HeaderText ="Name" />
                        <asp:BoundField DataField ="id"  HeaderText ="ID" />
                 <asp:BoundField DataField ="cons"  HeaderText ="Constituency" />   
                 
                    
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
            <td style ="text-align :center ;">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table></center>
</asp:Content>

