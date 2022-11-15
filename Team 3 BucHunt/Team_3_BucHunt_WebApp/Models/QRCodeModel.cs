using System.ComponentModel.DataAnnotations;

namespace Team_3_BucHunt_WebApp.Models
{
    public class QRCodeModel
    {
        [Display(Name = "Enter QRCode Text")]
        public string QRCodeText { get; set; }
    }
}
