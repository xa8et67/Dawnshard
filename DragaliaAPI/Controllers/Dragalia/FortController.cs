using DragaliaAPI.Models.Generated;
using Microsoft.AspNetCore.Mvc;

namespace DragaliaAPI.Controllers.Dragalia;

[Route("fort")]
[Consumes("application/octet-stream")]
[Produces("application/octet-stream")]
[ApiController]
public class FortController : DragaliaControllerBase
{
    [Route("get_data")]
    [HttpPost]
    public async Task<DragaliaResult> FortGetData(FortGetDataRequest request)
    {
        return Ok(
            new FortGetDataData()
            {
                build_list = new List<BuildList>(),
                current_server_time = DateTimeOffset.UtcNow,
                dragon_contact_free_gift_count = 0,
                fort_bonus_list = new FortBonusList(),
                fort_detail = new FortDetail(),
                production_df = new AtgenProductionRp(),
                production_rp = new AtgenProductionRp(),
                production_st = new AtgenProductionRp()
            }
        );
    }
}
