using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace SMDB_Application.AdminPanel
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_username.Text))
            {
                if (!string.IsNullOrEmpty(tb_sifre.Text))
                {
                    Yonetici y = dm.YoneticiGiris(tb_username.Text, tb_sifre.Text);
                    if (y != null)
                    {
                        if (y.YoneticiTur_ID == 1)
                        {
                            Session["GirisYapanYonetici"] = y;
                            Response.Redirect("AdminPanel.aspx");
                        }
                        if (y.YoneticiTur_ID == 2) 
                        {
                            Session["GirisYapanModerator"] = y;
                            Response.Redirect("ModDefault.aspx");
                        }
                        else
                        {
                            pnl_hata.Visible = true;
                            lbl_hatametin.Text = "Kullanıcı bulunamadı";
                        }
                    }
                    else
                    {
                        pnl_hata.Visible = true;
                        lbl_hatametin.Text = "Kullanıcı bulunamadı";
                    }
                }
                else
                {
                    pnl_hata.Visible = true;
                    lbl_hatametin.Text = "Şifre boş bırakılamaz";
                }

            }
            else
            {
                pnl_hata.Visible = true;
                lbl_hatametin.Text = "Mail adresi boş bırakılamaz";
            }


        }
    }
}