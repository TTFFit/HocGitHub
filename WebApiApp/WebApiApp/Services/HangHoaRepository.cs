using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiApp.Data;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private readonly MyDBContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public HangHoaRepository(MyDBContext context){
            _context = context; 
        }
        public List<HangHoaModel> GetAll(int page = 1)
        {
            var hangHoas = _context.HangHoas.Include(it=>it.Loai).AsQueryable();

            #region Paging
            //hangHoas = hangHoas.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            var result = PaginatedList<Data.HangHoa>.Create(hangHoas, PAGE_SIZE, page);

            #endregion End Paging
            return result.Select(it => new HangHoaModel
            {
                MaHH = it.MaHH,
                TenHH = it.TenHH,
                Mota = it.Mota,
                DonGia = it.DonGia,
                GiamGia = it.GiamGia,
                MaLoaiHH = it.MaLoaiHH,
                TenLoaiHH = it.Loai.TenLoaiHH
            }).ToList();
        }

        public HangHoaModel GetById(Guid id)
        {
            var data = _context.HangHoas.Include(it=>it.Loai).SingleOrDefault(it => it.MaHH == id);
            if (data != null)
            {
                return new HangHoaModel { 
                    MaHH = data.MaHH,
                    TenHH = data.TenHH,
                    DonGia = data.DonGia,
                    GiamGia = data.GiamGia,
                    Mota = data.Mota,
                    MaLoaiHH = data.MaLoaiHH,
                    TenLoaiHH = data.Loai.TenLoaiHH,
                };
            }
            return null;
        }

        public HangHoaModel Create(HangHoaModel item)
        {
            var hangHoa = new HangHoa {
                MaHH = Guid.NewGuid(),
                TenHH = item.TenHH,
                Mota = item.Mota,
                GiamGia = item.GiamGia,
                DonGia = item.DonGia,
                MaLoaiHH = item.MaLoaiHH,
            };
            _context.Add(hangHoa);
            _context.SaveChanges();
            item.MaHH = hangHoa.MaHH;
            return item;
        }
    }
}
