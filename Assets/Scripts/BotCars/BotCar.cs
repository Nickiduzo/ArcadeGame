using UnityEngine;

public class BotCar : MonoBehaviour
{
    private float speed = 15f;

    private float zOffPosition = -15;

    private void Update() => Behaviour();

    private void Behaviour()
    {
        Move();
        GetOffPosition();
    }

    private void GetOffPosition()
    {
        if (transform.position.z < zOffPosition)
            Destroy(gameObject);
    }
    
    private void Move() =>
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
}
