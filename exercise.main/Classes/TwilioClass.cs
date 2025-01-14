using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using exercise.main.Classes;

class TwilioClass
{
    private readonly string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID") ?? "";
    private readonly string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN") ?? "";
    private readonly string messagingServiceSid = Environment.GetEnvironmentVariable("TWILIO_MESSAGING_SERVICE_SID") ?? "";

    private List<string> messageHistory = new List<string>();

    public TwilioClass()
    {
        if (string.IsNullOrEmpty(accountSid))
        {
            Console.WriteLine("Error: Twilio Account SID is missing or incorrect.");
        }
        else
        {
            Console.WriteLine($"Twilio Account SID fetched successfully.");
        }

        if (string.IsNullOrEmpty(authToken))
        {
            Console.WriteLine("Error: Twilio Auth Token is missing or incorrect.");
        }
        else
        {
            Console.WriteLine($"Twilio Auth Token fetched successfully.");
        }

        if (string.IsNullOrEmpty(messagingServiceSid))
        {
            Console.WriteLine("Error: Twilio Messaging Service SID is missing or incorrect.");
        }
        else
        {
            Console.WriteLine($"Twilio Messaging Service SID fetched successfully.");
        }

        if (string.IsNullOrEmpty(accountSid) || string.IsNullOrEmpty(authToken) || string.IsNullOrEmpty(messagingServiceSid))
        {
            Console.WriteLine("Error: Missing one or more required Twilio credentials. Initialization aborted.");
            return;
        }

        TwilioClient.Init(accountSid, authToken);
    }

    public void SendMessage(string toPhoneNumber, string messageBody)
    {
        var messageOptions = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
        {
            MessagingServiceSid = messagingServiceSid,
            Body = messageBody
        };

        var message = MessageResource.Create(messageOptions);
        Console.WriteLine($"Sent message: {message.Body}");
        messageHistory.Add(message.Body);
    }

    public void SendOrderConfirmation(string toPhoneNumber, Order order)
    {
        string orderSummary = order.OrderToSms();
        SendMessage(toPhoneNumber, orderSummary);
    }
}
