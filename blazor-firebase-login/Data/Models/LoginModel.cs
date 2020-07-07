
using System.ComponentModel.DataAnnotations;

namespace blazor_firebase_login.Data.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "ユーザIDを入力してください。")]
        [StringLength(32, ErrorMessage = "ユーザIDが長すぎます。")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "パスワードを入力してください。")]
        [StringLength(32, ErrorMessage = "パスワードが長すぎます。")]
        public string Password { get; set; }
    }
}