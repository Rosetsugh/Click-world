using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : MonoBehaviour
{
    public int amountOfGold;
    [SerializeField] GameObject noMoreGold;

    // Start is called before the first frame update
    void Start()
    {
        amountOfGold = Random.Range(30, 64);                                                //sets random amount in mine
    }

    // Update is called once per frame
    void Update()
    {
        NoMoreGold();                                                                       //replaces the mine when empty
    }

    private void NoMoreGold()
    {
        if (amountOfGold <= 0)
        {
            Instantiate(noMoreGold, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);

        }
    }
}
