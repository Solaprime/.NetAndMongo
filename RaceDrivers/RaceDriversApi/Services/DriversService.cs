using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RaceDriversApi.Configurations;
using RaceDriversApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceDriversApi.Services
{
    public class DriversService
    {
        //since we are working with driver here
        private readonly IMongoCollection<Driver> _driverCollections;
        public DriversService(IOptions<DataBaseSettings> dataBaseSettings)
        {
            //Create a new MongoClient
            var mongoClient = new MongoClient(dataBaseSettings.Value.ConnectionString);
            //Get the DataBase
            var mongoDatabase = mongoClient.GetDatabase(dataBaseSettings.Value.DatabaseName);
            //Get the Collection
            _driverCollections = mongoDatabase.GetCollection<Driver>(dataBaseSettings.Value.CollectionName);

        }
        public async Task<List<Driver>> GetAsync() => await _driverCollections.Find(filter => true).ToListAsync();
    //    public async Task<Driver> GetSingleAsync(string id) => await _driverCollections.Find(filter: x:Driver => x.Id == id).FirstorDefaultAsync();
        public async Task<Driver> GetSingleAsync(string id) => await _driverCollections.Find(x=> x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Driver driver) => await _driverCollections.InsertOneAsync(driver);
       // public async Task UpdateAsync(Driver driver) => await _driverCollections.UpdateOneAsync(x.Driver => x.Id == driver.Id, driver);
       //Replcaing everthing
        public async Task UpdateAsync1(Driver driver) => await _driverCollections.ReplaceOneAsync(x => x.Id == driver.Id, driver);
        public async Task RemoveAsync(string id) => await _driverCollections.DeleteOneAsync(x => x.Id == id);
    }
}
