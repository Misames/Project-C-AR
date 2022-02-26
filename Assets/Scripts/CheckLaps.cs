using UnityEngine;

public class CheckLaps : MonoBehaviour
{
    [SerializeField] private GameObject finishLine;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("CarPlayer"))
            finishLine.GetComponent<LapsSystem>().check = true;
    }
}
