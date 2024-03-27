using System;
using UnityEngine;

namespace Timers
{
	[Serializable]
	public class TimerData
	{
		[SerializeField] public int index;
		[SerializeField] public float value;
		[SerializeField] public float valueMax;
	}
}