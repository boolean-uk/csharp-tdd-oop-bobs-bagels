using System;

namespace exercise.main;

public class ActionMessage<T>
{
    public T ReturnValue {get; set;}
    public string Message {get; set;}

    public ActionMessage(T value, string msg)
    {
        ReturnValue = value;
        Message = msg;
    }

}
