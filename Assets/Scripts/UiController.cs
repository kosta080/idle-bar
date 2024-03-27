using Timers;
using UnityEngine;

public class UiController : MonoBehaviour
{
	[SerializeField] private TimersController _timersController;
	public void HandleClickStart5sec()
    {
	    _timersController.StartTimer(0, 10, 10);
	}

	public void HandleClickStart30sec()
	{
		_timersController.StartTimer(1, 30, 30);
	}
}
