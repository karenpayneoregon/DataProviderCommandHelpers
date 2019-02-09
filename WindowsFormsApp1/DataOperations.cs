using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using DataProviderCommandHelpers;
using KarenBase.ConnectionClasses;

namespace WindowsFormsApp1
{
    public class DataOperations : SqlServerConnection
    {
        /// <summary>
        /// Set server and database to work with.
        /// </summary>
        public DataOperations()
        {
            DatabaseServer = "KARENS-PC";
            DefaultCatalog = "NorthWindAzure2";
        }

        /// <summary>
        /// For remembering query with values
        /// </summary>
        public string CommandText { get; set; }
        /// <summary>
        /// For writing query to file
        /// </summary>
        public string CustomersSelectFileName => 
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "customersSelect.sql");

        /// <summary>
        /// List of countries
        /// </summary>
        /// <returns>All countries</returns>
        public List<Country> Countries()
        {
            var countryList = new List<Country>(); 

            var selectStatement = "SELECT id , CountryName FROM dbo.Countries;";

            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = selectStatement;
                    try
                    {
                        cn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            countryList.Add(new Country()
                            {
                                Id = reader.GetInt32(0),
                                CountryName = reader.GetString(1)
                            });
                        }
                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                    }
                }
            }

            return countryList;
        }
        /// <summary>
        /// List of contact types
        /// </summary>
        /// <returns>All contact types</returns>
        public List<ContactType> ContactTypes()
        {
            var countryList = new List<ContactType>(); 

            var selectStatement = "SELECT ContactTypeIdentifier ,ContactTitle FROM dbo.ContactType;";

            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = selectStatement;
                    try
                    {
                        cn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            countryList.Add(new ContactType()
                            {
                                ContactTypeIdentifier = reader.GetInt32(0),
                                ContactTitle = reader.GetString(1)
                            });
                        }
                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                    }
                }
            }

            return countryList;
        }
        /// <summary>
        /// Retrieve customers by contact type and country.
        /// </summary>
        /// <param name="contactTitle">Title to query for</param>
        /// <param name="countryName">Country to query for</param>
        /// <param name="exposeCommandText">When true gets query with values</param>
        /// <returns>DataTable results for where condition against title and country</returns>
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
                            CommandText = cmd.RevealCommandQuery();
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
    }
}