using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forest : MonoBehaviour
{
    public int amountOfWood;
    [SerializeField] GameObject noMoreForest;
    // Start is called before the first frame update
    void Start()
    {
        amountOfWood = Random.Range(12, 14);
    }

    // Update is called once per frame
    void Update()
    {
        IfEmpty();
    }

    private void OnMouseDown()
    {
        GameObject[] Lumb = GameObject.FindGameObjectsWithTag("Jacks");
        foreach (GameObject g in Lumb)
        {
            g.GetComponent<LumberJack>().nearestForestLocation = this.transform.position;
            g.GetComponent<LumberJack>().nearestForest = this.gameObject;
        }
    }

    private void IfEmpty()
    {
        if (amountOfWood <= 0)
        {
            Instantiate(noMoreForest, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);

        }
    }
}
