using System.ComponentModel.DataAnnotations;

namespace Ksiegarnia.Models;

public class Author
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    public ICollection<Book> Books { get; set; }
}