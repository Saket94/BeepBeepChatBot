# Project Name: Beep Beep ChatBot

This project contains the Telegram chatbot which talks with a user and provides him/her with relevant information like the weather, 
news and other interesting tidbits on any particular day, at a geographic location. 

This project is build using 1-tier architecture as mentioned below layers:-

    1.BeepBeep_ChatBot: This is the business layer that consists of the project logic.

## Project Initial Requirement:    

    1. Install the .NET Core 3 framework.

    2. Install Visual Studio 2019.

     3. To create a bot, go in your Telegram app and add @BotFather in your contact. This is the bot used to create other new bots..!
    Once you have added it, you can “chat” with the bot giving him the commands to execute to create your new bot.
    
    To create your bot: First, we have to generate a token with @BotFather to handle messages. 
        1.Login with telegram and Type @BotFather in the search area.
        2.Request for New Bot: Now, type /newbot in the message. It will ask you the name of your bot.
        3.Name of your Bot: @BotFather ask you to name your Bot, you will have to give a name to your bot.  
        4.User Name of your Bot: @BotFather ask you the user name of your Bot, we will give a user name. user name must be ending with _bot.
        5. The bot will now give you a token to use when you want to access to the Telegram API. 
    your bot is done and you can use it!
 
    4. After that, You have to add one NuGet package Telegram. Bot to use inbuilt methods.

## BeepBeep_ChatBotUnitTest Project

    1. If any error occurs while executing the unit test cases, then check the properties of the .json file which is placed inside the 
    TestCases folder of the BeepBeep_ChatBotUnitTest project.

    2. If "Copy to Output Directory" is not set to "Copy if newer" then make it "Copy if newer".

    3. In the telegram bot application when we used the unit testing then in this case the nugget which is used for the telegram bot had already done the integration testing.

    4. For that reason, we have only added the test cases to check the scenario of the response made by the chat bot using mock testing.
    (i.e by creating the replica of the actual bot response method)
    
    
## Error

If after downloading the code, the code does not execute in the visual studio then delete the ".vs"  folder and build the solution once again.

##Reference

Telegram Web https://web.telegram.org

Bots: An introduction for developers https://core.telegram.org

##Steps To Check Bot

    1. Visit the "https://web.telegram.org" url and login into your telegram application from web. You can also use the telegram application from your cellphone.

    2. After login into the telegram application. Search for the bot by the name "BeepBeepBotBot".

    3. When you find the bot you can ask the below mention things and the bot will respond according to it.
        a.When you will send "Hi" message to the bot, the bot will ask for your name and after that bot will start adderessing the user by the provided name.
        b.After provding the name , the bot should ask for the location of the person.
        c.When the user provide the location, the bot should ask for the news or weather for the given location.
        d.Now user will enter "news/weather" one by one then the bot will answer the weather of the day of the given location and top three news of the given location.
