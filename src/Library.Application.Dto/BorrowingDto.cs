namespace Library.Application.Dto
{
    public class BorrowingDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int BookPublishYear { get; set; }
        public string BookAuthor { get; set; }
        public required string BorrowingFullName { set; get; }
        public required string BorrowingNationalCode { set; get; }
        public required string BorrowingMobile { set; get; }
        public int ExtentCounter { get; set; }
        public DateTime MaximumReturnDate { get; set; }
        public bool IsReturn { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? CurrentUserFullname { get; set; }
    }
}
