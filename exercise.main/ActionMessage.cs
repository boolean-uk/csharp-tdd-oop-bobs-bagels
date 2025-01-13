using System;

namespace exercise.main;

public class ActionMessage
{
    public bool Success {get; set;}
    public string Message {get; set;}

    public ActionMessage(bool success, string msg)
    {
        Success = success;
        Message = msg;
    }

}
