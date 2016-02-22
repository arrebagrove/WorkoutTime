using System;
using System.Collections.Generic;

namespace WorkoutTime
{
	public static class IntervalExtensions
	{
		public static bool IsNullOrEmpty (this List<Interval> intervals) => intervals != null && intervals.Count > 0;


		public static void RefreshPositions (this List<Interval> intervals)
		{
			for (int i = 0; i < intervals.Count; i++) intervals [i].Position = i;
		}


		public static void AddItem (this List<Interval> intervals, Interval item)
		{
			intervals.Add (item);

			intervals.RefreshPositions ();
		}


		public static void MoveItem (this List<Interval> intervals, int from, int to)
		{
			var interval = intervals [from];

			intervals.RemoveAt (from);
			intervals.Insert (to, interval);

			intervals.RefreshPositions ();
		}


		public static void RemoveItem (this List<Interval> intervals, int at)
		{
			intervals.RemoveAt (at);

			intervals.RefreshPositions ();
		}
	}
}