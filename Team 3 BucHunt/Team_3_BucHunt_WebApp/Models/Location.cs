/**
* --------------------------------------------------------------------------- 
* File name: Location.cs
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
* Class Name: Location <br>
* Class Purpose: The data model for the Location object<br>
* <hr>
* Date created: Oct 09, 2022 <br>
* Date last modified: Nov 10, 2022 
* @author Dante Hays
*/
public partial class Location
{
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public double? Long { get; set; }

    public double? Lat { get; set; }

    public virtual ICollection<Hunt> Hunts { get; } = new List<Hunt>();
} //End public partial class Location
