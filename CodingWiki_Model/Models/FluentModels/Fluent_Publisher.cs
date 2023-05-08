namespace CodingWiki_Model.Models.FluentModels;

public class Fluent_Publisher
{
    public int Publisher_Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public List<Fluent_Book> Books { get; set; }
}