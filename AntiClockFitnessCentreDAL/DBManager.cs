using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Collections;
using System.Data;

namespace AntiClockFitnessCentreDAL
{
    public class DBManager
    {
        string commandText;
        DBCommandType commandType;
        string connectionString;
        string provider;
        Hashtable parameters;
        int timeout;
        DbConnection Connection;
        public Exception exceptionMessage;
        //CommonDAL _CommonBL = new CommonDAL();
        public DBManager()
        {
            parameters = new Hashtable();
            //_CommonBL = new CommonDAL();

        }

        /// <summary>
        /// Text-0, StoredProcedure -1
        /// </summary>
        public enum DBCommandType
        {
            Text,
            StoredProcedure
        }


        /// <summary>
        /// Query-0, StoredProcedure -1
        /// </summary>
        public DBCommandType CommandType
        {
            get { return commandType; }
            set { commandType = value; }
        }

        /// <summary>
        /// CommandText that used as Query in System.Data.common.DBCommand
        /// </summary>
        public string CommandText
        {
            get { return commandText; }
            set { commandText = value; }
        }

        /// <summary>
        /// ConnectionString to connect tne Database,
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        /// <summary>
        /// This is used for specify which type of databse we are using
        /// </summary>
        public string Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        /// <summary>
        /// Parameters for System.Data.Common.DBCommand. Key as a Column/Parameter Name. Value as a Column/parameter Value
        /// </summary>
        public Hashtable Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        /// <summary>
        /// Timeout for the connection
        /// </summary>
        public int TimeOut
        {
            get { return timeout; }
            set { timeout = value; }
        }

        /// <summary>
        /// Checks the connetion state
        /// </summary>
        /// <returns></returns>
        public bool CheckConnection()
        {
            if (Connection.State == ConnectionState.Open)
                return true;
            else
                return false;

        }

      

