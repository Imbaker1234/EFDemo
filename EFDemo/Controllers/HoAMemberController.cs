namespace EFDemo.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    public class HoAMemberController : ControllerBase
    {
        public HoAMemberService Service { get; set; }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HoAMember member)
        {
            var product = await Service.Create(member);
            return Created(Request.GetDisplayUrl(), product);
        }

        [HttpGet("{cookiemonster}")]
        public async Task<IActionResult> Read([FromRoute] string cookiemonster)
        {
            var product = await Service.Read(cookiemonster);

            return Ok(product);
        }
    }
}
