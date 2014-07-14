
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreMotion;

namespace CoreMotionSample
{
	public partial class AltimeterViewController : UIViewController
	{
		private CMAltimeter altimeter;

		public AltimeterViewController (IntPtr handle) 
			: base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			if (CMAltimeter.IsRelativeAltitudeAvailable) {
				this.altimeter = new CMAltimeter ();

				this.altimeter.StartRelativeAltitudeUpdates (NSOperationQueue.MainQueue, this.UpdateAltitudeData);
			} else {
				this.AltitudeLabel.Text = "Your device does not have required hardware for altitude..";
			}
		}

		private void UpdateAltitudeData(CMAltitudeData data, NSError error)
		{
			this.InvokeOnMainThread (() => {
				this.AltitudeLabel.Text = string.Format ("Your relative altitude is {0}", data.RelativeAltitude);
			});
		}
	}
}

