using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentTracking.Data;
using System.Transactions;
using SubSonic.DataProviders;
using StudentTracking.Data.Model;
using StudentTracking.Data.Repository;

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
		public static void Update(Person person, Address address)
		{
			Student student = new Student();

			using (TransactionScope transactionScope = new TransactionScope())
			{
				using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
				{
					try
					{
						new AddressRepository().Update(address);
						new PersonRepository().Update(person);

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
