
namespace WebApi.Models
{
    public class CsvstoreDatabaseSettings : ICsvstoreDatabaseSettings
    {
        public string CsvsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICsvstoreDatabaseSettings
    {
        string CsvsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
