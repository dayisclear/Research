using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTFP.Generator.Constraints;

namespace RTFP.Generator.FloorPlan
{
	interface Generator
	{
		ConstraintSet Constraints { get; set; }
		FloorPlan GenerateFloorPlan();
	}
}
