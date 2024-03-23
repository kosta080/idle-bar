using UnityEngine;


public class AppBoot : MonoBehaviour
{
	void Start()
    {
        TimersController.Instance.RestartTimers();
	}
}
