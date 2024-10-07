using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    public static event Action GameOver;

    [SerializeField] private WheelCollider[] wheels;
    [SerializeField] private WheelHit[] hits;
    [SerializeField] public float speed = 5f;

    [SerializeField] private GameObject carLight;

    private float timeToPick = 1.5f;

    private float leftCorner = -3f;
    private float rightCorner = 3f;

    private void Start()
    {
        AudioManager.instance.Play("Volga");
    }
    private void Update()
    {
        PickPick();
        IncreaseDecreaseSpeed();
        TurnLeftRight();
        LimitMovement();
        CheckTime();
    }
    
    private void CheckTime()
    {
        if(TimeManager.instance.IsItMorning())
            carLight.gameObject.SetActive(false);

        if (TimeManager.instance.IsItEvening())
            carLight.gameObject.SetActive(true);
    }
    private void LimitMovement()
    {
        if (transform.position.x < leftCorner)
        {
            transform.position = new Vector3(leftCorner, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightCorner)
        {
            transform.position = new Vector3(rightCorner, transform.position.y, transform.position.z);
        }
    }
    private void PickPick()
    {
        timeToPick -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timeToPick <= 0)
        {
            timeToPick = 1.5f;
            AudioManager.instance.Play("PickPick");
        }
    }

    #region MOVE
    private void IncreaseDecreaseSpeed()
    {
        speed += Time.deltaTime * 2;
        
        if (Input.GetKey(KeyCode.S) && speed > 10f)
            speed -= Time.deltaTime * 30;
    }

    private void TurnLeftRight()
    {
        if (IsOnGround())
        {
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.left * Time.deltaTime * (speed/3));
            
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * Time.deltaTime * (speed/3));
        }
    }
    private bool IsOnGround()
    {
        int wheelsOnGround = 0;
        
        foreach (WheelCollider wheelCollider in wheels)
            if (wheelCollider.isGrounded)
                wheelsOnGround++;
    
        return wheelsOnGround == 4 ? true : false;
    }

    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bot"))
        {
            AudioManager.instance.Play("Crash");
            GameOver?.Invoke();
        }
    }
}
