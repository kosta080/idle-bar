using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{

	public void HandleClickStart5sec()
    {
		TimersController.Instance.StartTimer(0, 10, 10);
	}

	public void HandleClickStart30sec()
	{
		TimersController.Instance.StartTimer(1, 30, 30);
	}
}
