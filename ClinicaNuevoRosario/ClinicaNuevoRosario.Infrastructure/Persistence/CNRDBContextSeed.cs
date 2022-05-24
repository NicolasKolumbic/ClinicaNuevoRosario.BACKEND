using Microsoft.Extensions.Logging;

namespace ClinicaNuevoRosario.Infrastructure.Persistence
{
    public static class CNRDBContextSeed
    {
        /* NICO REVISAR
       /* public async static Task SeedAsync(CNRDBContext context, ILogger<CNRDBContext> logger)
        {
            if (!context.Streamers.Any())
            {
                context.Streamers.AddRange(GetStreamers());
                await context.SaveChangesAsync();
                logger.LogInformation("Add Default Records");
            }
        }

        private static IEnumerable<Streamer> GetStreamers()
        {
            return new List<Streamer>()
                {
                    new Streamer()
                    {
                        CreateDate = DateTime.Now,
                        CreatedBy = "Nicolas Kolumbic",
                        Name =  "NVK",
                        Url = "www.nvkvideo.com"
                    }
                };
        }*/
    }
}
