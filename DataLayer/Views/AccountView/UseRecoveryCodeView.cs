using System.ComponentModel.DataAnnotations;

namespace DataLayer.AccountView
{
    public class UseRecoveryCodeView
    {
        [Required]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }
    }
}
