namespace Library.UI.Helpers
{
    public class APIMethodUrls
    {
        public static string JsonContent { get; private set; } = "application/json";
        public static string SelectedBook { get; private set; } = "SelectedBook";
        public static string Book { get; private set; } = "Book";
        public static string RemainBooks { get; private set; } = "Book/GetRemainBooks";
        public static string NotReturnedBooksQuery { get; private set; } = "Book/GetNotReturnedBooksQuery";
        public static string FiltersBooksQuery { get; private set; } = "Book/GetFiltersBooksQuery";
        public static string BorrowingBooksQuery { get; private set; } = "Book/GetBorrowingBooksQuery";
        public static string GetBookById { get; private set; } = "GetById";
        public static string Borrowing { get; private set; } = "Borrowing";
        public static string SignUp { get; private set; } = "UserManager/Register";
        public static string Login { get; private set; } = "UserManager/Login";
        public static string Logout { get; private set; } = "UserManager/Logout";
    }
}
