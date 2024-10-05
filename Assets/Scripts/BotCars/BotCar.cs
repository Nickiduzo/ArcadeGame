using UnityEngine;

public class BotCar : MonoBehaviour
{
    private float speed = 5f;

    private float zOffPosition = -15;

    private void Update() => Behaviour();

    private void Behaviour()
    {
        transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        GetOffPosition();
    }

    private void GetOffPosition()
    {
        if (transform.position.z < zOffPosition || transform.position.z > 200)
            Destroy(gameObject);
        else if (transform.position.y < 0 || transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }    
}
