
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreMotion;

namespace CoreMotionSample
{
	public partial class PedometerViewController : UIViewController
	{
		private CMPedometer pedometer;
		public PedometerViewController (IntPtr handle) 
			: base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.pedometer = new CMPedometer ();
			this.pedometer.StartPedometerUpdates (new NSDate (), this.UpdatePedometerData);

			var data  = await this.pedometer.QueryPedometerDataAsync (DateTime.SpecifyKind (DateTime.Now.AddHours(-24), DateTimeKind.Utc), DateTime.Now);

			this.UpdatePedometerData(data, null);
		}

		private void UpdatePedometerData(CMPedometerData data, NSError error)
		{
			if (error == null) {
				this.InvokeOnMainThread (() => {
					this.StepsLabel.Text = string.Format ("You have taken {0:0.00} steps", data.NumberOfSteps);

					this.DistanceLabel.Text = string.Format ("You have travelled {0:0.00} meters", data.Distance.DoubleValue);

					var endTime = DateTime.SpecifyKind(data.EndDate, DateTimeKind.Utc);
					var startTime = DateTime.SpecifyKind(data.StartDate , DateTimeKind.Utc);
					var time = endTime.Subtract(startTime);
					var speed = data.Distance.DoubleValue / time.TotalSeconds;
					this.SpeedLabel.Text = string.Format ("Your speed was {0:0.00} meters a second", speed);

					this.FloorsAscendedLabel.Text = string.Format("You have ascended {0} floors", data.FloorsAscended);

					this.FloorsDescendedLabel.Text = string.Format("You have descended {0} floors", data.FloorsDescended);
				});
			}
		}
	}
}

