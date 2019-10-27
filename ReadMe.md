 # Overview   
 This application produces a Postgresql database populated with stock market information and I've split this solution up into two projects: Stocks.Domain and Stocks.Data   
The Stocks.Data is the models for the stock market and saving YahooFinanceAPI's json into Postgres SQL. Stocks.Domain is used for displaying, manipulating, and controlling the stock information and API.   

# Prerequisites   
Database (Postgres)   
.NET Core   
Entity Framework Core   
Postman   
Visual Studio Code


# Getting a Stock Market DB   
If you want to start from scratch so you can change the backend of the database, you'll need to update the connection string in appsettings.json and run entity framework database migrations. To do the latter, you'll run in the package manager console, `update database`. The StockTicker.Ids are taken from the Stocks.Data/Models/Seeds/NYSE.csv () in which you can then import the CSV as a table to a new Docker Postgres container mapping the fields to the model. It would be preferred to seed this CSV as a table as .NET core recently released the ability to seed which can be done upon refactoring. To get a new version of this CSV, you can attain one here: https://www.nasdaq.com/screening/company-list.aspx (Note: the NYSE is a combination of the NASDAQ and AMEX)

Once you've attained a blank database (except for the StockTickers table), you can run the entity framework migrations for the application from the Nuget Package Manager Console. Start the application which should open up a default Microsoft page for a variety of their applications
To generate data, you can go to https://localhost:5001/api/generate/goog/2018-01-01/2018-02-01/daily where you can replace "goog" with any stock ticker that YahooFinanceAPI supports    

Leveraging Postman, this process can be automated to attain (most) stock market information. To do this, create a New Collection set a GET request to the URL https://localhost:5001/api/generate/{{Symbol}}/2018-01-01/2018-02-01/daily. In the Data section of Collection, use the CSV from Stocks.Data/Models/Seeds/NYSE.csv and have a 10 second delay between requests (Yahoo's Finance API has limitations) and Run the Collection.    

# References   
Thanks to: YahooFinanceAPI implementation from dennislwy (https://github.com/dennislwy/YahooFinanceAPI)   
Microsoft .NET Core API documentation (https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db?view=aspnetcore-2.0&tabs=visual-studio)  
    
