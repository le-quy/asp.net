using quan_ly_cafe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quan_ly_cafe
{
    public partial class datmonadmin : System.Web.UI.Page
    {
        string diachi = "datmonadmin.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["ban"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                HienThiDanhSachMon();
                lbtenban.Text = Session["ban"].ToString();
                string user = Session["user"].ToString();
                lbnv.Text = NGUOIDUNGDAO.Instance.hienthinhanvien(user);
            }           
        }
        public void HienThiDanhSachMon()
        {
            dsmon.DataSource = MONDAO.Instance.hienthimon();
            dsmon.DataBind();
        }

        protected void btncf_Click(object sender, EventArgs e)
        {
            dsmon.DataSource = MONDAO.Instance.hienthimoncf();
            dsmon.DataBind();
        }

        protected void btnnuocep_Click(object sender, EventArgs e)
        {
            dsmon.DataSource = MONDAO.Instance.hienthimonnuocep();
            dsmon.DataBind();
        }

        protected void btntrasua_Click(object sender, EventArgs e)
        {
            dsmon.DataSource = MONDAO.Instance.hienthimontrasua();
            dsmon.DataBind();
        }

        protected void btnsuachua_Click(object sender, EventArgs e)
        {
            dsmon.DataSource = MONDAO.Instance.hienthimonsuachua();
            dsmon.DataBind();
        }
        //Sự kiện khi nhấn chọn vào món trong Gridview
        protected void dsmon_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = dsmon.SelectedRow;
            int mamon = int.Parse(row.Cells[0].Text.ToString());
            int dongia = int.Parse(row.Cells[2].Text.ToString());
            string session = mamon.ToString();
            Session["mamon"] = session;
            lbtenmon.Text = MONDAO.Instance.tenmon(mamon);
            lbgia.Text = dongia.ToString();
        }
        //Sự kiện nhấn vào nút tìm kiếm
        protected void btntim_Click(object sender, EventArgs e)
        {
            string keyword = txttenmon.Text.ToString();
            if(String.IsNullOrEmpty(keyword))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), 
                    "alert", "alert('Bạn phải nhập dữ liệu');location.href='" + diachi + "';", true);
            }
            else {
                int kw;
                Int32.TryParse(keyword, out kw);
                if (kw > 0)
                {
                    int mamon = int.Parse(keyword.ToString());
                    dsmon.DataSource = MONDAO.Instance.timkiemtheomamon(mamon);
                    dsmon.DataBind();

                }
                else
                {
                    dsmon.DataSource = MONDAO.Instance.timkiemtheoten(keyword);
                    dsmon.DataBind();
                }
                if (dsmon.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert", "alert('Không tìm thấy dữ liệu về món');location.href='" + diachi + "';", true);
                }
            }
            
        }

        protected void dsmon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dsmon.PageIndex = e.NewPageIndex;
            this.HienThiDanhSachMon();
        }
        //Lấy các giá trị nhập từ form
        private HOADONDTO LayGiaTriTuForm()
        {
            int maban = BANDAO.Instance.maban(lbtenban.Text);
            string user = Session["user"].ToString();
            int mamon = int.Parse(Session["mamon"].ToString());
            int soluong = int.Parse(txtsl.Text.ToString());
            int dongia = int.Parse(lbgia.Text.ToString());
            int thanhtien = dongia * soluong;
            string ngayban = DateTime.Today.ToShortDateString();
            string ghichu = txtghichu.Text.ToString();
            HOADONDTO hoadon = new HOADONDTO(maban, user, mamon, soluong, thanhtien, ngayban, ghichu);
            return hoadon;
        }

        protected void btnxacnhan_Click(object sender, EventArgs e)
        {
            string tenmon = lbtenmon.Text.ToString();
            string sl = txtsl.Text.ToString();
            if (String.IsNullOrEmpty(tenmon) || String.IsNullOrEmpty(sl)) // Thông báo khi dữ liệu tên món hoặc số lượng trống
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), 
                    "alert", "alert('Bạn phải chọn món và nhập số lượng món');location.href='" + diachi + "';", true);
            }
            else // So sánh khi dữ liệu đầy đủ
            {
                int soluong = int.Parse(sl);
                if (soluong <= 0) // Số lượng nhập vào < 0 
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), 
                        "alert", "alert('Bạn phải nhập số lượng món > 0');location.href='" + diachi + "';", true);
                }
                else //Các thông tin đều hợp lệ
                {
                    
                    HOADONDTO hoadon = LayGiaTriTuForm();
                    //Khai báo 1 biến check kiểu bool thực hiện gọi phương thức thêm hóa đơn hoàn chỉnh từ Form datmon
                    bool check = datmon.Instance.ThemMon(hoadon.Maban, hoadon.User, hoadon.Mamon, hoadon.Soluong, hoadon.Thanhtien, hoadon.Ngayban, hoadon.Ghichu);
                    if (check)
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

        //Chuyển qua giao diện danh sách bàn
        protected void btndsban_Click(object sender, EventArgs e)
        {
            phieutamtinhtn ptt = new phieutamtinhtn(); //Khời tạo 1 đối tượng từ form Phieutamtinh
            ptt.KiemTraBan(lbtenban.Text); //Gọi phương thức kiemtraban từ Form phieutamtinh
            if (Session["guibep"] == null) 
            {
                Response.Redirect("dsbanadmin.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Có món chưa gửi bếp');location.href='" + diachi + "';", true);
                Session.Remove("guibep");
            }
        }
        //Chuyển qua giao diện phiếu tạm tính
        protected void btnptt_Click(object sender, EventArgs e)
        {
            Response.Redirect("phieutamtinhadmin.aspx");
        }
     
    }
}