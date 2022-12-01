/**
* --------------------------------------------------------------------------- 
* File name: QRController.cs
* Project name: 404 Industries BucHunt
* --------------------------------------------------------------------------- 
* Author’s name and email: Janine Day, dayjn1@etsu.edu
* Creation Date: Nov 16, 2022
* Last modified: Janine Day, dayjn1@etsu.edu, Nov 17, 2022
* --------------------------------------------------------------------------- 
*/

using Microsoft.AspNetCore.Mvc;
using Team_3_BucHunt_WebApp.Models;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Team_3_BucHunt_WebApp.Controllers
{
    /**
    * Class Name: QRController
    * Class Purpose: Holds the logic for the QR page<br>
    * <hr>
    * Date created: Nov 16, 2022
    * Date last modified: Nov 17, 2022 
    * @author Janine Day
    */
    public class QRController : Controller
    {
        /**
        * Method Name: CreateQRCode() <br>
        * Method Purpose: Returns the view of the QR page <br>
        * <hr>
        * Date created: Nov 16, 2022 <br>
        * Date last modified: Nov 17, 2022 <br>
        * <hr>
        * Notes on specifications, special algorithms, and assumptions: N/A
        * <hr> 
        * @returns View()
        */
        [HttpGet]
        public IActionResult CreateQRCode()
        {
            return View();
        }//end CreateQRCode()

        /**
        * Method Name: CreateQRCode(QRCodeModel) <br>
        * Method Purpose: Returns the view of the QR page with the QR code picture based on text <br>
        * <hr>
        * Date created: Oct 27, 2022 <br>
        * Date last modified: Nov 03, 2022 <br>
        * <hr>
        * Notes on specifications, special algorithms, and assumptions: N/A
        * <hr> 
        * @returns View()
        */
        [HttpPost]
        public IActionResult CreateQRCode(QRCodeModel qRCode)
        {
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(qRCode.QRCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode QrCode = new QRCode(QrCodeInfo);
            Bitmap QrBitmap = QrCode.GetGraphic(60);
            byte[] BitmapArray = QrBitmap.BitmapToByteArray();
            string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
            ViewBag.QrCodeUri = QrUri;
            return View();
        }//end CreateQRCode(QRCodeModel)
    }//end QRController

    /**
    * Class Name: BitmapExtension
    * Class Purpose: Extension method to convert Bitmap to Byte Array <br>
    * <hr>
    * Date created: Nov 16, 2022
    * Date last modified: Nov 17, 2022 
    * @author Janine Day
    */
    public static class BitmapExtension
    {
        /**
        * Method Name: BitmapToByteArray(Bitmap) <br>
        * Method Purpose: Bitmap to Byte Array <br>
        * <hr>
        * Date created: Nov 16, 2022 <br>
        * Date last modified: Nov 17, 2022 <br>
        * <hr>
        * Notes on specifications, special algorithms, and assumptions: N/A
        * <hr> 
        * @returns byte[] conversion 
        */
        public static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }//end using
        }//end BitmapToByteArray(Bitmap)
        
    }//end BitmapExtension
}//end Team_3_BucHunt_WebApp.Controllers