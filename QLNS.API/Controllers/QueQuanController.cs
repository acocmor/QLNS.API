using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.API.Application.DTOs.QueQuan;
using QLNS.API.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueQuanController : ControllerBase
    {
        private readonly IQueQuanService _queQuanService;
        public QueQuanController(IQueQuanService service)
        {
            _queQuanService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetQueQuanDTO>>> GetAllQueQuans()
        {
            return Ok(await _queQuanService.GetAllQueQuans());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetQueQuanDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetQueQuanDTO>> GetQueQuanById(Guid id)
        {
            var result = await _queQuanService.GetQueQuanById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GetQueQuanDTO>> Create([FromBody] CreateQueQuanDTO request)
        {
            var newQueQuan = await _queQuanService.CreateQueQuan(request);
            return CreatedAtAction(nameof(GetQueQuanById), new { id = newQueQuan.Id }, newQueQuan);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetQueQuanDTO>> Update(Guid id, [FromBody] UpdateQueQuanDTO request)
        {
            var update = await _queQuanService.UpdateQueQuan(id, request);
            if (update == null) return NotFound();
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _queQuanService.DeleteQueQuan(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
