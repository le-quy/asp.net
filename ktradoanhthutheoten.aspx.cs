using quan_ly_cafe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;


namespace quan_ly_cafe
{
    public partial class ktradoanhthutheoten : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if(!IsPostBack)
            {
                HienThiDsnv();
                HienthiNgay();
                pnngay.Visible = false;
                pnds.Visible = false;
            }
                     
        }
        private void HienThiDsnv()
        {
            ddlnhanvien.DataSource = NGUOIDUNGDAO.Instance.danhsachnhanvien();
            ddlnhanvien.DataTextField= "TENNHANVIEN";
            ddlnhanvien.DataValueField = "USERNAME";
            ddlnhanvien.DataBind();
            
        }
        private void KiemTraDanhSach(GridView gvds)
        {
            int soluongrow = gvds.Rows.Count;
            if (soluongrow == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Không tìm thấy dữ liệu ');location.href='/ktradoanhthutheoten.aspx';", true);
            }
            else
            {
                int thanhtien = 0;
                for (int i = 0; i < soluongrow; i++)
                {
                    thanhtien += int.Parse(gvds.Rows[i].Cells[2].Text.ToString());
                }
                lbtt.Text = thanhtien.ToString() + " VNĐ";
            }
        }
        private void HienThiHoaDon(string user,string ngayban)
        {
            gvds.DataSource = DOANHTHUDAO.Instance.doanhthutheonhanvien(user, ngayban);
            gvds.DataBind();
            KiemTraDanhSach(gvds);
            
        }

        //thêm các dữ liệu vào dropdownlist ngày,tháng,năm
        private void HienthiNgay()
        {
            int i;
            //Thêm ngày 
            for (i = 1; i <= 31; i++ )
            {
                string ngay = i.ToString();
                ddlngay.Items.Add(ngay);
            }
            //Thêm tháng 
            for (i = 1; i <= 12; i++)
            {
                string thang = i.ToString();
                ddlthang.Items.Add(thang);
            }
            //Thêm năm 
            for (i = 2015 ; i <= DateTime.Now.Year ; i++)
            {
                string nam = i.ToString();
                ddlnam.Items.Add(nam);
            }
        }

        private string LayNgay()
        {
            string ngay = ddlngay.SelectedItem.Text.ToString();
            string thang = ddlthang.SelectedItem.Text.ToString();
            string nam = ddlnam.SelectedItem.Text.ToString();
            string ngayban = thang + "/" + ngay + "/" + nam;
            return ngayban;
        }
        public void HienThiMauSacNutChon(Button a)
        { 
            a.BackColor = Color.Blue;
            a.ForeColor = Color.White;
        }
        public void HienThiMauSacCu(Button a)
        {
            a.BackColor = Color.DarkOrange;
            a.ForeColor = Color.Black;
            
        }
        protected void Chon_Click(object sender, EventArgs e)
        {
            pnds.Visible = true;
            string user = ddlnhanvien.SelectedValue.ToString();
            string ngay = LayNgay();
            HienThiHoaDon(user, ngay);
            KiemTraDanhSach(gvds);
        }

        protected void btntuchon_Click(object sender, EventArgs e)
        {
            HienThiMauSacNutChon(btntuchon);
            HienThiMauSacCu(btnhomnay);
            pnngay.Visible = true;
            pnds.Visible = false;
        }

        protected void btnhomnay_Click(object sender, EventArgs e)
        {
            HienThiMauSacNutChon(btnhomnay);
            HienThiMauSacCu(btntuchon);
            pnds.Visible = true;
            pnngay.Visible = false;
            string user = ddlnhanvien.SelectedValue.ToString();
            string ngay = DateTime.Today.ToShortDateString();
            HienThiHoaDon(user, ngay);
        }
    }
}