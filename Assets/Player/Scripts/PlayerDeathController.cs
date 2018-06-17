using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    private bool _isDead = false;


	public void OnDeath (HealthController.DamageData data)
	{
	    if (_isDead)
	        return;

	    _isDead = true;
        var playerStatisticsController = gameObject.GetComponent<PlayerStatisticsController> ();
	    gameObject.GetComponent<PlayerTimeCounter>().StopCounting();
        Debug.Log($"You survived {gameObject.GetComponent<PlayerTimeCounter>()._survivedTime} seconds");
        playerStatisticsController.SetMaxSurvivedTime(gameObject.GetComponent<PlayerTimeCounter>()._survivedTime);
	    playerStatisticsController.ResetGame();

        Debug.Log("You DIED!");
	}
}