<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/ModMaster.Master" AutoEventWireup="true" CodeBehind="PlakSirketEkle.aspx.cs" Inherits="SMDB_Application.AdminPanel.PlakSirketEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/KatEkleStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anaPanel">
        <div class="panelBaslik">
            <h3>Plak Şirketi Ekle</h3>
        </div>
        <div class="panelIci">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="panel basarili" Visible="false">
                <span style="color: white">Kategori Ekleme İşlemi Başarılı</span>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panel basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="satir">
                <label>Şirket Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu" placeholder="İsim"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Şirket Adres</label><br />
                <asp:TextBox ID="tb_adres" runat="server" CssClass="metinKutu" placeholder="Adres"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Şirket Telefon</label><br />
                <asp:TextBox ID="tb_telefon" runat="server" CssClass="metinKutu" placeholder="Telefon"></asp:TextBox>
            </div>
            <div class="satir">
                <asp:CheckBox ID="cb_durum" runat="server" CssClass="katEkleCheck" Text="Şirket Aktif Mi?" />
            </div>
            <br />
            <div class="satir">
                <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click" CssClass="EkleButon">Şirket Ekle</asp:LinkButton>
                <div style="clear: both"></div>
            </div>
        </div>
    </div>
</asp:Content>
