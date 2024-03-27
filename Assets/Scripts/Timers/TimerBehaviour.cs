using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Timers
{
	public class TimerBehaviour : MonoBehaviour
	{
		public float Value => _value;
		public float ValueMax => _valueMax;
		public int Index => _timerIndex;

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

			StartCoroutine(Tick());
		}

	
		IEnumerator Tick()
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
			float timerValue = _value / _valueMax;
			_slider.value = timerValue;

			if (timerValue <= 0)
			{
				_particleSystem.Emit(50);
				_jobActive = false;
				_onSliderFinished?.Invoke(_timerIndex);
			}
		}

	}
}
