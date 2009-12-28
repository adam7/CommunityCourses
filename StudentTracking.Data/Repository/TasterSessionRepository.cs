using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentTracking.Data.Model;
using System.Transactions;
using SubSonic.DataProviders;

namespace StudentTracking.Data.Repository
{
	public class TasterSessionRepository : RepositoryBase<TasterSession>
	{
		public void AddStudentToTasterSession(int studentId, int id)
		{
			StudentTasterSession studentTasterSession = 
				new StudentTasterSession { StudentId = studentId, TasterSessionId = id, };

			studentTasterSession.Save();
		}
	}
}
