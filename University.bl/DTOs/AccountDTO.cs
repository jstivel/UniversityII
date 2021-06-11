namespace University.BL.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class ProfileDTO
    {
        public string UserID { get; set; }
        public string Image { get; set; }
        public string Ext { get; set; }
    }
}
