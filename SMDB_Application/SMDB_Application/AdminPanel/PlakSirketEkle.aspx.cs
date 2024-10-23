using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMDB_Application.AdminPanel
{
    public partial class PlakSirketEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cb_durum.Checked = true;
            }
        }


        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                if (!string.IsNullOrEmpty(tb_adres.Text))
                {
                    if (!string.IsNullOrEmpty(tb_telefon.Text))
                    {
                        PlakSirket ps = new PlakSirket();
                        ps.Isim = tb_isim.Text;
                        ps.Adres = tb_adres.Text;
                        ps.Telefon = tb_telefon.Text;
                        ps.Durum = cb_durum.Checked;
                        if (dm.PlakSirketiEkle(ps))
                        {
                            pnl_basarisiz.Visible = false;
                            pnl_basarili.Visible = true;
                        }
                        else
                        {
                            lbl_mesaj.Text = "Şirket eklenirken bir hata oluştu";
                            pnl_basarisiz.Visible = true;
                            pnl_basarili.Visible = false;
                        }
                    }
                    else
                    {
                        lbl_mesaj.Text = "Telefon numarası giriniz";
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                    } 
                           
                }
                else
                {
                    lbl_mesaj.Text = "Adres giriniz";
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                }
            }
            else
            {
                lbl_mesaj.Text = "Şirket adı boş bırakılamaz";
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
            }
        }
    }
}