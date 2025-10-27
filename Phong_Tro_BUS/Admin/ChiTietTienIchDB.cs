using System.Collections.Generic;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;
using System.Data.Entity;

namespace Phong_Tro_BUS.Admin
{
    public class ChiTietTienIchDB
    {
        private readonly Connect db = new Connect();

        public List<ChiTietTienIch> GetAll()
        {
            return db.ChiTietTienIches.ToList();
        }

        public void Add(ChiTietTienIch ctti)
        {
            db.ChiTietTienIches.Add(ctti);
            db.SaveChanges();
        }

        public void Update(ChiTietTienIch ctti)
        {
            var old = db.ChiTietTienIches.Find(ctti.MaPhong, ctti.MaTienIch);
            if (old != null)
            {
                db.Entry(old).CurrentValues.SetValues(ctti);
                db.SaveChanges();
            }
        }

        public void Delete(string maPhong, int maTienIch)
        {
            var item = db.ChiTietTienIches.Find(maPhong, maTienIch);
            if (item != null)
            {
                db.ChiTietTienIches.Remove(item);
                db.SaveChanges();
            }
        }

        public ChiTietTienIch GetById(string maPhong, int maTienIch)
        {
            return db.ChiTietTienIches.Find(maPhong, maTienIch);
        }
    }
}
