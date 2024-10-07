using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private DayToNight dayNightCycle;

    public static TimeManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    public bool IsItMorning()
    {
        float hours = ConvertTimeToHours();
        return hours >= 6f && hours <= 12f;
    }

    public bool IsItEvening()
    {
        float hours = ConvertTimeToHours();
        return hours >= 18f || hours < 6f;
    }

    private float ConvertTimeToHours()
    {
        return dayNightCycle.timeOfDay * 24f;
    }
}
