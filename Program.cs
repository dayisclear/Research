using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using RTFP.DataStructures;
using RTFP.Generator.FloorPlan;


namespace RTFP
{
	static class Program
	{
		static void Main()
		{
			SuburbanGenerator generator = new SuburbanGenerator();
			FloorPlan fp = generator.GenerateFloorPlan();

			Console.WriteLine(fp);
		}
	}
}
