﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMDB_Application.AdminPanel
{

    public partial class KategoriListele : System.Web.UI.Page

    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Doldur();
        }
       

        protected void lv_kategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "durum")
            {
                dm.KategoriDurumDegistir(id);
            }
                if(e.CommandName =="sil")
            {
                dm.KategoriSil(id);
            }
            Doldur();
        }
        void Doldur()
        {
            lv_kategoriler.DataSource = dm.KategorileriGetir();
            lv_kategoriler.DataBind();
        }
    }
}
