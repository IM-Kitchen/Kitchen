using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;
using System.Configuration;

namespace Kitchen
{
    /// <summary>
    /// Hand-rolled wrapper class for handling database access. Does not build the SqlConnection object until
    /// just prior to execution and is sure to close it and dispose of it as soon as possible.
    /// </summary>
    public class DatabaseExecutor
    {
        private static string connectionStringName = ConfigurationSettings.AppSettings["Database_ConnectionStringName"];

        private static string connectionString =
            ConfigurationManager.ConnectionStrings[connectionStringName].ToString();

        /// <summary>
        /// SQL statement to be executed when either <see cref="ExecuteReader"/>()
        /// or <see cref="ExecuteNonQuery"/>() are called
        /// </summary>
        private string sqlStatement;
        /// <summary>
        /// <see cref="SqlParameter" />s to be added when executing the query.
        /// </summary>
        private Dictionary<string, SqlParameter> parameters;

        /// <summary>
        /// Gets the <see cref="Dictionary" /> containing all the <see cref="SqlParameters" /> to be added to the <see cref="SqlCommand" /> object.
        /// </summary>
        public Dictionary<string, SqlParameter> Parameters
        {
            get
            {
                return parameters;
            }
        }

        /// <summary>
        /// Constructs <see cref="DatabaseExecutor" /> with and empty SQL Statement.
        /// </summary>
        public DatabaseExecutor()
            : this("GO;")
        {
        }
        /// <summary>
        /// Constructs <see cref="DatabaseExecutor" /> with the specified <see cref="string" /> SQL Statement.
        /// </summary>
        /// <param name="sql"><see cref="string" /> SQL Statement to be executed.</param>
        public DatabaseExecutor(string sql)
        {
            parameters = new Dictionary<string, SqlParameter>();
            sqlStatement = sql;
        }

        /// <summary>
        /// Adds a <see cref="SqlParameter"/> to be applied before execution.
        /// </summary>
        /// <param name="parameterName"><see cref="string"/> name of the <see cref="SqlParameter"/> to be added.</param>
        /// <param name="sqlDbtype"><see cref="SqlDbType"/> of the <see cref="SqlParameter"/> to be added.</param>
        /// <returns>The prepraed <see cref="SqlParameter"/> so that it may further be manipulated.</returns>
        public SqlParameter AddParameter(string parameterName, SqlDbType sqlDbtype)
        {
            SqlParameter sqlParameter = new SqlParameter(parameterName, sqlDbtype);
            parameters.Add(parameterName, sqlParameter);
            return sqlParameter;
        }
        /// <summary>
        /// Adds a <see cref="SqlParameter"/> to be applied before execution.
        /// </summary>
        /// <param name="parameterName"><see cref="string"/> name of the <see cref="SqlParameter"/> to be added.</param>
        /// <param name="sqlDbtype"><see cref="SqlDbType"/> of the <see cref="SqlParameter"/> to be added.</param>
        /// <param name="size"><see cref="int"/> size of the <see cref="SqlParameter"/> to be added.</param>
        /// <returns>The prepraed <see cref="SqlParameter"/> so that it may further be manipulated.</returns>
        public SqlParameter AddParameter(string parameterName, SqlDbType sqlDbtype, int size)
        {
            SqlParameter sqlParameter = new SqlParameter(parameterName, sqlDbtype, size);
            parameters.Add(parameterName, sqlParameter);
            return sqlParameter;
        }

        /// <summary>
        /// Builds a <see cref="SqlConnection"/> object using the connection string and SQL statement specified in the constructor. Then, 
        /// builds a <see cref="SqlCommandObject"/> using the <see cref="SqlConnection"/> and addes the <see cref="SqlParameter"/>s to it.
        /// Calls the <see cref="SqlParameter"/>'s ExecuteReader() method and uses it to fill a <see cref="DataTable"/> with the results.
        /// </summary>
        /// <returns><see cref="DataTable"/> of results.</returns>
        public DataTable ExecuteReader()
        {
            DataTable dataTable = null;
            SqlConnection conn = null;
            SqlCommand comm = null;
            try
            {
                conn = new SqlConnection(connectionString);
                comm = new SqlCommand(sqlStatement, conn);
                comm.CommandTimeout = 90;

                foreach (KeyValuePair<string, SqlParameter> pair in parameters)
                {
                    if (pair.Value.Value == null)
                        pair.Value.Value = System.DBNull.Value;

                    comm.Parameters.Add(pair.Value);
                }

                dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comm);
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }

            return dataTable;
        }
        /// <summary>
        /// Builds a <see cref="SqlConnection"/> object using the connection string and SQL statement specified in the constructor. Then, 
        /// builds a <see cref="SqlCommandObject"/> using the <see cref="SqlConnection"/> and addes the <see cref="SqlParameter"/>s to it.
        /// Calls the <see cref="SqlParameter"/>'s ExecuteNonQuery() method.
        /// </summary>
        public void ExecuteNonQuery()
        {
            if (sqlStatement.Length == 0)
                return;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(sqlStatement, conn);
            comm.CommandTimeout = 90;
            try
            {
                foreach (KeyValuePair<string, SqlParameter> pair in parameters)
                {
                    if (pair.Value.Value == null)
                        pair.Value.Value = System.DBNull.Value;

                    comm.Parameters.Add(pair.Value);
                }

                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
    }
}
