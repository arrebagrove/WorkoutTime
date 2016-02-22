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
	[Register ("EditIntervalTableViewController")]
	partial class EditIntervalTableViewController
	{
		[Outlet]
		UIKit.UIPickerView intervalTimePickerView { get; set; }

		[Outlet]
		UIKit.UITextField intervalTitleTextField { get; set; }

		[Outlet]
		UIKit.UISegmentedControl intervalTypeSegmentedControl { get; set; }

		[Action ("cancelClicked:")]
		partial void cancelClicked (Foundation.NSObject sender);

		[Action ("intervalTypeSegmentedControlChanged:")]
		partial void intervalTypeSegmentedControlChanged (Foundation.NSObject sender);

		[Action ("saveClicked:")]
		partial void saveClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (intervalTimePickerView != null) {
				intervalTimePickerView.Dispose ();
				intervalTimePickerView = null;
			}

			if (intervalTitleTextField != null) {
				intervalTitleTextField.Dispose ();
				intervalTitleTextField = null;
			}

			if (intervalTypeSegmentedControl != null) {
				intervalTypeSegmentedControl.Dispose ();
				intervalTypeSegmentedControl = null;
			}
		}
	}
}
