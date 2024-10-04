using UnityEngine;

public class BotCar : MonoBehaviour
{
    private float speed = 15f;

    private float zOffPosition = -15;

    private Car playerSpeed;

    private void Start()
    {
        playerSpeed = GameObject.Find("Player").GetComponent<Car>();
    }
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
        else if (transform.position.y < 0 || transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }
    
    private void Move()
    {
        float adjustedSpeed = speed - playerSpeed.speed;
        //transform.Translate(Vector3.forward * adjustedSpeed * Time.deltaTime); 
        float rotationY = transform.eulerAngles.y;
        if (rotationY > 170)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (rotationY < 60)
        {
            transform.Translate(Vector3.back * Time.deltaTime * adjustedSpeed);
        }
    }
}
