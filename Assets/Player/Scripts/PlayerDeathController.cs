using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    AudioClip clip; 
	public GameObject _sky;
	private bool _isDead = false;

	public void OnDeath (HealthController.DamageData data)
	{
		if (_isDead)
			return;

		_isDead = true;
		Die();
	}

	public void Die()
	{
		Instantiate (_sky, new Vector3 (gameObject.transform.position.x, _sky.transform.position.y, gameObject.transform.position.z), _sky.transform.rotation);

		var playerStatisticsController = gameObject.GetComponent<PlayerStatisticsController> ();
		gameObject.GetComponent<PlayerTimeCounter> ().StopCounting ();
		Debug.Log ($"You survived {gameObject.GetComponent<PlayerTimeCounter>()._survivedTime} seconds");
		playerStatisticsController.SetMaxSurvivedTime (gameObject.GetComponent<PlayerTimeCounter> ()._survivedTime);
		playerStatisticsController.ResetGame ();

		Debug.Log ("You DIED!");
		Destroy(gameObject);

	}
}