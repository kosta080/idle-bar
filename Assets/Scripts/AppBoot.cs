using Timers;
using UnityEngine;

public class AppBoot : MonoBehaviour
{
	[SerializeField] private TimersController _timersController;
	void Start()
    {
	    _timersController.RestartTimers();
	}
}
