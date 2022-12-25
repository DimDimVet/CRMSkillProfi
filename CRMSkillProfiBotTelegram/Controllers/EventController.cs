using CRMSkillProfiBotTelegram.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRMSkillProfiBotTelegram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        public EventController()
        {

        }

        [HttpPost]
        public async Task<ActionResult<Messange>> PostNewEvent(Messange _event)
        {
            if (_event == null)
            {
                return BadRequest();
            }
           await LogicBot.EventMessange(_event);
            return Ok(_event);
        }
    }
}
