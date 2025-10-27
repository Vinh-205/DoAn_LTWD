using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.Admin
{
    public class TienIchDB
    {
        private readonly Connect db = new Connect();

        // Lấy toàn bộ danh sách tiện ích
        public List<TienIch> GetAll()
        {
            return db.TienIches.ToList();
        }

        // Lấy tiện ích theo mã
        public TienIch GetById(int maTienIch)
        {
            return db.TienIches.FirstOrDefault(t => t.MaTienIch == maTienIch);
        }

        // Tìm tiện ích theo tên
        public List<TienIch> SearchByName(string keyword)
        {
            return db.TienIches
                     .Where(t => t.TenTienIch.Contains(keyword))
                     .ToList();
        }

        // Thêm mới tiện ích
        public void Add(TienIch tienIch)
        {
            if (!ExistsByName(tienIch.TenTienIch))
            {
                db.TienIches.Add(tienIch);
                db.SaveChanges();
            }
        }

        // Cập nhật thông tin tiện ích
        public void Update(TienIch tienIch)
        {
            var old = db.TienIches.FirstOrDefault(t => t.MaTienIch == tienIch.MaTienIch);
            if (old != null)
            {
                db.Entry(old).CurrentValues.SetValues(tienIch);
                db.SaveChanges();
            }
        }

        // Xóa tiện ích
        public void Delete(int maTienIch)
        {
            var item = db.TienIches.FirstOrDefault(t => t.MaTienIch == maTienIch);
            if (item != null)
            {
                db.TienIches.Remove(item);
                db.SaveChanges();
            }
        }

        // Kiểm tra tên tiện ích có trùng chưa
        private bool ExistsByName(string tenTienIch)
        {
            return db.TienIches.Any(t => t.TenTienIch.ToLower() == tenTienIch.ToLower());
        }
    }
}
