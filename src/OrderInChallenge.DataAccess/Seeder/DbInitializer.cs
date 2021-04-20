using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderInChallenge.DataAccess.Entities;
using OrderInChallenge.DataAccess.Seeder.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OrderInChallenge.DataAccess.Seeder
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ILogger<DbInitializer> logger;
        private readonly AppDbContext appDbContext;
        private readonly string filePath;
        private readonly IEnumerable<Restaurant> _resturantsList;

        public DbInitializer(
            ILogger<DbInitializer> logger,
            AppDbContext dbContext)
        {
            this.logger = logger;
            this.appDbContext = dbContext;
            this.filePath = Path.Combine(AppContext.BaseDirectory, $"Input{Path.DirectorySeparatorChar}SampleData.json");
            if (!File.Exists(this.filePath))
            {
                throw new InvalidOperationException("Input data file doesn't exists");
            }
            else
            {
                using StreamReader r = new StreamReader(this.filePath);
                string json = r.ReadToEnd();
                _resturantsList = JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(json);
            }
        }

        public async Task InitializeAsync(CancellationToken cancellationToken = default)
        {
            this.logger.LogInformation("Seeding from {file}", this.filePath);
            //TODO: Investigate how to bulk insert
            if (this.appDbContext.Restaurants.EstimatedDocumentCount() == 0)
            {
                await this.appDbContext.Restaurants.InsertManyAsync(_resturantsList, cancellationToken: cancellationToken);
            }
        }
    }
}
