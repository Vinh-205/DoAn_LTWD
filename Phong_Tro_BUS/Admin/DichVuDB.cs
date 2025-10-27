using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.Admin
{
    public class DichVuDB
    {
        // Lấy toàn bộ danh sách dịch vụ
        public List<DichVu> GetAll()
        {
            using (var db = new Connect())
            {
                return db.DichVus.ToList();
            }
        }

        // Lấy dịch vụ theo mã
        public DichVu GetById(string maDV)
        {
            using (var db = new Connect())
            {
                return db.DichVus.FirstOrDefault(x => x.MaDV == maDV);
            }
        }

        // Thêm mới dịch vụ
        public void Add(DichVu dv)
        {
            using (var db = new Connect())
            {
                db.DichVus.Add(dv);
                db.SaveChanges();
            }
        }

        // Cập nhật dịch vụ
        public void Update(DichVu dv)
        {
            using (var db = new Connect())
            {
                var existing = db.DichVus.FirstOrDefault(x => x.MaDV == dv.MaDV);
                if (existing != null)
                {
                    db.Entry(existing).CurrentValues.SetValues(dv);
                    db.SaveChanges();
                }
            }
        }

        // Xóa dịch vụ
        public void Delete(string maDV)
        {
            using (var db = new Connect())
            {
                var dv = db.DichVus.FirstOrDefault(x => x.MaDV == maDV);
                if (dv != null)
                {
                    db.DichVus.Remove(dv);
                    db.SaveChanges();
                }
            }
        }
    }
}
