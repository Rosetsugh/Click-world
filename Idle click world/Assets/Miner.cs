using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Miner : MonoBehaviour
{
    #region Variables
    private Vector3 nearestMinesLocation;
    public GameObject nearestMines;
    public GameObject[] nearestMinesArray;
    public float moveSpeed = .01f;
    public bool collectStuff = true;
    private bool miningGold;
    private bool returnToTheCastle;
    private double goldCollected;
    public Vector3 castleLocation;
    GameObject[] castleHome;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        castleLocation = new Vector3(0, .1f, 0);                                                            //encapsulates castle location
        nearestMinesArray = GameObject.FindGameObjectsWithTag("Mines");                                     //finds all Mines and arranges them in array
        //Debug.Log(nearestMinesArray);
        nearestMines = nearestMinesArray[Random.Range(0, nearestMinesArray.Length)];                        //picks a random mine from the array 
        //Debug.Log(nearestMines);
        nearestMinesLocation = nearestMines.transform.position;                                             //gets the location of the mine that was picked
        //Debug.Log(nearestMinesLocation);
        castleHome = GameObject.FindGameObjectsWithTag("Castle");                                           //finds and encapsulates the gameobject data of the castle
    }

    // Update is called once per frame
    void Update()
    {
        GoPlaces();                                                                                         //has worker travel to the mine that is picked
        MineGold();                                                                                         // once there has worker mine gold
        GoHome();                                                                                           // once mining is done returns to castle
        AtHome();                                                                                           // increments gold and cleans up worker

    }

    private void GoPlaces()
    {
        if (nearestMinesArray.Length == 0)
        {
            returnToTheCastle = true;
            GameObject c = castleHome[0];
            c.GetComponent<CastleCode>().numOfJacks = 0;
        }
        if (nearestMines == null)
        {
            nearestMinesArray = GameObject.FindGameObjectsWithTag("Mines");
            //Debug.Log(nearestMinesArray);
            if (nearestMinesArray.Length > 0)
            {
                nearestMines = nearestMinesArray[Random.Range(0, nearestMinesArray.Length)];
                //Debug.Log(nearestMines);
                nearestMinesLocation = nearestMines.transform.position;
                //Debug.Log(nearestMinesLocation);
            }
            else
            {
                collectStuff = false;
                miningGold = false;
                returnToTheCastle = true;
            }

        }
        if (collectStuff)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(nearestMinesLocation.x, this.transform.position.y, nearestMinesLocation.z), moveSpeed);
        }
    }

    private void MineGold()
    {
        if (this.transform.position.x == nearestMinesLocation.x && this.transform.position.z == nearestMinesLocation.z)
        {
            collectStuff = false;
            miningGold = true;
        }

        if (miningGold)
        {
            goldCollected += .0005;
            //Debug.Log(woodCollected);
            if (goldCollected >= 1)
            {
                nearestMines.GetComponent<GoldMine>().amountOfGold -= 1;
                miningGold = false;
                returnToTheCastle = true;
            }
        }
    }

    private void GoHome()
    {
        if (returnToTheCastle)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(0, this.transform.position.y, 0), moveSpeed);

        }
    }

    private void AtHome()
    {
        if (this.transform.position == castleLocation)
        {
            GameController.goldStash += 1;
            goldCollected = 0;
            CastleCode.minersOnField -= 1;
            Destroy(this.gameObject);

        }
    }
}
