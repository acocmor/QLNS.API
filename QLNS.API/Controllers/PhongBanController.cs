using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.API.Application.DTOs.PhongBan;
using QLNS.API.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongBanController : ControllerBase
    {
        private readonly IPhongBanService _phongBanService;
        public PhongBanController(IPhongBanService service)
        {
            _phongBanService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPhongBanDTO>>> GetAllChucVu()
        {
            return Ok(await _phongBanService.GetAllPhongBans());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetPhongBanDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetPhongBanDTO>> GetChucVuById(Guid id)
        {
            var result = await _phongBanService.GetNhanPhongBanId(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GetPhongBanDTO>> Create([FromBody] CreatePhongBanDTO request)
        {
            var newChucVu = await _phongBanService.CreatePhongBan(request);
            return CreatedAtAction(nameof(GetChucVuById), new { id = newChucVu.Id }, newChucVu);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetPhongBanDTO>> Update(Guid id, [FromBody] UpdatePhongBanDTO request)
        {
            var updateChucVu = await _phongBanService.UpdatePhongBan(id, request);
            if (updateChucVu == null) return NotFound();
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _phongBanService.DeletePhongBan(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
