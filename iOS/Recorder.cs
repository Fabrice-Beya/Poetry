using System;
using AVFoundation;
using AudioToolbox;
using Foundation;
using System.IO;
using System.Diagnostics;

namespace Poetry.iOS
{
	public class Recorder
	{
		//declaire Audio class
		AVAudioRecorder recorder;
		AVPlayer player;
		NSDictionary settings;
		Stopwatch stopwatch = null;
		NSUrl audioFilePath = null;
		NSObject observer;
		public string Status { get; set; }
		public string LengthRecorded { get; set; }

		public Recorder()
		{
			AudioSession.Initialize();
		}

		public void StartRecording()
		{
			Status = "Preparing to Record...";

			AudioSession.Category = AudioSessionCategory.RecordAudio;
			AudioSession.SetActive(true);

			if (!PrepareAudioSession())
			{
				Status = "Error...";
			}
			else
			{
				Status = "Recording...";
				recorder.Record();
			}
			stopwatch = new Stopwatch();
			stopwatch.Start();
			LengthRecorded = string.Format("{0:hh\\:mm\\:ss}", this.stopwatch.Elapsed);

		}
		public void StopRecording()
		{
			Status = "Stopped Recording...";
			this.recorder.Stop();
			LengthRecorded = string.Format("{0:hh\\:mm\\:ss}", this.stopwatch.Elapsed);
			stopwatch.Stop();

			observer = NSNotificationCenter.DefaultCenter.AddObserver(AVPlayerItem.DidPlayToEndTimeNotification, delegate (NSNotification n)
			{
				player.Dispose();
				player = null;
			});
		}

		public void PlayRecord()
		{
			AudioSession.Category = AudioSessionCategory.MediaPlayback;

			this.player = new AVPlayer(this.audioFilePath);
			this.player.Play();
		}

		bool PrepareAudioSession()
		{
			//This will initialize the audio session before trying to record
			var audioSession = AVAudioSession.SharedInstance();
			var err = audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
			err = audioSession.SetActive(true);

			//Set up the file storage settings for the audio file
			string filename = string.Format("MyPoem{0}.aac", DateTime.Now.ToString("yyyy-MMMMM-dd"));
			string tempLocation = Path.Combine(Path.GetTempPath(), filename);
			audioFilePath = NSUrl.FromFilename(tempLocation);

			//set up the NSObject Array of values that will be combined with the keys to make the NSDictionary
			NSObject[] values = new NSObject[]
			{
				NSNumber.FromFloat(44100.0f),
				NSNumber.FromInt32((int)AudioToolbox.AudioFormatType.MPEG4AAC),
				NSNumber.FromInt32(1),
				NSNumber.FromInt32((int)AVAudioQuality.High)
			};
			//Set up the NSObject Array of keys that will be combined with the values to make the NSDictionary
			NSObject[] keys = new NSObject[]
			{
				AVAudioSettings.AVSampleRateKey,
				AVAudioSettings.AVFormatIDKey,
				AVAudioSettings.AVNumberOfChannelsKey,
				AVAudioSettings.AVEncoderAudioQualityKey
			};

			//generate settings based on the keys and values
			NSError error;
			settings = NSDictionary.FromObjectsAndKeys(values, keys);

			//set recorder parameters
			recorder = AVAudioRecorder.Create(audioFilePath, new AudioSettings(settings), out error);

			//Set Recorder to Prepare To Record
			if (!recorder.PrepareToRecord())
			{
				recorder.Dispose();
				recorder = null;
				return false;
			}

			recorder.FinishedRecording += delegate (object sender, AVStatusEventArgs e)
			{
				recorder.Dispose();
				recorder = null;
				Console.WriteLine("Done Recording (status: {0})", e.Status);
			};

			return true;

		}
	}
}

