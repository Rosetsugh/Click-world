using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleCode : MonoBehaviour
{
    [SerializeField] public GameObject lumberJack;
    [SerializeField] public GameObject miner;
    public int numOfJacks = 5;
    public int numofMiners = 5;
    public static int jacksOnField = 0;
    public static int minersOnField = 0;
    public int spawnTimer = 0;
    public int timer = 500;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jacksOnField = GameObject.FindGameObjectsWithTag("Jacks").Length;
        //Debug.Log(jacksOnField);
        //Debug.Log(spawnTimer);
        minersOnField = GameObject.FindGameObjectsWithTag("Miners").Length;
        if (jacksOnField < numOfJacks && spawnTimer <= 0)
        {
            Instantiate<GameObject>(lumberJack, new Vector3(this.transform.position.x, this.transform.position.y + .1f), this.transform.rotation);
        }
        if (minersOnField < numofMiners && spawnTimer <= 0)
        {
            Instantiate<GameObject>(miner,new Vector3(this.transform.position.x, this.transform.position.y + .1f), this.transform.rotation);
            spawnTimer = timer;

        }
    }

    private void FixedUpdate()
    {
        spawnTimer -= 1;
    }
}
