using DbUp;

string connectionString = args.FirstOrDefault() ??
    "Server=Desk-SMK,1433;Initial Catalog=Orders;Database=Orders;User Id=****;Password=*****;TrustServerCertificate=True;";

EnsureDatabase.For.SqlDatabase(connectionString);

var upgrader = DeployChanges.To.SqlDatabase(connectionString)
                .LogToConsole()
                .WithScriptsFromFileSystem("Scripts")
                .Build();

var result = upgrader.PerformUpgrade();

if (result.Successful)
{
    Console.WriteLine("Success! YAY..");
}
else
{
    Console.WriteLine("Failure");
}