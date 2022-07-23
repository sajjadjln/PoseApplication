﻿using PoseLibrary;
using PoseLibrary.DataAccess;
using PoseLibrary.DataAccess.TextHelpers;
using PoseLibrary.Models;
using PosePassword;

Console.WriteLine("Welcome to password application");
Console.WriteLine("please enter the number of your desire option(1 or 2)\n");
Console.WriteLine("1.Creat a new card\n2.choose a saved card and generate password");
int FirstUserInput = 0;

try
{
     FirstUserInput = Convert.ToInt32(Console.ReadLine());
     Console.Clear();
}
catch (FormatException)
{
    Console.Write("wrong number!");
}

switch (FirstUserInput)
{
    case 1://creat new card

       var convertedCardType = CardInput.CardInputInfo();
       TextConnection CardtextFile = new TextConnection();
        CardtextFile.CreatCard(convertedCardType);
        break;

    case 2:// show the list of cards
           // how to access field CardFile in TextConnection class

        var Cardshow = new ShowListCard();
        Cardshow.ShowInfo();
        password();
        break;
    default:
        Console.WriteLine("Your number is out of reach");
        break;
}

 void password() 
{

     Random generator = new Random();
     String r = generator.Next(0, 1000000).ToString("D6");
     Console.WriteLine($"this is your password : {r}");
     TextConnection PasswordtextFile = new TextConnection();
     ConvertToPassword password = new ConvertToPassword(r);
     PasswordtextFile.CreatPassword(password);
     
}
