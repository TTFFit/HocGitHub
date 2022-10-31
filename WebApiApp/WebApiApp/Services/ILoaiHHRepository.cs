using System.Collections.Generic;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public interface ILoaiHHRepository
    {
        List<LoaiHHVM> GetAll();
        LoaiHHVM GetById(int id);
        LoaiHHVM Crreate(LoaiHHModel loai);
        void Edit(LoaiHHVM loai);
        void Delete(int id);

    }
}
