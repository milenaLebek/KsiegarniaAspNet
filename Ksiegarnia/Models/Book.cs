using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ksiegarnia.Models;

public class Book
{
    [Key]
    public int Id {get; set;}
    
    [Required]
    [StringLength(100)]
    public string Title {get; set;}
    
    [Required]
    public int AuthorId {get; set;}
    [ForeignKey(nameof(AuthorId))]
    public Author Author {get; set;}
    
    [Required]
    [StringLength(13)]
    public string ISBN {get; set;}
    
    [Required]
    [Range(0.01, 1000.00)]
    public decimal Price {get; set;}
    
    [StringLength(500)]
    public string Description {get; set;}
    
    [Required]
    public int GenreId {get; set;}
    [ForeignKey(nameof(GenreId))]
    public Genre Genre {get; set;}
    
    [Range(0, 3000)]
    public int PublicationYear {get; set;}
}