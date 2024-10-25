<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/ModMaster.Master" AutoEventWireup="true" CodeBehind="AlbumEkle.aspx.cs" Inherits="SMDB_Application.AdminPanel.AlbumEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/KatEkleStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anaPanel">
        <div class="panelBaslik">
            <h3>Albüm Ekle</h3>
        </div>
        <div class="panelIci">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="panel basarili" Visible="false">
                <span style="color: white">Albüm Ekleme İşlemi Başarılı</span>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panel basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="satir">
                <label>Albüm Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu" placeholder="Albüm Adı Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Çıkış Yılı</label><br />
                <asp:TextBox ID="tb_cikisYili" runat="server" CssClass="metinKutu" placeholder="Albüm Çıkış Yılı" TextMode="DateTime"></asp:TextBox>
            </div>
            <div class="satir">

                <label>Sanatçı Seçiniz</label><br />
                <asp:DropDownList ID="ddl_sanatciSec" runat="server" DataTextField="IsimSoyisim" DataValueField="ID" AppendDataBoundItems="true" CssClass="metinKutu">
                    <asp:ListItem Value="-1" Text="Sanatçı"></asp:ListItem>
                </asp:DropDownList>

                <label>Plak Şirketi Seçiniz</label><br />
                <asp:DropDownList ID="ddl_plakSirketSec" runat="server" DataTextField="Isim" DataValueField="ID" AppendDataBoundItems="true" CssClass="metinKutu">
                    <asp:ListItem Value="-1" Text="Şirket"></asp:ListItem>
                </asp:DropDownList>
                <div class="satir">
                    <label>Kapak Resmi</label><br />
                    <asp:FileUpload ID="fu_resim" runat="server" CssClass="metinKutu" />
                </div>
                <div class="satir">
                    <asp:CheckBox ID="cb_durum" runat="server" CssClass="katEkleCheck" Text="Albüm Aktif Mi?" />
                </div>
                <br />
                <div class="satir">
                    <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click" CssClass="EkleButon">Albüm Ekle</asp:LinkButton>
                    <div style="clear: both"></div>
                </div>

               
            </div>
        </div>
</asp:Content>
