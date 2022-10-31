using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Models;
using WebApiApp.Services;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiHHsController : ControllerBase
    {
        private readonly ILoaiHHRepository _loaiRepository;

        public LoaiHHsController(ILoaiHHRepository loaiRepository) {
            _loaiRepository = loaiRepository;
        }
        [HttpGet]
        public IActionResult GetAll() {
            try
            {
                return Ok(_loaiRepository.GetAll());
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _loaiRepository.GetById(id);
                if (data == null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Create(LoaiHHModel loai)
        {
            try
            {
                var data = _loaiRepository.Crreate(loai);
                return Ok(data);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id,LoaiHHVM loai)
        {
            if (id != loai.MaLoaiHH)
            {
                return BadRequest();
            }
            try
            {
                
                _loaiRepository.Edit(loai);
                return NoContent();
                
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _loaiRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
       
    }
}
