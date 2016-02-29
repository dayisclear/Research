using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTFP.Generator.Constraints;

namespace RTFP.Generator.Constraints
{
	public class ConstraintSet
	{
		private Dictionary<string, Constraint> Constraints { get; set; }

		public ConstraintSet()
		{
			this.Constraints = new Dictionary<string, Constraint>();
		}

		public void Add(string name, Constraint constraint)
		{
			Constraints[name] = constraint;
		}

		public void Remove(string name)
		{ 
			Constraints.Remove(name);
		}

		public Constraint Get(string constraintName)
		{
			return Constraints[constraintName];
		}

		public object GenerateValue(string constraintName)
		{
			return Get(constraintName).ProduceValidValue();
		}

		public bool HasConstraint(string constraintName)
		{
			return Constraints.Keys.Contains(constraintName);
		}		
	}
}