namespace BookReserve.Core.Entities;

public partial class Reserve : BaseEntity
{
    public int UserId { get; set; }

    public int BookId { get; set; }

    public int Days { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
