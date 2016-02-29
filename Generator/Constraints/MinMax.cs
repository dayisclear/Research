using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTFP.Generator.Constraints
{
	public class MinMax : Constraint
	{
		private int min, max;

		public MinMax(int min, int max)
		{
			this.min = min;
			this.max = max;
		}

		public int ProduceValidValue()
		{
			return GetRandomNumber(min, max);
		}

		public bool isValidValue(object value)
		{
			return isValidValue((int) value);
		}

		public bool isValidValue(int value)
		{
			return (value >= min) && (value <= max);
		}
	}
}