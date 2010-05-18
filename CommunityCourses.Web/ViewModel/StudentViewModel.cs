using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityCourses.Data.Model;
using AutoMapper;

namespace CommunityCourses.Web.ViewModel
{
	public class StudentViewModel
	{
		public StudentViewModel() : this(null) { }

		public StudentViewModel(Student student)
		{
			if (student != null)
			{
				Id = student.Id;
				Person person = student.Person;
				this.Person = Mapper.Map<Person, PersonViewModel>(person);
				this.Address = Mapper.Map<Address, AddressViewModel>(person.Address);
			}
			else
			{
				Person = new PersonViewModel();
				Address = new AddressViewModel();
			}
		}

		public int Id { get; set; }
		public PersonViewModel Person { get; set; }
		public AddressViewModel Address { get; set; }
	}
}
