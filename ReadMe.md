Thanks to: YahooFinanceAPI, Microsoft .NET Core API documentation
This application produces a Postgresql database populated with stock market information and I've split this solution up into two projects: Stocks.Domain and Stocks.Data
The Stocks.Data is the models for the stock market and saving YahooFinanceAPI's json into Postgres SQL. Stocks.Domain is used for displaying, manipulating, and controlling the stock information and API.

#Prerequisites
Docker
.NET Core
Postman
Visual Studio 2017 (Verified Mac version 7.8)


If you want to start from scratch, the StockTicker.Ids are taken from the Stocks.Data/Models/Seeds/NYSE.csv () in which I import the CSV as a table to a new Docker Postgres container. It would be preferred to seed this CSV as a table, but .NET core recently released the ability to seed.

If you want to skip adding the CSV part, I've prepped a docker image here: 

Once you've attained a blank database (except for the StockTickers table), you can Start the application which should open up a default Microsoft page for a variety of their applications
To generate data, you can go to https://localhost:5001/api/apistockdata/goog/2018-01-01/2018-02-01/daily where you can replace "goog" with any stock ticker that YahooFinanceAPI supports

Leveraging Postman, I create a New Collection set a GET request to the URL https://localhost:5001/api/apistockdata/{{Symbol}}/2018-01-01/2018-02-01/daily. In the Data section of Collection, I use the CSV from Stocks.Data/Models/Seeds/NYSE.csv and have a 10 second delay between requests (Yahoo's Finance API has limitations) and Run the Collection.


