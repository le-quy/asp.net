﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quan_ly_cafe
{
    public partial class dangxuat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("login.aspx");
        }
    }
}