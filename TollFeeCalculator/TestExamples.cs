using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator
{
	public class TestExamples
	{
		public List<Example> Examples = new List<Example>();

		public TestExamples()
		{
			Examples.Add(new Example { Vehicle = VehicleType.Car, PassageTimes = new List<DateTime> { DateTime.Parse("2022-03-16 08:35"), DateTime.Parse("2022-03-16 10:15"), DateTime.Parse("2022-03-16 15:45") } });
			Examples.Add(new Example { Vehicle = VehicleType.Car, PassageTimes = new List<DateTime> { DateTime.Parse("2022-03-16 10:35"), DateTime.Parse("2022-03-16 10:50"), DateTime.Parse("2022-03-16 17:45") } });
			Examples.Add(new Example { Vehicle = VehicleType.Car, PassageTimes = new List<DateTime> { DateTime.Parse("2022-03-19 10:35"), DateTime.Parse("2022-03-19 10:50"), DateTime.Parse("2022-03-19 17:45") } }); // Lördag
			Examples.Add(new Example { Vehicle = VehicleType.Car, PassageTimes = new List<DateTime> { DateTime.Parse("2022-03-20 10:35"), DateTime.Parse("2022-03-20 10:50"), DateTime.Parse("2022-03-20 17:45") } }); // Söndag
			Examples.Add(new Example { Vehicle = VehicleType.Car, PassageTimes = new List<DateTime> { DateTime.Parse("2022-04-18 10:35"), DateTime.Parse("2022-04-18 10:50"), DateTime.Parse("2022-04-18 17:45") } }); // Annandag påsk
			Examples.Add(new Example { Vehicle = VehicleType.Car, PassageTimes = new List<DateTime> { DateTime.Parse("2022-05-26 10:35"), DateTime.Parse("2022-05-26 10:50"), DateTime.Parse("2022-05-26 17:45") } }); // Kristi flygare
			Examples.Add(new Example { Vehicle = VehicleType.Car, PassageTimes = new List<DateTime> { DateTime.Parse("2022-06-24 10:35"), DateTime.Parse("2022-06-24 10:50"), DateTime.Parse("2022-06-24 17:45") } }); // Midsommarafton
			Examples.Add(new Example { Vehicle = VehicleType.Car, PassageTimes = new List<DateTime> { DateTime.Parse("2022-07-18 10:35"), DateTime.Parse("2022-07-18 10:50"), DateTime.Parse("2022-07-18 17:45") } }); // SEMESTER!
			Examples.Add(new Example { Vehicle = VehicleType.Car, PassageTimes = new List<DateTime> { DateTime.Parse("2022-11-04 10:35"), DateTime.Parse("2022-11-04 10:50"), DateTime.Parse("2022-11-04 17:45") } }); // Alla helgona
			Examples.Add(new Example { Vehicle = VehicleType.Diplomat, PassageTimes = new List<DateTime> { DateTime.Parse("2022-03-19 10:35"), DateTime.Parse("2022-03-19 10:50"), DateTime.Parse("2022-03-19 17:45") } }); // Diplomat
			Examples.Add(new Example { Vehicle = VehicleType.Motorbike, PassageTimes = new List<DateTime> { DateTime.Parse("2022-03-16 08:35"), DateTime.Parse("2022-03-16 10:15"), DateTime.Parse("2022-03-16 15:45") } }); // Motorbike
			Examples.Add(new Example { Vehicle = VehicleType.Car, PassageTimes = new List<DateTime> { DateTime.Parse("2023-04-10 10:35"), DateTime.Parse("2023-04-10 10:50"), DateTime.Parse("2023-04-10 17:45") } }); // Annandag påsk 2023
			Examples.Add(new Example { Vehicle = VehicleType.Car, PassageTimes = new List<DateTime> { DateTime.Parse("2023-04-11 10:35"), DateTime.Parse("2023-04-11 10:50"), DateTime.Parse("2023-04-11 17:45") } }); // Annandag påsk 2023
			Examples.Add(new Example { Vehicle = VehicleType.Car, PassageTimes = new List<DateTime> { DateTime.Parse("2022-03-16 6:35"), DateTime.Parse("2022-03-16 7:20"), DateTime.Parse("2022-03-16 7:55"), DateTime.Parse("2022-03-16 15:45"), DateTime.Parse("2022-03-16 16:55"), DateTime.Parse("2022-03-16 18:25"), DateTime.Parse("2022-03-16 20:45") } });
		}
	}

	public class Example
	{
		public VehicleType Vehicle { get; set; }
		public List<DateTime> PassageTimes { get; set; }

	}

}
