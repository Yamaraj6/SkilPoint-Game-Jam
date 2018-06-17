using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public int MaxPoints = 10;
    public int MaxTrees = 1000;
    public PlayerStatisticsController playerStatisticsController;
    public PlayerTimeCounter playerTimeCounter;
    public Image imagePoints;
    public Text txtPoints;
    public Image imageTrees;

    // Use this for initialization
    void Start()
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
        imageTrees.fillAmount = (float)trees / (float)MaxTrees;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}