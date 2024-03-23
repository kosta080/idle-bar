using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
	[SerializeField] private ParticleSystem _particleSystem;

	private Action<int> _onSliderFinished;
	private float _value;
	private float _valueMax;
	private bool _jobActive = false;
	private int _timerIndex;

	public void InitSlider(int timerIndex, float seconds, float secondsMax, Action<int> onSliderFinished)
    {
		_valueMax = secondsMax;
		_value = seconds;
		_onSliderFinished = onSliderFinished;
		_jobActive = true;
		_timerIndex = timerIndex;

		StartCoroutine(TickSlider());
	}
	public float Value => _value;
	public float ValueMax => _valueMax;
	public int Index => _timerIndex;
	

	IEnumerator TickSlider()
	{
		while (_jobActive)
		{
			_value -= Time.deltaTime;
			UpdateVisual();
			yield return null;
		}
	}

	void UpdateVisual()
	{
		float sliderValue = _value / _valueMax;
		_slider.value = sliderValue;

		if (sliderValue <= 0)
		{
			_particleSystem.Emit(50);
			_jobActive = false;
			_onSliderFinished?.Invoke(_timerIndex);
		}
	}

}
