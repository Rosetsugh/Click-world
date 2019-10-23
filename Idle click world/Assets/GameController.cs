using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Global Variables
    public static int woodStash = 0;
    public static int goldStash = 0;
    [SerializeField] TMPro.TextMeshProUGUI lumberStash;
    [SerializeField] TMPro.TextMeshProUGUI goldStores;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject castle;
    public TextMeshProUGUI text;
    public TextMeshProUGUI workerCount;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(woodStash);
        lumberStash.text = woodStash.ToString();                                                //prints amount to HUD
        goldStores.text = goldStash.ToString();                                                 //prints amount to HUD
        workerCount.text = castle.GetComponent<CastleCode>().numofworkers.ToString();
    }
    public void BuyAWorker()
    {
        if (goldStash > 3 && woodStash > 9)
        {
            goldStash -= 3;
            woodStash -= 10;
            castle.GetComponent<CastleCode>().numofworkers += 1;
        }
        else
        {
            text.alpha = 0;
        }
    }

}
