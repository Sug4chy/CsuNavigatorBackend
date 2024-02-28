using CsuNavigatorBackend.Api.Requests.Maps;
using CsuNavigatorBackend.Api.Responses.Maps;
using CsuNavigatorBackend.Api.Validators.Maps;
using CsuNavigatorBackend.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

namespace CsuNavigatorBackend.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MapsController(
        IMapService mapService,
        IOrganizationService organizationService) : ControllerBase
    {
        [HttpPost]
        public async Task<CreateMapResponse> CreateMap(
            [FromBody] CreateMapRequest request, 
            [FromServices] CreateMapRequestValidator validator,
            CancellationToken ct = default)
        {
            var validationResult = await validator.ValidateAsync(request, ct);
            if (!validationResult.IsValid)
            {
                throw new Exception();
            }

            var organization = await organizationService
                .GetOrganizationByNameAsync(request.OrganizationName, ct);
            if (organization is null)
            {
                throw new Exception();
            }

            await mapService.CreateMapAsync(request.Map, organization, ct);
            return new CreateMapResponse();
        }
    }
}
