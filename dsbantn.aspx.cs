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
    public partial class dsbantn : System.Web.UI.Page
    {
        string diachi = "dsbantn.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            string user = Session["user"].ToString();
            lbtennv.Text = NGUOIDUNGDAO.Instance.hienthinhanvien(user);
            if (!IsPostBack)
            {

                hienthidsban();
                pnchuyenban.Visible = false;
                pntachban.Visible = false;
                pnghepban.Visible = false;
                pnhoadon.Visible = false;
            }
        }
        private void hienthiban(Button a)
        {
            string tenban = a.Text.ToString();
            int trangthaiban = BANDAO.Instance.tinhtrangban(tenban);
            switch (trangthaiban)
            {
                case 1: a.BackColor = Color.LightGray;
                    break;
                case 2: a.BackColor = Color.CornflowerBlue;
                    break;
                default : a.BackColor = Color.Yellow;
                    break;
            }
        }
        private void hienthidsban()
        {
            hienthiban(btn1); hienthiban(btn2); hienthiban(btn3); hienthiban(btn4);
            hienthiban(btn5); hienthiban(btn6); hienthiban(btn7); hienthiban(btn8);
            hienthiban(btn9); hienthiban(btn10); hienthiban(btn11); hienthiban(btn12);
            hienthiban(btn13); hienthiban(btn14); hienthiban(btn15); hienthiban(btn16);
            hienthiban(btn17); hienthiban(btn18); hienthiban(btn19); hienthiban(btn20);
        }
        private void chuyentrang()
        {
            Response.Redirect("datmontn.aspx");
        }
        private void laySessionban(Button a)
        {
            Session["ban"] = a.Text.ToString();
            chuyentrang();
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            laySessionban(btn1);
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            laySessionban(btn2);
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            laySessionban(btn3);
        }

        protected void btn4_Click(object sender, EventArgs e)
        {
            laySessionban(btn4);
        }

        protected void btn5_Click(object sender, EventArgs e)
        {
            laySessionban(btn5);
        }

        protected void btn6_Click(object sender, EventArgs e)
        {
            laySessionban(btn6);
        }

        protected void btn7_Click(object sender, EventArgs e)
        {
            laySessionban(btn7);
        }

        protected void btn8_Click(object sender, EventArgs e)
        {
            laySessionban(btn8);
        }

        protected void btn9_Click(object sender, EventArgs e)
        {
            laySessionban(btn9);
        }

        protected void btn10_Click(object sender, EventArgs e)
        {
            laySessionban(btn10);
        }

        protected void btn11_Click(object sender, EventArgs e)
        {
            laySessionban(btn11);
        }

        protected void btn12_Click(object sender, EventArgs e)
        {
            laySessionban(btn12);
        }

        protected void btn13_Click(object sender, EventArgs e)
        {
            laySessionban(btn13);
        }

        protected void btn14_Click(object sender, EventArgs e)
        {
            laySessionban(btn14);
        }

        protected void btn15_Click(object sender, EventArgs e)
        {
            laySessionban(btn15);
        }

        protected void btn16_Click(object sender, EventArgs e)
        {
            laySessionban(btn16);
        }

        protected void btn17_Click(object sender, EventArgs e)
        {
            laySessionban(btn17);
        }

        protected void btn18_Click(object sender, EventArgs e)
        {
            laySessionban(btn18);
        }
        protected void btn19_Click(object sender, EventArgs e)
        {
            laySessionban(btn19);
        }

        protected void btn20_Click(object sender, EventArgs e)
        {
            laySessionban(btn20);
        }
        private void hienthihoadon(int mabancu)
        {
            gvdanhsachmon.DataSource = HOADONDAO.Instance.phieutamtinh(mabancu);
            gvdanhsachmon.DataBind();
        }
        public bool capnhatban(int mabancu, int mabanmoi)
        {
            bool kt = new bool();
            bool chuyen = HOADONDAO.Instance.capnhatchuyenban(mabancu, mabanmoi);
            if (chuyen)
            {
                bool capnhat1 = BANDAO.Instance.capnhattrangthaitrong(mabancu);
                bool capnhat2 = BANDAO.Instance.capnhattrangthaicokhach(mabanmoi);
                if (capnhat1 && capnhat2)
                {
                    kt = true;
                }
                else kt = false;
            }
            else
            {
                kt = false;
            }
            return kt;
        }
        //Lấy giá trị từ bàn
        private void laygiatrituban()
        { 
            
        }
            
        private void chuyenban()
        {
            string bancu = txtbancu.Text.ToString();
            string banmoi = txtbanmoi.Text.ToString();
            int mabancu = BANDAO.Instance.maban(bancu);
            int mabanmoi = BANDAO.Instance.maban(banmoi);
            int trangthaibancu = BANDAO.Instance.tinhtrangban(bancu);
            int trangthaibanmoi = BANDAO.Instance.tinhtrangban(banmoi);   
            if (trangthaibancu == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bàn chọn trống');location.href='" + diachi + "';", true);
            }
            else
            {
                if (trangthaibanmoi == 1)
                {
                    bool capnhat = capnhatban(mabancu, mabanmoi);
                    if (capnhat)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thành công');location.href='" + diachi + "';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thất bại ');location.href='" + diachi + "';", true);
                    }
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bàn chuyển có khách');location.href='" + diachi + "';", true);
                }
            }
        }
        private void ghepban()
        {
            string bancu = txtbancughep.Text.ToString();
            string banmoi = txtbanmoighep.Text.ToString();
            int mabancu = BANDAO.Instance.maban(bancu);
            int mabanmoi = BANDAO.Instance.maban(banmoi);
            int trangthaibancu = BANDAO.Instance.tinhtrangban(bancu);
            int trangthaibanmoi = BANDAO.Instance.tinhtrangban(banmoi);
            if (trangthaibancu == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bàn chọn trống');location.href='" + diachi + "';", true);
            }
            else
            {
                if (trangthaibanmoi == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bàn ghép trống');location.href='" + diachi + "';", true);
                }
                else
                {
                    bool capnhat = capnhatban(mabancu, mabanmoi);
                    if (capnhat)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thành công');location.href='" + diachi + "';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thất bại ');location.href='" + diachi + "';", true);
                    }
                }
            }
        }

        protected void btnchuyenban_Click(object sender, EventArgs e)
        {
            pnchuyenban.Visible = true;
            pnghepban.Visible = false;
            pntachban.Visible = false;

        }
        protected void btnthchuyenban_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbancu.Text) || !String.IsNullOrEmpty(txtbanmoi.Text))
            {
                chuyenban();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Phải điền đầy đủ thông tin');location.href='/dsbanadmin.aspx';", true);
            }
        }
        protected void btntachban_Click(object sender, EventArgs e)
        {
            pnchuyenban.Visible = false;
            pnghepban.Visible = false;
            pntachban.Visible = true;
        }
        protected void btnthchonban_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbantachcu.Text) || !String.IsNullOrEmpty(txtbantachmoi.Text))
            {
                string bancu = txtbantachcu.Text.ToString();
                string banmoi = txtbantachmoi.Text.ToString();
                int mabancu = BANDAO.Instance.maban(bancu);
                int mabanmoi = BANDAO.Instance.maban(banmoi);
                int trangthaibancu = BANDAO.Instance.tinhtrangban(bancu);
                int trangthaibanmoi = BANDAO.Instance.tinhtrangban(banmoi);
                if (trangthaibancu == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bàn chọn trống');location.href='" + diachi + "';", true);
                }
                else
                {
                    hienthihoadon(mabancu);
                    pnhoadon.Visible = true;

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Phải điền đầy đủ thông tin');location.href='/dsbanadmin.aspx';", true);
            }
            
        }
        protected void btnghepban_Click(object sender, EventArgs e)
        {
            pnchuyenban.Visible = false;
            pnghepban.Visible = true;
            pntachban.Visible = false;
        }

       

        protected void btnthghepban_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbancughep.Text) || !String.IsNullOrEmpty(txtbanmoighep.Text))
            {
                ghepban();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Phải điền đầy đủ thông tin');location.href='/dsbanadmin.aspx';", true);
            }
        }
        protected void btnthtach_Click(object sender, EventArgs e)
        {
            HOADONDTO hoadon = laygiatrituform();
            string bancu = txtbantachcu.Text.ToString();
            int mabancu = BANDAO.Instance.maban(bancu);
            string tenmon = lbmonselected.Text.ToString(); //Lấy tên món
            string sl = txtsl.Text.ToString(); // Lấy số lượng món
            if (tenmon == "" || sl == "") //Nếu các ô dữ liệu trống, chưa có chọn món
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thất bại');location.href='" + diachi + "';", true);
            }
            else
            {
                try
                {
                    int soluongtach = int.Parse(sl);
                    int soluongmon = HOADONDAO.Instance.soluongdaguibep(mabancu, hoadon.Mamon);
                    int soluongconlai = soluongmon - soluongtach;
                    if (soluongtach <= 0) //Số lượng món nhập vào <= 0
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bạn phải nhập số lượng > 0');location.href='" + diachi + "';", true);
                    }
                    else if (soluongconlai < 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Số lượng tách lớn hơn số lượng món trong bàn');location.href='" + diachi + "';", true);
                    }
                    else
                    {
                        int dongia = MONDAO.Instance.dongia(hoadon.Mamon);
                        int thanhtienconlai = dongia * soluongconlai;
                        bool taohd = HOADONDAO.Instance.hoadontach(hoadon);
                        bool capnhattrangthai = BANDAO.Instance.capnhattrangthaicokhach(hoadon.Maban);
                        {
                            if (taohd && capnhattrangthai)
                            {
                                if (soluongconlai == 0)
                                {
                                    bool xoa = HOADONDAO.Instance.xoahoadontach(mabancu, hoadon.Mamon);
                                    if (xoa)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Đã tách');location.href='" + diachi + "';", true);
                                    }
                                }
                                else
                                {
                                    bool xoa = HOADONDAO.Instance.xoahoadontach(mabancu, hoadon.Mamon);
                                    if (xoa)
                                    {
                                        HOADONDTO hdt = new HOADONDTO(mabancu, hoadon.User, hoadon.Mamon, soluongconlai, thanhtienconlai, hoadon.Ngayban, hoadon.Ghichu);
                                        bool tao = HOADONDAO.Instance.hoadontach(hdt);
                                        if (tao)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Đã tách');location.href='" + diachi + "';", true);
                                        }
                                        else
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thất bại');location.href='" + diachi + "';", true);
                                    }
                                    else
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thất bại');location.href='" + diachi + "';", true);
                                }
                            }
                            else ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thất bại');location.href='" + diachi + "';", true);
                        }
                    }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Món chưa được chế biến');location.href='" + diachi + "';", true);
                }
            }
        }

        protected void gvdanhsachmon_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvdanhsachmon.SelectedRow;
            string tenmon = row.Cells[1].Text.ToString();
            lbmonselected.Text = tenmon;
            Session["mamontach"] = row.Cells[0].Text.ToString();
        }
        private HOADONDTO laygiatrituform()
        {
            string banmoi = txtbantachmoi.Text.ToString();
            int maban = BANDAO.Instance.maban(banmoi);
            string user = Session["user"].ToString();
            int mamon = int.Parse(Session["mamontach"].ToString());
            int soluong = int.Parse(txtsl.Text.ToString());
            int dongia = MONDAO.Instance.dongia(mamon);
            int thanhtien = soluong * dongia;
            string ngayban = DateTime.Today.ToShortDateString();
            string chuthich = "";
            HOADONDTO hoadon = new HOADONDTO(maban, user, mamon, soluong, thanhtien, ngayban, chuthich);
            return hoadon;
        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            pnkhua.Visible = true;
            pnkhub.Visible = true;
        }

        protected void btnkva_Click(object sender, EventArgs e)
        {
            pnkhua.Visible = true;
            pnkhub.Visible = false;
        }

        protected void btnkvb_Click(object sender, EventArgs e)
        {
            pnkhua.Visible = false;
            pnkhub.Visible = true;
        }

    }
}