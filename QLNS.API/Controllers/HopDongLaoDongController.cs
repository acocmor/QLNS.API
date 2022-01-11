using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.API.Application.Interfaces;

namespace QLNS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HopDongLaoDongController : ControllerBase
    {
        private readonly IHopDongLaoDongService _hopDongLaoDongVuService;
        public HopDongLaoDongController(IHopDongLaoDongService service)
        {
            _hopDongLaoDongVuService = service;
        }
    }
}
