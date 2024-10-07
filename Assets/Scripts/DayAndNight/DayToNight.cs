using UnityEngine;

public class DayToNight : MonoBehaviour
{
    [Header("Time Settings")]
    public float dayDurationInMinutes = 1f; 

    [Header("Lighting Settings")]
    public Light directionalLight;          
    public Gradient lightColor;             
    public AnimationCurve lightIntensity;   

    [HideInInspector] public float timeOfDay = 0f;           
    private float secondsPerDay;

    private void Start()
    {
        secondsPerDay = dayDurationInMinutes * 60f;
    }

    private void Update()
    {
        timeOfDay += Time.deltaTime / secondsPerDay;

        if (timeOfDay >= 1f)
        {
            timeOfDay = 0f;
        }

        directionalLight.transform.rotation = Quaternion.Euler(new Vector3((timeOfDay * 360f) - 90f, 170f, 0f));

        directionalLight.color = lightColor.Evaluate(timeOfDay);
        directionalLight.intensity = lightIntensity.Evaluate(timeOfDay);
    }
}
