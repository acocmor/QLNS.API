using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.API.Application.DTOs.NhanVien;
using QLNS.API.Application.Interfaces;
using System;
using System.Collections.Generic;
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
            var newNhanVien = await _nhanVienService.CreateNhanVien(request);
            return CreatedAtAction(nameof(GetNhanVienById), new { id = newNhanVien.Id }, newNhanVien);
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
