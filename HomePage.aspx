<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style >

  .style7
        {
          
            font-size: 35px;
            font-family: "Times New Roman", Times, serif;
            color: #FF3300;
            font-style: italic;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label2" runat="server" CssClass="style7" 
        Text="&quot;<b>Vote<b> is Our Right.Don't Sell Your Vote&quot;"></asp:Label>
    <br />
    <br />


    <marquee >
      <img src="Img/v12.jpg" width ="300" height ="200" />
        <img src="Img/v13.jpg" width ="300" height ="200" />
     <img src="Img/v5.jpg" width ="300" height ="200" />
      <img src="Img/v6.jpg" width ="300" height ="200" />
       <img src="Img/v7.jpg" width ="300" height ="200" />
         <img src="Img/v8.jpg" width ="300" height ="200" />

    <img src="Img/v9.jpg" width ="300" height ="200" />
     <img src="Img/v10.jpg" width ="300" height ="200" />
    </marquee>
</asp:Content>


