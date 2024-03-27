using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using UnityEngine;

namespace Timers
{
	public class TimersDataSaver
	{
		private const string TimersDataKey = "timersData";
		private const string ExitTimeKey = "exitTime";
		private const string timeFormat = "yyyy-MM-ddTHH:mm:ss";

		public void SaveTimersData(List<TimerBehaviour> timers)
		{
			List<TimerData> _timers = new List<TimerData>();
			foreach (var timer in timers)
			{
				if (timer.Value <= 0) continue;
				TimerData data = new TimerData { index = timer.Index, value = timer.Value, valueMax = timer.ValueMax};
				_timers.Add(data);
			}
			string dataAsString = JsonConvert.SerializeObject(_timers);
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetString(TimersDataKey, dataAsString);
			PlayerPrefs.SetString(ExitTimeKey, DateTimeNowToString());
			Debug.Log("Saved");
		}

		public DateTime GetExitTime()
		{
			return StringToDateTime(PlayerPrefs.GetString(ExitTimeKey));
		}

		public List<TimerData> LoadTimersData()
		{
			string dataAsString = PlayerPrefs.GetString(TimersDataKey);
			if (string.IsNullOrEmpty(dataAsString))
			{
				return new List<TimerData>();
			}

			List<TimerData> timersData = JsonConvert.DeserializeObject<List<TimerData>>(dataAsString);
			return timersData;
		}

		public string DateTimeNowToString()
		{
			return DateTime.Now.ToString(timeFormat);
		}

		public DateTime StringToDateTime(string dateTimeString)
		{
			return DateTime.ParseExact(dateTimeString, timeFormat, CultureInfo.InvariantCulture);
		}
	}
}
