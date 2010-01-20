using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Schema;
using SubSonic.Repository;
using SubSonic.DataProviders;
using StudentTracking.Data.Model;
using StudentTracking.Data.Extensions;
using System.Reflection;

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
				T updatedItem = repository.GetByKey(item.KeyValue());

				Type type = typeof(T);
				PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);

				foreach (PropertyInfo info in propertyInfos)
				{
					// Check if the type is a value type, a nullable value type, or a string. We don't want to update any complicated types
					Type propertyType = info.PropertyType;
					if (propertyType.IsValueType
						|| (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
						|| propertyType == typeof(string))
					{
						// Make sure we don't update any audit columns
						string upperName = info.Name.ToUpperInvariant();
						if(upperName != "CREATEDBY" 
							&& upperName != "CREATEDON"
							&& upperName != "MODIFIEDBY"
							&& upperName != "MODIFIEDON")
						{
							info.SetValue(updatedItem, info.GetValue(item, null), null);
						}						
					}
				}

        updatedItem.Update();
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
