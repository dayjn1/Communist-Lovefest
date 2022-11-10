/**
* --------------------------------------------------------------------------- 
* File name: User.cs
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
* Class Name: User <br>
* Class Purpose: The data model for the Player object<br>
* <hr>
* Date created: Oct 09, 2022 <br>
* Date last modified: Nov 10, 2022 
* @author Dante Hays
*/
public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNum { get; set; } = null!;

    public string? AccessCode { get; set; }

    public int? HuntId { get; set; }

    public virtual Hunt? Hunt { get; set; }

    public virtual ICollection<Hunt> Hunts { get; } = new List<Hunt>();
} //End public partial class User