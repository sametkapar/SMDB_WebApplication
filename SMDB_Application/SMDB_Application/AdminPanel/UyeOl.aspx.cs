using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMDB_Application.AdminPanel
{
    public partial class UyeOl : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_kaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                if (!string.IsNullOrEmpty(tb_soyisim.Text))
                {
                    if (!string.IsNullOrEmpty(tb_mail.Text))
                    {
                        if (tb_username.Text.Length < 20)
                        {
                            Kullanici k = new Kullanici();
                            k.Isim = tb_isim.Text;
                            k.Soyisim = tb_soyisim.Text;
                            k.Mail = tb_mail.Text;
                            k.KullaniciAdi = tb_username.Text;
                            k.Sifre = tb_sifre.Text;
                            k.Durum = false;
                            k.AktifMi = false;
                            if (dm.KullaniciKaydet(k))
                            {
                                pnl_basarili.Visible = true;
                                pnl_hata.Visible = false;
                            }
                            else
                            {
                                pnl_hata.Visible = true;
                                lbl_hatametin.Text = "Kullanıcı oluşturulurken bir hata oluştu.";
                            }
                        }
                        else
                        {
                            pnl_hata.Visible = true;
                            lbl_hatametin.Text = "Kullanici adı 20 karakterden fazla olamaz";
                        }

                    }
                    else
                    {
                        pnl_hata.Visible = true;
                        lbl_hatametin.Text = "Mail adresi boş bırakılamaz";
                    }
                }
                else
                {
                    pnl_hata.Visible = true;
                    lbl_hatametin.Text = "Soyisim boş bırakılamaz";
                }
            }
            else
            {
                pnl_hata.Visible = true;
                lbl_hatametin.Text = "İsim boş bırakılamaz";
            }
        }
    }
}