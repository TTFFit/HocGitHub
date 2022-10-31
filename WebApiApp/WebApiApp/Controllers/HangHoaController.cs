using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiApp.Models;
using WebApiApp.Services;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly IHangHoaRepository _hangHoaRepository;
        public  HangHoaController(IHangHoaRepository hangHoaRepository)
        {
            _hangHoaRepository = hangHoaRepository;
        }

        [HttpGet("{id}/GetById")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = _hangHoaRepository.GetById(Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("GetAll/{page}/{sreach}")]
        public IActionResult GetAll(int page = 1,string sreach = null) 
        {
            var result = _hangHoaRepository.GetAll(page);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Create(HangHoaModel item)
        {
            if (ModelState.IsValid)
            {
                var result = _hangHoaRepository.Create(item);
                return Ok(new
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return BadRequest();
            }
            
        }

        //[HttpPut("{id}")]
        //public IActionResult Edit(string id, HangHoa hangHoaEdit)
        //{
        //    try
        //    {
        //        var hangHoa = hangHoas.SingleOrDefault(it => it.MaHangHoa == Guid.Parse(id));
        //        if (hangHoa == null)
        //        {
        //            return NotFound();
        //        }
        //        if (id != hangHoa.MaHangHoa.ToString())
        //        {
        //            return BadRequest();
        //        }
        //        //Update
        //        hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
        //        hangHoa.DonGia = hangHoaEdit.DonGia;
        //        return Ok();

        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    try
        //    {
        //        var hangHoa = hangHoas.SingleOrDefault(it => it.MaHangHoa == Guid.Parse(id));
        //        if (hangHoa == null)
        //        {
        //            return NotFound();
        //        }
        //        hangHoas.Remove(hangHoa);
        //        return Ok();

        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
