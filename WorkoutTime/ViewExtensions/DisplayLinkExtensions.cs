using System;
using CoreAnimation;

namespace WorkoutTime
{
	public static class DisplayLinkExtensions
	{
		public static void SetPaused (this CADisplayLink displayLink, bool paused)
		{
			displayLink.Paused = paused;
		}
	}
}

