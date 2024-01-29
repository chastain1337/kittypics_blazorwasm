using KittyPics.Shared;
using KittyPics.Shared.Data;
using Microsoft.AspNetCore.Mvc;

namespace KittyPics.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PicsController : ControllerBase
{
    private readonly IPicsRepository _picsRepository;

    public PicsController(IPicsRepository picsRepository)
    {
        _picsRepository = picsRepository;
    }
    
    [HttpGet("GetRandomPics")]
    public IEnumerable<Pic> GetRandomPics([FromQuery] int count)
    {
        return _picsRepository.GetRandomPics(count);
    }

    [HttpGet("Vote")]
    public void Vote([FromQuery] int picId)
    {
        _picsRepository.Vote(picId);
    }
}