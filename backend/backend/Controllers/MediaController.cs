using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/media")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly MediaAPIDbContext dbContext;

        public MediaController(MediaAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetMedia(bool? filter_date, string? media_type)
        {
         
            if (filter_date == true && !string.IsNullOrEmpty(media_type))
            {
                var medias = dbContext.Medias.Where(m => m.type.Equals(media_type));
                return Ok(await medias.OrderByDescending(m => m.date).ToListAsync());
            }
            if (filter_date == true)
            {
                return Ok(await dbContext.Medias.OrderByDescending(m => m.date).ToListAsync());
            }
            if (!String.IsNullOrEmpty(media_type))
            {
                return Ok(await dbContext.Medias.Where(m => m.type.Equals(media_type)).ToListAsync());
            }
            return Ok(await dbContext.Medias.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddMedia(AddMediaRequest addMediaRequest)
        {
            var media = new Media()
            {
                Id = Guid.NewGuid(),
                location = addMediaRequest.location,
                type = addMediaRequest.type,
                date = addMediaRequest.date,
            };
            await dbContext.Medias.AddAsync(media);
            await dbContext.SaveChangesAsync();

            return Ok(media);
        }
    }
}
