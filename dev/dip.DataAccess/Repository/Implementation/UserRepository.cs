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
    /// Get User by email
    /// </summary>
    public User GetByEmail(string email)
    {
      var user = new User();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[auth].[User_GetByEmail]";
        dataManager.Add("@Email", SqlDbType.NVarChar, ParameterDirection.Input, email);
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
        dataManager.Add("@UserId", SqlDbType.NVarChar, ParameterDirection.Input, entity.Id);
        dataManager.Add("@Email", SqlDbType.NVarChar, ParameterDirection.Input, entity.Email);

        dataManager.Add("@Password", SqlDbType.NVarChar, ParameterDirection.Input, entity.Password);
        dataManager.Add("@FirstName", SqlDbType.NVarChar, ParameterDirection.Input, entity.FirstName);
        dataManager.Add("@LastName", SqlDbType.NVarChar, ParameterDirection.Input, entity.LastName);
        dataManager.Add("@MiddleName", SqlDbType.NVarChar, ParameterDirection.Input, entity.MiddleName);
        dataManager.Add("@Photo", SqlDbType.Image, ParameterDirection.Input, entity.Photo);
        dataManager.Add("@PhoneNumber", SqlDbType.NVarChar, ParameterDirection.Input, entity.PhoneNumber);
        dataManager.Add("@Status", SqlDbType.Bit, ParameterDirection.Input, entity.Status);

        dataManager.ExecuteNonQuery();
      }

      entity = GetByEmail(entity.Email);

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
    /// Get Users list (NOT IMPLEMENTED)
    /// </summary>
    public List<User> List()
    {
      return List(new User());
    }
  }
}