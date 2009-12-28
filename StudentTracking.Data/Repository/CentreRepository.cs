using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xVal.ServerSide;
using System.Transactions;
using SubSonic.DataProviders;
using StudentTracking.Data.Extensions;
using SubSonic.Repository;
using StudentTracking.Data.Model;

namespace StudentTracking.Data.Repository
{
  public class CentreRepository : RepositoryBase<Centre>
  {    
    public void Add(Centre centre, Address address)
    {
      if (centre.GetErrors().Any())
      {
        throw new RulesException(centre.GetErrors());
      }

      using (TransactionScope transactionScope = new TransactionScope())
      {
        using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
        {
          try
          {
            address.Save();
            centre.Address = address;
            centre.Save();

            transactionScope.Complete();
          }
          catch (Exception exception)
          {
            // TODO: Log the error so we don't need to rethrow
            throw exception;
          }
        }
      }
    }
  }
}
