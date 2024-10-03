using UnityEngine;

public class DayToNight : MonoBehaviour
{
    [SerializeField] private float speedOfChanging = 10f;
    private void FixedUpdate()
    {
        RotateWithDeltaTime();
    }

    private void RotateWithDeltaTime()
    {
        Vector3 rotation = transform.rotation.eulerAngles;

        rotation.x += Time.deltaTime * speedOfChanging;

        if (rotation.x >= 360f)
            rotation.x = 0f;

        transform.rotation = Quaternion.Euler(rotation);
    }
}
