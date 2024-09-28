using PlatformService.Models;

namespace PlatformService.Data;

public interface IPlatfromRepo
{
    bool SaveChanges();

    IEnumerable<Platform> GetAllPlatforms();
    Platform? GetPlatformById(int id);

    void CreatePlatform(Platform plat);

    
}