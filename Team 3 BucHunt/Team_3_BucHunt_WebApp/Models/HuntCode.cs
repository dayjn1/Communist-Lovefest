/**
* --------------------------------------------------------------------------- 
* File name: HuntCode.cs
* Project name: 404 Industries BucHunt
* --------------------------------------------------------------------------- 
* Author’s name and email: Dante Hays, haysdc@etsu.edu
* Creation Date: Oct 09, 2022
* Last modified: Dante Hays haysdc@etsu.edu Nov 10, 2022
* --------------------------------------------------------------------------- 
*/

using System;
using System.Collections.Generic;

namespace Team_3_BucHunt_WebApp.Models;

/**
* Class Name: HuntCode <br>
* Class Purpose: The data model for the Hunt object<br>
* <hr>
* Date created: Oct 09, 2022 <br>
* Date last modified: Nov 10, 2022 
* @author Dante Hays
*/
public partial class HuntCode
{
    public int HuntId { get; set; }

    public string Code { get; set; } = null!;

    public int? UseCount { get; set; }

    public int? MaxCount { get; set; }

    public virtual Hunt Hunt { get; set; } = null!;
} //End public partial class HuntCode
