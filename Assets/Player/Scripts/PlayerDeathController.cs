using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{

	public void OnDeath (HealthController.DamageData data)
	{
		gameObject.GetComponent<PlayerStatisticsController>().ResetGame();
	}
}