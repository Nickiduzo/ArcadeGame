using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    public static event Action GameOver;

    [SerializeField] private WheelCollider[] wheels;
    [SerializeField] private WheelHit[] hits;
    [SerializeField] public float speed = 5f;

    private float timeToPick = 1.5f;
    private void Start()
    {
        AudioManager.instance.Play("Volga");
    }
    void Update()
    {
        timeToPick -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timeToPick <= 0)
        {
            timeToPick = 1.5f;
            AudioManager.instance.Play("PickPick");
        }

        if (Input.GetKey(KeyCode.W) && speed < 50f)
        {
            speed += Time.deltaTime * 10;
        }
        else if (Input.GetKey(KeyCode.S) && speed > 10f)
        {
            speed -= Time.deltaTime * 15;
        }
        else if (speed > 20f)
        {
            speed -= Time.deltaTime * 10;
        }


        if (IsOnGround())
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.fixedDeltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.fixedDeltaTime);
            }
        }
    }

    private bool IsOnGround()
    {
        int wheelsOnGround = 0;
        foreach (WheelCollider wheelCollider in wheels)
        {
            if (wheelCollider.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        return wheelsOnGround == 4 ? true : false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bot"))
        {
            AudioManager.instance.Play("Crash");
            GameOver?.Invoke();
        }
    }
}
