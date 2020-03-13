using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Services
{
    public class CsvService
    {
        private readonly IMongoCollection<Csv> _csvs;

        public CsvService(ICsvstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _csvs = database.GetCollection<Csv>(settings.CsvsCollectionName);
        }

        public List<Csv> Get() =>
            _csvs.Find(csv => true).ToList();

        public Csv Get(string id) =>
            _csvs.Find<Csv>(csv => csv.Id == id).FirstOrDefault();

        public List<Csv> Get(string nome, string cidade, string uf) =>
            _csvs.Find(csv => csv.Nome == nome || csv.Cidade == cidade || csv.UF == uf ).ToList();
    }
}
