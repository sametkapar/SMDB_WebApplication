<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KullaniciGiris.aspx.cs" Inherits="SMDB_Application.KullaniciGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kullanıcı Giriş</title>
    <link href="AdminPanel/CSS/LoginPageStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="logoAlani">
                <%--<img src="Resimler/Logo300x300.png" />--%>
            </div>
            <h3>HOŞGELDİNİZ</h3>
            <asp:Panel ID="pnl_hata" runat="server" CssClass="hatakutu" Visible="false">
                <asp:Label ID="lbl_hatametin" runat="server"></asp:Label>
            </asp:Panel>
            <div class="anaPanel">
                <div class="satir">
                    <label>MAİL ADRESİ</label>
                    <asp:TextBox ID="tb_username" runat="server" CssClass="metinKutu" Placeholder="mail@smdb.com"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>PAROLA</label>
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu" TextMode="password" Placeholder="Parola"></asp:TextBox>
                </div>
                <div class="satir" style="text-align: center;">
                    <asp:LinkButton ID="lbtn_giris" runat="server" CssClass="girisButon" OnClick="lbtn_giris_Click">Giriş Yap</asp:LinkButton>
                </div>
                <br />
                <div class="satir" style="text-align: center;">
                    <a href="UyeOl.aspx" class="girisButon">Uye Ol</a>
                </div>
            </div>
            <div style="clear: both"></div>
        </div>
    </form>
</body>
</html>
