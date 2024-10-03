using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Car carPosition;
    [SerializeField] private float defYPosition;
    [SerializeField] private float defZPosition;

    private void LateUpdate()
    {
        transform.position = new Vector3(carPosition.transform.position.x, defYPosition, carPosition.transform.position.z + defZPosition);
    }
}
