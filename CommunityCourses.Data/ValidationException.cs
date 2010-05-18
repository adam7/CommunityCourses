using System;
using System.Collections.Generic;
using System.Web.Mvc;
using xVal.ServerSide;

namespace CommunityCourses.Data
{
  public class ValidationException : Exception
  {
    IEnumerable<ErrorInfo> errorMessages;

    public ValidationException() { }
    public ValidationException(IEnumerable<ErrorInfo> errorMessages) 
    {
      this.errorMessages = errorMessages;
    }

    public void CopyToModelState(ModelStateDictionary modelState, string prefix)
    {
      foreach (ErrorInfo errorInfo in errorMessages)
      {
        modelState.AddModelError(errorInfo.PropertyName, errorInfo.ErrorMessage);
      }
    }
  }
}
