using Microsoft.AspNetCore.Http;

namespace Demo.BackendApi.Controllers
{
    public class ImageCreateRequest
    {
        public IFormFile ImageFile { get; set; }
    }
}