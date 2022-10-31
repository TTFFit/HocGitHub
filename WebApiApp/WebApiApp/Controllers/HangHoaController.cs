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
        /// <summary>
        ///  Day la chuc nang quan ly hang hoa API
        /// </summary>
        /*cuong test xunf dột dữ liệu*/
        private readonly IHangHoaRepository _hangHoaRepository;
        public  HangHoaController(IHangHoaRepository hangHoaRepository)
        {
            _hangHoaRepository = hangHoaRepository;
            /// test hàng hóa
            /// tetetetete djdjdskjdkjsdk j

            /// Triệu thị xà mây vợ cường

            /// hjhejhrjeh r
            /// Lý Quốc CƯờng Đẹp trai
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

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoaModel hangHoa)
        {
            try
            {
                if (id != hangHoa.MaHH.ToString())
                {
                    return BadRequest();
                }
                try
                {
                    _hangHoaRepository.Edit(hangHoa);
                    return NoContent();
                }
                catch
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _hangHoaRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
