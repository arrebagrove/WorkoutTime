// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WorkoutTime
{
	[Register ("IntervalsTableViewController")]
	partial class IntervalsTableViewController
	{
		[Outlet]
		UIKit.UIBarButtonItem doneButton { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem editButton { get; set; }

		[Outlet]
		UIKit.UIButton startButton { get; set; }

		[Action ("addClicked:")]
		partial void addClicked (Foundation.NSObject sender);

		[Action ("doneClicked:")]
		partial void doneClicked (Foundation.NSObject sender);

		[Action ("editClicked:")]
		partial void editClicked (Foundation.NSObject sender);

		[Action ("startClicked:")]
		partial void startClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (doneButton != null) {
				doneButton.Dispose ();
				doneButton = null;
			}

			if (editButton != null) {
				editButton.Dispose ();
				editButton = null;
			}

			if (startButton != null) {
				startButton.Dispose ();
				startButton = null;
			}
		}
	}
}
