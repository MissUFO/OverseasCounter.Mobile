using System.Configuration;

namespace dip.DataAccess
{
  public class ConnectionString
  {
    public static string DbConnection
    {
      get
      {
        return ConfigurationManager.ConnectionStrings["database"].ConnectionString;
      }
    }
  }
}