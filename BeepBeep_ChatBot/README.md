# Project Name: Beep Beep ChatBot

This project contains the Telegram chatbot which talks with a user and provides him/her with relevant information like the weather, 
news and other interesting tidbits on any particular day, at a geographic location. 

This project is build using 1-tier architecture as mentioned below layer:-

    1.BeepBeep_ChatBot: This is the business layer that consists of the project logic.

## Project Initial Requirement:    

    1. Install the .NET Core 3 framework.

    2. Install Visual Studio 2019.

    3. To create a bot, go in your Telegram app and add @BotFather in your contact. This is the bot used to create 
       other new bots. Once you have added it, you can “chat” with the bot giving him the commands to execute 
       to create your new bot.
    
       To create your bot: First, we have to generate a token with @BotFather to handle messages. 
         1.Login with telegram and Type @BotFather in the search area.
         2.Request for New Bot: Now, type /newbot in the message. It will ask you the name of your bot.
         3.Name of your Bot: @BotFather ask you to name your Bot, you will have to give a name to your bot.  
         4.User Name of your Bot: @BotFather ask you the user name of your Bot, we will give a user name. 
           User name must be ending with _bot.
         5.The bot will now give you a token to use when you want to access to the Telegram API. 
           your bot is done and you can use it!
 
    4. After that, You have to add one NuGet package Telegram. Bot to use inbuilt methods.

## Deviations : For Hosting on heroku.com

We have followed the following steps to host chatbot application on Heroku :-

### A. Windows Environment

Install docker on your machine with windows environment and follow the below steps :-

    Step 1: You can create a new account on heroku.com or can use the old account also.
    Step 2: Install Heroku CLI on your machine if not installed.
    Step 3: Go to heroku.com and log in.
    Step 4: Create a new Heroku app.
    Step 5: Create a docker file in your .net core application at the root folder. 
            Right-click on the project and then add docker support. And then choose windows .
            Remove all default code from the docker file and add the below code as the given code is not working.

            FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
            WORKDIR /app
            COPY . .

            CMD ASPNETCORE_URLS=http://*:$PORT dotnet {projectName}.dll

    Step 6: Now publish the project and copy docker file into publish folder.
            (bin-->Release--><yourdotnetcoreversion>-->publish)
    Step 7 : Now go to the docker terminal and execute the below commands for building docker image.
           $ docker build -t {imagename} {publish folder path }
    Step 8: Now login to heroku container.
           heroku container:login
    Step 9: Heroku runs a container registry on registry.heroku.com for that execute the below command.
           $ docker tag {imagename} registry.heroku.com/{heroku app name}/{process -type}
    Step 10: Now push the image to container registry. 
           $ docker push registry .heroku.com /{heroku app name}/{process type}
    
    But at this step when image is pushed on Heroku it gives error: 
    Error: Received unexpected HTTP status:500 internal server error. 

    As the platform used by heroku is different,we have also tried deploying the dot net application using 
    linux environment. Because the heroku support the linux environment, due to this the container created 
    from the windows enviroment was creating error. 
    Belows are the steps followed to create and push container from the docker linux terminal.

### B. Linux Environment

Install docker on your machine with linux environment and follow the below steps :-

    Step 1: You can create a new account on heroku.com or can use the old account also.
    Step 2: Install Heroku CLI on your machine if not installed.
    Step 3: Go to heroku.com and log in.
    Step 4: Create a new Heroku app.
    Step 5: Create a docker file in your .net core application at the root folder. 
            Right-click on the project and then add docker support. And then choose linux .
            Remove all default code from the docker file and add the below code as the given code is not working.

            FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
            WORKDIR /app
            COPY . .

            CMD ASPNETCORE_URLS=http://*:$PORT dotnet {projectName}.dll

    Step 6: Now publish the project and copy docker file into publish folder.
            (bin-->Release--><yourdotnetcoreversion>-->publish)
    Step 7 : Now go to the docker terminal and execute the below commands for building docker image.
              $ docker build -t {imagename} {publish folder path }
    Step 8: Now login to heroku container.
              heroku container:login
    Step 9: Heroku runs a container registry on registry.heroku.com for that execute the below command.
              $ docker tag {imagename} registry.heroku.com/{heroku app name}/{process -type}
    Step 10: Now push the image to container registry. 
              $ docker push registry .heroku.com /{heroku app name}/{process type}
    Step 11: Now release the container on heroku. After this the application will run.
              $ heroku container : release {process type} -- app {heroku app name}

    All the above mentioned steps have been successfully executed and the container is released.
    But when we open the application on heroku we get the below mentioned error.

    Error: 503 Service Unavailable Error is occurred:
    503 Service Unavailable Error is an HTTP response status code indicating that a server is temporarily 
    unable to handle the request. This may be due to the server being overloaded or down for maintenance. 
    This particular response code differs from a code like the 500 Internal Server Error.

Link : https://airbrake.io/blog/http-errors/503-service-unavailable

## Reference links : To deploy Dot Net Core application on heroku.

Youtube link: https://www.youtube.com/watch?v=gQMT4al2Grg
    
Heroku link : https://devcenter.heroku.com/articles/container-registry-and-runtime


## Reference for Telegram

Telegram Web https://web.telegram.org

Bots: An introduction for developers https://core.telegram.org

## Steps To Check Bot
    
    1. Download and execute the console application from github on your local machine.

    2. Visit the "https://web.telegram.org" url and login into your telegram application from web. You can also 
       use the telegram application from your cellphone.

    3. After login into the telegram application. Search for the bot by the name "BeepBeepBotBot".

    4. When you find the bot you can ask the below mention things and the bot will respond according to it.
        a.When you will send "Hi" message to the bot, the bot will ask for your name and after that bot will start 
          adderessing the user by the provided name.
        b.After provding the name , the bot should ask for the location of the person.
        c.When the user provide the location, the bot should ask for the news or weather for the given location.
        d.Now user will enter "news/weather" one by one then the bot will answer the weather of the day of the 
          given location and top three news of the given location.

## BeepBeep_ChatBotUnitTest Project

    1. If any error occurs while executing the unit test cases, then check the properties of the .json file 
       which is placed inside the TestCases folder of the BeepBeep_ChatBotUnitTest project.

    2. If "Copy to Output Directory" is not set to "Copy if newer" then make it "Copy if newer".

    3. In the telegram bot application when we used the unit testing then in this case the nugget which is used 
       for the telegram bot had already done the integration testing.

    4. For that reason, we have only added the test cases to check the scenario of the response made by the chat 
       bot using mock testing.(i.e by creating the replica of the actual bot response method)
    
    
## Error

If after downloading the code, the code does not execute in the visual studio then delete the ".vs"  folder and build 
the solution once again.
