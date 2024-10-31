<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/ModMaster.Master" AutoEventWireup="true" CodeBehind="AlbumListele.aspx.cs" Inherits="SMDB_Application.AdminPanel.AlbumListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

            </div>
        </div>
    </div>
</asp:Content>
