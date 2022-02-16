using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.Library.Models
{
    public class Common
    {
		public enum Entity
		{
			Initial,
			Category,
			Leads
		}

		public static int Skip(int skip, int limit)
		{
			return skip - limit;
		}
	}
}
