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
        Console.WriteLine("-----> Getting Platforms");
        IEnumerable<Platform> plat = _repository.GetAllPlatforms();
        if(plat.Any() != true ){
            return NotFound("No data exists");
        }
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(plat));

    }

    [HttpGet("{id}", Name ="GetPlatfromById")]
    public ActionResult<PlatformReadDto> GetPlatfromById(int id){
        Console.WriteLine("-------> Getting By Id");
        Platform? plat = _repository.GetPlatformById(id);
        if(plat is null){
            return NotFound("platfrom with given id not found");
        }
        return Ok(_mapper.Map<PlatformReadDto>(plat));
    }

    [HttpPost]
    public ActionResult<PlatformCreateDto> CreatePlatform(PlatformCreateDto platCreateDto){
        Platform plat = _mapper.Map<Platform>(platCreateDto);
        _repository.CreatePlatform(plat);
        _repository.SaveChanges();
        PlatformReadDto platReadDto=  _mapper.Map<PlatformReadDto>(plat);
        return CreatedAtAction(nameof(GetPlatfromById),new{Id = platReadDto.Id},platReadDto);
    }

}