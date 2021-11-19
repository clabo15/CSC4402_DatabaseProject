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
using TestDBProj.Dictionary;
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
            if(await _context.BikeRackLocations.AnyAsync())
            {
                _context.Database.ExecuteSqlRaw("TRUNCATE TABLE testdb.bostonbikes");
                _logger.LogInformation("--- BostonBike Table Deleted --- \n");
            }
            _context.SaveChanges();
        }
        public async Task ParseModelResults()
        {
            _logger.LogInformation("--- Seeding CSVs --- \n");
            if(!await _context.BikeRackLocations.AnyAsync())
            {
                List<BikeRackLocation> bikeRackLocations = ParseBostonBikeCSV();
                await AddBikeRackLocations(bikeRackLocations);
                _logger.LogInformation("--- BikeRackLocations.csv saved --- \n");
            }
            if(!await _context.Bikes.AnyAsync())
            {
                List<Bike> bikes = ParseBikeCSV();
                await AddBikes(bikes);
                _logger.LogInformation("--- Bikes.csv saves --- \n");
            }
            if(!await _context.ModelTypes.AnyAsync())
            {
                List<ModelType> bikeModels = ParseBikeTypeCSV();
                await AddBikeTypes(bikeModels);
                _logger.LogInformation("--- BikeModelType.cs --- \n");

            }
            if(!await _context.UsersInformation.AnyAsync())
            {
                List<UserInformation> userInformation = ParseUserInformationCSV();
                await AddUserInformation(userInformation);
                _logger.LogInformation("--- UserData.cs --- \n");
            }
            if (!await _context.Bike_ModelTypes.AnyAsync())
            {
                JoinBike_ModelType();
            }
            if (!await _context.Bike_UsersInformation.AnyAsync())
            {
                JoinBike_UserInformation();
            }
            if(!await _context.Bike_BikeRackLocations.AnyAsync())
            {
                JoinBike_BikeRackLocation();
            }
            await _context.SaveChangesAsync();
        }

        public async Task AddBikeRackLocations(List<BikeRackLocation> bostonBikes)
        {
            _context.BikeRackLocations.AddRange(bostonBikes);
        }
        public async Task AddBikes(List<Bike> bikes)
        {
            _context.Bikes.AddRange(bikes);
        }
        public async Task AddBikeTypes(List<ModelType> bikeModels)
        {
            _context.ModelTypes.AddRange(bikeModels);
        }
        public async Task AddUserInformation(List<UserInformation> userInformations)
        {
            _context.UsersInformation.AddRange(userInformations);
        }

        public List<BikeRackLocation> ParseBostonBikeCSV() 
        {
            var engine = new FileHelperEngine<BikeRackLocation>();
            var result = engine.ReadFile(Path.Combine(csvDataDirectory, @"BikeRackLocations.csv")).ToList();
            return result;

        }

        public List<Bike> ParseBikeCSV()
        {
            var engine = new FileHelperEngine<Bike>();
            var result = engine.ReadFile(Path.Combine(csvDataDirectory, @"Bikes.csv")).ToList();
            return result;
        }

        public List<ModelType> ParseBikeTypeCSV()
        {
            var engine = new FileHelperEngine<ModelType>();
            var result = engine.ReadFile(Path.Combine(csvDataDirectory, @"BikeType.csv")).ToList();
            return result;
        }

        public List<UserInformation> ParseUserInformationCSV()
        {
            var engine = new FileHelperEngine<UserInformation>();
            var result = engine.ReadFile(Path.Combine(csvDataDirectory, @"UserData.csv")).ToList();
            return result;
        }

        public void JoinBike_ModelType()
        {
            var bikeTypes = _context.ModelTypes.ToList();
            var bikes = _context.Bikes.ToList();
            foreach(var bike in bikes)
            {
                var mapToBikeName = ModelTypeDictionary.mappedTypes[bike.SerialNumber];
                if(mapToBikeName != null)
                {
                    var bikeTypeEntity = bikeTypes.SingleOrDefault(bt => bt.Name.Trim().ToLower() == mapToBikeName.Trim().ToLower());
                    if(bikeTypeEntity != null)
                    {
                        _context.Bike_ModelTypes.Add(new Bike_ModelType
                        {
                            BikeId = bike.Id,
                            ModelTypeId = bikeTypeEntity.Id
                        });
                    }
                }
            }
            
            
        }

        public void JoinBike_UserInformation()
        {
            var userInformation = _context.UsersInformation.ToList();
            var bikes = _context.Bikes.ToList();
            for(int index = 0; index < bikes.Count; index++)
            {
                _context.Bike_UsersInformation.Add(new Bike_UserInformation
                {
                    UserInformationId = userInformation[index].Id,
                    BikeId = bikes[index].Id
                });
            }
        }

        public void JoinBike_BikeRackLocation()
        {
            var bikeRackLocation = _context.BikeRackLocations.ToList();
            var bikes = _context.Bikes.ToList();
            Random randomLocationIndex = new Random();
            for(int index = 0; index < bikeRackLocation.Count; index++)
            {
                _context.Bike_BikeRackLocations.Add(new Bike_BikeRackLocation
                {
                    BikeRackLocationId = bikeRackLocation[index].Id,
                    BikeId = bikes[index].Id
                });
                if(index > bikeRackLocation.Count)
                {
                    int randomIndex = randomLocationIndex.Next(0, bikeRackLocation.Count - 1);
                    _context.Bike_BikeRackLocations.Add(new Bike_BikeRackLocation
                    {
                        BikeRackLocationId = bikeRackLocation[randomIndex].Id,
                        BikeId = bikes[index].Id
                    });
                }
            }
        }
    }
}
