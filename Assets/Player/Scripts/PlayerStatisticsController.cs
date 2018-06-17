using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatisticsController : MonoBehaviour
{

	private PlayerStats _playerStats;
	private string _key = "save";
	// Use this for initialization
	private int _actualKills = 0;
	private void Awake ()
	{
		_playerStats = JsonUtility.FromJson<PlayerStats>(PlayerPrefs.GetString(_key, JsonUtility.ToJson(new PlayerStats())));
	}
	public void SetMaxKillCount(int maxKillCount)
	{
		if(maxKillCount>_playerStats.MaxKillCount)
			_playerStats.MaxKillCount = maxKillCount;

	}
	public void SetMaxSurvivedTime(int maxSurvivedTime)
	{
		if(maxSurvivedTime>_playerStats.MaxSurvivedTime)
			_playerStats.MaxSurvivedTime = maxSurvivedTime;			
	}

	public void AddToActualKillCount(int kills)
	{
		_actualKills+= kills;
	}

	public void ResetGame()
	{
		SetMaxKillCount(_actualKills);
		_actualKills = 0;
	}

	public void SetNickname(string nickname)
	{
		_playerStats.Nickname = nickname;
	}

	public void AddSpendingPoints(int spendedPoints)
	{
		_playerStats.SpendingPoints += spendedPoints;
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