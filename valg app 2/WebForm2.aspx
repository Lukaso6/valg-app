<%@ Page Title="Valg app charts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="valg_app_2.WebForm2" %>
<asp:Content ID="chart1" ContentPlaceHolderID="MainContent" runat="server">

<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>

<canvas id="myChart" style="width:100%;max-width:600px;margin: auto;"></canvas>
    <asp:HiddenField runat="server" ID="count" />
<script>

    /*parti variabler*/

    var Values = document.querySelector("#MainContent_count").value.split(",");

    /*sektor diagram*/

    const xValues = ["Rødt", "SV", "AP", "SP", "MDG", "KRF", "Venstre", "Høyre", "FRP"];
    const yValues = Values;
    const barColors = [
      "#E52437",
      "#AE0161",
      "#D60927",
      "#13974D",
      "#8BC043",
      "#FBB13A",
      "#01462E",
      "#257CE1",
      "#06205C"
    ];

    new Chart("myChart", {
      type: "pie",
      data: {
        labels: xValues,
        datasets: [{
          backgroundColor: barColors,
          data: yValues
        }]
      },
      options: {
        title: {
          display: true,
          text: "Valg resultater 2069"
        }
      }
    });
</script>
</asp:Content>
