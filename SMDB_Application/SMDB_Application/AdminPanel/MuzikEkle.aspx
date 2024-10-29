<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/ModMaster.Master" AutoEventWireup="true" CodeBehind="MuzikEkle.aspx.cs" Inherits="SMDB_Application.AdminPanel.MuzikEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/KatEkleStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anaPanel">
        <div class="panelBaslik">
            <h3>Müzik Ekle</h3>
        </div>
        <div class="panelIci">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="panel basarili" Visible="false">
                <span style="color: white">Müzik Ekleme İşlemi Başarılı</span>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panel basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="satir">
                <label>Müzik Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu" placeholder="Müzik Adı Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Albüm Seçiniz</label><br />
                <asp:DropDownList ID="ddl_albumSec" runat="server" DataTextField="Isim" DataValueField="ID" AppendDataBoundItems="true" CssClass="metinKutu">
                    <asp:ListItem Value="-1" Text="Albüm"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="satir">
                <label>Müzik Türlerini Seçiniz</label>
           <asp:DropDownList ID="ddl_turSec" runat="server" DataTextField="Isim" DataValueField="ID" AppendDataBoundItems="true" CssClass="metinKutu">
                 <asp:ListItem Value="-1" Text="Tür"></asp:ListItem>
           </asp:DropDownList>
            </div>
            <div class="satir">
                <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click" CssClass="EkleButon">Müzik Ekle</asp:LinkButton>
                <div style="clear: both"></div>
            </div>


        </div>
    </div>
</asp:Content>
