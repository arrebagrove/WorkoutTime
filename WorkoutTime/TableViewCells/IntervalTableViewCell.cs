using System;

using CoreGraphics;
using Foundation;
using UIKit;

namespace WorkoutTime
{
	public partial class IntervalTableViewCell : UITableViewCell, IIntervalTableViewCell
	{
		CGRect accessoryFrame;

		public Interval Interval { get; set; }

		public IntervalTableViewCell (IntPtr handle) : base (handle) { }


		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			if (AccessoryView is UISwitch) {

				// TODO: This is fucked

				if ((AccessoryView.Frame.X > 0 && AccessoryView.Frame.Y > 0) &&
					(accessoryFrame.IsEmpty || accessoryFrame.X < AccessoryView.Frame.X || accessoryFrame.X > Frame.Width)) {

					accessoryFrame = AccessoryView.Frame;

				} else if (AccessoryView.Frame.X <= accessoryFrame.X) {

					AccessoryView.Frame = accessoryFrame;
				}
			}
		}


		public void SetData (Interval interval)
		{
			Interval = interval;

			intervalTimeLabel.Text = Interval.Time;
			intervalDetailLabel.Text = Interval.TimeDetail;
			intervalTypeLabel.Text = Interval.DisplayTitle;

			var enabledSwitch = AccessoryView as UISwitch;

			if (enabledSwitch != null) enabledSwitch.On = Interval.Enabled;

			setEnabledState ();
		}


		partial void intervalTypeSwitchValueChanged (NSObject sender)
		{
			var enabledSwitch = AccessoryView as UISwitch;

			if (enabledSwitch != null) Interval.Enabled = enabledSwitch.On;

			setEnabledState ();
		}


		void setEnabledState ()
		{
			intervalTimeLabel.Enabled = Interval.Enabled;
			intervalDetailLabel.Enabled = Interval.Enabled;
			intervalTypeLabel.Enabled = Interval.Enabled;
		}
	}
}