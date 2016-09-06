// This file has been autogenerated from a class added in the UI designer.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Timers; 

using Foundation;
using CoreFoundation; 
using AVFoundation;
using UIKit;
using CoreVideo;
using CoreMedia;
using CoreGraphics;

namespace FinanceCalculator
{
	public partial class CameraController : UIViewController
	{
		UIImageView cameraImage = new UIImageView();

		#region control variables 
		private NSError Error;
		private bool Automatic = true; 
		#endregion

		#region Computed Properties
		public AppDelegate CameraControllerApp {
			get {
				return (AppDelegate)UIApplication.SharedApplication.Delegate; 
			}
		}

		public Timer SampleTimer { get; set;}

		#endregion



		public CameraController(IntPtr handle) : base(handle){}

		public CameraController() { }

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			this.NavigationController.SetNavigationBarHidden(false, true);

			cameraImage.Image = CameraControllerApp.Recorder.DisplayView.Image;
			//starts updating the display 
			if(CameraControllerApp.CameraAvailable) {
				CameraControllerApp.Recorder.DisplayView = cameraImage;

				CameraControllerApp.Session.StartRunning();
				SampleTimer.Start();
			}
		}

		public override void ViewDidLoad()
		{
			try {
				if(cameraImage == null) {
					throw new NullReferenceException();
				}
				else {
			CameraControllerApp.Recorder.DisplayView = cameraImage;		
					CameraControllerApp.CaptureDevice.FocusMode = AVCaptureFocusMode.ContinuousAutoFocus;
				}
			}
			catch(NullReferenceException) {
				Console.WriteLine("Null image view detected");
			}

			/*
			 * Check the storyboard and create segues to the controllers that you need to pop the controller to 

			*/


			//add a timer to monitor and update the UI 
			SampleTimer = new Timer(5000); 
			SampleTimer.Elapsed += (object sender, ElapsedEventArgs e) => {
			};

	
			SampleTimer.Start();
			Automatic = true;

			//locks device in continuous auto focus mode
			try {
				if(CameraControllerApp.CaptureDevice == null) {
					throw new NullReferenceException();
				}
				else {
					CameraControllerApp.CaptureDevice.LockForConfiguration(out Error); 
				}
			}
			catch(NullReferenceException) {
				Console.WriteLine("WTF!");
			}

		}
	}
	//This class will monitor the sample buffer that contains the images that are 
	//updated from the camera, thus to render a video on the UIImageView

	public class OutputRecorder : AVCaptureVideoDataOutputSampleBufferDelegate
	{

		#region image to update
		public UIImageView DisplayView { get; set; }

		#endregion

		#region these methods update the image buffer and UI 
		private UIImage GetImageFromSampleBuffer(CMSampleBuffer sampleBuffer)
		{
			//get a pixel buffer from the sample buffer 
			using (var pixelBuffer = sampleBuffer.GetImageBuffer() as CVPixelBuffer)
			{
				//locks the base address
				pixelBuffer.Lock(CVPixelBufferLock.ReadOnly);

				//decode the buffer 
				var flags = CGBitmapFlags.PremultipliedFirst | CGBitmapFlags.ByteOrder32Little;

				//decode buffer - create a new colorspace   
				using (var cs = CGColorSpace.CreateDeviceRGB())
				{
					//creae new context from the image buffer 
					using (var context = new CGBitmapContext(pixelBuffer.BaseAddress, pixelBuffer.Width, pixelBuffer.Height, 8, pixelBuffer.BytesPerRow, cs, (CGImageAlphaInfo)flags))
					{
						//get the image from the context
						using (var cgImage = context.ToImage())
						{
							//unlock and return image 
							pixelBuffer.Unlock(CVPixelBufferLock.ReadOnly);
							return UIImage.FromImage(cgImage);
						}
					}
				}
			}

		}
		#endregion

		#region overrides 
		public override void DidOutputSampleBuffer(AVCaptureOutput captureOutput, CMSampleBuffer sampleBuffer, AVCaptureConnection connection)
		{
			//handle ny errors that occur in the image 
			try {
				//grab an image from the buffer  
				var image = GetImageFromSampleBuffer(sampleBuffer);

				//display the image 
				if(DisplayView != null) {
					DisplayView.BeginInvokeOnMainThread(() =>
					{
						//set the image 
						DisplayView.Image = image;

						//rotate image to the correct display orientation 
						DisplayView.Transform = CGAffineTransform.MakeRotation((float)Math.PI / 2);
					});
				}
				//dispose of the sample image buffer otherwise the UI will get stuck at a certain number of frames
				sampleBuffer.Dispose();
			}
			catch(Exception e) {
				//report the error 
				Console.WriteLine("Error sample Buffer description: {0}", e.Message);
			}
		}
		#endregion
	}
}
