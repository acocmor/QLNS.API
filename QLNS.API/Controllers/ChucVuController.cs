using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.API.Application.DTOs;
using QLNS.API.Application.DTOs.ChucVu;
using QLNS.API.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuService _chucVuService;
        public ChucVuController(IChucVuService service)
        {
            _chucVuService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetChucVuDTO>>> GetAllChucVu()
        {
            return Ok(await _chucVuService.GetAllChucVus());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetChucVuDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetChucVuDTO>> GetChucVuById(Guid id)
        {
            var result = await _chucVuService.GetChucVuById(id);
            if(result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GetChucVuDTO>> Create([FromBody] CreateChucVuDTO request)
        {
            var newChucVu = await _chucVuService.CreateChucVu(request);
            return CreatedAtAction(nameof(GetChucVuById), new { id = newChucVu.Id }, newChucVu);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetChucVuDTO>> Update(Guid id, [FromBody] UpdateChucVuDTO request)
        {
            var updateChucVu = await _chucVuService.UpdateChucVu(id, request);
            if (updateChucVu == null) return NotFound();
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _chucVuService.DeleteChucVu(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
