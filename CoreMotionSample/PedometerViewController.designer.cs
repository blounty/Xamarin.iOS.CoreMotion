// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace CoreMotionSample
{
	[Register ("PedometerViewController")]
	partial class PedometerViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel DistanceLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel FloorsAscendedLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel FloorsDescendedLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel SpeedLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel StepsLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DistanceLabel != null) {
				DistanceLabel.Dispose ();
				DistanceLabel = null;
			}

			if (SpeedLabel != null) {
				SpeedLabel.Dispose ();
				SpeedLabel = null;
			}

			if (StepsLabel != null) {
				StepsLabel.Dispose ();
				StepsLabel = null;
			}

			if (FloorsAscendedLabel != null) {
				FloorsAscendedLabel.Dispose ();
				FloorsAscendedLabel = null;
			}

			if (FloorsDescendedLabel != null) {
				FloorsDescendedLabel.Dispose ();
				FloorsDescendedLabel = null;
			}
		}
	}
}
