namespace WorkoutTime
{
	public enum IntervalTypes
	{
		Workout,
		Rest
	}

	public class Interval
	{
		public Interval ()
		{
			Enabled = true;
		}

		public Interval (Interval interval)
		{
			Position = interval.Position;
			Enabled = interval.Enabled;
			Title = interval.Title;
			Seconds = interval.Seconds;
			IntervalType = interval.IntervalType;
		}

		public int Position { get; set; }

		public bool Enabled { get; set; }

		public string Title { get; set; }

		public double Seconds { get; set; }

		public IntervalTypes IntervalType { get; set; }

		public string Time {
			get {
				return Seconds.ToString ();// <= 60 ? Seconds : 
			}
		}

		public string TimeDetail {
			get {
				return "Seconds";
				//return Seconds <= 60 ? "Seconds" : "Minutes";
			}
		}

		public string DisplayTitle {
			get {
				return string.IsNullOrWhiteSpace (Title) ? IntervalType.ToString () : Title;
			}
		}
	}
}