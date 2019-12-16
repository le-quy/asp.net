using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quan_ly_cafe
{
    public class HOADONDTO
    {
        private int maban;

        public int Maban
        {
            get { return maban; }
            set { maban = value; }
        }
        private string user;

        public string User
        {
            get { return user; }
            set { user = value; }
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

        public string Ngayban
        {
            get { return ngayban; }
            set { ngayban = value; }
        }
        private string ghichu;

        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
        public HOADONDTO (int maban, string user, int mamon, int soluong, int thanhtien, string ngayban, string ghichu)
        {
            this.maban = maban;
            this.user = user;
            this.mamon = mamon;
            this.soluong = soluong;
            this.thanhtien = thanhtien;
            this.ngayban = ngayban;
            this.ghichu = ghichu;

        }
    }
}