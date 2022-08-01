namespace Domain.Models {

    public class PaginatedObject<T> where T : class {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageObjects { get; set; }
        public IEnumerable<T> Data { get; set; }
    }

}