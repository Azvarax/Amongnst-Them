using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mop : MonoBehaviour
{
	public void StartGame()
	{
		BloodMopManager.Instance.StartBloodGame();
	}
}
