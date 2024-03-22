using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimersController : MonoBehaviour
{
    [SerializeField] private List<SliderView> sliderViews;

	private string slidersDataKey = "slidersdata";


	public void StartTimer(int timerIndex,float seconds)
	{
		if (timerIndex >= sliderViews.Count) return;
		PlayerPrefs.SetFloat(slidersDataKey + timerIndex.ToString(), seconds);
		sliderViews[timerIndex].InitSlider(timerIndex, seconds, onFinished);
	}

	public void RestartTimers()
	{

	}

	private void onFinished(int timerIndex) 
	{
		Debug.Log("done " + timerIndex);
		PlayerPrefs.DeleteKey(slidersDataKey + timerIndex);
	}

	public static TimersController Instance;
	private void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	private void OnApplicationQuit()
	{
		foreach (var slider in sliderViews) 
		{
			float timerValue = slider.GetCurentValue();
			float timerIndex = slider.GetCurentValue();
			PlayerPrefs.SetFloat(slidersDataKey + timerIndex.ToString(), timerValue);
		}
	}
}


[Serializable]
public class SliderData
{
	public int index;
	public float value;
}

