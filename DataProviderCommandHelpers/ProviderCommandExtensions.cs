using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace DataProviderCommandHelpers
{
    public static class ProviderCommandExtensions
    {
        /// <summary> 
        /// Used to show an SQL statement with actual values for debugging or logging to a file. 
        /// </summary> 
        /// <param name="pCommand">Command object</param>
        /// <param name="pProvider">Data provider e.g. SQL-Server, MS-Access</param>
        /// <param name="pQualifier">Character which denotes a query parameter e.g. @ for SQL-Server, : or Oracle</param>
        /// <returns>Command object command text with parameter values using <seealso cref="ActualCommandText"/></returns> 
        public static string RevealCommandQuery(this IDbCommand pCommand, CommandProvider pProvider = CommandProvider.SqlServer, string pQualifier = "@")
        {
            return pCommand.ActualCommandText(pProvider, pQualifier);
        }

        /// <summary> 
        /// Used to show an SQL statement with actual values for debugging or logging to a file. 
        /// </summary> 
        /// <param name="pCommand">Command object</param>
        /// <param name="pFileName">Path and file name to write SQL statement to</param>
        /// <param name="pProvider">Data provider e.g. SQL-Server, MS-Access</param>
        /// <param name="pQualifier">Character which denotes a query parameter e.g. @ for SQL-Server, : or Oracle</param>
        /// <returns>Command object command text with parameter values using <seealso cref="ActualCommandText"/></returns> 
        public static void RevealCommandQueryToFile(this IDbCommand pCommand,string pFileName, CommandProvider pProvider = CommandProvider.SqlServer, string pQualifier = "@")
        {
            File.WriteAllText(pFileName, pCommand.ActualCommandText(pProvider, pQualifier));
        }

        /// <summary> 
        /// Used to show an SQL statement with actual values for debugging or logging to a file. 
        /// </summary> 
        /// <param name="pCommand">Command object</param>
        /// <param name="pProvider">Data provider e.g. SQL-Server, MS-Access</param>
        /// <param name="pQualifier">Character which denotes a query parameter e.g. @ for SQL-Server, : or Oracle</param>
        /// <returns>Command object command text with parameter values</returns> 
        public static string ActualCommandText(this IDbCommand pCommand, CommandProvider pProvider = CommandProvider.SqlServer, string pQualifier = "@")
        {
            var sb = new StringBuilder(pCommand.CommandText);

            if (pProvider != CommandProvider.Oracle)
            {
                // test for at least one parameter without a name, if found stop here.
                var emptyParameterNames =
                    (
                        from parameter in pCommand.Parameters.Cast<IDataParameter>()
                        where string.IsNullOrWhiteSpace(parameter.ParameterName)
                        select parameter
                    ).FirstOrDefault();

                if (emptyParameterNames != null)
                {
                    return pCommand.CommandText;
                }
            }
            else if (pProvider == CommandProvider.Oracle)
            {
                pQualifier = ":";
            }


            foreach (IDataParameter parameter in pCommand.Parameters)
            {

                if ((parameter.DbType == DbType.AnsiString) || (parameter.DbType == DbType.AnsiStringFixedLength) || (parameter.DbType == DbType.Date) || (parameter.DbType == DbType.DateTime) || (parameter.DbType == DbType.DateTime2) || (parameter.DbType == DbType.Guid) || (parameter.DbType == DbType.String) || (parameter.DbType == DbType.StringFixedLength) || (parameter.DbType == DbType.Time) || (parameter.DbType == DbType.Xml))
                {
                    if (parameter.ParameterName.Substring(0, 1) == pQualifier)
                    {
                        if (parameter.Value == null)
                        {
                            throw new Exception($"no value given for parameter '{parameter.ParameterName}'");
                        }

                        sb = sb.Replace(parameter.ParameterName, $"'{parameter.Value.ToString().Replace("'", "''")}'");

                    }
                    else
                    {
                        sb = sb.Replace(string.Concat(pQualifier, parameter.ParameterName), $"'{parameter.Value.ToString().Replace("'", "''")}'");
                    }
                }
                else
                {
                    /*
                     * Dummy up a INSERT Oracle statement where the RETURNING has no
                     * value for that parameter so return the parameter name instead
                     * rather than a value.
                     */
                    if (pProvider == CommandProvider.Oracle)
                    {
                        if (parameter.Value == null)
                        {
                            sb = sb.Replace(parameter.ParameterName, parameter.ParameterName);
                        }
                        else
                        {
                            sb = sb.Replace(parameter.ParameterName, parameter.Value.ToString());
                        }
                    }
                    else
                    {
                        sb = sb.Replace(parameter.ParameterName, parameter.Value.ToString());
                    }

                }
            }

            return sb.ToString();

        }

    }
}
