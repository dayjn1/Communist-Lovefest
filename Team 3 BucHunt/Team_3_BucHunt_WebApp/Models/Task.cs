/**
* --------------------------------------------------------------------------- 
* File name: Task.cs
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
* Class Name: Task <br>
* Class Purpose: The data model for the Task object <br>
* <hr>
* Date created: Oct 09, 2022 <br>
* Date last modified: Nov 10, 2022 
* @author Dante Hays
*/
public partial class Task
{
    public int TaskId { get; set; }

    public int LocationId { get; set; }

    public string? Question { get; set; }

    public string? Answer { get; set; }
} //End public partial class Task
