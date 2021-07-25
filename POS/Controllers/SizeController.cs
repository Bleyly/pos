using Microsoft.AspNetCore.Authorization;
using POS.Data;
using POS.Service;

namespace POS.Controllers
{
    [Authorize(Roles = "Admin")]
    public sealed class SizeController : BaseController<Size>
    {
        public SizeController(IService<Size> service) : base(service)
        {

        }
    }
}
