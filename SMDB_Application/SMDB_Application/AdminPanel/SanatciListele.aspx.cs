using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMDB_Application.AdminPanel
{
    public partial class SanatciListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)

        {
            
                Doldur();
            
        }
        void Doldur()
        {
            lv_sanatcilar.DataSource = dm.SanatciGetir();
            lv_sanatcilar.DataBind();
        }

    }
}