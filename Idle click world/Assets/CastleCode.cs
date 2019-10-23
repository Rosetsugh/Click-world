using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleCode : MonoBehaviour
{
    #region Variables
    [SerializeField] public GameObject lumberJack;
    [SerializeField] public GameObject miner;
    public int numOfJacks = 3;
    public int numofMiners;
    public static int jacksOnField = 0;
    public static int minersOnField = 0;
    public int spawnTimer = 0;
    public int timer = 500;
    public int numofworkers = 3;
    public TMPro.TextMeshProUGUI text;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //numOfJacks = numofworkers - numofMiners;
        jacksOnField = GameObject.FindGameObjectsWithTag("Jacks").Length;                                                                               // Finds all objects with tag "Jacks"
        //Debug.Log(jacksOnField);
        //Debug.Log(spawnTimer);
        minersOnField = GameObject.FindGameObjectsWithTag("Miners").Length;                                                                             // Finds all objects with tag "Miners"
        SpawnLumberJacks();                                                                                                                             // Spawns Lumber Jacks if there are less then Max
        SpawnGoldMiners();                                                                                                                              // Spawns Gold Miners When there are less then max
    }

    private void SpawnGoldMiners()
    {
        if (minersOnField < numofMiners && spawnTimer <= 0)
        {
            Instantiate<GameObject>(miner, new Vector3(this.transform.position.x, this.transform.position.y + .1f), this.transform.rotation);
            spawnTimer = timer;

        }
    }

    private void SpawnLumberJacks()
    {
        if (jacksOnField < numOfJacks && spawnTimer <= 0)
        {
            Instantiate<GameObject>(lumberJack, new Vector3(this.transform.position.x, this.transform.position.y + .1f), this.transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        spawnTimer -= 1;                                                                                                                                // Timer for respawns
    }

    public void MinerIncrease()
    {
        if (numOfJacks + numofMiners < numofworkers + 1)
        {
            numofMiners += 1;
        }
    }

    public void JackIncrease()
    {
        if (numofMiners > 0)
        {
            numofMiners -= 1;
        }
    }

}
