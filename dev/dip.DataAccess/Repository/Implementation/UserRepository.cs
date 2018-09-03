using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using dip.DataAccess.DataObject.Implementation;
using dip.DataAccess.Repository.Interface;

namespace dip.DataAccess.Repository.Implementation
{
  /// <summary>
  /// User repository with access for database
  /// </summary>
  public class UserRepository : IRepository<User>
  {
    public string ConnectionString { get; set; }

    public UserRepository()
    {
      ConnectionString = DataAccess.ConnectionString.DbConnection;
    }

    /// <summary>
    /// Get User by userid
    /// </summary>
    public User Get(int id)
    {
      var user = new User();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[auth].[User_Get]";
        dataManager.Add("@Id", SqlDbType.Int, ParameterDirection.Input, id);
        dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
        dataManager.ExecuteReader();
        XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
        user.UnpackXML(xmlOut.Element("User"));
      }

      return user;
    }

    /// <summary>
    /// Get user if the user is exist
    /// </summary>
    public User Login(string login, string password)
    {
      var user = new User();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[auth].[User_Login]";
        dataManager.Add("@Email", SqlDbType.NVarChar, ParameterDirection.Input, login);
        dataManager.Add("@Password", SqlDbType.NVarChar, ParameterDirection.Input, password);
        dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
        dataManager.ExecuteReader();
        XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
        user.UnpackXML(xmlOut.Element("User"));
      }

      return user;
    }

    /// <summary>
    /// AddEdit User
    /// </summary>
    public User AddEdit(User entity)
    {
      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[auth].[User_AddEdit]";
        dataManager.Add("@Email", SqlDbType.NVarChar, ParameterDirection.Input, entity.Email);

        dataManager.Add("@Password", SqlDbType.NVarChar, ParameterDirection.Input, entity.Password);
        dataManager.Add("@FirstName", SqlDbType.NVarChar, ParameterDirection.Input, entity.FirstName);
        dataManager.Add("@LastName", SqlDbType.NVarChar, ParameterDirection.Input, entity.LastName);
        dataManager.Add("@MiddleName", SqlDbType.NVarChar, ParameterDirection.Input, entity.MiddleName);
        dataManager.Add("@Status", SqlDbType.Bit, ParameterDirection.Input, entity.Status);

        dataManager.ExecuteNonQuery();
      }

      return entity;
    }

    /// <summary>
    /// Get list (NOT IMPLEMENTED)
    /// </summary>
    public List<User> List(User entity)
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// Delete User
    /// </summary>
    public bool Delete(int id)
    {
      return true;
    }

    /// <summary>
    /// Get Users list
    /// </summary>
    public List<User> List()
    {
      var users = new List<User>();
      return users;
    }
  }
}