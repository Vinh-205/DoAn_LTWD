using System.Collections.Generic;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro; // để dùng Connect và ChuNha entity
using System.Data.Entity;

namespace Phong_Tro_BUS.Admin
{
    public class ChuNhaDB
    {
        private readonly Connect db = new Connect();

        // Lấy toàn bộ danh sách chủ nhà
        public List<ChuNha> GetAll()
        {
            return db.ChuNhas.ToList();
        }

        // Lấy 1 chủ nhà theo ID
        public ChuNha GetById(int maChu)
        {
            return db.ChuNhas.FirstOrDefault(x => x.MaChu == maChu);
        }

        // Thêm mới chủ nhà
        public void Add(ChuNha cn)
        {
            db.ChuNhas.Add(cn);
            db.SaveChanges();
        }

        // Cập nhật chủ nhà
        public void Update(ChuNha cn)
        {
            var existing = db.ChuNhas.FirstOrDefault(x => x.MaChu == cn.MaChu);
            if (existing != null)
            {
                db.Entry(existing).CurrentValues.SetValues(cn);
                db.SaveChanges();
            }
        }

        // Xóa chủ nhà
        public void Delete(int maChu)
        {
            var cn = db.ChuNhas.FirstOrDefault(x => x.MaChu == maChu);
            if (cn != null)
            {
                db.ChuNhas.Remove(cn);
                db.SaveChanges();
            }
        }
    }
}
