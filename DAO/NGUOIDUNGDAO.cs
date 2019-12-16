using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

namespace quan_ly_cafe.DAO
{
    public class NGUOIDUNGDAO
    {
        private static NGUOIDUNGDAO instance;

        public static NGUOIDUNGDAO Instance
        {
            get { if (instance == null) instance = new NGUOIDUNGDAO(); return NGUOIDUNGDAO.instance; }
            private set { NGUOIDUNGDAO.instance = value; }
        }
        private NGUOIDUNGDAO() { }
        public bool kiemtra(string username, string password)
        {
            string sql = "SELECT COUNT(*) FROM NGUOIDUNG WHERE USERNAME ='" + username + "' AND PASSWORD = '" + password + "'";
            int result = Dataprovider.Instance.ExScalar(sql);
            return result > 0;
        }
        public DataTable danhsachnhanvien()
        {
            string sql = "select USERNAME,TENNHANVIEN from NGUOIDUNG WHERE CHUCVU ='1' OR CHUCVU ='2'";
            DataTable result = Dataprovider.Instance.Query(sql);
            return result;
        }
        public string hienthinhanvien(string username)
        {
            string sql = "select TENNHANVIEN from NGUOIDUNG where USERNAME = '" + username + "' ";
            DataTable da = Dataprovider.Instance.Query(sql);
            GridView gv = new GridView();
            gv.DataSource = da;
            gv.DataBind();
            string tennv = gv.Rows[0].Cells[0].Text.ToString();
            return tennv;
        }
        public int kiemtrachucvu(string username)
        {
            string sql = "select CHUCVU from NGUOIDUNG where USERNAME = '" + username + "' ";
            DataTable da = Dataprovider.Instance.Query(sql);
            GridView gv = new GridView();
            gv.DataSource = da;
            gv.DataBind();
            int chucvu = int.Parse(gv.Rows[0].Cells[0].Text.ToString());
            return chucvu;
        }
        
    }
}