using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapsScript : MonoBehaviour
{
  public bool verif = false   ;
  private void OnTriggerEnter(Collider col)
  {
    
    if (col.gameObject.CompareTag("CarPlayer") && verif)
    {
      GameObject.Find("Canvas").GetComponent<UIScript>().Nblaps();
      verif = false;
    }
  }
}
