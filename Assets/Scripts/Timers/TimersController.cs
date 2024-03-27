using System;
using System.Collections.Generic;
using UnityEngine;

namespace Timers
{
	public class TimersController : MonoBehaviour
	{
		[SerializeField] private List<TimerBehaviour> _timers;
		private TimersDataSaver _timersDataSaver = new();
	
		public void StartTimer(int timerIndex,float seconds,float secondsMax)
		{
			if (timerIndex >= _timers.Count) return;
			_timers[timerIndex].InitSlider(timerIndex, seconds, secondsMax, onFinished);
		}

		public void RestartTimers()
		{
			TimeSpan timeDifference = DateTime.Now - _timersDataSaver.GetExitTime();
			float deltaTimeInSeconds = (float)timeDifference.TotalSeconds;
			List <TimerData> timersData = _timersDataSaver.LoadTimersData();
			foreach (TimerData timer in timersData)
			{
				StartTimer(timer.index, timer.value - deltaTimeInSeconds, timer.valueMax);
			}
		}

		private void onFinished(int timerIndex) 
		{
			Debug.Log("done " + timerIndex);
		}

		private void OnApplicationQuit()
		{
			_timersDataSaver.SaveTimersData(_timers);
		}
	}
}


