using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    public readonly IPlatfromRepo _repository;
    public readonly IMapper _mapper;
    public PlatformsController(IPlatfromRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms(){
        Console.WriteLine("");
        IEnumerable<Platform> plat = _repository.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(plat));

    }
}