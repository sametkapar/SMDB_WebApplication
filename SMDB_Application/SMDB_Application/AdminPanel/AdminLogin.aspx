<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="SMDB_Application.AdminPanel.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/LoginPageStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="logoAlani">
                <img src="Resimler/Logo300x300.png" />
            </div>
            <h3>SMDB ADMİN PANEL</h3>
            <asp:Panel ID="pnl_hata" runat="server" CssClass="hatakutu" Visible="false">
                <asp:Label ID="lbl_hatametin" runat="server"></asp:Label>
            </asp:Panel>
            <div class="anaPanel">
                <div class="satir">
                    <label>MAİL ADRESİ</label>
                    <asp:TextBox ID="tb_username" runat="server" CssClass="metinKutu" Text="sk@smdb.com"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>PAROLA</label>
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu" Text="1965"></asp:TextBox>
                </div>
                <div class="satir" style="text-align: center;">
                    <asp:LinkButton ID="lbtn_giris" runat="server" CssClass="girisButon" OnClick="lbtn_giris_Click">Giriş Yap</asp:LinkButton>
                </div>
            </div>
            <div style="clear:both"></div>

        </div>
    </form>
</body>
</html>
