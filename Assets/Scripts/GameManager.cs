using System.Collections;
using System.Net;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject feu;
    // Start is called before the first frame update
    void Start()
    {
        StopGame();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void StopGame()
    {
        GameObject Car;
        Car= GameObject.FindGameObjectWithTag("CarPlayer");
        Car.GetComponent<CarController>().enabled = false;
        StartCoroutine(Decompte());
    }

    IEnumerator Decompte()
    {
        yield return new WaitForSeconds(3);
        StartGame();
    }
    
    void StartGame()
    {
        GameObject Car;
        Car= GameObject.FindGameObjectWithTag("CarPlayer");
        Car.GetComponent<CarController>().enabled = true;
    }
    
}
