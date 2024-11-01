<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="SMDB_Application.UyeOl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="AdminPanel/CSS/LoginPageStyle.css" rel="stylesheet" />
    <title>UYE OL</title>
</head>
<body>
    <form id="form1" runat="server">
      <div class="main">
    <div class="logoAlani">
        <%--<img src="Resimler/Logo300x300.png" />--%>
    </div>
    <h3>SMDB'ye UYE OL</h3>
    <asp:Panel ID="pnl_hata" runat="server" CssClass="hatakutu" Visible="false">
        <asp:Label ID="lbl_hatametin" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnl_basarili" runat="server" CssClass="hatakutu basarili" Visible="false">
        <span style="color: white">Üyelik İşlemi Başarılı</span>
    </asp:Panel>
    <div class="anaPanel">
        <div class="satir">
            <label>İSİM</label>
            <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu"></asp:TextBox>
        </div>
        <div class="satir">
            <label>SOYİSİM</label>
            <asp:TextBox ID="tb_soyisim" runat="server" CssClass="metinKutu"></asp:TextBox>
        </div>
        <div class="satir">
            <label>KULLANICI ADI</label>
            <asp:TextBox ID="tb_username" runat="server" CssClass="metinKutu"></asp:TextBox>
        </div>
        <div class="satir">
            <label>MAİL ADRESİ</label>
            <asp:TextBox ID="tb_mail" runat="server" CssClass="metinKutu"></asp:TextBox>
        </div>
        <div class="satir">
            <label>PAROLA</label>
            <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu"></asp:TextBox>
        </div>
        <div class="satir" style="text-align: center;">
            <asp:LinkButton ID="lbtn_kaydet" runat="server" CssClass="girisButon" OnClick="lbtn_kaydet_Click">KAYIT</asp:LinkButton>
        </div>
    </div>
    <div style="clear: both"></div>
</div>
    </form>
</body>
</html>
