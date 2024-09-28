
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo(AppDbContext dbContext) : IPlatfromRepo
    {
        public readonly AppDbContext _context = dbContext;

        public void CreatePlatform(Platform plat)
        {
            ArgumentNullException.ThrowIfNull(plat);
            _context.Platforms.Add(plat);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return [.. _context.Platforms];
        }

        public Platform? GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p=> p.Id == id);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}