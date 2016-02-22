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
	[Register ("PlayTableViewCell")]
	partial class PlayTableViewCell
	{
		[Outlet]
		UIKit.UILabel intervalTimeLabel { get; set; }

		[Outlet]
		UIKit.UILabel intervalTitleLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (intervalTimeLabel != null) {
				intervalTimeLabel.Dispose ();
				intervalTimeLabel = null;
			}

			if (intervalTitleLabel != null) {
				intervalTitleLabel.Dispose ();
				intervalTitleLabel = null;
			}
		}
	}
}
