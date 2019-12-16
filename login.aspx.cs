using quan_ly_cafe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quan_ly_cafe
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
       
        protected void btndn_Click1(object sender, EventArgs e)
        {
            string username = txtuser.Text.ToString();
            string matkhau = txtpass.Text.ToString();
            bool check = NGUOIDUNGDAO.Instance.kiemtra(username, matkhau);
            if (check)
            {
                Session["user"] = username;
                int chucvu = NGUOIDUNGDAO.Instance.kiemtrachucvu(username);
                switch (chucvu)
                {
                    case 1: Response.Redirect("dsbanadmin.aspx");
                        break;
                    case 2: Response.Redirect("dsbantn.aspx");
                        break;
                    default: Response.Redirect("dsbannv.aspx");
                        break;
                }
            }
            else
            {
                lbtb.Text = "Đã sai tài khoản hoặc mật khẩu";
            }
        }


    }
}