using UIKit;
using CoreText;

namespace WorkoutTime
{
	public static class FontExtensions
	{
		public static UIFont MonospacedNumbers (this UIFont font)
		{
			var attributes = new UIFontAttributes (new UIFontFeature (CTFontFeatureNumberSpacing.Selector.MonospacedNumbers));
			using (var desc = font.FontDescriptor.CreateWithAttributes (attributes)) {
				return UIFont.FromDescriptor (desc, font.PointSize);
			}
		}
	}
}