﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommunityCourses.Web.Model
{
	public class CourseSession : Session
	{
		public string CourseId { get; set; }
		public bool Complete { get; set; }
	}
}
