using UnityEngine;

public class LapsSystem : MonoBehaviour
{
    public bool check = false;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("CarPlayer") && check)
        {
            GameManager.instance.LapPassed();
            check = false;
        }
    }
}
