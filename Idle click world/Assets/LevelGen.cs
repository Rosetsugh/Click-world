using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    #region Variables
    [SerializeField] public GameObject[] Land;                                                                                          // [SerializedField] is an UnityEditor Window mod that puts droppable fields in
    private int LandArrayLocation = 0;
    private int Randomizer;
    [SerializeField] public int KingdomSize;
    int[,] LandGridSize;
    [SerializeField] Camera playerCamera;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        Instantiate<GameObject>(Land[0], new Vector3(this.transform.position.x, this.transform.position.y), this.transform.rotation);   // This places the castle at 0,0,0 in the map
        PositiveXMapBuild();                                                                                                            // This function builds the map in the positive X direction
        this.transform.position = new Vector3(-1, 0, 0);                                                                                // this resets the map building object to the negative side after the first half of the build
        NegativeXMapBuild();                                                                                                            // This builds the map to the Negative X direction

        playerCamera.transform.position = new Vector3(4, 4, -4);                                                                        //Sets up initial camera postion
        Destroy(this.gameObject);                                                                                                       // removes map builder from memory

    }

    private void NegativeXMapBuild()
    {
        for (int i = 0; i < KingdomSize; i++)
        {
            RandomizerFunction();
            for (int e = 0; e <= KingdomSize; e++)
            {
                RandomizerFunction();
                Instantiate<GameObject>(Land[Randomizer], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + e), this.transform.rotation);
                RandomizerFunction();
                if (this.transform.position.z - e != 0 || this.transform.position.z + e != 0)
                {
                    Instantiate<GameObject>(Land[Randomizer], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - e), this.transform.rotation);
                }

            }
            this.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
        }
    }

    private void PositiveXMapBuild()
    {
        for (int i = 1; i <= KingdomSize + 1; i++)
        {
            RandomizerFunction();
            if (this.transform.position.x > 0)
            {
                Instantiate<GameObject>(Land[Randomizer], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
            }

            for (int e = 1; e <= KingdomSize; e++)
            {
                RandomizerFunction();
                Instantiate<GameObject>(Land[Randomizer], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + e), this.transform.rotation);
                RandomizerFunction();
                if (this.transform.position.x + e > 0)
                {
                    Instantiate<GameObject>(Land[Randomizer], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - e), this.transform.rotation);
                }

            }
            this.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
   
    
    // This Function provides a random number based on the size of the Land Array which offers flexibility in the randomly generated level
    public void RandomizerFunction()
    {
        Randomizer = Random.Range(1, Land.Length);

    }
}
