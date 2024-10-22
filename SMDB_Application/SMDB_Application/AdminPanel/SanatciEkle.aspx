<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/ModMaster.Master" AutoEventWireup="true" CodeBehind="SanatciEkle.aspx.cs" Inherits="SMDB_Application.AdminPanel.SanatciEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/KatEkleStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anaPanel">
        <div class="panelBaslik">
            <h3>Sanatçı Ekle</h3>
        </div>
        <div class="panelIci">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="panel basarili" Visible="false">
                <span style="color: white">Sanatçı Ekleme İşlemi Başarılı</span>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panel basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="satir">
                <label>Sanatçı İsim</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu" placeholder="Sanatçı İsim Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Sanatçı Soyisim</label><br />
                <asp:TextBox ID="tb_soyisim" runat="server" CssClass="metinKutu" placeholder="Sanatçı Soyisim Giriniz"></asp:TextBox>
            </div>

            <div class="satir">
                <asp:CheckBox ID="cb_grupMu" runat="server" CssClass="katEkleCheck" Text="Grup Mu?" />
            </div>
            <div class="satir">
                <asp:CheckBox ID="cb_durum" runat="server" CssClass="katEkleCheck" Text="Durum" />
            </div>
            <div class="satir">
                <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click" CssClass="EkleButon">Sanatçı Ekle</asp:LinkButton>
                <div style="clear: both"></div>
            </div>
        </div>
    </div>

</asp:Content>
