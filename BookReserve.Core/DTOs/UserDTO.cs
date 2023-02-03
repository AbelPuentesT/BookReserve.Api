namespace BookReserve.Core.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public byte[]? Photo { get; set; }

        public int Reserves { get; set; }

        public string? UserName { get; set; }
    }
}
