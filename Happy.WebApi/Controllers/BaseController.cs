using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Happy.WebApi.Controllers;

[Authorize]
[ApiVersion(GlobalSettings.API_VERSION)]
[ApiController]
public class BaseController : ControllerBase
{

}
