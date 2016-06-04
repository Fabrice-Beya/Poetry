using System;
using System.Diagnostics;

namespace Poetry
{
	public interface IRecorder
	{
		void StartRecording();
		void StopRecording();
		void PlayRecord(string Filename);
		void StopPlay();

		string Status { get; set; }
		string LengthRecorded { get; set; }
		string AudioFileName { get; set; }
		Stopwatch stopwatch { get; set; }

	}
}

