using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;


public class AppBoot : MonoBehaviour
{
   
	void Start()
    {
        TimersController.Instance.RestartTimers();

		List<SliderData> sliders = new List<SliderData>();
		sliders.Add(new SliderData {index = 0, value = 21f});
		sliders.Add(new SliderData {index = 1, value = 29f});

		string dataAsString = JsonConvert.SerializeObject(sliders);
		Debug.Log(dataAsString);

		List<SliderData> slidersRestore = JsonConvert.DeserializeObject<List<SliderData>>(dataAsString);

		foreach (var slider in slidersRestore)
		{
			Debug.Log($"Index: {slider.index}, Value: {slider.value}");
		}

	}

}
