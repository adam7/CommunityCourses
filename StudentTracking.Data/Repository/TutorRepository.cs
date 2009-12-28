using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentTracking.Data.Model;

namespace StudentTracking.Data.Repository
{
  public class TutorRepository : RepositoryBase<Tutor>
  {
    //new public List<Person> GetPaged(int page)
    //{
    //  IQueryable<Person> query = from people in Person.All()
    //                             join tutors in Tutor.All()
    //                             on people.Id equals tutors.PersonId
    //                             orderby PersonTable.LastNameColumn
    //                             select people;
    //  return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    //}

    //new public Person Get(int id)
    //{
    //  IQueryable<Person> query = from people in Person.All()
    //                             join tutors in Tutor.All()
    //                             on people.Id equals tutors.PersonId
    //                             where people.Id == id
    //                             select people;
    //  return query.FirstOrDefault();
    //}
  }
}
