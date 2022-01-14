using System.Collections.Generic;
using System.Net;

namespace QLNS.API.Application.DTOs.Error
{
    public class ErrorRespone
    {
        public HttpStatusCode HttpStatus { get; set; }
        public List<Error> Errors { get; set; }

        public ErrorRespone()
        {
            Errors = new List<Error>();
        }
    }
}
