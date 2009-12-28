using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentTracking.Data.Model;

namespace StudentTracking.Data.Repository
{
  public class VerifierRepository : RepositoryBase<Verifier>
  {
    //new public List<Person> GetPaged(int page)
    //{
    //  IQueryable<Person> query = from people in Person.All()
    //                             join verifiers in Verifier.All()
    //                             on people.Id equals verifiers.PersonId
    //                             orderby PersonTable.LastNameColumn
    //                             select people;
    //  return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    //}

    //new public Person Get(int id)
    //{
    //  IQueryable<Person> query = from people in Person.All()
    //                             join verifiers in Verifier.All()
    //                             on people.Id equals verifiers.PersonId
    //                             where people.Id == id
    //                             select people;
    //  return query.FirstOrDefault();
    //}
  }
}