        /// <summary>
        /// Insert the database using System.Data.common.
        /// </summary>
        /// <returns></returns>
        public int ExecuteInsertCommand()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Provider);
            Connection = factory.CreateConnection();
            DbCommand command = factory.CreateCommand();
            try
            {
                Connection.ConnectionString = ConnectionString;
                command.Connection = Connection;
                command.CommandText = CommandText;
                if (CommandType == DBCommandType.StoredProcedure)
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Clear();

                List<DbParameter> param = new List<DbParameter>();
                if (!(parameters == null))
                {
                    foreach (DictionaryEntry de in parameters)
                    {
                        param.Add(CreateParameters(de.Key.ToString(), de.Value));
                    }
                }
                if (!(param == null))
                {
                    foreach (DbParameter para in param)
                    {
                        command.Parameters.Add(para);
                    }
                }
                if (!CheckConnection())
                    Connection.Open();

                int val = command.ExecuteNonQuery();
                command.Parameters.Clear();
                Parameters.Clear();
                if (CheckConnection())
                    Connection.Close();
                return val;
            }
            catch (DbException ex)
            {
                Parameters.Clear();
                exceptionMessage = ex;
                return -1;
            }
            catch (Exception exx)
            {
                Parameters.Clear();
                exceptionMessage = exx;
                return -1;
            }
        }

        public string ExecuteInsertCommandWithOutput(string outputColumn)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Provider);
            Connection = factory.CreateConnection();
            DbCommand command = factory.CreateCommand();
            try
            {
                Connection.ConnectionString = ConnectionString;
                command.Connection = Connection;
                command.CommandText = CommandText;
                if (CommandType == DBCommandType.StoredProcedure)
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Clear();

                List<DbParameter> param = new List<DbParameter>();
                if (!(parameters == null))
                {
                    foreach (DictionaryEntry de in parameters)
                    {
                        param.Add(CreateParameters(de.Key.ToString(), de.Value));
                    }
                }
                if (!(param == null))
                {
                    foreach (DbParameter para in param)
                    {
                        command.Parameters.Add(para);
                    }
                }

                DbParameter output = command.CreateParameter();
                output.ParameterName = outputColumn;
                output.DbType = DbType.String;
                output.Direction = ParameterDirection.Output;
                output.Size = 300;
                command.Parameters.Add(output);
                if (!CheckConnection())
                    Connection.Open();
                command.ExecuteNonQuery();
                string ou = output.Value.ToString();
                command.Parameters.Clear();
                Parameters.Clear();
                if (CheckConnection())
                    Connection.Close();
                return ou;
            }
            catch (DbException ex)
            {
                Parameters.Clear();
                exceptionMessage = ex;
                return string.Empty;
            }
            catch (Exception exx)
            {
                Parameters.Clear();
                exceptionMessage = exx;
                return string.Empty;
            }
        }

        /// <summary>
        /// Delete the database using System.Data.common.
        /// </summary>
        /// <returns></returns>
        public int ExecuteDeleteCommand()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Provider);
            Connection = factory.CreateConnection();
            DbCommand command = factory.CreateCommand();
            try
            {
                Connection.ConnectionString = ConnectionString;
                command.Connection = Connection;
                command.CommandText = CommandText;
                if (CommandType == DBCommandType.StoredProcedure)
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Clear();
                List<DbParameter> param = new List<DbParameter>();
                if (!(parameters == null))
                {
                    foreach (DictionaryEntry de in parameters)
                    {
                        param.Add(CreateParameters(de.Key.ToString(), de.Value));
                    }
                }
                if (!(param == null))
                {
                    foreach (DbParameter para in param)
                    {
                        command.Parameters.Add(para);
                    }
                }
                if (!CheckConnection())
                    Connection.Open();

                int val = command.ExecuteNonQuery();
                command.Parameters.Clear();
                Parameters.Clear();
                if (CheckConnection())
                    Connection.Close();
                return val;
            }
            catch (DbException ex)
            {
                Parameters.Clear();
                exceptionMessage = ex;
                return -1;
            }
            catch (Exception exx)
            {
                Parameters.Clear();
                exceptionMessage = exx;
                return -1;
            }
        }

        /// <summary>
        /// Update the database using System.Data.common.
        /// </summary>
        /// <returns></returns>
        public int ExecuteUpdateCommand()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Provider);
            Connection = factory.CreateConnection();
            DbCommand command = factory.CreateCommand();
            try
            {
                Connection.ConnectionString = ConnectionString;
                if (!CheckConnection())
                    Connection.Open();
                command.Connection = Connection;
                command.CommandText = CommandText;
                if (CommandType == DBCommandType.StoredProcedure)
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Clear();
                List<DbParameter> param = new List<DbParameter>();
                if (!(parameters == null))
                {
                    foreach (DictionaryEntry de in parameters)
                    {
                        param.Add(CreateParameters(de.Key.ToString(), de.Value));
                    }
                }
                if (!(param == null))
                {
                    foreach (DbParameter para in param)
                    {
                        command.Parameters.Add(para);
                    }
                }
                if (!CheckConnection())
                    Connection.Open();
                int val = command.ExecuteNonQuery();
                command.Parameters.Clear();
                Parameters.Clear();
                if (CheckConnection())
                    Connection.Close();
                return val;
            }
            catch (DbException ex)
            {
                Parameters.Clear();
                exceptionMessage = ex;
                return -1;
            }
            catch (Exception exx)
            {
                Parameters.Clear();
                exceptionMessage = exx;
                return -1;
            }
        }

        /// <summary>
        /// It returns the Dataset from database using System.Data.Common.DBCommon
        /// </summary>
        /// <returns></returns>
        public DataSet SelectTables()
        {
            try
            {
                DataSet returnvalue = new DataSet();
                DbDataAdapter dba = GetAdapter();
                dba.Fill(returnvalue);
                if (CheckConnection())
                    Connection.Close();
                return returnvalue;
            }
            catch (Exception exx)
            {
                Parameters.Clear();
                exceptionMessage = exx;
                return null;
            }
        }

        /// <summary>
        /// Gets the Data from database using System.Data.Common and return as Datatable
        /// </summary>
        /// <param name="Hst">Hashtable that we are going to convert into parameters collection</param>
        /// <returns></returns>
        public DataTable SelectTable()
        {
            try
            {
                DataTable returnvalue = new DataTable();
                returnvalue.TableName = "DataTable";
                DbDataAdapter dba = GetAdapter();
                dba.Fill(returnvalue);
                if (CheckConnection())
                    Connection.Close();
                return returnvalue;
            }
            catch (Exception exx)
            {
                Parameters.Clear();
                exceptionMessage = exx;
                return null;
            }
        }

        /// <summary>
        /// Returns the result as a objects retrevied from database using System.Data.Common
        /// </summary>
        /// <returns></returns>
        public object GetResultAsObject()
        {
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
                Connection = factory.CreateConnection();
                Connection.ConnectionString = ConnectionString;
                if (!CheckConnection())
                    Connection.Open();
                DbCommand dbcmd = factory.CreateCommand();
                dbcmd.Connection = Connection;
                dbcmd.CommandText = CommandText;
                if (CommandType == DBCommandType.StoredProcedure)
                    dbcmd.CommandType = System.Data.CommandType.StoredProcedure;
                dbcmd.Parameters.Clear();
                List<DbParameter> param = new List<DbParameter>();
                if (!(parameters == null))
                {
                    foreach (DictionaryEntry de in parameters)
                    {
                        param.Add(CreateParameters(de.Key.ToString(), de.Value));
                    }
                }
                if (!(param == null))
                {
                    foreach (DbParameter para in param)
                    {
                        dbcmd.Parameters.Add(para);
                    }
                }

                object returnvalue = dbcmd.ExecuteScalar();
                Parameters.Clear();
                return returnvalue;
            }
            //catch (DbException ex)
            //{
            //    Parameters.Clear();
            //    string ExceptionMessage = ex.Message;
            //    _CommonBL.InsertException("MySearch", "FirstTimeUpdateUser-exc", ex.Message + "-" + ex.StackTrace, "User");
            //    return null;
            //}
            catch (Exception exx)
            {
                Parameters.Clear();
                exceptionMessage = exx;

                return null;
            }
        }

        /// <summary>
        /// Returns the result as a string retrevied from database using System.Data.Common
        /// </summary>
        /// <returns></returns>
        public string GetResultAsString()
        {
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
                Connection = factory.CreateConnection();
                Connection.ConnectionString = ConnectionString;
                if (!CheckConnection())
                    Connection.Open();
                DbCommand dbcmd = factory.CreateCommand();
                dbcmd.Connection = Connection;
                dbcmd.CommandText = CommandText;
                if (CommandType == DBCommandType.StoredProcedure)
                    dbcmd.CommandType = System.Data.CommandType.StoredProcedure;
                dbcmd.Parameters.Clear();
                List<DbParameter> param = new List<DbParameter>();
                if (!(parameters == null))
                {
                    foreach (DictionaryEntry de in parameters)
                    {
                        param.Add(CreateParameters(de.Key.ToString(), de.Value));
                    }
                }
                if (!(param == null))
                {
                    foreach (DbParameter para in param)
                    {
                        dbcmd.Parameters.Add(para);
                    }
                }

                string returnvalue = dbcmd.ExecuteScalar().ToString();
                Parameters.Clear();
                return returnvalue;
            }
            //catch (DbException ex)
            //{
            //    Parameters.Clear();
            //    string ExceptionMessage = ex.Message;
            //    return null;
            //}
            catch (Exception exx)
            {
                Parameters.Clear();
                exceptionMessage = exx;
                return null;
            }
        }

        /// <summary>
        /// Returns the result as a int retrevied from database using System.Data.Common
        /// </summary>
        /// <returns></returns>
        public int GetResultAsInteger()
        {
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
                Connection = factory.CreateConnection();
                Connection.ConnectionString = ConnectionString;
                if (!CheckConnection())
                    Connection.Open();
                DbCommand dbcmd = factory.CreateCommand();
                dbcmd.Connection = Connection;
                dbcmd.CommandText = CommandText;
                if (CommandType == DBCommandType.StoredProcedure)
                    dbcmd.CommandType = System.Data.CommandType.StoredProcedure;
                dbcmd.Parameters.Clear();
                List<DbParameter> param = new List<DbParameter>();
                if (!(parameters == null))
                {
                    foreach (DictionaryEntry de in parameters)
                    {
                        param.Add(CreateParameters(de.Key.ToString(), de.Value));
                    }
                }
                if (!(param == null))
                {
                    foreach (DbParameter para in param)
                    {
                        dbcmd.Parameters.Add(para);
                    }
                }
                int returnvalue = (int)dbcmd.ExecuteScalar();
                Parameters.Clear();
                return returnvalue;
            }
            catch (DbException ex)
            {
                Parameters.Clear();
                string ExceptionMessage = ex.Message;
                return -1;
            }
            catch (Exception exx)
            {
                Parameters.Clear();
                string ExceptionMessage = exx.Message;
                return -1;
            }
        }

        /// <summary>
        /// Binds the parameter to DbDataAdapter.Returns the DbDataAdapter
        /// </summary>
        /// <returns></returns>
        private DbDataAdapter GetAdapter()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Provider);
            Connection = factory.CreateConnection();
            Connection.ConnectionString = ConnectionString;
            if (!CheckConnection())
                Connection.Open();
            DbCommand dbcmd = factory.CreateCommand();
            dbcmd.Connection = Connection;
            dbcmd.CommandText = CommandText;
            if (CommandType == DBCommandType.StoredProcedure)
                dbcmd.CommandType = System.Data.CommandType.StoredProcedure;
            List<DbParameter> param = new List<DbParameter>();
            if (!(parameters == null))
            {
                foreach (DictionaryEntry de in parameters)
                {
                    param.Add(CreateParameters(de.Key.ToString(), de.Value));
                }
            }
            if (!(param == null))
            {
                foreach (DbParameter para in param)
                {
                    dbcmd.Parameters.Add(para);
                }
            }
            DbDataAdapter dbAdapter = factory.CreateDataAdapter();
            dbAdapter.SelectCommand = dbcmd;
            Parameters.Clear();
            return dbAdapter;
        }

        /// <summary>
        /// Adds the parameter to System.Data.Common.DBCommand
        /// </summary>
        /// <param name="name">name is a parameter name</param>       
        /// <param name="value">Value is the parameter value </param>      
        /// <returns></returns>
        public DbParameter CreateParameters(string name, object value)
        {
            DbParameter paramet;
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(Provider);
                DbCommand dbcmd = factory.CreateCommand();
                paramet = dbcmd.CreateParameter();
                if (paramet != null)
                {
                    paramet.ParameterName = name;
                    paramet.Value = value;
                    paramet.Direction = ParameterDirection.Input;
                }
                return paramet;
            }
            catch (DbException ex)
            {

                string ExceptionMessage = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Insert the row with Identity and return the Identity value
        /// </summary>
        /// <returns></returns>
        public long ExecuteInsertAndReturnIdentity()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Provider);
            Connection = factory.CreateConnection();
            Connection.ConnectionString = ConnectionString;
            if (!CheckConnection())
                Connection.Open();
            DbCommand command = factory.CreateCommand();
            DbDataAdapter dbAdapter = factory.CreateDataAdapter();
            try
            {
                command.Connection = Connection;
                command.CommandText = CommandText;
                if (CommandType == DBCommandType.StoredProcedure)
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                // command.CommandType = (CommandType)CommandType;
                dbAdapter.InsertCommand = command;
                command.Parameters.Clear();
                DbParameter[] param = new DbParameter[0];
                if (!(parameters == null))
                {
                    int count = parameters.Count;
                    int i = 0;
                    param = new DbParameter[count];
                    foreach (DictionaryEntry de in parameters)
                    {
                        param[i] = CreateParameters(de.Key.ToString(), de.Value);
                        i++;
                    }
                }
                if (!((param == null)))
                {
                    foreach (DbParameter para in param)
                    {
                        command.Parameters.Add(para);
                    }
                }

                command.ExecuteNonQuery();
                command.Parameters.Clear();
                if (CheckConnection())
                    Connection.Close();
                if (!CheckConnection())
                    Connection.Open();
                CommandText = "Select SCOPE_IDENTITY()";
                command.CommandText = CommandText;
                long val = (long)command.ExecuteScalar();
                Parameters.Clear();
                if (CheckConnection())
                    Connection.Close();
                return val;
            }
            catch (DbException ex)
            {
                Parameters.Clear();
                string ExceptionMessage = ex.Message;
                return -1;
            }
            catch (Exception exx)
            {
                Parameters.Clear();
                string ExceptionMessage = exx.Message;
                return -1;
            }
        }

        /// <summary>
        /// Insert the row with UniqueIdentifer and return the value
        /// </summary>
        /// <returns></returns>
        public Guid ExecuteInsertAndReturnUniqueIdentifer()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Provider);
            Connection = factory.CreateConnection();
            Connection.ConnectionString = ConnectionString;
            if (!CheckConnection())
                Connection.Open();
            DbCommand command = factory.CreateCommand();
            DbDataAdapter dbAdapter = factory.CreateDataAdapter();
            try
            {

                command.Connection = Connection;
                if (CommandType == DBCommandType.StoredProcedure)
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = CommandText;
                command.Parameters.Clear();

                DbParameter[] param = new DbParameter[0];
                if (!(parameters == null))
                {
                    int count = parameters.Count;
                    int i = 0;
                    param = new DbParameter[count];
                    foreach (DictionaryEntry de in parameters)
                    {
                        param[i] = CreateParameters(de.Key.ToString(), de.Value);
                        i++;
                    }
                }
                if (!((param == null)))
                {
                    foreach (DbParameter para in param)
                    {
                        command.Parameters.Add(para);
                    }
                }
                Guid result = (Guid)command.ExecuteScalar();
                Parameters.Clear();
                if (CheckConnection())
                    Connection.Close();
                return result;
            }
            catch (DbException ex)
            {
                Parameters.Clear();
                string ExceptionMessage = ex.Message;
                return Guid.Empty;
            }
            catch (Exception exx)
            {
                Parameters.Clear();
                string ExceptionMessage = exx.Message;
                return Guid.Empty;
            }
        }

        //Added New 
        public DbTransaction Transcation()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Provider);
            Connection = factory.CreateConnection();

            Connection.ConnectionString = ConnectionString;
            if (!CheckConnection())
                Connection.Open();

            return Connection.BeginTransaction();
        }

        //Added New
        public DataSet SelectTables(int startRecord, int pageSize , string tableName)
        {
            try
            {
                DataSet returnvalue = new DataSet();
                DbDataAdapter dba = GetAdapter();
                dba.Fill(returnvalue, startRecord, pageSize, tableName);
                if (CheckConnection())
                    Connection.Close();
                return returnvalue;
            }
            catch (Exception exx)
            {
                Parameters.Clear();
                exceptionMessage = exx;
                return null;
            }
        }
    }
}
