using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{

    [SerializeField] public GameObject[] Land;
    private int LandArrayLocation = 0;
    private int Randomizer;
    [SerializeField] public int KingdomSize;
    int[,] LandGridSize;
    [SerializeField] Camera playerCamera;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate<GameObject>(Land[0],new Vector3(this.transform.position.x,this.transform.position.y),this.transform.rotation);
        for (int i = 1; i <= KingdomSize+1; i++)
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
        this.transform.position = new Vector3(-1, 0, 0);
        for (int i = 0; i < KingdomSize; i++)
        {
            RandomizerFunction();
            for (int e = 0; e <= KingdomSize; e++)
            {
                RandomizerFunction();
                Instantiate<GameObject>(Land[Randomizer], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + e), this.transform.rotation);
                RandomizerFunction();
                if (this.transform.position.z -e != 0 || this.transform.position.z +e != 0)
                {
                    Instantiate<GameObject>(Land[Randomizer], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - e), this.transform.rotation);
                }

            }
            this.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
        }

        playerCamera.transform.position = new Vector3(4, 4, -4);
        Destroy(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RandomizerFunction()
    {
        Randomizer = Random.Range(1, Land.Length);

    }
}
