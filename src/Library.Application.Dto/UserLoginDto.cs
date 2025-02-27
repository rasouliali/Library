namespace Library.Application.Dto
{
    public class UserLoginDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Tel { get; set; }
        public string? Token { get; set; }
        public string? Roles { get; set; }
        public string Password { get; set; }
        public DateTime ExpireDateTime { get; set; }
    }
}
