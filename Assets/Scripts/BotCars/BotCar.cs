using UnityEngine;

public class BotCar : MonoBehaviour
{
    private float speed = 3f;
    private float roadSpeed = 0f;

    private float zOffPosition = -15;

    private float lefrCorner = -3f;
    private float rightCorent = 3f;

    private Road road;

    [SerializeField] private GameObject carLight;
    private void Start()
    {
        road = GameObject.Find("MainRoad").GetComponent<Road>();
        if (road == null )
        {
            print("ִמנמדא סתובאכאסü");
        }
    }
    private void Update()
    {
        LimitMovement();
        Behaviour();
        CheckTime();
    }
    private void CheckTime()
    {
        if (TimeManager.instance.IsItMorning())
            carLight.gameObject.SetActive(false);

        if(TimeManager.instance.IsItEvening())
            carLight.gameObject.SetActive(true);
    }

    private void LimitMovement()
    {
        if(transform.position.x < lefrCorner)
        {
            transform.position = new Vector3(lefrCorner, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightCorent)
        {
            transform.position = new Vector3(rightCorent, transform.position.y, transform.position.z);
        }
    }
    private void Behaviour()
    {
        roadSpeed = road.speed;

        if (transform.rotation.eulerAngles.y > 60)
        {
            transform.Translate(Vector3.forward * (speed + roadSpeed) * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * (speed - roadSpeed) * Time.deltaTime);
        }
        GetOffPosition();
    }

    private void GetOffPosition()
    {
        if (transform.position.z < zOffPosition || transform.position.z > 200)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < 0 || transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }   
}
