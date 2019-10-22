using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int woodStash = 0;
    public static int goldStash = 0;
    [SerializeField] TMPro.TextMeshProUGUI lumberStash;
    [SerializeField] TMPro.TextMeshProUGUI goldStores;
    [SerializeField] Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(woodStash);
        lumberStash.text = woodStash.ToString();
       goldStores.text = goldStash.ToString();
       
    }
}
