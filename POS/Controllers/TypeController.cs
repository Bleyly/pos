using Microsoft.AspNetCore.Authorization;
using POS.Data;
using POS.Service;

namespace POS.Controllers
{
    [Authorize(Roles = "Admin")]
    public sealed class TypeController : BaseController<Type>
    {
        public TypeController(IService<Type> service) : base(service)
        {

        }
    }
}
