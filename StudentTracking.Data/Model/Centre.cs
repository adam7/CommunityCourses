using System;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using StudentTracking.Data.Extensions;
using SubSonic.DataProviders;
using xVal.ServerSide;

namespace StudentTracking.Data.Model
{
	public partial class Centre
	{
		public static void Add(Centre centre, Address address)
		{
			using (TransactionScope transactionScope = new TransactionScope())
			{
				using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
				{
					address.Save();
					centre.Address = address;
					centre.Save();

					transactionScope.Complete();
				}
			}
		}
	}
}
