using UnityEngine;

public class DayToNight : MonoBehaviour
{
    [Header("Time Settings")]
    public float dayDurationInMinutes = 1f; // Длительность дня в минутах

    [Header("Lighting Settings")]
    public Light directionalLight;          // Ссылка на Directional Light
    public Gradient lightColor;             // Цвет света в зависимости от времени
    public AnimationCurve lightIntensity;   // Интенсивность света в зависимости от времени

    private float timeOfDay = 0f;           // От 0 до 1, где 0 - полночь, 0.5 - полдень, 1 - снова полночь
    private float secondsPerDay;

    private void Start()
    {
        // Конвертируем длительность дня из минут в секунды
        secondsPerDay = dayDurationInMinutes * 60f;
    }

    private void Update()
    {
        // Обновляем время дня
        timeOfDay += Time.deltaTime / secondsPerDay;

        // Ограничиваем время дня значением от 0 до 1 (переход по кругу)
        if (timeOfDay >= 1f)
        {
            timeOfDay = 0f;
        }

        // Устанавливаем вращение света по оси X (симулирует движение солнца)
        directionalLight.transform.rotation = Quaternion.Euler(new Vector3((timeOfDay * 360f) - 90f, 170f, 0f));

        // Изменяем цвет и интенсивность света в зависимости от времени дня
        directionalLight.color = lightColor.Evaluate(timeOfDay);
        directionalLight.intensity = lightIntensity.Evaluate(timeOfDay);
    }
}
