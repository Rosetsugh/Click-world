using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughResources : MonoBehaviour
{
    TMPro.TextMeshProUGUI text = new TMPro.TextMeshProUGUI();

    // Start is called before the first frame update
    void Start()
    {
        text.alpha = 255;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        text.alpha = 255;
    }
}
