
namespace ToDoApi.Models
{
    public class MyDBSetting
    {
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ToDoCollectionName { get; set; } = null!;
    }
}