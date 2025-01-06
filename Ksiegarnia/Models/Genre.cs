using System.ComponentModel.DataAnnotations;

namespace Ksiegarnia.Models;

public class Genre
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    public ICollection<Book> Books { get; set; }
}