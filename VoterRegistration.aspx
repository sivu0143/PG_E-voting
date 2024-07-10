<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VoterRegistration.aspx.cs" Inherits="VoterRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
            text-align: left;
        }
        .style2
        {
            height: 21px;
        }
        .style3
        {
            text-align: left;
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table border="1" width ="70%">
            <tr>
                <th colspan ="2"  >
                    <h1>
                        Voter Registration</h1>
                </th>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Voter ID</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Name of the Voter</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Father Name</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;" class="style2">
                    Email ID</td>
                <td class="style3">
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="TextBox8" ErrorMessage="Type Valid MailID" ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Date of Birth</td>
                <td class="style1">
                    <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="False">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList2" runat="server" Font-Bold="False">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Jan</asp:ListItem>
                        <asp:ListItem>Feb</asp:ListItem>
                        <asp:ListItem>Mar</asp:ListItem>
                        <asp:ListItem>Apr</asp:ListItem>
                        <asp:ListItem>May</asp:ListItem>
                        <asp:ListItem>Jun</asp:ListItem>
                        <asp:ListItem>Jul</asp:ListItem>
                        <asp:ListItem>Aug</asp:ListItem>
                        <asp:ListItem>Sep</asp:ListItem>
                        <asp:ListItem>Oct</asp:ListItem>
                        <asp:ListItem>Nov</asp:ListItem>
                        <asp:ListItem>Dec</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList3" runat="server" Font-Bold="False">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Gender</td>
                <td class="style1">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Mobile Number</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="TextBox4" ErrorMessage="Enter 10 Digit Mobile Number" 
                        ForeColor="Red" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    State</td>
                <td class="style1">
                    <asp:DropDownList ID="DropDownList4" runat="server" Font-Bold="False">
                         <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>TamilNadu</asp:ListItem>
                    <%--<asp:ListItem>Kerala</asp:ListItem>
                    <asp:ListItem>Andra</asp:ListItem>
                    <asp:ListItem>Karnadaga</asp:ListItem>--%>
                    </asp:DropDownList>
                   </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Constituency</td>
                <td class="style1">
                    <asp:DropDownList ID="DropDownList5" runat="server" Font-Bold="False">
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
                <td style ="text-align :right ;">
                    Address</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Regstration Date</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox6" runat="server" Height="22px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td style ="text-align :right ;">
                    Password</td>
                <td class="style1">
                    <asp:TextBox ID="TextBox7" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Face
                </td>
                <td class="style1">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
           
            <tr>
                <td style ="text-align :right ;">
                    Finger Print</td>
                <td class="style1">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </td>
            </tr>
           
            <tr>
                <td style ="text-align :center ;" colspan="2">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Register</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
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

