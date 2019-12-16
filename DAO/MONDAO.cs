using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
namespace quan_ly_cafe.DAO

{
    public class MONDAO
    {
        private static MONDAO instance;


        public static MONDAO Instance
        {
            get { if (instance == null) instance = new MONDAO(); return MONDAO.instance; }
            set { MONDAO.instance = value; }
        }
        private MONDAO() { }

        public DataTable hienthimon()
        {
            string sql = "select MAMON,TENMON,DONGIA from MON ";
            DataTable result = Dataprovider.Instance.Query(sql);
            return result;
        }
        public DataTable hienthimoncf()
        {
            string sql = "select MAMON,TENMON,DONGIA from MON WHERE LOAI = N'CÀ PHÊ' ";
            DataTable result = Dataprovider.Instance.Query(sql);
            return result;
        }
        public DataTable hienthimonnuocep()
        {
            string sql = "select MAMON,TENMON,DONGIA from MON WHERE LOAI = N'NƯỚC ÉP' ";
            DataTable result = Dataprovider.Instance.Query(sql);
            return result;
        }
        public DataTable hienthimontrasua()
        {
            string sql = "select MAMON,TENMON,DONGIA from MON WHERE LOAI = N'TRÀ SỮA' ";
            DataTable result = Dataprovider.Instance.Query(sql);
            return result;
        }
        public DataTable hienthimonsuachua()
        {
            string sql = "select MAMON,TENMON,DONGIA from MON WHERE LOAI = N'SỮA CHUA' ";
            DataTable result = Dataprovider.Instance.Query(sql);
            return result;
        }
        //Tìm kiếm món theo tên 
        public DataTable timkiemtheoten(string tenmon)
        {
            string sql = "select MAMON,TENMON,DONGIA from MON WHERE TENMON LIKE N'%"+tenmon+"%' ";
            DataTable result = Dataprovider.Instance.Query(sql);
            return result;
        }
        //Tìm kiếm món theo mã món
        public DataTable timkiemtheomamon(int mamon)
        {
            string sql = "select MAMON,TENMON,DONGIA from MON WHERE MAMON = '"+mamon+"'  ";
            DataTable result = Dataprovider.Instance.Query(sql);
            return result;
        }

        //Lấy đơn giá từ món
        public int dongia(int mamon)
        {
        string sql = "select DONGIA from MON where MAMON = '"+mamon+"' ";
        DataTable result = Dataprovider.Instance.Query(sql);
        GridView gv = new GridView();
        gv.DataSource = result;
        gv.DataBind();
        int gia = int.Parse(gv.Rows[0].Cells[0].Text.ToString());
        return gia;
        }
        //Lấy tên món
        public string tenmon(int mamon)
        {
            string sql = "select TENMON from MON where MAMON = '" + mamon + "' ";
            DataTable result = Dataprovider.Instance.Query(sql);
            GridView gv = new GridView();
            gv.DataSource = result;
            gv.DataBind();
            string tenmon = gv.Rows[0].Cells[0].Text.ToString();
            return tenmon;
        }

       
    }
}