using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using SkilPoint_Game_Jam.Assets.Scripts;

public class UIController : MonoBehaviour
{
    public int MaxPoints = 10;
    public int MaxTrees = 1;
    public GameObject Player;
    private PlayerStatisticsController playerStatisticsController;
    private PlayerTimeCounter playerTimeCounter;
    private LooseChecker looseChecker;
    public Image imagePoints;
    public Text txtPoints;
    public Image imageTrees;

    // Use this for initialization
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject
                .FindGameObjectWithTag("Player");
        }

        playerStatisticsController = Player.GetComponent<PlayerStatisticsController>();
        playerTimeCounter = Player.GetComponent<PlayerTimeCounter>();
        looseChecker = Player.GetComponent<LooseChecker>();
        
        StartCoroutine(WaitForTrees());
    }

    IEnumerator WaitForTrees()
    {
        yield return new WaitForSeconds(3);
        MaxTrees = GameObject.FindGameObjectsWithTag("tree").Count();
    }
    
    // Update is called once per frame
    void Update()
    {
        CountPoints();
        CountTrees();
        RestartLevel();
    }

    void CountPoints()
    {
        var points = (int)(playerStatisticsController._actualKills * 10
            + playerTimeCounter._survivedTime * 5);
        txtPoints.text = points + " pkt";
        imagePoints.fillAmount = (float)points / (float)MaxPoints;
    }
    void CountTrees()
    {
        var trees = GameObject.FindGameObjectsWithTag("tree").Count();
        imageTrees.fillAmount = (float)trees / (float)(MaxTrees- looseChecker._treesToLoose);
    }

    public void RestartLevel()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}