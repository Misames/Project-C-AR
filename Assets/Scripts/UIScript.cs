using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text txtlaps;
    public int nbLapsForWin = 3;
    public int laps = 0;

    private void Start()
    {
        txtlaps.text = "Lap : " + laps + " / " + nbLapsForWin;
    }

    public void Nblaps()
    {
        laps += 1;
        txtlaps.text = "Lap : " + laps + " / " + nbLapsForWin;
        if (laps == nbLapsForWin)
            Debug.Log("course terminer");
    }

}
