using System;
using UIKit;

namespace WorkoutTime
{
	public static class LabelExtensions
	{
		public static void SetText (this UILabel label, string text)
		{
			label.Text = text;
		}

		public static void SetText (this UILabel label, Enum text)
		{
			label.Text = text.ToString ();
		}

	}
}

