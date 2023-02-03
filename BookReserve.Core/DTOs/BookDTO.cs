using Store.Core.Enumerations;

namespace BookReserve.Core.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string? Description { get; set; }

        public byte[]? Image { get; set; }
        public Category? BookCategory { get; set; }
        public bool? BookReserve { get; set; }
        public int? Days { get; set; }


    }
}
