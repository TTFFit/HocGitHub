using System;
using System.Collections.Generic;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public interface IHangHoaRepository
    {
        List<HangHoaModel> GetAll(int page);
        HangHoaModel GetById(Guid id);
        HangHoaModel Create(HangHoaModel item);
    }
}
