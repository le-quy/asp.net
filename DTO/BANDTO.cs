using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace quan_ly_cafe.DTO
{
    public class BANDTO
    {
        private int maban;

        public int Maban
        {
            get { return maban; }
            set { maban = value; }
        }
        private string tenban;

        public string Tenban
        {
            get { return tenban; }
            set { tenban = value; }
        }
        private int tinhtrang;

        public int Tinhtrang
        {
            get { return tinhtrang; }
            set { tinhtrang = value; }
        }

        
        private string khuvuc;

        public string Khuvuc
        {
            get { return khuvuc; }
            set { khuvuc = value; }
        }

        public BANDTO (int maban, string tenban, int tinhtrang, string khuvuc)
        {
            this.maban = maban;
            this.tenban = tenban;
            this.tinhtrang = tinhtrang;
           
            this.Khuvuc = khuvuc;
        }
        public BANDTO (DataRow row)
        {
            this.maban = (int)row["MABAN"];
            this.tenban = row["TENBAN"].ToString();
            this.tinhtrang =(int)  row["TINHTRANG"];
            this.khuvuc = row["KHUVUC"].ToString();
        }
    }
}