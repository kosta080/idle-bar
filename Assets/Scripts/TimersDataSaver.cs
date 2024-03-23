using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class TimersDataSaver
{

	private static TimersDataSaver _instance;
	public static TimersDataSaver Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new TimersDataSaver();
			}
			return _instance;
		}
	}

	public void SaveTimersData(List<SliderView> sliderViews)
	{
		List<TimerData> _timers = new List<TimerData>();
		foreach (var slider in sliderViews)
		{
			if (slider.Value <= 0) continue;
			TimerData data = new TimerData { index = slider.Index, value = slider.Value, valueMax = slider.ValueMax};
			_timers.Add(data);
		}
		string dataAsString = JsonConvert.SerializeObject(_timers);
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetString("timersData", dataAsString);
		PlayerPrefs.SetString("exitTime", DateTimeNowToString());
		Debug.Log("Saved");
	}

	public DateTime GetExitTime()
	{
		return StringToDateTime(PlayerPrefs.GetString("exitTime"));
	}

	public List<TimerData> LoadTimersData()
	{
		string dataAsString = PlayerPrefs.GetString("timersData");
		if (string.IsNullOrEmpty(dataAsString))
		{
			return new List<TimerData>();
		}

		List<TimerData> timersData = JsonConvert.DeserializeObject<List<TimerData>>(dataAsString);
		return timersData;
	}

	string timeFormat = "yyyy-MM-ddTHH:mm:ss";
	public string DateTimeNowToString()
	{
		return DateTime.Now.ToString(timeFormat);
	}

	public DateTime StringToDateTime(string dateTimeString)
	{
		return DateTime.ParseExact(dateTimeString, timeFormat, CultureInfo.InvariantCulture);
	}
}
