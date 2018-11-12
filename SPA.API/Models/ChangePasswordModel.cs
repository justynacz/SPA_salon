namespace SPA.API.Models
{
    public class ChangePasswordModel
    {
        public int LoginId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordRepeat { get; set; }
    }
}
