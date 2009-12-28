using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentTracking.Data.Model;

namespace StudentTracking.Data.Repository
{
  public class PersonRepository : RepositoryBase<Person>
  {
    new public List<Person> GetAllTutors()
    {
      IQueryable<Person> query = from people in Person.All()
                                 join tutors in Tutor.All()
                                 on people.Id equals tutors.PersonId
                                 select people;
      return query.ToList();
    }

    new public List<Person> GetAllVerifiers()
    {
      IQueryable<Person> query = from people in Person.All()
                                 join verifiers in Verifier.All()
                                 on people.Id equals verifiers.PersonId
                                 select people;
      return query.ToList();
    }
  }
}
