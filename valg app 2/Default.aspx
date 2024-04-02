<%@ Page Title="Valg app" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="valg_app_2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <div class="triangle" id="Home">
        <svg width="100" height="100">
            <polygon points="5000, 50, 100, 100, 0, 100" fill="#ede6db" />
        </svg>
    </div> 

    <div class="triangle-container">
        <h1 class="h1-heading">Velg et parti</h1>
        <div class="triangle triangle-left"></div>
        <div class="triangle triangle-right"></div>
        <div class="content-container">
            <div class="content">
                <div class="grid-container">
                    <div class="grid-item"><img class="parti-img parti-img-r" src="img/rodt.png" alt="Rødt"></div>
                    <div class="grid-item"><img class="parti-img parti-img-sv" src="img/sv.png" alt="Sosialistisk venstre"></div>
                    <div class="grid-item"><img class="parti-img parti-img-ap" src="img/Arbeiderpartiet.png" alt="Arbeider partiet"></div>
                    <div class="grid-item"><img class="parti-img parti-img-sp" src="img/SP.png" alt="Senter partiet"></div>
                    <div class="grid-item"><img class="parti-img parti-img-mdg" src="img\Miljøpartiet_de_Grønne_logo.svg.png" alt="Miljø partiet de grønne"></div>
                    <div class="grid-item"><img class="parti-img parti-img-krf" src="img/krf.png" alt="Kristlig folkeparti"></div>
                    <div class="grid-item"><img class="parti-img parti-img-v" src="img/venstre.png" alt="Venstre"></div>
                    <div class="grid-item"><img class="parti-img parti-img-h" src="img/hoyre.png" alt="Høyre"></div>
                    <div class="grid-item"><img class="parti-img parti-img-frp" src="img/frp.png" alt="Fremskritts partiet"></div>
                </div>
            </div>
              <div class="dropdown">
                <%--<div class="pnr">--%>
                    <div class="dropdown">
                        <input class="dropdown-button" runat="server" type="text" ID="fnr" name="Fødselsnummer" maxlength="11" placeholder="Pnr..." required title="Ugyldig fødselsnummer!" pattern="(0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])\d{2}\s?\d{5}"/>
                        <div class="dropdown">
                            <span class="dropdown"></span>
                        </div>
                    </div>
                  </div>
            <div class="dropdown">
                <%--<div class="dropdown-content">--%>
                <asp:DropDownList ID="DropDownListKommuner" runat="server" Class="dropdown-button">
                    <asp:ListItem Selected="True" Value="0">Velg Kommune...</asp:ListItem>
                </asp:DropDownList>
            </div>
             <div class="dropdown">
                <%--<div class="Parti Button">--%>
                <asp:DropDownList ID="DropDownListPartier" runat="server" Class="dropdown-button">
                    <asp:ListItem Selected="True" Value="0">Velg Parti...</asp:ListItem>
                 </asp:DropDownList>
                </div>
            <asp:Button runat="server" CssClass="stem-button" Text="Stem" OnClick="ButtonVote_Click"/>
        </div>
    </div>

        <script src="/Scripts/JavaScript.js"></script>

</asp:Content>
