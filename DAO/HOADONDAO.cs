using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

namespace quan_ly_cafe.DAO
{
    public class HOADONDAO
    {
         private static HOADONDAO instance;

        public static HOADONDAO Instance
        {
            get { if (instance == null) instance = new HOADONDAO(); return HOADONDAO.instance; }
            private set { HOADONDAO.instance = value; }
        }
        private HOADONDAO() { }
        //Tạo một hóa đơn mới
        public bool datmon(HOADONDTO hoadon)
        {
            string sql = "INSERT INTO HOADON(MABAN,USERNAMENV, MAMON ,SOLUONG,THANHTIEN,GUIBEP,THANHTOAN,NGAYBAN,CHUTHICH) values( '" + hoadon.Maban + "', '" + hoadon.User + "','" + hoadon.Mamon + "', '" + hoadon.Soluong + "','" + hoadon.Thanhtien + "','False','False','" + hoadon.Ngayban + "',N'" + hoadon.Ghichu + "')";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        public bool hoadontach(HOADONDTO hoadon)
        {
            string sql = "INSERT INTO HOADON(MABAN,USERNAMENV, MAMON ,SOLUONG,THANHTIEN,GUIBEP,THANHTOAN,NGAYBAN,CHUTHICH) values( '" + hoadon.Maban + "', '" + hoadon.User + "','" + hoadon.Mamon + "', '" + hoadon.Soluong + "','" + hoadon.Thanhtien + "','True','False','" + hoadon.Ngayban + "',N'" + hoadon.Ghichu + "')";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        //Hiển thị danh sách phiếu tạm tính
        public DataTable phieutamtinh(int maban)
        {
            string sql = "select HOADON.MAMON, MON.TENMON , SUM(HOADON.SOLUONG) AS SOLUONG, SUM(HOADON.THANHTIEN) AS THANHTIEN FROM MON, HOADON WHERE MON.MAMON = HOADON.MAMON AND MABAN = '" + maban + "' GROUP BY HOADON.MAMON, MON.TENMON ";
            DataTable da = Dataprovider.Instance.Query(sql);
            return da;
        }
        //Cập nhật món gửi bếp
        public bool guibep(int maban)
        {
            string sql = "update HOADON set GUIBEP = 1 WHERE MABAN = '" + maban + "'   ";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        //Cập nhật đã thanh toán
        public bool thanhtoan(int maban)
        {
            string sql = "update HOADON set THANHTOAN = 1 WHERE MABAN = '" + maban + "'   ";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        //Xóa món trong hóa đơn 
        public bool huymon(int maban, int mamon)
        {
            string sql = "delete from HOADON where MABAN = '" + maban + "' AND MAMON='" + mamon + "' and GUIBEP ='False'";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        //Cập nhật lại số lượng món huy 
        public bool giamsoluongmon(int maban, int mamon, int soluong)
        {
            string sql = "update HOADON set SOLUONG = (SOLUONG - '" + soluong + "') where  MABAN = '" + maban + "' AND MAMON='" + mamon + "' and GUIBEP ='False'";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        //Cập nhật lại số lượng món thêm
        public bool tangsoluongmon(int maban, int mamon, int soluong)
        {
            string sql = "update HOADON set SOLUONG = (SOLUONG + '" + soluong + "') where  MABAN = '" + maban + "' AND MAMON='" + mamon + "' and GUIBEP ='False'";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        //Cập nhật lại thành tiền 
        public bool capnhatthanhtien(int maban, int mamon, int dongia)
        {
            string sql = "update HOADON set THANHTIEN = (SOLUONG * '" + dongia + "') where  MABAN = '" + maban + "' AND MAMON='" + mamon + "' and GUIBEP ='False'";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        //Kiem tra món được chọn đã có trong hóa đơn và chưa gửi bếp 
        public bool kiemtracomonchuaguibep(int maban, int mamon)
        {
            string sql = "select count(*) from HOADON where MABAN = '" + maban + "' and MAMON = '" + mamon + "' and GUIBEP = 'False' ";
            int result = Dataprovider.Instance.ExScalar(sql);
            return result > 0;
        }
        //Kiểm tra bàn có chứa món nào chưa gửi bếp
        public bool kiemtrabanchuaguibep(int maban)
        {
            string sql = "select count(*) from HOADON where MABAN = '" + maban + "' and GUIBEP = 0 ";
            int result = Dataprovider.Instance.ExScalar(sql);
            return result > 0;
        }
        //Lấy số lượng của món chưa gửi bếp trong bàn
        public int soluongchuaguibep(int maban, int mamon)
        {
            string sql = "select SOLUONG from HOADON where MABAN = '" + maban + "' and MAMON = '" + mamon + "' and GUIBEP = 'False' ";
            DataTable da = Dataprovider.Instance.Query(sql);
            GridView gv = new GridView();
            gv.DataSource = da;
            gv.DataBind();
            int sl = int.Parse(gv.Rows[0].Cells[0].Text.ToString());
            return sl;
        }
        //Lấy số lượng của món đã gửi bếp trong bàn
        public int soluongdaguibep(int maban, int mamon)
        {
            string sql = "select SUM(SOLUONG) as SOLUONG from HOADON where MABAN = '" + maban + "' and MAMON = '" + mamon + "' and GUIBEP = 1 ";
            DataTable da = Dataprovider.Instance.Query(sql);
            GridView gv = new GridView();
            gv.DataSource = da;
            gv.DataBind();
            int sl = int.Parse(gv.Rows[0].Cells[0].Text.ToString());
            return sl;
        }
       
        //Cập nhật trạng thái đã thanh toán
        public bool capnhatthanhtoan(int maban,string userthungan, string ngaytt)
        {
            string sql = "update HOADON set THANHTOAN = 1, USERNAMETN = '"+userthungan+"', NGAYTT = '"+ngaytt+"'  where MABAN = '" + maban + "' ";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        //Xóa những hóa đơn đã thanh toán
        public bool xoahoadonthanhtoan()
        {
            string sql = "DELETE from HOADON where THANHTOAN = 1 ";
            int result = Dataprovider.Instance.ExNonQuery(sql);
                return result >0;
        }
        public bool xoahoadoncomonbang0()
        {
            string sql = "DELETE from HOADON where SOLUONG = 0 ";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        //Xóa hóa đơn có mã bàn và món vừa tách để tạo hóa đơn mới
        public bool xoahoadontach(int maban, int mamon)
        {
            string sql = "DELETE from HOADON where MABAN = '"+maban+"' and MAMON= '"+mamon+"'  ";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        //Cập nhật trạng thái đã thanh toán
        public bool capnhatchuyenban(int bancu, int banmoi )
        {
            string sql = "update HOADON set MABAN = '"+banmoi+"' where MABAN = '" + bancu + "' ";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        //Kiểm tra bàn đã có hóa đơn gửi bếp
        public bool kiemtrabancohoadon(int maban)
        {
            string sql = "select count(*) from HOADON where MABAN = '" + maban + "' and GUIBEP = 1 ";
            int result = Dataprovider.Instance.ExScalar(sql);
            return result > 0;
        }
    }
}