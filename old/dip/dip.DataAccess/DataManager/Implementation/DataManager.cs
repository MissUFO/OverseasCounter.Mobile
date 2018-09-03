using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Xml;
using dip.DataAccess.DataManager.Interface;

namespace dip.DataAccess.DataManager.Implementation
{
    public class DataManager : IDataManager, IDisposable
    {
        private readonly string _connectionString;
        private SqlCommand _dbCommand;

        #region Constructor ( 1+ overloads)
        public DataManager(string connectionString)
        {
            _dbCommand = new SqlCommand();
            this._connectionString = connectionString;
        }

        public DataManager(string connectionString, int commandTimeout)
        {
            _dbCommand = new SqlCommand();
            this._connectionString = connectionString;
            _dbCommand.CommandTimeout = commandTimeout;
        }

        ~DataManager()
        {
            Dispose(false);
        }

        #endregion

        #region Properties

        public int TotalRecordCount
        {
            get
            {
                if (this.Contains("@TotalNumberOfRecords"))
                {
                    return (int)this["@TotalNumberOfRecords"].Value;
                }
                return 0;
            }
        }

        #endregion

        #region IDisposable Members
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
            _dbCommand.Parameters.Clear();
            if (_dbCommand.Connection != null)
            {
                if (_dbCommand.Connection.State == System.Data.ConnectionState.Open)
                {
                    _dbCommand.Connection.Close();
                }
            }
            _dbCommand.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        public string ExecuteString { get; set; }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, object value)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType), ParameterDirection.Input, value);
        }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, object value)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType, size), ParameterDirection.Input, value);
        }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, ParameterDirection direction = ParameterDirection.Output)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType), direction);
        }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, ParameterDirection direction) // DONT ASSIGNE TO DEFAULT PARAMATERS.
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType, size), direction);
        }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, ParameterDirection direction, object value)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType), direction, value);
        }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, ParameterDirection direction, object value)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType, size), direction, value);
        }

        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, byte precision, byte scale, ParameterDirection direction, object value = null)
        {
            return this.Add(new SqlParameter(parameterName, sqlDbType) { Precision = precision, Scale = scale }, direction, value);
        }

        public SqlParameter Add(SqlParameter sqlPar, ParameterDirection direction = ParameterDirection.Input, object value = null)
        {
            if (_dbCommand.CommandType != CommandType.StoredProcedure)
                _dbCommand.CommandType = CommandType.StoredProcedure;
            sqlPar.Value = value ?? DBNull.Value;
            sqlPar.Direction = direction;
            if (sqlPar.DbType == DbType.Xml && value != null)
                sqlPar.Value = new SqlXml(new XmlTextReader(value.ToString(), XmlNodeType.Document, null));
            if (!_dbCommand.Parameters.Contains(sqlPar))
                _dbCommand.Parameters.Add(sqlPar);
            _dbCommand.Parameters[sqlPar.ParameterName] = sqlPar;
            return sqlPar;
        }

        public void Clear()
        {
            _dbCommand.Parameters.Clear();
        }

        public bool Contains(object value)
        {
            return _dbCommand.Parameters.Contains(value);
        }

        public bool Contains(string value)
        {
            return _dbCommand.Parameters.Contains(value);
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return _dbCommand.Parameters.GetEnumerator();
        }

        public int IndexOf(object value)
        {
            return _dbCommand.Parameters.IndexOf(value);
        }

        public int IndexOf(string parameterName)
        {
            return _dbCommand.Parameters.IndexOf(parameterName);
        }

        public void Insert(int index, object value)
        {
            _dbCommand.Parameters.Insert(index, value);
        }

        public void Remove(object value)
        {
            _dbCommand.Parameters.Remove(value);
        }

        public void RemoveAt(string parameterName)
        {
            _dbCommand.Parameters.RemoveAt(parameterName);
        }

        public void RemoveAt(int index)
        {
            _dbCommand.Parameters.RemoveAt(index);
        }

        public int Count
        {
            get { return _dbCommand.Parameters.Count; }
        }

        public SqlParameter this[int index]
        {
            get { return _dbCommand.Parameters[index]; }
            set { _dbCommand.Parameters[index] = value; }

        }

        public SqlParameter this[string parameterName]
        {
            get { return _dbCommand.Parameters[parameterName]; }
            set { _dbCommand.Parameters[parameterName] = value; }
        }

        public CommandType CommandType
        {
            get { return _dbCommand.CommandType; }
            set { _dbCommand.CommandType = value; }
        }

        public int ReturnValue
        {
            get
            {
                if (this["@ReturnValue"].Value == DBNull.Value)
                    return int.MinValue;
                return (int)this["@ReturnValue"].Value;
            }
        }

        private SqlConnection PrepareExecution(string executeString)
        {
            if (_dbCommand == null)
            {
                _dbCommand = new SqlCommand();
            }
            if (_dbCommand.Connection == null)
            {
                _dbCommand.Connection = new SqlConnection(_connectionString);
            }
            else if (_dbCommand.Connection.ConnectionString.Length == 0)
            {
                _dbCommand.Connection.ConnectionString = _connectionString;
            }
            if (_dbCommand.Connection.State != System.Data.ConnectionState.Open)
            {
                _dbCommand.Connection.Open();
            }
            _dbCommand.CommandText = executeString;
            if (_dbCommand.CommandType == CommandType.StoredProcedure)
            {
                Add("@ReturnValue", SqlDbType.Int, ParameterDirection.ReturnValue);
            }

            return _dbCommand.Connection;
        }

        private void CheckDbError()
        {
            if (this.Contains("@ReturnValue"))
            {
                if (ReturnValue != 0) { throw new Exception(ReturnValue.ToString()); }
            }
        }

        public int ExecuteNonQuery()
        {
            using (PrepareExecution(ExecuteString))
            {
                int returnValue = _dbCommand.ExecuteNonQuery();
                CheckDbError();
                return returnValue;
            }
        }

        public object ExecuteScalar()
        {
            using (PrepareExecution(ExecuteString))
            {
                object returnValue = _dbCommand.ExecuteScalar();
                CheckDbError();
                return returnValue;
            }
        }

        public XmlReader ExecuteXmlReader()
        {
            PrepareExecution(ExecuteString);
            XmlReader returnValue = _dbCommand.ExecuteXmlReader();
            CheckDbError();
            return returnValue;
        }

        public string ExecuteXmlString()
        {
            using (PrepareExecution(ExecuteString))
            {
                using (XmlReader reader = _dbCommand.ExecuteXmlReader())
                {
                    CheckDbError();
                    StringBuilder builder = new StringBuilder();
                    if (reader.Read())
                    {
                        string text = null;
                        while (!string.IsNullOrEmpty((text = reader.ReadOuterXml())))
                            builder.Append(text);
                    }
                    return builder.ToString();
                }
            }
        }

        public SqlDataReader ExecuteReader(CommandBehavior behavior = CommandBehavior.Default)
        {
            PrepareExecution(ExecuteString);
            SqlDataReader returnValue = _dbCommand.ExecuteReader(behavior);
            CheckDbError();
            return returnValue;
        }

        public IEnumerable<T> GetList<T>(Func<IDataRecord, T> current)
        {
            using (PrepareExecution(ExecuteString))
            {
                IList<T> list = new List<T>();
                using (IDataReader reader = _dbCommand.ExecuteReader())
                {
                    CheckDbError();
                    while (reader.Read()) { list.Add(current(reader)); }
                }
                return list;
            }
        }
        
        DbDataReader IDataManager.ExecuteReader(CommandBehavior behavior)
        {
            return this.ExecuteReader(behavior);
        }

        DbParameter IDataManager.this[int index]
        {
            get
            {
                return this[index];
            }
        }

        DbParameter IDataManager.this[string parameterName]
        {
            get
            {
                return this[parameterName];
            }
        }
    }
}