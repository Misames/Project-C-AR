using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text txtlaps;

    public int nbLapsForWin = 3;
    public int laps = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        txtlaps.text = "Lap : " + laps + " / " + nbLapsForWin;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Nblaps()
    {
        laps += 1;
        txtlaps.text = "Lap : " + laps + " / " + nbLapsForWin;

        if (laps == nbLapsForWin)
        {
            Debug.Log("course terminer");
        }
    }
    
}
