/**
* --------------------------------------------------------------------------- 
* File name: QRCodeModel.cs
* Project name: 404 Industries BucHunt
* --------------------------------------------------------------------------- 
* Author’s name and email: Janine Day, dayjn1@etsu.edu
* Creation Date: Nov 16, 2022
* Last modified: Janine Day, dayjn1@etsu.edu, Nov 17, 2022
* --------------------------------------------------------------------------- 
*/

using System.ComponentModel.DataAnnotations;

namespace Team_3_BucHunt_WebApp.Models
{
    /**
    * Class Name: QRCodeModel <br>
    * Class Purpose: The data model for the QR object<br>
    * <hr>
    * Date created: Nov 16, 2022 <br>
    * Date last modified: Nov 17, 2022 
    * @author Janine Day
    */
    public class QRCodeModel
    {
        [Key]
        [Display(Name = "Enter QRCode Text")]
        public string QRCodeText { get; set; }
    }//end QRCodeModel
}//end Team_3_BucHunt_WebApp.Models
