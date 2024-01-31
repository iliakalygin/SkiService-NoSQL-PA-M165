namespace WebApi.Models
{
    public class SkiServiceManagementDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string OrdersCollectionName { get; set; } = null!;
    }
}
