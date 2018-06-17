using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(HealthController))]
public class BodyPartsController : MonoBehaviour {
    public GameObject[] bodyParts;
    public GameObject bodyCutEffect;
    private List<GameObject> listBodyParts;
    HealthController healthController;
    int legsPartFlag = 2;

    // Use this for initialization
    void Start () {
        healthController = GetComponent<HealthController>();
        listBodyParts = bodyParts.OfType<GameObject>().ToList();
    }

    // Update is called once per frame
    void Update() {
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (healthController.actual < healthController.max * 0.8f && legsPartFlag == 2)
        {
            CutBodyPart();
        }
        else if (healthController.actual < healthController.max * 0.4f && legsPartFlag == 1)
        {
            CutBodyPart();
        }
    }

    private void CutBodyPart()
    {
        if (listBodyParts[0] != null)
        {
            listBodyParts[0].transform.localScale = new Vector3(0, 0, 0);
            RespEffect(listBodyParts[0].transform);
            listBodyParts.RemoveAt(0);
            legsPartFlag--;
        }
    }

    private void RespEffect(Transform transform)
    {
    var effect = GameObject.Instantiate(bodyCutEffect, 
        transform.position, transform.rotation);
        Destroy(effect,2);
    }
}
