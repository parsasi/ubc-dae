
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Database{
    public abstract class Database
    {
        protected int Query(string query , List<string> parameters = null)
        {
            Console.WriteLine($"Executing query: {this.AddParametersToQuery(query , parameters)}");
            return 1;
        }

        private string AddParametersToQuery(string query , List<string> parameters = null)
        {
            if(parameters == null)
            {
                return query;
            }

            var queryCopy = query;

            foreach(var parameter in parameters)
            {
                var regex = new Regex(@"\{(\w+)\}");
                queryCopy = regex.Replace(query , parameter);
            }

            return queryCopy;
        }
    }    
}
