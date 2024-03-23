using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class TimersController : MonoBehaviour
{
	public static TimersController Instance;
	[SerializeField] private List<SliderView> sliderViews;


	
	private void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	public void StartTimer(int timerIndex,float seconds,float secondsMax)
	{
		if (timerIndex >= sliderViews.Count) return;
		//_timers.Add(new TimerData {index = timerIndex, value = seconds});
	
		sliderViews[timerIndex].InitSlider(timerIndex, seconds, secondsMax, onFinished);
	}

	public void RestartTimers()
	{
		DateTime exitTime = TimersDataSaver.Instance.GetExitTime();
		DateTime now = DateTime.Now;
		TimeSpan timeDifference = now - exitTime;
		float deltaTimeInSeconds = (float)timeDifference.TotalSeconds;

		List <TimerData> timersData = TimersDataSaver.Instance.LoadTimersData();
		foreach (TimerData timer in timersData)
		{
			Debug.Log($"data for restart {timer.index} {timer.value} {timer.value}");
			StartTimer(timer.index, timer.value - deltaTimeInSeconds, timer.valueMax);
		}
		
	}

	private void onFinished(int timerIndex) 
	{
		Debug.Log("done " + timerIndex);
	}

	private void OnApplicationQuit()
	{
		TimersDataSaver.Instance.SaveTimersData(sliderViews);
	}
}


