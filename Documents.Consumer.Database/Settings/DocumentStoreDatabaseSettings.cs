namespace Documents.Consumer.Database.Settings
{
    public class DocumentStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string DocumentCollectionName { get; set; } = null!;
    }
}
