using System;
using System.Linq;

using Foundation;
using UIKit;

namespace WorkoutTime
{
	public partial class EditIntervalTableViewController : UITableViewController, IUIPickerViewDelegate, IUIPickerViewDataSource
	{
		nint minutes, seconds;

		Interval workingInterval;

		public Interval Interval { get; set; }


		public EditIntervalTableViewController (IntPtr handle) : base (handle) { }


		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			if (workingInterval == null) workingInterval = new Interval ();

			setIntervalData ();
		}


		public void SetInterval (Interval interval)
		{
			Interval = interval;
			workingInterval = new Interval (interval);
		}


		public void setIntervalData ()
		{
			intervalTitleTextField.Text = workingInterval.Title ?? string.Empty;

			intervalTitleTextField.Placeholder = workingInterval.IntervalType.ToString ();

			intervalTypeSegmentedControl.SelectedSegment = (int)workingInterval.IntervalType;

			intervalTimePickerView.Select ((nint)Math.Floor (workingInterval.Seconds / 60.0), 0, false);
			intervalTimePickerView.Select ((nint)workingInterval.Seconds % 60, 1, false);
		}


		public nint GetComponentCount (UIPickerView pickerView) => 3;


		public nint GetRowsInComponent (UIPickerView pickerView, nint component) => (component < 2) ? 60 : 0;


		[Export ("pickerView:titleForRow:forComponent:")]
		public string GetTitle (UIPickerView pickerView, nint row, nint component) => row.ToString ();


		[Export ("pickerView:didSelectRow:inComponent:")]
		public void Selected (UIPickerView pickerView, nint row, nint component)
		{
			minutes = pickerView.SelectedRowInComponent (0);
			seconds = pickerView.SelectedRowInComponent (1);

			workingInterval.Seconds = (minutes * 60) + seconds;

			Console.WriteLine ($"{minutes} min {seconds} sec  ==  {workingInterval.Seconds}");
		}


		partial void intervalTypeSegmentedControlChanged (NSObject sender)
		{
			workingInterval.IntervalType = (IntervalTypes)((int)intervalTypeSegmentedControl.SelectedSegment);

			intervalTitleTextField.Placeholder = workingInterval.IntervalType.ToString ();
		}

		public override nfloat GetHeightForFooter (UITableView tableView, nint section) => 1;


		partial void cancelClicked (NSObject sender) => DismissViewController (true, null);


		partial void saveClicked (NSObject sender)
		{
			var navController = PresentingViewController as UINavigationController;

			var intervalController = navController?.TopViewController as IntervalsTableViewController;

			if (Interval == null) {

				workingInterval.Title = intervalTitleTextField.Text;

				intervalController?.Intervals.AddItem (workingInterval);

				DismissViewController (true, () => intervalController?.TableView?.InsertRows (new [] {
					NSIndexPath.FromRowSection (intervalController?.Intervals?.LastOrDefault ()?.Position ?? 0, 0)
				}, UITableViewRowAnimation.Automatic));

			} else {

				// Interval.Position = workingInterval.Position;
				// Interval.Enabled = workingInterval.Enabled;


				Interval.Title = intervalTitleTextField.Text; //workingInterval.Title;
				Interval.Seconds = workingInterval.Seconds;
				Interval.IntervalType = workingInterval.IntervalType;

				DismissViewController (true, () => intervalController?.TableView?.ReloadRows (new [] {
					NSIndexPath.FromRowSection (Interval.Position, 0)
				}, UITableViewRowAnimation.Automatic));
			}
		}
	}
}