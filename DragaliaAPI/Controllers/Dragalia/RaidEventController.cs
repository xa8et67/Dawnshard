using DragaliaAPI.Models.Generated;
using MessagePack;
using Microsoft.AspNetCore.Mvc;

namespace DragaliaAPI.Controllers.Dragalia;

[Route("raid_event")]
[Consumes("application/octet-stream")]
[Produces("application/octet-stream")]
[ApiController]
public class RaidEventController : ControllerBase
{
    [HttpPost]
    [Route("get_event_data")]
    public DragaliaResult GetEventData()
    {
        return Ok(new RaidEventEntryData());
    }
}
