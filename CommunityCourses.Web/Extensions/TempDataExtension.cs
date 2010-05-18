
namespace System.Web.Mvc
{
  public static class TempDataExtension
  {
    static readonly string messageKey = "message";

    public static string GetMessage(this TempDataDictionary tempDataDictionary)
    {
      return tempDataDictionary[messageKey] as string;
    }

    public static void SetMessage(this TempDataDictionary tempDataDictionary, string message)
    {
      tempDataDictionary[messageKey] = message;
    }
  }
}
