
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace CoreMotionSample
{
	public partial class FloorsViewController : UIViewController
	{

		private CLLocationManager locationManager;
		private LocationManagerDelegate locationManagerDelegate;
		public FloorsViewController (IntPtr handle) 
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
			
			this.locationManager = new CLLocationManager ();
			this.locationManagerDelegate = new LocationManagerDelegate ((location) => 
				{
					if(location.Floor != null){
						this.FloorLabel.Text = string.Format("You are currently on floor {0}", location.Floor.Level);
					} else {
						this.FloorLabel.Text = string.Format("You are currently {0:0.00} meters above sea level", location.Altitude);
					}
				});

			this.locationManager.Delegate = this.locationManagerDelegate;
			this.locationManager.RequestAlwaysAuthorization ();
			this.locationManager.StartUpdatingLocation ();
		}
	}

	class LocationManagerDelegate : CLLocationManagerDelegate
	{
		private Action<CLLocation> locationChangedAction;

		public LocationManagerDelegate (Action<CLLocation> locationChangedAction)
		{
			this.locationChangedAction = locationChangedAction;
		}

		public override void LocationsUpdated (CLLocationManager manager, CLLocation[] locations)
		{
			var location = locations [0];
			var floor = location.Floor;

			this.InvokeOnMainThread(() =>{
				this.locationChangedAction (location);
			});

		}
	}
}

