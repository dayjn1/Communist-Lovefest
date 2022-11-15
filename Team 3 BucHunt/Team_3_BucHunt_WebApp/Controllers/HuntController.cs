/**
* --------------------------------------------------------------------------- 
* File name: HuntController.cs
* Project name: 404 Industries BucHunt
* --------------------------------------------------------------------------- 
* Author’s name and email: Dante Hays, haysdc@etsu.edu
* Creation Date: Nov 01, 2022
* Last modified: Dante Hays haysdc@etsu.edu Nov 02, 2022
* --------------------------------------------------------------------------- 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Team_3_BucHunt_WebApp.Controllers;

/**
* Class Name: HuntController <br>
* Class Purpose: Holds the logic for the Hunt page<br>
* <hr>
* Date created: Oct 27, 2022 <br>
* Date last modified: Nov 02, 2022 
* @author Dante Hays
*/

public class HuntController : Controller
{
    /**
    * Method Name: Index <br>
    * Method Purpose: Returns the view of the Hunt page <br>
    * <hr>
    * Date created: Oct 27, 2022 <br>
    * Date last modified: Nov 03, 2022 <br>
    * <hr>
    * Notes on specifications, special algorithms, and assumptions: N/A
    * <hr> 
    * @returns View()
    */

    public IActionResult Index()
    {
        return View();
    } //End public IActionResult Index()

} //End public class HuntController : Controller


