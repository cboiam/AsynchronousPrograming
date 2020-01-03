using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace FibonacciApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult> Get() 
        {
            await Task.Delay(2000);
            return Ok();
        }

        [HttpGet("{sequenceNumber}")]
        public async Task<ActionResult<int>> Get(int sequenceNumber) =>
            await sequenceNumber.GetNumberInSequenceAsync();
    }
}
