using MongoDB.Driver;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApi.Models;
using System.Text;

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

        public void Create(Csv csv)
        {
            _csvs.InsertOne(csv);
        }

        public void SetCsv()
        {
            StreamReader stream = new StreamReader(@"C:\Users\PC\Documents\Import.csv", Encoding.ASCII);
            string line = null;

            while ((line = stream.ReadLine()) != null) 
            {
                var array = line.Split(";");

                if (array[0].Equals("Nome"))
                    continue;

                var a = new Csv
                {
                    Nome = array[0],
                    Cidade = array[1],
                    UF = array[2]
                };

                this.Create(a);
            }

            stream.Close();
        }
    }
}
