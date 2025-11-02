using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS
{
    public class DichVuBUS
    {
        private readonly Connect db;

        public DichVuBUS()
        {
            db = new Connect();
        }

        public List<DichVu> LayTatCa()
        {
            return db.DichVus.AsNoTracking().ToList();
        }

        public bool Them(DichVu dv)
        {
            if (dv == null) throw new ArgumentNullException(nameof(dv));
            if (db.DichVus.Any(x => x.MaDV == dv.MaDV))
                throw new Exception("Mã dịch vụ đã tồn tại!");
            db.DichVus.Add(dv);
            db.SaveChanges();
            return true;
        }

        public bool Sua(DichVu dv)
        {
            var existing = db.DichVus.Find(dv.MaDV);
            if (existing == null) throw new Exception("Không tìm thấy dịch vụ!");
            existing.TenDV = dv.TenDV;
            existing.DonGia = dv.DonGia;
            existing.MoTa = dv.MoTa;
            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public bool Xoa(string maDV)
        {
            var dv = db.DichVus.Find(maDV);
            if (dv == null) throw new Exception("Không tìm thấy dịch vụ!");
            db.DichVus.Remove(dv);
            db.SaveChanges();
            return true;
        }


        public List<DichVu> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return LayTatCa();

            return db.DichVus
                     .Where(x => x.TenDV.Contains(tuKhoa))
                     .AsNoTracking()
                     .ToList();
        }

        public DichVu LayTheoMa(string maDV)
        {
            return db.DichVus
                     .AsNoTracking()
                     .FirstOrDefault(x => x.MaDV == maDV);
        }
    }
}
