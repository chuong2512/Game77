using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scaleCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GetComponent<CanvasScaler>().scaleFactor = 1 / 1920f * Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
