using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki_Model.Models.FluentModels;

public class Fluent_Author
{    
    public int Author_Id { get; set; }    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Location { get; set; }   
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
    //public List<Fluent_Book> Books { get; set; }
    public List<Fluent_BookAuthorMap> BookAuthorMap { get; set; }
}
