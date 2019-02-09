# Data Provider Command Helpers
This repository contains a language extension method to reveal a parameterized SQL statement written using a managed data provider in C# or VB.NET programming languages.

### NuGet command installation
Install-Package DataProviderCommandHelpers -Version 1.0.0
### Instructions
1 Add this package to your Visual Studio Solution.
- Call RevealCommandQuery where cmd is a command object Console.WriteLine(cmd.RevealCommandQuery());
- Call RevealCommandQueryToFile where cmd is a command object RevealCommandQueryToFile("SomeFile.txt");

If not using SQL-Server, you need to pass in a database type as the last parameter of the above extension methods.

```csharp
public enum CommandProvider
{
    SqlServer,
    Access,
    Oracle
}
```
### MS-Access
Although parameters use **?** for parameter markers the **@** character can be used also but since MS-Access parameters are positional parameters that are named must remain positional.


#### Example 1
A developer writes, in this case a SELECT statement with multiple WHERE conditions which was written in SSMS (SQL-Server Management Studio) which was tested and worked as expected.

In production customers complain when applying values for country and contact type nothing is being returned yet know there are records which match their conditions.

How can this be diagnosed when the customers are not local? Using RevealCommandQuery extension method the application can be setup to write the resulting query to a text file or email'd to the developer for figuring out why the query failed.

There are many reasons for failure but in this case the developer provided ComboBox controls to allow a 
user to select values for the WHERE condition and as many developer do did not set the drop down type of the 
ComboBoxes which allow the customer to alter a selection which does not exists thus returning no records. For simple SELECT, UPDATE, DELETE or INSERT queries this extension may not seem worthy of use yet for queries such as the one below or large is where these extensions shine.

```csharp
public DataTable ReadSpecificCustomers(string contactTitle, string countryName, bool exposeCommandText = false)
{

    var dt = new DataTable();

    var selectStatement = 
        "SELECT Cust.CustomerIdentifier ,Cust.CompanyName ," + 
        "Cust.ContactName ,Cust.ContactIdentifier , Cust.ContactTypeIdentifier ," + 
        "Cust.CountryIdentfier ,C.id ,C.CountryName ,ct.ContactTypeIdentifier AS ctIdentifier ," + 
        "ct.ContactTitle FROM   dbo.Customers AS Cust " + 
        "INNER JOIN dbo.ContactType AS ct ON Cust.ContactTypeIdentifier = ct.ContactTypeIdentifier " + 
        "INNER JOIN dbo.Countries AS C ON Cust.CountryIdentfier = C.id " + 
        "WHERE  ct.ContactTitle = @ContactTitle AND C.CountryName = @CountryName;";

    using (var cn = new SqlConnection { ConnectionString = ConnectionString })
    {
        using (var cmd = new SqlCommand { Connection = cn })
        {
            cmd.CommandText = selectStatement;
            try
            {
                cmd.Parameters.AddWithValue("@ContactTitle", contactTitle);
                cmd.Parameters.AddWithValue("@CountryName", countryName);

                if (exposeCommandText)
                {
                    cmd.RevealCommandQueryToFile(CustomersSelectFileName);
                }

                cn.Open();

                dt.Load(cmd.ExecuteReader());

            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }
        }
    }

    return dt;
}
```
#### Example 2
A developer write an SQL statement directly in code and when executing the query no results are returned. By using RevealCommandQuery which write the SQL statement to the IDE Output window the developer can a) create a new text file in Visual Studio, give it a .sql extension, drop the query it and run the query against the database. If there are errors the database will report them.

