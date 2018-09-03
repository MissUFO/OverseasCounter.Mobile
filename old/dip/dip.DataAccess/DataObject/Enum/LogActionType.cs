namespace dip.DataAccess.DataObject.Enum
{
  public enum LogActionType : byte
  {
    Undefined = 0,
    Login = 1,
    Logoff = 2,
    ChangeSettings = 3,
    ChangeLocation = 4,
    Unauthorized = 5,
    Exception = 100
  }
}
