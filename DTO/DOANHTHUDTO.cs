using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace quan_ly_cafe.DTO
{
    public class DOANHTHUDTO
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private int mamon;

        public int Mamon
        {
            get { return mamon; }
            set { mamon = value; }
        }
        private int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        private int thanhtien;

        public int Thanhtien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }
        private string ngayban;

        private string ngaytt;

        public string Ngaytt
        {
            get { return ngaytt; }
            set { ngaytt = value; }
        }
        public DOANHTHUDTO (DataRow row)
        {
            this.username =  row["USERNAMETN"].ToString();
            this.mamon = (int) row["MAMON"];
            this.soluong = (int)row["SOLUONG"];
            this.thanhtien = (int)row["THANHTIEN"];
            this.ngaytt = row["NGAYTT"].ToString();
        }
        public DOANHTHUDTO (string username, int mamon, int soluong, int thanhtien, string ngaytt )
        {
            this.username = username;
            this.mamon = mamon;
            this.soluong = soluong;
            this.thanhtien = thanhtien;
            this.ngaytt = ngayban;
        }
    }
}