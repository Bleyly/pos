using Microsoft.AspNetCore.Authorization;
using POS.Data;
using POS.Service;

namespace POS.Controllers
{
    [Authorize(Roles = "Admin")]
    public sealed class ColorController : BaseController<Color>
    {
        public ColorController(IService<Color> service) : base(service)
        {
        }
    }
}
