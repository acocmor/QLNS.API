using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.API.Application.DTOs.NhanVien;
using QLNS.API.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;
        public NhanVienController(INhanVienService service)
        {
            _nhanVienService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetNhanVienDTO>>> GetAllNhanVien()
        {
            return Ok(await _nhanVienService.GetAllNhanViens());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetNhanVienDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetNhanVienDTO>> GetNhanVienById(Guid id)
        {
            var result = await _nhanVienService.GetNhanVienById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GetNhanVienDTO>> Create([FromBody] CreateNhanVienDTO request)
        {
            if(request == null)
            {
                return BadRequest();
            }
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try
            {
                if (await _nhanVienService.GetUserByEmail(request.User.Email))
                {
                    ModelState.AddModelError(nameof(request.User.Email), "Địa chỉ email đã tồn tại.");
                    return BadRequest(ModelState);
                }
                if (request.PhongBanId != null)
                {
                    if(!await _nhanVienService.GetPhongBanById((Guid)request.PhongBanId))
                    {
                        ModelState.AddModelError(nameof(request.PhongBanId), "Phòng ban này không tồn tại");
                        return BadRequest(ModelState);
                    }
                }
                if (request.ChucVuId != null)
                {
                    if (!await _nhanVienService.GetChucVuById((Guid)request.ChucVuId))
                    {
                        ModelState.AddModelError(nameof(request.ChucVuId), "Chức vụ này không tồn tại");
                        return BadRequest(ModelState);
                    }
                }
                var newNhanVien = await _nhanVienService.CreateNhanVien(request);
                if (newNhanVien == null) return BadRequest(ModelState);
                return CreatedAtAction(nameof(GetNhanVienById), new { id = newNhanVien.Id }, newNhanVien);
            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi ghi dữ liệu vào database!");
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetNhanVienDTO>> Update(Guid id, [FromBody] UpdateNhanVienDTO request)
        {
            var updateNhanVien = await _nhanVienService.UpdateNhanVien(id, request);
            if (updateNhanVien == null) return NotFound();
            return NoContent();
        }
            
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _nhanVienService.DeleteNhanVien(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
