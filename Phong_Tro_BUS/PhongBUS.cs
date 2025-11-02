using System;
using System.Collections.Generic;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS
{
    public class PhongBUS
    {
        public List<Phong> LayTatCaPhong()
        {
            using (var db = new Connect())
            {
                return db.Phongs.ToList();
            }
        }

        public Phong LayPhongTheoMa(string maPhong)
        {
            using (var db = new Connect())
            {
                return db.Phongs.FirstOrDefault(p => p.MaPhong == maPhong);
            }
        }

        public bool ThemPhong(Phong phong)
        {
            if (phong == null)
                throw new ArgumentNullException(nameof(phong));
            if (string.IsNullOrWhiteSpace(phong.TenPhong))
                throw new ArgumentException("Tên phòng không được để trống.");
            if (phong.GiaThue <= 0)
                throw new ArgumentException("Giá thuê phải lớn hơn 0.");

            using (var db = new Connect())
            {
                db.Phongs.Add(phong);
                return db.SaveChanges() > 0;
            }
        }

        public bool CapNhatPhong(Phong phong)
        {
            using (var db = new Connect())
            {
                var old = db.Phongs.FirstOrDefault(p => p.MaPhong == phong.MaPhong);
                if (old == null) return false;

                db.Entry(old).CurrentValues.SetValues(phong);
                return db.SaveChanges() > 0;
            }
        }

        public bool XoaPhong(string maPhong)
        {
            using (var db = new Connect())
            {
                var phong = db.Phongs.FirstOrDefault(p => p.MaPhong == maPhong);
                if (phong == null) return false;

                db.Phongs.Remove(phong);
                return db.SaveChanges() > 0;
            }
        }
    }
}
