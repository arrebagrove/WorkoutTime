using System.Collections.Generic;
namespace WorkoutTime
{
	public static class TestData
	{
		public static List<Interval> Intervals = new List<Interval> {
			new Interval {
				Enabled = true,
				IntervalType = IntervalTypes.Workout,
				Position = 0,
				Seconds = 10
			},
			new Interval {
				Enabled = true,
				IntervalType = IntervalTypes.Rest,
				Position = 1,
				Seconds = 5
			},
			new Interval {
				Enabled = true,
				IntervalType = IntervalTypes.Workout,
				Position = 2,
				Seconds = 10
			},
			new Interval {
				Enabled = false,
				IntervalType = IntervalTypes.Rest,
				Position = 3,
				Seconds = 5
			},
			new Interval {
				Enabled = true,
				IntervalType = IntervalTypes.Workout,
				Position = 4,
				Seconds = 10
			}
			//new Interval {
			//	Enabled = true,
			//	IntervalType = IntervalTypes.Rest,
			//	Position = 5,
			//	Seconds = 5
			//},
			//new Interval {
			//	Enabled = false,
			//	IntervalType = IntervalTypes.Workout,
			//	Position = 6,
			//	Seconds = 10
			//},
			//new Interval {
			//	Enabled = true,
			//	IntervalType = IntervalTypes.Rest,
			//	Position = 7,
			//	Seconds = 5
			//},
			//new Interval {
			//	Enabled = true,
			//	IntervalType = IntervalTypes.Workout,
			//	Position = 8,
			//	Seconds = 10
			//},
			//new Interval {
			//	Enabled = false,
			//	IntervalType = IntervalTypes.Rest,
			//	Position = 9,
			//	Seconds = 5
			//},
			//new Interval {
			//	Enabled = true,
			//	IntervalType = IntervalTypes.Workout,
			//	Position = 10,
			//	Seconds = 10
			//},
			//new Interval {
			//	Enabled = true,
			//	IntervalType = IntervalTypes.Rest,
			//	Position = 11,
			//	Seconds = 5
			//},
			//new Interval {
			//	Enabled = true,
			//	IntervalType = IntervalTypes.Workout,
			//	Position = 12,
			//	Seconds = 10
			//},
			//new Interval {
			//	Enabled = true,
			//	IntervalType = IntervalTypes.Rest,
			//	Position = 13,
			//	Seconds = 5
			//},
			//new Interval {
			//	Enabled = true,
			//	IntervalType = IntervalTypes.Workout,
			//	Position = 14,
			//	Seconds = 10
			//},
			//new Interval {
			//	Enabled = false,
			//	IntervalType = IntervalTypes.Rest,
			//	Position = 5,
			//	Seconds = 5
			//},
			//new Interval {
			//	Enabled = true,
			//	IntervalType = IntervalTypes.Workout,
			//	Position = 16,
			//	Seconds = 10
			//},
			//new Interval {
			//	Enabled = true,
			//	IntervalType = IntervalTypes.Rest,
			//	Position = 17,
			//	Seconds = 5
			//}
		};
	}
}