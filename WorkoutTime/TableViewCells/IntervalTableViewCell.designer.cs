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
	[Register ("IntervalTableViewCell")]
	partial class IntervalTableViewCell
	{
		[Outlet]
		UIKit.UILabel intervalDetailLabel { get; set; }

		[Outlet]
		UIKit.UILabel intervalTimeLabel { get; set; }

		[Outlet]
		UIKit.UILabel intervalTypeLabel { get; set; }

		[Action ("intervalTypeSwitchValueChanged:")]
		partial void intervalTypeSwitchValueChanged (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (intervalDetailLabel != null) {
				intervalDetailLabel.Dispose ();
				intervalDetailLabel = null;
			}

			if (intervalTimeLabel != null) {
				intervalTimeLabel.Dispose ();
				intervalTimeLabel = null;
			}

			if (intervalTypeLabel != null) {
				intervalTypeLabel.Dispose ();
				intervalTypeLabel = null;
			}
		}
	}
}
