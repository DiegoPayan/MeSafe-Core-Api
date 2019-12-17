namespace Backend.Models
{

  public class MeSafeDatabaseSettings : IMeSafeDatabaseSettings
  {
    public string UsersCollectionName { get; set; }
    public string ReportsCollectionName { get; set; }
    public string RolesCollectionName { get; set; }
    public string ReportTypesCollectionName { get; set; }
    public string ReportsImagesCollectionName { get; set; }
    public string CentrosAyudaCollectionName { get; set; }
    public string ConsejosCollectionName { get; set; }
    public string ConocidosCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }

  public interface IMeSafeDatabaseSettings
  {
    string UsersCollectionName { get; set; }
    string ReportsCollectionName { get; set; }
    string RolesCollectionName { get; set; }
    string ReportTypesCollectionName { get; set; }
    string ReportsImagesCollectionName { get; set; }
    string CentrosAyudaCollectionName { get; set; }
    string ConsejosCollectionName { get; set; }
    string ConocidosCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }

}