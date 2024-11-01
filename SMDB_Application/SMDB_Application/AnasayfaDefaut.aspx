<%@ Page Title="" Language="C#" MasterPageFile="~/AnasayfaMaster.Master" AutoEventWireup="true" CodeBehind="AnasayfaDefaut.aspx.cs" Inherits="SMDB_Application.AnasayfaDefaut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="AdminPanel/CSS/anaMenuStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anaMenu">
        <div class="solMenu">
            <div class="muzik">
                <h3>müzik info</h3>
            </div>
            <div class="albumler">
                <div class="albumKapak">
                </div>
                <div>
                    <h3>albüm info</h3>
                </div>
            </div>

        </div>
        <div class="sagMenu">
            <div>
                <h3>Müzik Tür Listesi</h3>
            </div>
        </div>
        <div style="clear: both"></div>
    </div>
</asp:Content>
