using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace FibonacciApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        [HttpGet("{sequenceNumber}")]
        public async Task<ActionResult<int>> Get(int sequenceNumber) =>
            await sequenceNumber.GetNumberInSequenceAsync();
    }
}
