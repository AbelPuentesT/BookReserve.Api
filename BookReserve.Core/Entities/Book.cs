using Store.Core.Enumerations;

namespace BookReserve.Core.Entities;

public partial class Book : BaseEntity
{
    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? Description { get; set; }


    public byte[]? Image { get; set; }
    public Category? BookCategory { get; set; }
    public bool? BookReserve { get; set; }
    public int? Days { get; set; }

    public virtual ICollection<Reserve> Reserves { get; } = new List<Reserve>();
}
