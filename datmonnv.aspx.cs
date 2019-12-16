using quan_ly_cafe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace quan_ly_cafe
{
    public partial class datmon : System.Web.UI.Page
    {
        private static datmon instance;

        public static datmon Instance
        {
            get { if (instance == null) instance = new datmon(); return datmon.instance; }
            set { datmon.instance = value; }
        }
        public datmon() { }
        string diachi = "datmonnv.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"]==null || Session["ban"] ==null )
            {
                Response.Redirect("login.aspx");
            }
            if(!IsPostBack)
            {
                hienthidanhsachmon();
                lbtenban.Text = Session["ban"].ToString();
                string user = Session["user"].ToString();
                lbnv.Text = NGUOIDUNGDAO.Instance.hienthinhanvien(user);
            }           
        }
        //hien thị danh sách món
        public void hienthidanhsachmon()
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
        //Chọn món 
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
        //Sự kiện khi nhấn nút tìm kiếm món
        protected void btntim_Click(object sender, EventArgs e)
        {
            string keyword = txttenmon.Text.ToString();
            if (String.IsNullOrEmpty(keyword))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bạn phải nhập dữ liệu');location.href='" + diachi + "';", true);
            }
            else { 
            int kw;
            Int32.TryParse(keyword, out kw);
            if(kw >0 )
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Không tìm thấy dữ liệu về món');location.href='" + diachi + "';", true);
            }     }
                
        }
        protected void dsmon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dsmon.PageIndex = e.NewPageIndex;
            this.hienthidanhsachmon();
        }
        //Lấy các giá trị trong giao diện để lưu vào CSDL
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
        //Dùng kiểu public cho các phương thức được gọi lại trong các Class khác

        //Thêm một hóa đơn
        public bool TaoHDMoi(int maBan, string user, int maMon, int soLuong, int thanhTien, string ngayBan, string ghiChu)
        {
            bool kt = new bool();
            HOADONDTO hoadon = new HOADONDTO(maBan, user, maMon, soLuong, thanhTien, ngayBan, ghiChu);
            bool them = HOADONDAO.Instance.datmon(hoadon);
            if (them)
            {
                kt = true;             
            }
            else
            {
                kt = false;
            }
            return kt;
        }
        // Thêm hóa đơn hoàn chỉnh 
        public bool ThemMon(int maBan, string user, int maMon, int soLuong, int thanhTien, string ngayBan, string ghiChu)
        {
            bool check = new bool();
            HOADONDTO hoadon = new HOADONDTO(maBan, user, maMon, soLuong, thanhTien, ngayBan, ghiChu);
            bool kiemtra = HOADONDAO.Instance.kiemtracomonchuaguibep(maBan, maMon); //Thực hiện kiểm tra có hóa đơn trùng món chưa gửi bếp không
            if (kiemtra) // Mếu có hóa đơn trùng món và chưa gửi bếp
            {
                bool themsoluong = HOADONDAO.Instance.tangsoluongmon(maBan, maMon, soLuong); // Cập nhật thêm số lượng vào hóa đơn đó
                if (themsoluong)
                {
                    int dongia = MONDAO.Instance.dongia(maMon);
                    bool capnhattien = HOADONDAO.Instance.capnhatthanhtien(maBan, maMon, dongia); // Cập nhật lại thành tiền trong hóa đơn
                    if (capnhattien)
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                    }
                }
            }
            else // Nếu không có hóa đơn trùng món và chưa gửi bếp
            {
                check = TaoHDMoi(maBan, user, maMon, soLuong, thanhTien, ngayBan, ghiChu);  //Gọi phương thức thêm hóa đơn mới.
            }
            return check;
        }

        
        //Thông báo lên trên màn hình sau khi thực hiện các lệnh
        public void ThongBaoThanhCong(Page a , string diaChi )
        {
            ScriptManager.RegisterStartupScript( a , a.GetType(), "alert", "alert('thành công');location.href= '/" + diaChi + "';", true);
        }
        public void ThongBaoThatBai(Page a, string diaChi)
        {
            ScriptManager.RegisterStartupScript(a, a.GetType(), "alert", "alert('thất bại');location.href= '/" + diaChi + "';", true);
        }
        
        //Sự kiện nhấn vào nút xác nhận
        protected void btnxacnhan_Click(object sender, EventArgs e)
        {
            string tenmon = lbtenmon.Text.ToString();
            string sl = txtsl.Text.ToString();           
            if(String.IsNullOrEmpty(tenmon) || String.IsNullOrEmpty(sl)) // Kiểm tra các dữ liệu có bị trống không
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bạn phải chọn món và nhập số lượng món');location.href='" + diachi + "';", true);
            }
            else // So sánh khi dữ liệu đầy đủ
            {
                int soluong = int.Parse(sl);
                if(soluong<=0) // Số lượng nhập vào < 0 
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bạn phải nhập số lượng món > 0');location.href='" + diachi + "';", true);
                }
                else //Các thông tin đều hợp lệ
                {
                   HOADONDTO hoadon = LayGiaTriTuForm();
                    //Khai báo 1 biến check kiểu bool thực hiện gọi phương thức thêm hóa đơn hoàn chỉnh 
                   bool check =  ThemMon(hoadon.Maban,hoadon.User,hoadon.Mamon,hoadon.Soluong,hoadon.Thanhtien,hoadon.Ngayban,hoadon.Ghichu);                                 
                   if(check == true) 
                   {
                       ThongBaoThanhCong(this, diachi);
                   }
                    else
                   {
                       ThongBaoThatBai(this,diachi);
                   }
                }
            }           
        }
        protected void btnptt_Click(object sender, EventArgs e)
        {
            Response.Redirect("phieutamtinhnv.aspx");
        }

        protected void btndsban_Click(object sender, EventArgs e)
        {
            phieutamtinhtn ptt = new phieutamtinhtn();
            ptt.KiemTraBan(lbtenban.Text);
            if (Session["guibep"] == null)
            {
                Response.Redirect("dsbannv.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Có món chưa gửi bếp');location.href='" + diachi + "';", true);
                Session.Remove("guibep");
            }
        }
      
    }
}