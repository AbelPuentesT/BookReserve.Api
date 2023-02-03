namespace BookReserve.Core.Entities;

public partial class User : BaseEntity
{
    public string Nombre { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public int Reserves { get; set; }

    public string? UserName { get; set; }

    public virtual ICollection<Reserve> ReservesNavigation { get; } = new List<Reserve>();
}
