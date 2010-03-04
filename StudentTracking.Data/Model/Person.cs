using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StudentTracking.Data.Model
{
	public partial class Person
	{
		public string Name
		{
			get { return string.Format("{0} {1} {2}", Title, FirstName, LastName); }
		}

		public static List<Person> GetAllTutors()
		{
			IQueryable<Person> query = from people in Person.All()
																 join tutors in Tutor.All()
																 on people.Id equals tutors.PersonId
																 select people;
			return query.ToList();
		}

		public static List<Person> GetAllVerifiers()
		{
			IQueryable<Person> query = from people in Person.All()
																 join verifiers in Verifier.All()
																 on people.Id equals verifiers.PersonId
																 select people;
			return query.ToList();
		}

		public List<Disability> Disabilities
		{
			get
			{
				return (from disabilities in Disability.All()
							 join personDisabilities in PersonDisability.All() on disabilities.Id equals personDisabilities.DisabilityId
							 where personDisabilities.PersonId == Id
							 select disabilities)
							 .ToList();
			}
		}

		public void SetDisabilities(IEnumerable<string> disabilityNames)
		{
			// TODO: This here's pretty messy, should probably work out a way to clean and make it atomic
			// and check whether anything needs updating before we go ahead .. ho hum

			// Clear the existing disabilities for this person
			PersonDisability.Delete(personDisability => personDisability.PersonId == Id);

			// Get all the disabilites that're specified
			IList<Disability> disabilities = Disability.All()
				.Where(disability => disabilityNames.Contains(disability.Name)).ToList(); 

			// Create a PersonDisability for each disability and save them all
			IList<PersonDisability> personDisabilities = new List<PersonDisability>();
			foreach (Disability disability in disabilities)
			{
				personDisabilities.Add(new PersonDisability { PersonId = Id, DisabilityId = disability.Id });
			}
			PersonDisability.GetRepo().Add(personDisabilities);
		}
	}
}
