using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Schema;
using SubSonic.Repository;
using SubSonic.DataProviders;
using StudentTracking.Data.Model;
using StudentTracking.Data.Extensions;

namespace StudentTracking.Data.Repository
{
  public abstract class RepositoryBase<T> where T : class, IActiveRecord, new()
  {
    protected IRepository<T> repository = new SubSonicRepository<T>(new StudentTrackingDB());
    protected const int pageSize = 10;

    public PagedList<T> GetPaged(int pageNumber)
    {
      return repository.GetPaged(pageNumber, pageSize);
    }

    public List<T> GetAll()
    {
      return repository.GetAll().ToList();
    }

    public T Get(int id)
    {
      return repository.GetByKey(id);
    }

    public void Add(T item)
    {
      if (item.IsValid())
      {
        item.Add();
      }
      else
      {
        throw new ValidationException(item.GetErrors());
      }
    }

    public void Update(T item)
    {
      if (item.IsValid())
      {
        item.Update();
      }
      else
      {
        throw new ValidationException(item.GetErrors());
      }
    }

    //public void Update(IEnumerable<T> items)
    //{
      
    //  repository.Update(items);
    //}
  }
}
