using Microsoft.AspNetCore.Authorization;
using POS.Data;
using POS.Service;

namespace POS.Controllers
{
    [Authorize(Roles = "Admin")]
    public sealed class SupplierController : BaseController<Supplier>
    {
        public SupplierController(IService<Supplier> service) : base(service)
        {
        }
    }
}
