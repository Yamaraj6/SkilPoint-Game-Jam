using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
	private GameObject _player;
	public void Awake()
	{
		_player = GameObject.FindGameObjectWithTag("Player");
	}
	public void OnDeath (HealthController.DamageData data)
	{
		_player.GetComponent<PlayerStatisticsController>().AddToActualKillCount(1);
	}
}