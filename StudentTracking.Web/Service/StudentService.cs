using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentTracking.Data;
using System.Transactions;
using SubSonic.DataProviders;
using StudentTracking.Data.Model;

namespace StudentTracking.Web.Service
{
  public static class StudentService
  {
    public static void Create(Person person, Address address)
    {
      Student student = new Student();

      using (TransactionScope transactionScope = new TransactionScope())
      {
        using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
        {
          try
          {
            address.Save();
            person.AddressId = address.Id;
            person.Save();
            student.PersonId = person.Id;
            student.Save();

            transactionScope.Complete();
          }
          catch (Exception exception)
          {
           // TODO: Log error
            throw exception;
          }
        }
      }
    }
  }
}
