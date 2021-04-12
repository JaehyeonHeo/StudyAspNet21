﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidationWebApp
{
    public partial class FrmInputValid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.SetFocus(TxtUserID); 
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Write("<script>alert('통과');</script>"); 
            }
        }
    }
}