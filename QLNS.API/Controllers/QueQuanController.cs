using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.API.Application.Interfaces;

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
    }
}
