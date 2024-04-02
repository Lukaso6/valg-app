<%@ Page Title="Valg app resultater" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="valg_app_2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="leder" HeaderText="Leder"/>
        <asp:BoundField DataField="pnavn" HeaderText="Parti" />
        <asp:BoundField DataField="antall" HeaderText="Stemmer" />
    </Columns>
  </asp:GridView>

</asp:Content>
