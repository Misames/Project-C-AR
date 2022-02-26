using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("CarPlayer"))
        {
            GameObject.Find("Ligne d'arrivé").GetComponent<LapsScript>().verif = true;
        }
    }
}
