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
    public partial class ktradoanhthutheomon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if(!IsPostBack)
            {
                pnngay.Visible = false;
                hienthingay();
                HienThiDoanhThuHomNay(gvdsmon);
            }
            
        }
        //thêm các dữ liệu vào dropdownlist ngày,tháng,năm
        private void hienthingay()
        {
            int i;
            //Thêm ngày 
            for (i = 1; i <= 31; i++)
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
            for (i = 2015; i <= DateTime.Now.Year; i++)
            {
                string nam = i.ToString();
                ddlnam.Items.Add(nam);
            }
        }
        //Hiển thị doanh thu khi vừa vào Form.
        private void HienThiDoanhThuHomNay(GridView gvdsmon)
        {
            string ngay = DateTime.Today.ToShortDateString();
            gvdsmon.DataSource = DOANHTHUDAO.Instance.doanhthutheomon(ngay);
            gvdsmon.DataBind();
            KiemTraDanhSach(gvdsmon);

        }
        //Kiểm tra danh sách trong gridview để hiển thị các thông báo
        private void KiemTraDanhSach(GridView gvdsmon)
        {
            int thanhtien = 0;
            int soluongrow = gvdsmon.Rows.Count;
            if(soluongrow == 0)
            {
                lbtb.Text = "Không tìm thấy dữ liệu";
            }
            else
            {
                for (int i = 0; i < soluongrow; i++)
                    thanhtien += int.Parse(gvdsmon.Rows[i].Cells[2].Text.ToString());
            }
            lbtong.Text = thanhtien.ToString() + " VNĐ"; 
        }
       
        //Lấy ngày trong các dropdownlist
        private string LayNgay()
        {
            string ngay = ddlngay.SelectedItem.Text.ToString();
            string thang = ddlthang.SelectedItem.Text.ToString();
            string nam = ddlnam.SelectedItem.Text.ToString();
            string ngayban = thang + "/" + ngay + "/" + nam;
            return ngayban;
        }
        //Thực hiện cú pháp switch
        private void ThucHienSwitch(GridView gvdsmon ,string phanloai, string ngay)
        {
            switch(phanloai)
            {
                case "Tất cả": gvdsmon.DataSource = DOANHTHUDAO.Instance.doanhthutheomon(ngay);
                    gvdsmon.DataBind();
                    break;
                default: gvdsmon.DataSource = DOANHTHUDAO.Instance.doanhthutheoloai(phanloai, ngay);
                    gvdsmon.DataBind();
                    break;
            } 
        }
        protected void btnchon_Click(object sender, EventArgs e)
        {
            pnds.Visible = true;
            string ngay = LayNgay();
            string phanloai = ddldoanhmuc.SelectedValue.ToString();
            ThucHienSwitch(gvdsmon, phanloai, ngay);
            KiemTraDanhSach(gvdsmon);
            
        }

        protected void btnhomnay_Click(object sender, EventArgs e)
        {
            ktradoanhthutheoten form = new ktradoanhthutheoten();
            form.HienThiMauSacNutChon(btnhomnay);
            form.HienThiMauSacCu(btntuchon);
            pnds.Visible = true;
            pnngay.Visible = false;
            lbtb.Text = "";
            string ngay = DateTime.Today.ToShortDateString();
            string phanloai = ddldoanhmuc.SelectedValue.ToString();
            ThucHienSwitch(gvdsmon, phanloai,ngay);
            KiemTraDanhSach(gvdsmon);
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