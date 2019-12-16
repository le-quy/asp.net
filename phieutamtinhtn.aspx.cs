﻿using quan_ly_cafe.DAO;
using quan_ly_cafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quan_ly_cafe
{
    public partial class phieutamtinhtn : System.Web.UI.Page
    {
        
        string diachi = "phieutamtinhtn.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"]==null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
               
                lbtenban.Text = Session["ban"].ToString();
                string user = Session["user"].ToString();
                lbnv.Text = NGUOIDUNGDAO.Instance.hienthinhanvien(user);
                hienthiptt();
            }
            
        }
        private void hienthiptt()
        {
            int maban = BANDAO.Instance.maban(lbtenban.Text);
            gvtamtinh.DataSource = HOADONDAO.Instance.phieutamtinh(maban);
            gvtamtinh.DataBind();
            hienthitien();
        }
        private void hienthitien()
        {
            int tongthanhtien = 0;
            int sl = gvtamtinh.Rows.Count;
            for (int i = 0; i < sl; i++)
            {
                tongthanhtien += int.Parse(gvtamtinh.Rows[i].Cells[3].Text.ToString());
            }
            lbtien.Text = tongthanhtien.ToString() + " VNĐ";
        }
        //Sự kiện nhấn vào nút chế biến (Gửi bếp)
        protected void btnchebien_Click(object sender, EventArgs e)
        {
            KiemTraBan(lbtenban.Text);
            if (Session["guibep"] == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thất bại - Tất cả món đều đã được gửi bếp');location.href='" + diachi + "';", true);
            }
            else
            {
                int maban = BANDAO.Instance.maban(lbtenban.Text);
                bool guibep = HOADONDAO.Instance.guibep(maban);
                if (guibep)
                {
                    Session["guibep"] = null;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Gửi bếp thành công');location.href='" + diachi + "';", true);
                    bool tt = BANDAO.Instance.capnhattrangthaicokhach(maban);
                    if (!tt)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cập nhật không thành công');location.href='" + diachi + "';", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thất bại');location.href='" + diachi + "';", true);
                }
            }
        }

        protected void gvtamtinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvtamtinh.SelectedRow;
            string tenmon = row.Cells[1].Text.ToString();
            lbmonselected.Text = tenmon;
            Session["mon"] = row.Cells[0].Text.ToString();           
        }

        //lấy dữ liệu từ form
        private HOADONDTO laydulieutuform()
        {
            int maban = BANDAO.Instance.maban(lbtenban.Text);
            string user = Session["user"].ToString();
            int mamon = int.Parse(Session["mon"].ToString());
            int soluong =int.Parse(txtsl.Text.ToString());
            int dongia = MONDAO.Instance.dongia(mamon);
            int thanhtien = soluong * dongia;
            string ngayban = DateTime.Today.ToShortDateString();
            string chuthich = txtghichu.Text.ToString();
            HOADONDTO hoadon = new HOADONDTO(maban, user, mamon, soluong, thanhtien, ngayban, chuthich);
            return hoadon;
        }

        //Thêm một món mới
        protected void btnthemmon_Click(object sender, EventArgs e)
        {
            string tenmon = lbmonselected.Text.ToString(); //Lấy tên món
            string sl = txtsl.Text.ToString(); // Lấy số lượng món
            if (String.IsNullOrEmpty(tenmon) || String.IsNullOrEmpty(sl)) //Nếu các ô dữ liệu trống, chưa có chọn món
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thất bại');location.href='" + diachi + "';", true);
            }
            else
            {
                int soluong = int.Parse(sl);
                if (soluong <= 0) //Số lượng món nhập vào <= 0
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bạn phải nhập số lượng > 0');location.href='" + diachi + "';", true);
                }
                else
                {
                    HOADONDTO hoadon = laydulieutuform();               
                    bool kt = datmon.Instance.ThemMon(hoadon.Maban, hoadon.User, hoadon.Mamon, hoadon.Soluong, hoadon.Thanhtien, hoadon.Ngayban, hoadon.Ghichu);
                    if(kt == true)
                    {
                        datmon.Instance.ThongBaoThanhCong(this, diachi);
                    }
                    else
                    {
                        datmon.Instance.ThongBaoThatBai(this, diachi);
                    }
                }
            }
       }
          
        //Hủy món chưa gửi bếp
        protected void btnhuymon_Click(object sender, EventArgs e)
        { 
            try
            {
                int maban = BANDAO.Instance.maban(lbtenban.Text);
                int mamon = int.Parse(Session["mon"].ToString());
                if (String.IsNullOrEmpty(txtsl.Text))
                {
                    bool huymon = HOADONDAO.Instance.huymon(maban, mamon);
                    if (huymon)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hủy món thành công');location.href='" + diachi + "';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bạn phải chọn món');location.href='" + diachi + "';", true);
                    }
                }
                else
                {
                    int soluonghuy = int.Parse(txtsl.Text.ToString());// Số lượng muốn hủy
                    int soluongmon = HOADONDAO.Instance.soluongchuaguibep(maban, mamon); //Số lượng món có trong hóa đơn chưa gửi bếp
                    if (soluongmon - soluonghuy > 0)
                    {
                        bool giammon = HOADONDAO.Instance.giamsoluongmon(maban, mamon, soluonghuy);
                        if (giammon)
                        {
                            int dongia = MONDAO.Instance.dongia(mamon);
                            bool capnhattien = HOADONDAO.Instance.capnhatthanhtien(maban, mamon, dongia);
                            if (capnhattien)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hủy món thành công');location.href='" + diachi + "';", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thất bại');location.href='" + diachi + "';", true);
                        }
                    }
                    else if ((soluongmon - soluonghuy) == 0)
                    {
                        bool giammon = HOADONDAO.Instance.giamsoluongmon(maban, mamon, soluonghuy);
                        bool xoamon = HOADONDAO.Instance.xoahoadoncomonbang0();
                        if (xoamon)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hủy món thành công');location.href='" + diachi + "';", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thất bại');location.href='" + diachi + "';", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hủy hơn số lượng chưa gửi bếp');location.href='" + diachi + "';", true);
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bạn chưa chọn món');location.href='" + diachi + "';", true);
            }
           
        }
        //Phương thức kiểm tra bàn
        public void KiemTraBan( string maban)
        {
            int mb = BANDAO.Instance.maban(maban);
            bool kiemtra = HOADONDAO.Instance.kiemtrabanchuaguibep(mb);
            if (kiemtra)
            {
                Session["guibep"] = "tontai"; // Nếu có tồn tại món chưa gửi bếp thì gán 1 Session 
            }
        }
       //sự kiện nhấn vào nút đặt món
        protected void btnthanhtoan_Click(object sender, EventArgs e)
        {

            string user = Session["user"].ToString();
            int maban = BANDAO.Instance.maban(lbtenban.Text);
            string ngaytt = DateTime.Today.ToShortDateString();
            bool thanhtoan = HOADONDAO.Instance.capnhatthanhtoan(maban, user, ngaytt);
            if (thanhtoan)
            {
                List<DOANHTHUDTO> dt = DOANHTHUDAO.Instance.danhsachthem();
                foreach (DOANHTHUDTO item in dt)
                {
                    bool themdt = DOANHTHUDAO.Instance.themdoanhthu(item);
                    if (themdt)
                    {
                        bool xoahd = HOADONDAO.Instance.xoahoadonthanhtoan();
                        bool capnhattrangthai = BANDAO.Instance.capnhattrangthaitrong(maban);
                        datmon.Instance.ThongBaoThanhCong(this, diachi);
                    }
                }
            }
            else
            {
                datmon.Instance.ThongBaoThatBai(this, diachi);
            }
        }
        // Sự kiện nhấn vào nút kiểm tra bàn
        protected void btndsban_Click(object sender, EventArgs e)
        {
            KiemTraBan(lbtenban.Text);
            if (Session["guibep"] == null)
            {
                Response.Redirect("dsbantn.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Có món chưa gửi bếp');location.href='" + diachi + "';", true);
                Session.Remove("guibep");
            }
        }

        protected void btndm_Click(object sender, EventArgs e)
        {

            KiemTraBan(lbtenban.Text);
            if (Session["guibep"] == null)
            {
                Response.Redirect("datmontn.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Có món chưa gửi bếp');location.href='datmontn.aspx';", true);
                Session.Remove("guibep");
            }
        }

        protected void btninhoadon_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Đã xuất hóa đơn');location.href='datmontn.aspx';", true);
        }

    }
}