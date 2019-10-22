using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Miner : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
        castleLocation = new Vector3(0, .1f, 0);
        nearestMinesArray = GameObject.FindGameObjectsWithTag("Mines");
        //Debug.Log(nearestMinesArray);
        nearestMines = nearestMinesArray[Random.Range(0, nearestMinesArray.Length)];
        //Debug.Log(nearestMines);
        nearestMinesLocation = nearestMines.transform.position;
        //Debug.Log(nearestMinesLocation);
        castleHome = GameObject.FindGameObjectsWithTag("Castle");
    }

    // Update is called once per frame
    void Update()
    {
        GoPlaces();

        MineGold();
        GoHome();
        AtHome();

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
