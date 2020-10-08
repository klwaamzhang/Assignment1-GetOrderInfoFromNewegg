<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment1_GetOrderInfoFromNewegg._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div >
        <asp:Label runat="server" ID="errStr"></asp:Label>
         <asp:Literal ID="DynamicTable" runat="server"></asp:Literal>
    </div>

</asp:Content>
