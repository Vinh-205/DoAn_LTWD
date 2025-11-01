using System;
using System.Collections.Generic;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;
using System.Data.Entity;

namespace Phong_Tro_BUS.Core
{
    public class HopDongBUS
    {
        public List<HopDong> LayTatCaHopDong()
        {
            using (var db = new Connect())
            {
                return db.HopDongs
                    .Include("Phong")
                    .Include("KhachThue")
                    .ToList();
            }
        }

        public HopDong LayHopDongTheoMa(int maHopDong)
        {
            using (var db = new Connect())
            {
                return db.HopDongs
                    .Include("Phong")
                    .Include("KhachThue")
                    .FirstOrDefault(h => h.MaHopDong == maHopDong);
            }
        }

        public bool ThemHopDong(HopDong hopDong)
        {
            if (hopDong == null)
                throw new ArgumentNullException(nameof(hopDong));

            using (var db = new Connect())
            {
                db.HopDongs.Add(hopDong);
                return db.SaveChanges() > 0;
            }
        }

        public bool CapNhatHopDong(HopDong hopDong)
        {
            using (var db = new Connect())
            {
                var old = db.HopDongs.FirstOrDefault(h => h.MaHopDong == hopDong.MaHopDong);
                if (old == null) return false;

                db.Entry(old).CurrentValues.SetValues(hopDong);
                return db.SaveChanges() > 0;
            }
        }

        public bool XoaHopDong(int maHopDong)
        {
            using (var db = new Connect())
            {
                var hopDong = db.HopDongs.FirstOrDefault(h => h.MaHopDong == maHopDong);
                if (hopDong == null) return false;

                db.HopDongs.Remove(hopDong);
                return db.SaveChanges() > 0;
            }
        }
    }
}
