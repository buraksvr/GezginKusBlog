<%@ Page Title="" Language="C#" MasterPageFile="~/YöneticiPaneli/YoneticiPanel.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="GezginKusBlogWebApp.YöneticiPaneli.KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-check-input input{
            margin-top: -5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Kategori İşlemleri</h1>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">Kategori Ekle</h3>
                </div>
                <div class="card-body">
                    <asp:Panel ID="pnl_basarili" runat="server" CssClass="alert alert-success" Visible="false"> Kategori Ekleme <strong>Başarılı</strong></asp:Panel>
                    <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="alert alert-danger" Visible="false">
                        <asp:label ID="lbl_basarisiz" runat="server"></asp:label>
                    </asp:Panel>
                    <div class="mb-3">
                        <label class="form-label">Kategori Adı</label>
                        <asp:TextBox ID="tb_isim" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mt-3">
                        <label class="form-label">Açıklama</label>
                        <asp:TextBox ID="tb_aciklama" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="mt-3">
                        <asp:CheckBox ID="cb_durum" runat="server" />
                        <label  for="ContentPlaceHolder1_cb_durum">Aktif Kategori <small>(İşaretlenirse Kategori Yayınlanır)</small></label>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="btn btn-primary" OnClick="lbtn_ekle_Click" Visible="false">Kategori Ekle</asp:LinkButton>

                    <asp:LinkButton ID="lbtn_ModelİleEkle" runat="server" CssClass="btn btn-primary" OnClick="lbtn_ModelİleEkle_Click">Kategori Ekle</asp:LinkButton>
                    <a href="KategoriEkle.aspx" class="btn-link m-2" >Kategori Listesine Dön</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
