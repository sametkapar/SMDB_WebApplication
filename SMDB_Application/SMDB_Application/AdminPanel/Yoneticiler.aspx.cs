using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMDB_Application.AdminPanel
{
    public partial class Yoneticiler : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        DropDownList yoneticiler;
        protected void Page_Load(object sender, EventArgs e)
        {
            Doldur();
        }
        protected void lv_yoneticiler_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            DropDownList yoneticiler = (DropDownList)e.Item.FindControl("ddl_Yoneticiler");
            yoneticiler.DataSource = dm.YoneticiGetir();
            yoneticiler.DataBind();
        }
        void Doldur()
        {
            lv_yoneticiler.DataSource = dm.YoneticiGetir();
            lv_yoneticiler.DataBind();
        }

        protected void ddl_Yoneticiler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}