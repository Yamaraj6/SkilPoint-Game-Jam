using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
	private GameObject _player;
    private bool _isDead = false;
	public void Awake()
	{
		_player = GameObject.Find("Player");
		var objs = GameObject.FindGameObjectsWithTag("Player");
		objs.ToList().ForEach(f => Debug.Log(f.name));
	}
	public void OnDeath (HealthController.DamageData data)
	{
        if(_isDead)
            return;

	    _isDead = true;
		_player.GetComponent<PlayerStatisticsController>().AddToActualKillCount(1);
	}
}