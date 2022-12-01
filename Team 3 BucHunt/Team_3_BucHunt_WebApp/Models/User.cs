/**
* --------------------------------------------------------------------------- 
* File name: User.cs
* Project name: 404 Industries BucHunt
* --------------------------------------------------------------------------- 
* Author’s name and email: Dante Hays, haysdc@etsu.edu
* Creation Date: Oct 09, 2022
* Last modified: Dante Hays haysdc@etsu.edu Nov 10, 2022
*                Hannah Taylor taylorhm1@etsu.edu Dec 01, 2022
* --------------------------------------------------------------------------- 
*/

using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Team_3_BucHunt_WebApp.Models;

/**
* Class Name: User <br>
* Class Purpose: The data model for the Player object. This class and other model classes should really only
*           contain a reflection of what is in the corresponding table in the database and minimal constructors 
*           for an instance of the user object -- see Microsoft MVC documentation for best practices<br>
* <hr>
* Date created: Oct 09, 2022 <br>
* Date last modified: Nov 10, 2022 
* @author Dante Hays
* @author Hannah Taylor
*/
public class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNum { get; set; } = null!; //char

    [Required(ErrorMessage = "AccessCode is Required"), MaxLength(8)]
    public string AccessCode { get; set; }

    public int? HuntId { get; set; }

    public virtual Hunt? Hunt { get; set; }

    public virtual ICollection<Hunt> Hunts { get; } = new List<Hunt>();

    


    /// <summary>
    ///  Base constructor for the User class
    /// </summary> 
    public User()
    {

    }


    /// <summary>
    ///  Constructor for the User class
    /// </summary>
    /// <param name="id"></param>
    /// <param name="email"></param>
    /// <param name="phone"></param>
    /// <param name="code"></param>
    /// <param name="huntId"></param>
    public User(int id, string email, string phone, string code, int huntId)
    {
        HuntId = id;

        Email = email;

        PhoneNum = phone;

        AccessCode = code;

        HuntId = huntId;
    }

} //End public partial class User
