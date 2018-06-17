using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatisticsController : MonoBehaviour
{

	private PlayerStats _playerStats;
	private string _key = "save";
    private readonly PlayerStats _startupPlayer = new PlayerStats()
    {
        Nickname = "player1",
        MaxKillCount = 0,
        MaxSurvivedTime = 0,
        SpendingPoints = 1000
    };
	// Use this for initialization
	public int _actualKills = 0;
	private void Awake ()
	{
        var jsonString = PlayerPrefs.GetString(_key, JsonUtility.ToJson(_startupPlayer));
	    _playerStats = JsonUtility.FromJson<PlayerStats>(jsonString);
		Debug.Log($"Player stats: nickname: {_playerStats.Nickname}, max kill count: {_playerStats.MaxKillCount}, max survived time: {_playerStats.MaxSurvivedTime}, your money {_playerStats.SpendingPoints}");
	}
	public void SetMaxKillCount(int maxKillCount)
	{
		if(maxKillCount>_playerStats.MaxKillCount)
			_playerStats.MaxKillCount = maxKillCount;
		

	}
	public void SetMaxSurvivedTime(float maxSurvivedTime)
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
        Debug.Log($"You have killed {_actualKills} pinguins");
		SetMaxKillCount(_actualKills);
		AddSpendingPoints(_actualKills);
		Save ();
		_actualKills = 0;
	}

	public void SetNickname(string nickname)
	{
		_playerStats.Nickname = nickname;
		Save();
	}

	public void AddSpendingPoints(int spendedPoints)
	{
		_playerStats.SpendingPoints += spendedPoints;
		Save ();
	}

	private void Save ()
	{
		var serializedString = JsonUtility.ToJson(_playerStats);
		PlayerPrefs.SetString(_key, serializedString);
	}
}

[Serializable]
public class PlayerStats
{
    public string Nickname;
    public int MaxKillCount;
    public float MaxSurvivedTime;
    public int SpendingPoints;
}