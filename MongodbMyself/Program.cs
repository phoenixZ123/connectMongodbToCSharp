

using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using MongodbMyself;
using System;
using System.Data.Common;

string ConnectionString = "mongodb+srv://pwintphoowai:mongoose@phoo.glozq0x.mongodb.net/user?retryWrites=true&w=majority";
string databaseName = "simple_db";
string collectionName = "user";

var client =new MongoClient(ConnectionString);
var database = client.GetDatabase(databaseName);
//get table
var collection = database.GetCollection<UserModel>(collectionName);

//store data to mongodb
var insert = new UserModel { Name = "PwintPhooWai", Type = "Reader" };

await collection.InsertOneAsync(insert);

//await is scceptable code impt
var results =await collection.FindAsync(_ => true);

foreach (var data in results.ToList())
{
    Console.WriteLine($"{data.Id}: {data.Name} {data.Type}");
}

