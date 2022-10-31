using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApiApp.Data;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public class LoaiHHRepository : ILoaiHHRepository
    {
        private readonly MyDBContext _context;
        public LoaiHHRepository(MyDBContext context)
        {
            _context = context;
        }
        public LoaiHHVM Crreate(LoaiHHModel loai)
        {
            var _loai = new LoaiHH
            {
                TenLoaiHH = loai.TenLoaiHH,
            };
            _context.Add(_loai);
            _context.SaveChanges();
            return new LoaiHHVM
            {
                MaLoaiHH = _loai.MaLoaiHH,
                TenLoaiHH = _loai.TenLoaiHH
            };
        }
        public void Delete(int id)
        {
            var loai = _context.LoaiHHs.SingleOrDefault(it => it.MaLoaiHH == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }
        public void Edit(LoaiHHVM loai)
        {
            var _loai = _context.LoaiHHs.SingleOrDefault(it => it.MaLoaiHH == loai.MaLoaiHH);
            if (_loai != null)
            {
                _loai.TenLoaiHH = loai.TenLoaiHH;
                _context.SaveChanges();
            }
        }

        public List<LoaiHHVM> GetAll()
        {
            var loais = _context.LoaiHHs.Select(it => new LoaiHHVM { MaLoaiHH = it.MaLoaiHH, TenLoaiHH = it.TenLoaiHH });
            return loais.ToList();
        }

        public LoaiHHVM GetById(int id)
        {
            var loai = _context.LoaiHHs.SingleOrDefault(it=>it.MaLoaiHH == id);
            if (loai == null) {
                return new LoaiHHVM { MaLoaiHH = loai.MaLoaiHH, TenLoaiHH = loai.TenLoaiHH };
            }
            return null;
        }
    }
}
