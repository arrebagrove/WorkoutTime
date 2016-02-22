using System;
using System.Collections.Generic;
using System.Linq;

using AVFoundation;
using CoreAnimation;
using Foundation;
using UIKit;

namespace WorkoutTime
{
	public partial class PlayTableViewController : UITableViewController
	{
		const string emptyTimeString = "00:00.00";
		const string tapToStartString = "tap to start";

		public Interval Interval { get; set; }

		public List<Interval> Intervals { get; set; }

		public List<Interval> IntervalQueue { get; set; }

		AVAudioPlayer audioPlayerStart;
		AVAudioPlayer audioPlayerStop;

		CADisplayLink displayLink;

		double totalSeconds, totalSecondsFinished, timestampBase, pauseOffset, timeIncrement;


		public PlayTableViewController (IntPtr handle) : base (handle) { }


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			AVAudioSession.SharedInstance ().SetCategory (AVAudioSessionCategory.Ambient);

			var soundUrlStart = NSUrl.FromFilename ("robot-start.wav");
			var soundUrlStop = NSUrl.FromFilename ("robot-stop.wav");

			audioPlayerStart = AVAudioPlayer.FromUrl (soundUrlStart);
			audioPlayerStop = AVAudioPlayer.FromUrl (soundUrlStop);

			totalTimeLabel.Font = totalTimeLabel.Font.MonospacedNumbers ();

			currentIntervalTimeLabel.Font = currentIntervalTimeLabel.Font.MonospacedNumbers ();
		}


		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);

			killDisplayLink ();
		}


		public void SetIntervals (List<Interval> intervals)
		{
			Intervals = intervals;

			refreshIntervalQueue ();
		}


		public override nint NumberOfSections (UITableView tableView) => 1;


		public override nint RowsInSection (UITableView tableView, nint section) => IntervalQueue?.Count ?? 0;


		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath) => tableView.Dequeue<PlayTableViewCell> (indexPath, IntervalQueue [indexPath.Row]);


		public override nfloat GetHeightForHeader (UITableView tableView, nint section) => currentIntervalView.Frame.Height;


		public override UIView GetViewForHeader (UITableView tableView, nint section) => currentIntervalView;


		partial void refreshClicked (NSObject sender) => refreshIntervalQueue ();


		partial void doneClicked (NSObject sender) => DismissViewController (true, null);


		partial void currentIntervalButton (NSObject sender)
		{
			timestampBase = 0;


			if (displayLink != null) {

				displayLink.Paused = !displayLink.Paused;

				if (displayLink.Paused) pauseOffset = timeIncrement;

			} else {

				incrementInterval ();
			}
		}


		void refreshIntervalQueue (bool complete = false)
		{
			killDisplayLink ();

			IntervalQueue = Intervals?.Where (i => i.Enabled).ToList () ?? new List<Interval> ();

			totalSeconds = 0;
			totalSecondsFinished = 0;
			timestampBase = 0;
			pauseOffset = 0;

			foreach (var interval in IntervalQueue) totalSeconds += interval.Seconds;

			totalTimeLabel.Text = totalSeconds.ToTimerFormat ();

			currentIntervalTimeLabel.Text = complete ? "Complete!" : tapToStartString;

			currentIntervalTitleLabel.Text = $"{IntervalQueue.Count} Intervals";
			currentIntervalTotalTimeLabel.Text = $"{totalSeconds} Seconds";

			currentIntervalView.BackgroundColor = UIColor.White;

			totalProgressView.Progress = 0;

			TableView?.ReloadData ();
		}


		void incrementInterval ()
		{
			timestampBase = 0;
			pauseOffset = 0;

			Interval = IntervalQueue?.FirstOrDefault ();

			if (Interval != null) {

				if (Interval.IntervalType == IntervalTypes.Workout) {

					audioPlayerStart.Play ();

				} else {

					audioPlayerStop.Play ();
				}

				totalSecondsFinished += Interval?.Seconds ?? 0;

				IntervalQueue.Remove (Interval);

				TableView.DeleteRows (new [] { NSIndexPath.FromRowSection (0, 0) }, UITableViewRowAnimation.Automatic);

				currentIntervalTitleLabel.Text = Interval.DisplayTitle;

				currentIntervalTotalTimeLabel.Text = $"{Interval.Time} {Interval.TimeDetail}";

				currentIntervalTimeLabel.Text = Interval.Seconds.ToTimerFormat ();

				currentIntervalView.BackgroundColor = (Interval.IntervalType == IntervalTypes.Workout) ? UIColor.Green : UIColor.Yellow;

				initDisplayLink ();

			} else {

				refreshIntervalQueue (true);
			}
		}


		void initDisplayLink ()
		{
			if (displayLink == null) {

				displayLink = CADisplayLink.Create (updateTime);
				displayLink.AddToRunLoop (NSRunLoop.Current, NSRunLoopMode.Default);
			}
		}


		void killDisplayLink ()
		{
			totalTimeLabel?.SetText (emptyTimeString);
			currentIntervalTimeLabel?.SetText (tapToStartString);

			displayLink?.Invalidate ();
			displayLink = null;
		}


		void updateTime ()
		{
			if (Math.Abs (timestampBase) < double.Epsilon) timestampBase = displayLink.Timestamp;

			timeIncrement = (displayLink.Timestamp - timestampBase) + pauseOffset;

			var remaining = Interval.Seconds - timeIncrement;

			var totalProgress = totalSecondsFinished - remaining;

			if (remaining <= 0) {

				incrementInterval ();

				remaining = 0;

			} else {

				totalProgressView.Progress = (float)(totalProgress / totalSeconds);

				totalTimeLabel.Text = (totalSeconds - totalProgress).ToTimerFormat ();

				currentIntervalTimeLabel.Text = remaining.ToTimerFormat ();
			}
		}


		protected override void Dispose (bool disposing)
		{
			if (disposing) killDisplayLink ();

			base.Dispose (disposing);
		}
	}
}
