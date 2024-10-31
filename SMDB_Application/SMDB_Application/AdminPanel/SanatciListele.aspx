<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/ModMaster.Master" AutoEventWireup="true" CodeBehind="SanatciListele.aspx.cs" Inherits="SMDB_Application.AdminPanel.SanatciListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/KatEkleStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anaPanel">
        <div class="panelBaslik">
            <div class="panelBaslik">
                <h3>
                    <asp:Label ID="lbl_sanatciAdiGetir" runat="server" Text=""></asp:Label>
                </h3>
            </div>
        </div>
        <div class="panelIci">
            <div class="panelBaslik">
                <asp:Label ID="lbl_albumAdıGetir" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:ListView ID="lv_albümler" runat="server">
                    <LayoutTemplate>
                        <table class="pavlov" cellpadding="0" cellspacing="0">
                            <tr>
                                <th>Albüm ID</th>
                                <th>Albüm Adı</th>
                                <th>Çıkış Yılı</th>
                                <th>Plak Şirketi</th>
                            </tr>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("Isim") %></td>
                            <td><%# Eval("CikisYili") %></td>
                            <td><%# Eval("Sirket_ID") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
