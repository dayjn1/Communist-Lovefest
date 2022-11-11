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

    SqlCommand command;
    SqlDataReader dataReader;
    String sql = "";
    string connectionString = " ";

    public List<Task> tasksList = new List<Task>();

    /// <summary>
    ///  Establishes connection to the database
    ///  Generates a list of Tasks from the tasks stored on the database.
    /// </summary>
    public void OpenDB()
    {
        connectionString = @"Server=FALL22-4250-1-3; Database=BucHunt; User Id=dbaccess; Password=Password1!";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            sql = "SELECT * FROM [BucHunt].[dbo].[Tasks]";
            command = new SqlCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Task task = new Task(dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetString(2), dataReader.GetString(3));
                tasksList.Add(task);
            }
        }
    }

    /// <summary>
    /// Base constructor for Task class
    /// </summary>
    public Task()
    {

    }


    /// <summary>
    ///  Constructor for the Task class
    /// </summary>
    /// <param name="taskId"></param>
    /// <param name="locationId"></param>
    /// <param name="question"></param>
    /// <param name="answer"></param>
    public Task(int taskId, int locationId, string? question, string? answer)
    {
        TaskId = taskId;
        LocationId = locationId;
        Question = question;
        Answer = answer;
    }
}  //End public partial class Task
