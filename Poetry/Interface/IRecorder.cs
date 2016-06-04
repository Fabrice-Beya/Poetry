using System;
namespace Poetry
{
	public interface IRecorder
	{
		void StartRecording();
		void StopRecording();
		void PlayRecord(string Filename);
		void StopPlay();
	}
}

