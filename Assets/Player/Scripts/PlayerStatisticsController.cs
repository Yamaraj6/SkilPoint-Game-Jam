using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatisticsController : MonoBehaviour
{

	private PlayerStats _playerStats;
	private string _key = "save";
	// Use this for initialization
	private void Awake ()
	{
		_playerStats = JsonUtility.FromJson<PlayerStats>(PlayerPrefs.GetString(_key, JsonUtility.ToJson(new PlayerStats())));
	}

	private void OnApplicationQuit ()
	{
		var serializedString = JsonUtility.ToJson(_playerStats);
		PlayerPrefs.SetString(_key, serializedString);
	}
}

public class PlayerStats
{
	public string Nickname {get; set;}
	public int MaxKillCount{ get; set;}
	public int MaxSurvivedTime {get; set;}
	public int SpendingPoints {get; set;}
}