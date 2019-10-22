using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberJack : MonoBehaviour
{
    #region Variables
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

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        castleLocation = new Vector3(0, this.transform.position.y, 0);                                                  //sets the return location in a variable
        nearestForestArray = GameObject.FindGameObjectsWithTag("Forest") ;                                              //finds all the forest objects
        //Debug.Log(nearestForestArray);
        nearestForest = nearestForestArray[Random.Range(0,nearestForestArray.Length)];                                  //picks a forest -- may in the future pick the nearest forest
        //Debug.Log(nearestForest);
        nearestForestLocation = nearestForest.transform.position;                                                       //gets the location of the forest that is picked
        //Debug.Log(nearestForestLocation);
        castleHome = GameObject.FindGameObjectsWithTag("Castle");                                                       //sets the castle as a gameobject inside of a variable
    }

    // Update is called once per frame
    void Update()
    {
        NoMoreForests();                                                                                                //resets all workers back to the castle and sends no more if all forests are gone
        TargetForestLost();                                                                                             //Reasign worker to new forest if its target disapears on way to 
        GotoForest();                                                                                                   //Sends the worker to the forest that has been chosen
        CuttingWood();                                                                                                  // Sets the worker to collecting wood once they are in the forest
        ReturnWithTheWood();                                                                                            // Has the worker return with the wood they have collected

    }

    private void ReturnWithTheWood()
    {
        if (returnToTheCastle)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(0, this.transform.position.y, 0), moveSpeed);

        }
        if (this.transform.position == castleLocation)
        {
            GameController.woodStash += 1;
            woodCollected = 0;
            CastleCode.jacksOnField -= 1;
            Destroy(this.gameObject);

        }
    }

    private void CuttingWood()
    {
        if (this.transform.position.x == nearestForestLocation.x && this.transform.position.z == nearestForestLocation.z)
        {
            collectStuff = false;
            choppingWood = true;
        }

        if (choppingWood)
        {
            woodCollected += .001;
            //Debug.Log(woodCollected);
            if (woodCollected >= 1)
            {
                nearestForest.GetComponent<forest>().amountOfWood -= 1;
                choppingWood = false;
                returnToTheCastle = true;
            }
        }
    }

    private void GotoForest()
    {
        if (collectStuff)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(nearestForestLocation.x, this.transform.position.y, nearestForestLocation.z), moveSpeed);
        }
    }

    private void TargetForestLost()
    {
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
    }

    private void NoMoreForests()
    {
        if (nearestForestArray.Length == 0)
        {
            returnToTheCastle = true;
            GameObject c = castleHome[0];
            c.GetComponent<CastleCode>().numOfJacks = 0;
        }
    }
}
