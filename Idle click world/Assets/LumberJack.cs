using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberJack : MonoBehaviour
{
    public Vector3 nearestForestLocation;
    public GameObject nearestForest;
    public GameObject[] nearestForestArray;
    public float moveSpeed = .01f;
    public bool collectStuff = true;
    private bool choppingWood;
    private bool returnToTheCastle;
    private double woodCollected;
    public Vector3 castleLocation;
    GameObject[] castleHome;


    // Start is called before the first frame update
    void Start()
    {
        castleLocation = new Vector3(0, this.transform.position.y, 0);
        nearestForestArray = GameObject.FindGameObjectsWithTag("Forest") ;
        //Debug.Log(nearestForestArray);
        nearestForest = nearestForestArray[Random.Range(0,nearestForestArray.Length)];
        //Debug.Log(nearestForest);
        nearestForestLocation = nearestForest.transform.position;
        //Debug.Log(nearestForestLocation);
        castleHome = GameObject.FindGameObjectsWithTag("Castle");
    }

    // Update is called once per frame
    void Update()
    {
        if (nearestForestArray.Length == 0)
        {
            returnToTheCastle = true;
            GameObject c = castleHome[0];
            c.GetComponent<CastleCode>().numOfJacks = 0;
        }
        if (nearestForest == null)
        {
            nearestForestArray = GameObject.FindGameObjectsWithTag("Forest");
            //Debug.Log(nearestForestArray);
            if (nearestForestArray.Length > 0)
            {
                nearestForest = nearestForestArray[Random.Range(0, nearestForestArray.Length)];
                //Debug.Log(nearestForest);
                nearestForestLocation = nearestForest.transform.position;
                //Debug.Log(nearestForestLocation);
            }
            else
            {
                collectStuff = false;
                choppingWood = false;
                returnToTheCastle = true;
            }

        }
        if (collectStuff)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,new Vector3(nearestForestLocation.x,this.transform.position.y,nearestForestLocation.z),moveSpeed);
        }

            if (this.transform.position.x == nearestForestLocation.x && this.transform.position.z == nearestForestLocation.z)
            {
                collectStuff = false;
                choppingWood = true;
            }
        
        if (choppingWood)
        {
            woodCollected += .001;
            //Debug.Log(woodCollected);
            if (woodCollected  >= 1)
            {
                nearestForest.GetComponent<forest>().amountOfWood -= 1;
                choppingWood = false;
                returnToTheCastle = true;
            }
        }
        if (returnToTheCastle)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(0, this.transform.position.y,0), moveSpeed);

        }
        if (this.transform.position == castleLocation )
        {
            GameController.woodStash += 1;
            woodCollected = 0;
            CastleCode.jacksOnField -= 1;
            Destroy(this.gameObject);

        }
    
    }
}
