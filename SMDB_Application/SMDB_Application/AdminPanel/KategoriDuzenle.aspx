﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMaster.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenle.aspx.cs" Inherits="SMDB_Application.AdminPanel.KategoriDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/KatEkleStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anaPanel">
        <div class="panelBaslik">
            <h3>Kategori Düzenle</h3>
        </div>
        <div class="panelIci">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="panel basarili" Visible="false">
                <span style="color: white">Kategori Düzenleme İşlemi Başarılı</span>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panel basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="satir">
                <label>Kategori Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu" placeholder="Kategori Adı Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <asp:CheckBox ID="cb_durum" runat="server" CssClass="katEkleCheck" Text="Kategori Aktif Mi?" />
            </div>
            <br />
            <div class="satir">
                <asp:LinkButton ID="lbtn_düzenle" runat="server" OnClick="lbtn_düzenle_Click"
                    CssClass="EkleButon">Kategori Düzenle</asp:LinkButton>
                <div style="clear: both"></div>
            </div>
        </div>
    </div>

</asp:Content>