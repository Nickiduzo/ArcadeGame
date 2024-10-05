using UnityEngine;

public class DayToNight : MonoBehaviour
{
    [Header("Time Settings")]
    public float dayDurationInMinutes = 1f; // ������������ ��� � �������

    [Header("Lighting Settings")]
    public Light directionalLight;          // ������ �� Directional Light
    public Gradient lightColor;             // ���� ����� � ����������� �� �������
    public AnimationCurve lightIntensity;   // ������������� ����� � ����������� �� �������

    private float timeOfDay = 0f;           // �� 0 �� 1, ��� 0 - �������, 0.5 - �������, 1 - ����� �������
    private float secondsPerDay;

    private void Start()
    {
        // ������������ ������������ ��� �� ����� � �������
        secondsPerDay = dayDurationInMinutes * 60f;
    }

    private void Update()
    {
        // ��������� ����� ���
        timeOfDay += Time.deltaTime / secondsPerDay;

        // ������������ ����� ��� ��������� �� 0 �� 1 (������� �� �����)
        if (timeOfDay >= 1f)
        {
            timeOfDay = 0f;
        }

        // ������������� �������� ����� �� ��� X (���������� �������� ������)
        directionalLight.transform.rotation = Quaternion.Euler(new Vector3((timeOfDay * 360f) - 90f, 170f, 0f));

        // �������� ���� � ������������� ����� � ����������� �� ������� ���
        directionalLight.color = lightColor.Evaluate(timeOfDay);
        directionalLight.intensity = lightIntensity.Evaluate(timeOfDay);
    }
}
