using System;
using System.Collections.Generic;
using UnityEngine;


public class TimersController : MonoBehaviour
{
	public static TimersController Instance;
	[SerializeField] private List<TimerBehaviour> _timers;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	public void StartTimer(int timerIndex,float seconds,float secondsMax)
	{
		if (timerIndex >= _timers.Count) return;
		_timers[timerIndex].InitSlider(timerIndex, seconds, secondsMax, onFinished);
	}

	public void RestartTimers()
	{
		TimeSpan timeDifference = DateTime.Now - TimersDataSaver.Instance.GetExitTime();
		float deltaTimeInSeconds = (float)timeDifference.TotalSeconds;
		List <TimerData> timersData = TimersDataSaver.Instance.LoadTimersData();
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
		TimersDataSaver.Instance.SaveTimersData(_timers);
	}
}


