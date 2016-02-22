using System;
using Foundation;
using UIKit;

namespace WorkoutTime
{
	public static class TableViewCellExtensions
	{
		public static T Dequeue<T> (this UITableView tableView, NSIndexPath indexPath, Interval interval)
			where T : UITableViewCell, IIntervalTableViewCell
		{
			var cell = tableView.DequeueReusableCell (typeof (T).Name, indexPath) as T;

			cell.SetData (interval);

			return cell;
		}
	}
}