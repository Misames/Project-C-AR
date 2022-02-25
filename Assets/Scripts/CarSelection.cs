using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    private int currentCar;
    private Quaternion originalPosition;
    [SerializeField] private Button previousCar;
    [SerializeField] private Button nextCar;

    private void Start()
    {
        originalPosition = transform.GetChild(currentCar).transform.rotation;
    }

    private void Update()
    {
        transform.GetChild(currentCar).Rotate(new Vector3(0f, 10f, 0f) * Time.deltaTime);
    }

    public void SelectCar(int index)
    {
        previousCar.interactable = index != 0;
        nextCar.interactable = (index != transform.childCount - 1);

        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == index);
    }

    public void ChangeCar(int change)
    {
        transform.GetChild(currentCar).transform.rotation = originalPosition;
        currentCar += change;
        SelectCar(currentCar);
    }
}
