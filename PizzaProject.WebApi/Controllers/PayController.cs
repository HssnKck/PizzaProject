using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.WebApi.Dto;

namespace PizzaProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        [HttpPost("GetPaid")]
        public bool Pay(Payment pay)
        {
            return true;
        }
    }
}

