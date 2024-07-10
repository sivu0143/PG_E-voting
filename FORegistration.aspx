<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FORegistration.aspx.cs" Inherits="FORegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        text-align: left;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <center><tableborder="2"  width ="70%">
        <tr>
            <th colspan="2">
            <h1>Field Officer Registration</h1>

            </th>
        </tr>
        <tr>
            <td  style ="text-align :right ;">
               Field Officer Name</td>
        
            <td class="style1" >
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
             
            </td>
        </tr>
    
        <tr>
            <td  style ="text-align :right ;">
               User Id</td>
            <td class="style1" >
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
              
            </td>
        </tr>
   
        <tr>
            <td  style ="text-align :right ;">
                Password</td>
            <td class="style1" >
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
             
            </td>
        </tr>
   
        <tr>
            <td style ="text-align :right ;" >
                Constituency</td>
            <td class="style1" >
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
            <td style ="text-align :center ;" colspan="2" >
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Insert</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Clear</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2" >
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table></center>
       
    
</asp:Content>

