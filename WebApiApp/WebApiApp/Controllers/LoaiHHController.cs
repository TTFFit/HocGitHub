using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using WebApiApp.Data;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiHHController : ControllerBase
    {
        private readonly MyDBContext _context;
        public LoaiHHController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll() {
            try
            {
                var loaiHHS = _context.LoaiHHs.ToList();
                return Ok(loaiHHS);
            }
            catch 
            {
                return BadRequest();
            }
           
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loaiHH = _context.LoaiHHs.SingleOrDefault(it => it.MaLoaiHH == id);
            if (loaiHH == null)
            {
                return NotFound();
            }
            return Ok(loaiHH);

        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(LoaiHHModel item)
        {
            try
            {
                var loai = new LoaiHH
                {
                    TenLoaiHH = item.TenLoaiHH
                };
                _context.Add(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created,loai);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,LoaiHHModel model)
        {
            try { 
                var loaiHH = _context.LoaiHHs.SingleOrDefault(it => it.MaLoaiHH == id);
                if (loaiHH == null)
                {
                    return NotFound();
                }
                else
                {
                    loaiHH.TenLoaiHH = model.TenLoaiHH;
                    _context.SaveChanges();
                    return NoContent();
                }
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var loaiHH = _context.LoaiHHs.SingleOrDefault(it => it.MaLoaiHH == id);
                if (loaiHH == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Remove(loaiHH);
                    _context.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK);
                }
            }
            catch 
            {
                return BadRequest();
            }
        }
    }
}
