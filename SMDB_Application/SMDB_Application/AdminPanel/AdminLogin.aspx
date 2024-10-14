﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="SMDB_Application.AdminPanel.AdminLogin" %>

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
            <h3>GİRİŞ</h3>
            <label>SMDB'ye hoş geldiniz</label>
            <div class="anaPanel">
                <div class="satir">
                    <label>MAİL İLE GİRİŞ YAPIN</label>
                    <asp:TextBox ID="tb_username" runat="server" CssClass="metinKutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>PAROLA</label>
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu"></asp:TextBox>
                </div>
                <div class="satir" style="text-align: center">
                    <asp:LinkButton ID="lbtn_giris" runat="server" CssClass="girisButon" OnClick="lbtn_giris_Click">Giriş Yap</asp:LinkButton>
                </div>
            </div>

        </div>
    </form>
</body>
</html>