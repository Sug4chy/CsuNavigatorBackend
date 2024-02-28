using CsuNavigatorBackend.Api.Requests.Maps;
using CsuNavigatorBackend.Api.Validators.Maps;
using Microsoft.AspNetCore.Mvc;

namespace CsuNavigatorBackend.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MapsController : ControllerBase
    {
        [HttpPost]
        public async Task CreateMap([FromBody] CreateMapRequest request, [FromServices] CreateMapRequestValidator validator)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new Exception();
            }
        }
    }
}
