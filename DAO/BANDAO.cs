using quan_ly_cafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

namespace quan_ly_cafe.DAO
{
    public class BANDAO
    {
        private static BANDAO instance;

        public static BANDAO Instance
        {
            get { if (instance == null) instance = new BANDAO(); return BANDAO.instance; }
            private set { BANDAO.instance = value; }
        }
        private BANDAO() { }
        //Lấy danh sách bàn từ CSDL và lưu vào 1 danh sách bàn
       
        public List<BANDTO> Showtable()
        {
            List<BANDTO> dsban = new List<BANDTO>();
            string sql = "SELECT * FROM BAN";
            DataTable da = Dataprovider.Instance.Query(sql);
            foreach (DataRow item in da.Rows) // lấy với mỗi item có trong Rows vừa lấy 
            {
                BANDTO ban = new BANDTO(item);
                dsban.Add(ban);
            }
            return dsban;
        }
        //Hiển thị danh sách bàn khu A
        
         public int tinhtrangban(string tenban)
         { 
            string sql = "select TINHTRANG from BAN where TENBAN = '"+tenban+"'" ;
            DataTable da = Dataprovider.Instance.Query(sql);
            GridView gv = new GridView();
            gv.DataSource = da;
            gv.DataBind();
            int tinhtrang = int.Parse(gv.Rows[0].Cells[0].Text.ToString());
            return tinhtrang;
 
          }
        public int maban(string tenban)
         {
             string sql = "select MABAN from BAN where TENBAN = '" + tenban + "'";
             DataTable da = Dataprovider.Instance.Query(sql);
             GridView gv = new GridView();
             gv.DataSource = da;
             gv.DataBind();
             int maban = int.Parse(gv.Rows[0].Cells[0].Text.ToString());
             return maban;
         }

        public bool capnhattrangthaicokhach( int maban)
        {
            string sql = "update BAN set TINHTRANG = 2 WHERE MABAN  ='"+maban+"' ";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }

        public bool capnhattrangthaitrong(int maban)
        {
            string sql = "update BAN set TINHTRANG = 1 WHERE MABAN  ='" + maban + "' ";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }
        public bool capnhattrangthaiyeucau(int maban)
        {
            string sql = "update BAN set TINHTRANG = 3 WHERE MABAN  ='" + maban + "' ";
            int result = Dataprovider.Instance.ExNonQuery(sql);
            return result > 0;
        }


    }

   
}