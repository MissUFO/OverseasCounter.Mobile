using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml;

namespace dip.DataAccess.DataManager.Interface
{
    public interface IDataManager : IDisposable
    {
        void Clear();
        CommandType CommandType { get; set; }
        bool Contains(object value);
        bool Contains(string value);
        int Count { get; }
       
        void Dispose(bool disposing);
        int ExecuteNonQuery();
        DbDataReader ExecuteReader(CommandBehavior behavior = CommandBehavior.Default);
        object ExecuteScalar();
        string ExecuteString { get; set; }
        XmlReader ExecuteXmlReader();
        string ExecuteXmlString();
        IEnumerator GetEnumerator();
        IEnumerable<T> GetList<T>(Func<IDataRecord, T> current);
        int IndexOf(object value);
        int IndexOf(string parameterName);
        void Insert(int index, object value);
        void Remove(object value);
        void RemoveAt(int index);
        void RemoveAt(string parameterName);
        int ReturnValue { get; }
        DbParameter this[int index] { get; }
        DbParameter this[string parameterName] { get; }
        SqlParameter Add(string parameterName, SqlDbType sqlDbType, ParameterDirection direction = ParameterDirection.Output);
        SqlParameter Add(string parameterName, SqlDbType sqlDbType, ParameterDirection direction, object value);
        SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, ParameterDirection direction, object value);
        SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, ParameterDirection direction);
        SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, object value);
    }
}
