/**
* --------------------------------------------------------------------------- 
* File name: ErrorViewModel.cs
* Project name: 404 Industries BucHunt
* --------------------------------------------------------------------------- 
* Author’s name and email: Dante Hays, haysdc@etsu.edu
* Creation Date: Oct 27, 2022
* Last modified: Dante Hays haysdc@etsu.edu Oct 27, 2022
* --------------------------------------------------------------------------- 
*/

namespace Team_3_BucHunt_WebApp.Models;

/**
* Class Name: ErrorViewModel <br>
* Class Purpose: <br>
* <hr>
* Date created: Oct 27, 2022 <br>
* Date last modified: Nov 02, 2022 
* @author Dante Hays
*/
public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

