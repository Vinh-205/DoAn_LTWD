using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.Admin
{
    public class ChiTietHoaDonDB
    {
        private readonly Connect db = new Connect();

        public List<ChiTietHoaDon> GetAll()
        {
            return db.ChiTietHoaDons.ToList();
        }

        public void Add(ChiTietHoaDon cthd)
        {
            db.ChiTietHoaDons.Add(cthd);
            db.SaveChanges();
        }

        // Update theo composite key (maHD, maDV)
        public void Update(ChiTietHoaDon cthd)
        {
            var old = db.ChiTietHoaDons.Find(cthd.MaHD, cthd.MaDV);
            if (old != null)
            {
                db.Entry(old).CurrentValues.SetValues(cthd);
                db.SaveChanges();
            }
        }

        // Delete theo composite key
        public void Delete(string maHD, string maDV)
        {
            var item = db.ChiTietHoaDons.Find(maHD, maDV);
            if (item != null)
            {
                db.ChiTietHoaDons.Remove(item);
                db.SaveChanges();
            }
        }

        // Lấy theo composite key
        public ChiTietHoaDon GetById(string maHD, string maDV)
        {
            return db.ChiTietHoaDons.Find(maHD, maDV);
        }
    }
}
