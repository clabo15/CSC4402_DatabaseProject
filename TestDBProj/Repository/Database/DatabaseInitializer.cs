using FileHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBProj.Models;

namespace TestDBProj.Repository.Database
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }

    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public string csvDataDirectory = Environment.CurrentDirectory + @"\CSV\";


        public DatabaseInitializer(ApplicationDbContext context, ILogger<DatabaseInitializer> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false); 
            _logger.LogInformation("--- Parsing Files --- \n");

            //DeleteData();

            await SeedCSVData();

            _context.SaveChanges();
        }
        
        public async Task SeedCSVData()
        {
            await ParseModelResults();

            await _context.SaveChangesAsync();
        }
        public async Task DeleteData()
        {
            if(await _context.BostonBikes.AnyAsync())
            {
                _context.Database.ExecuteSqlRaw("TRUNCATE TABLE testdb.bostonbikes");
                _logger.LogInformation("--- BostonBike Table Deleted --- \n");
            }
            _context.SaveChanges();
        }
        public async Task ParseModelResults()
        {
            _logger.LogInformation("--- Seeding CSVs --- \n");
            if(!await _context.BostonBikes.AnyAsync())
            {
                List<BostonBike> bostonBikes = ParseBostonBikeCSV();
                await AddBostonBikeCSV(bostonBikes);
                _logger.LogInformation("--- boston.csv saved --- \n");
            }
            await _context.SaveChangesAsync();
        }

        public async Task AddBostonBikeCSV(List<BostonBike> bostonBikes)
        {
            _context.BostonBikes.BulkInsert(bostonBikes);
        }

        public List<BostonBike> ParseBostonBikeCSV() 
        {
            var engine = new FileHelperEngine<BostonBike>();
            var result = engine.ReadFile(Path.Combine(csvDataDirectory, @"boston.csv")).ToList();
            return result;

        }
    }
}
