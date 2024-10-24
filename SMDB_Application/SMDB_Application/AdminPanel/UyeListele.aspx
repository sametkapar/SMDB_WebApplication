﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMaster.Master" AutoEventWireup="true" CodeBehind="UyeListele.aspx.cs" Inherits="SMDB_Application.AdminPanel.UyeListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"><link href="CSS/KatEkleStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anaPanel">
    <div class="panelBaslik">
        <h3>Üye Listesi</h3>
    </div>
    <div class="panelIci">
        <asp:ListView ID="lv_uyeler" runat="server">
            <LayoutTemplate>
                <table class="pavlov" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>No</th>
                        <th>İsim</th>
                        <th>Soyisim</th>
                        <th>Mail</th>
                        <th>Kullanıcı Adı</th>
                        <th>Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Soyisim") %></td>
                    <td><%# Eval("Mail") %></td>    
                    <td><%# Eval("KullaniciAdi") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td>
                    
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>
</asp:Content>
