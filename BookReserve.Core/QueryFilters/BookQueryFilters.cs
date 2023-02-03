using Store.Core.Enumerations;

namespace BookReserve.Core.QueryFilters
{
    public class BookQueryFilters
    {
        public string? Title { get; set; }
        public Category? BookCategory { get; set; }
    }

}
