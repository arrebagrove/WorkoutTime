using System;
using System.Collections.Generic;

using Foundation;
using UIKit;

using ServiceStack;

namespace WorkoutTime
{
	public partial class IntervalsTableViewController : UITableViewController
	{
		const string intervalsKey = "com.xamarin.intervalskey";

		List<Interval> _intervals;

		public List<Interval> Intervals {
			get {
				if (_intervals == null) {

					_intervals = NSUserDefaults.StandardUserDefaults.StringForKey (intervalsKey)?
											   .FromJson<List<Interval>> () ?? new List<Interval> ();
				}
				return _intervals;
			}
		}


		public IntervalsTableViewController (IntPtr handle) : base (handle) { }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//UIApplication.Notifications.ObserveDidBecomeActive (HandleDidBecomeActive);
			//UIApplication.Notifications.ObserveDidEnterBackground (HandleDidEnterBackground);
			//UIApplication.Notifications.ObserveWillEnterForeground (HandleWillEnterForeground);
			UIApplication.Notifications.ObserveWillResignActive (HandleWillResignActive);
		}


		public void HandleWillResignActive (object sender, NSNotificationEventArgs e)
		{
			saveIntervals ();
			NSUserDefaults.StandardUserDefaults.Synchronize ();
		}


		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			saveIntervals ();

			setEditing (false, false);
		}


		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);

			saveIntervals ();
		}


		public override nint NumberOfSections (UITableView tableView) => 1;


		public override nint RowsInSection (UITableView tableView, nint section) => Intervals?.Count ?? 0;


		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath) => tableView.Dequeue<IntervalTableViewCell> (indexPath, Intervals [indexPath.Row]);


		public override UITableViewCellEditingStyle EditingStyleForRow (UITableView tableView, NSIndexPath indexPath) => UITableViewCellEditingStyle.Delete;


		public override bool CanMoveRow (UITableView tableView, NSIndexPath indexPath) => true;


		public override void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath) => Intervals.MoveItem (sourceIndexPath.Row, destinationIndexPath.Row);


		public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			Intervals.RemoveItem (indexPath.Row);
			tableView.DeleteRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);
		}


		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var editNavController = Storyboard.Instantiate<EditIntervalNavigationController> ();

			var editTableController = editNavController?.TopViewController as EditIntervalTableViewController;

			editTableController?.SetInterval (Intervals [indexPath.Row]);

			PresentViewController (editNavController, true, null);
		}


		partial void editClicked (NSObject sender) => setEditing (true, true);


		partial void doneClicked (NSObject sender) => setEditing (false, true);


		void setEditing (bool editing, bool animated)
		{
			if (TableView.Editing == editing) return;

			NavigationItem.SetLeftBarButtonItem (editing ? doneButton : editButton, true);

			TableView.SetEditing (editing, animated);
		}


		partial void startClicked (NSObject sender)
		{
			var playNavController = Storyboard.Instantiate<PlayNavigationController> ();

			var playTableController = playNavController?.TopViewController as PlayTableViewController;

			playTableController?.SetIntervals (Intervals);

			PresentViewController (playNavController, true, null);
		}


		partial void addClicked (NSObject sender)
		{
			var editNavController = Storyboard.Instantiate<EditIntervalNavigationController> ();

			PresentViewController (editNavController, true, null);
		}


		void saveIntervals () => NSUserDefaults.StandardUserDefaults.SetString (Intervals.ToJson (), intervalsKey);


		//partial void addClicked (NSObject sender) => doubleList ();

		//void saveIntervals () => Console.WriteLine ("foo");

		void doubleList ()
		{

			List<Interval> list = NSUserDefaults.StandardUserDefaults.StringForKey (intervalsKey)?
															.FromJson<List<Interval>> () ?? new List<Interval> ();

			Console.WriteLine (list.Count);

			foreach (var item in Intervals) {
				list.Add (new Interval (item));
			}

			Console.WriteLine (list.Count);

			NSUserDefaults.StandardUserDefaults.SetString (list.ToJson (), intervalsKey);

			NSUserDefaults.StandardUserDefaults.Synchronize ();

		}
	}
}
