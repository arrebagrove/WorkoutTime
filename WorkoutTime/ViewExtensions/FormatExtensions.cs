using System;
namespace WorkoutTime
{
	public static class FormatExtensions
	{

		public static string ToTimerFormat (this double time) => $"{Math.Floor (time / 60.0).ToString ("00")}:{(time % 60).ToString ("00.00")}";

	}
}