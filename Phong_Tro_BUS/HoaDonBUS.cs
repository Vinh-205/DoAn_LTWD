using System;
using System.Collections.Generic;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.Core
{
    public class HoaDonBUS
    {
        public List<HoaDon> LayTatCa()
        {
            using (var db = new Connect())
            {
                return db.HoaDons.Include("HopDong").ToList();
            }
        }

        public HoaDon LayTheoMa(string maHD)
        {
            using (var db = new Connect())
            {
                return db.HoaDons.FirstOrDefault(h => h.MaHD == maHD);
            }
        }

        public bool ThemHoaDon(HoaDon hoaDon)
        {
            if (hoaDon == null) throw new ArgumentNullException(nameof(hoaDon));

            using (var db = new Connect())
            {
                db.HoaDons.Add(hoaDon);
                return db.SaveChanges() > 0;
            }
        }

        public bool CapNhatHoaDon(HoaDon hoaDon)
        {
            using (var db = new Connect())
            {
                var old = db.HoaDons.FirstOrDefault(h => h.MaHD == hoaDon.MaHD);
                if (old == null) return false;

                old.SoDienMoi = hoaDon.SoDienMoi;
                old.SoNuocMoi = hoaDon.SoNuocMoi;
                old.TienDien = hoaDon.TienDien;
                old.TienNuoc = hoaDon.TienNuoc;
                old.TienDichVu = hoaDon.TienDichVu;
                old.TongTien = hoaDon.TongTien;
                old.NgayLap = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        public bool XoaHoaDon(string maHD)
        {
            using (var db = new Connect())
            {
                var hd = db.HoaDons.FirstOrDefault(h => h.MaHD == maHD);
                if (hd == null) return false;
                db.HoaDons.Remove(hd);
                return db.SaveChanges() > 0;
            }
        }
    }
}
