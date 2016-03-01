using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTFP.Generator.Constraints
{
	public abstract class Constraint
	{
		public abstract object ProduceValidValue();
		public abstract bool isValidValue(object value);

		private static Random _random = new Random();
		public static int GetRandomNumber(int min, int max)
		{
			return _random.Next(min, max + 1);
		}
	}
}