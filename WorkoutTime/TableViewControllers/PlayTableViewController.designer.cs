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
	[Register ("PlayTableViewController")]
	partial class PlayTableViewController
	{
		[Outlet]
		UIKit.UILabel currentIntervalTimeLabel { get; set; }

		[Outlet]
		UIKit.UILabel currentIntervalTitleLabel { get; set; }

		[Outlet]
		UIKit.UILabel currentIntervalTotalTimeLabel { get; set; }

		[Outlet]
		UIKit.UIView currentIntervalView { get; set; }

		[Outlet]
		UIKit.UIProgressView totalProgressView { get; set; }

		[Outlet]
		UIKit.UILabel totalTimeLabel { get; set; }

		[Action ("currentIntervalButton:")]
		partial void currentIntervalButton (Foundation.NSObject sender);

		[Action ("doneClicked:")]
		partial void doneClicked (Foundation.NSObject sender);

		[Action ("refreshClicked:")]
		partial void refreshClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (currentIntervalTimeLabel != null) {
				currentIntervalTimeLabel.Dispose ();
				currentIntervalTimeLabel = null;
			}

			if (currentIntervalTitleLabel != null) {
				currentIntervalTitleLabel.Dispose ();
				currentIntervalTitleLabel = null;
			}

			if (currentIntervalTotalTimeLabel != null) {
				currentIntervalTotalTimeLabel.Dispose ();
				currentIntervalTotalTimeLabel = null;
			}

			if (currentIntervalView != null) {
				currentIntervalView.Dispose ();
				currentIntervalView = null;
			}

			if (totalProgressView != null) {
				totalProgressView.Dispose ();
				totalProgressView = null;
			}

			if (totalTimeLabel != null) {
				totalTimeLabel.Dispose ();
				totalTimeLabel = null;
			}
		}
	}
}
