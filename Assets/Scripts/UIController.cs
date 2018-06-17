using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public PlayerStatisticsController playerStatisticsController;
    public PlayerTimeCounter playerTimeCounter;
    public Image imagePoints;
    public Text txtPoints;
    public Image imageTrees;

    // Use this for initialization
    void Start ()
    {
        if (playerStatisticsController == null)
        {
            playerStatisticsController = GameObject
                .FindGameObjectWithTag("Player")
                .GetComponent<PlayerStatisticsController>();
        }
        if (playerTimeCounter == null)
        {
            playerTimeCounter = GameObject
                .FindGameObjectWithTag("Player")
                .GetComponent<PlayerTimeCounter>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CountPoints()
    {
        txtPoints.text=
            playerStatisticsController._actualKills * 10 
            + playerTimeCounter._survivedTime * 5+" pts";
    }
}
