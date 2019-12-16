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
    public partial class ktradoanhthutheongay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if(!IsPostBack)
            {
                LoadNgay();
                pnngay.Visible = false;
                HienThiDoanhThuHomNay(gvds);
            }
        }

        //Load ngày
        private void LoadNgay()
        {
            int i;
            for (i = 1; i <= 31; i++)
            {
                string ngay = i.ToString();
                ddlngay1.Items.Add(ngay);
                ddlngay2.Items.Add(ngay);
            }
            //Thêm tháng 
            for (i = 1; i <= 12; i++)
            {
                string thang = i.ToString();
                ddlthang1.Items.Add(thang);
                ddlthang2.Items.Add(thang);
            }
            //Thêm năm 
            for (i = 2015; i <= DateTime.Now.Year; i++)
            {
                string nam = i.ToString();
                ddlnam1.Items.Add(nam);
                ddlnam2.Items.Add(nam);
            }
            
        }
        private string LayTuNgay()
        {
            string ngay = ddlngay1.SelectedItem.Text.ToString();
            string thang = ddlthang1.SelectedItem.Text.ToString();
            string nam = ddlnam1.SelectedItem.Text.ToString();
            string tungay = thang + "/" + ngay + "/" + nam;
            return tungay;
        }
        private string LayDenNgay()
        {
            string ngay = ddlngay2.SelectedItem.Text.ToString();
            string thang = ddlthang2.SelectedItem.Text.ToString();
            string nam = ddlnam2.SelectedItem.Text.ToString();
            string tungay = thang + "/" + ngay + "/" + nam;
            return tungay;
        }
        private void HienThiDoanhThuHomNay(GridView gvds)
        {
            string ngay = DateTime.Today.ToShortDateString();
            gvds.DataSource = DOANHTHUDAO.Instance.doanhthutheohomnay(ngay);
            gvds.DataBind();
            KiemTraDanhSach(gvds);
        }
        private void KiemTraDanhSach(GridView gvds)
        {
            int soluongrow = gvds.Rows.Count;
            if(soluongrow == 0)
            {
                lbtb.Text = "Không tìm thấy dữ liệu";
            }
            else
            {
                int thanhtien = 0;
                for(int i = 0; i< soluongrow; i++)
                {
                    thanhtien += int.Parse(gvds.Rows[i].Cells[2].Text.ToString());
                }
                lbtt.Text = thanhtien.ToString() + " VNĐ"; 
            }
        }
        protected void btnchon_Click(object sender, EventArgs e)
        {
            pnds.Visible = true;
            string tungay = LayTuNgay();
            string denngay = LayDenNgay();
            gvds.DataSource = DOANHTHUDAO.Instance.doanhthutheongaytuchon(tungay, denngay);
            gvds.DataBind();
            KiemTraDanhSach(gvds);
        }
        
        protected void btnhomnay_Click(object sender, EventArgs e)
        {
            ktradoanhthutheoten form = new ktradoanhthutheoten();
            form.HienThiMauSacNutChon(btnhomnay);
            form.HienThiMauSacCu(btntuchon);
            pnngay.Visible = false;
            pnds.Visible = true;
            HienThiDoanhThuHomNay(gvds);
        }

        protected void btntuchon_Click(object sender, EventArgs e)
        {
            ktradoanhthutheoten form = new ktradoanhthutheoten();
            form.HienThiMauSacNutChon(btntuchon);
            form.HienThiMauSacCu(btnhomnay);
            pnngay.Visible = true;
            pnds.Visible = false;
            lbtb.Text = "";
        }
        
    }
}