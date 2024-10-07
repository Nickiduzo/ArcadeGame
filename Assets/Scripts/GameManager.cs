using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUi;
    [SerializeField] private TextMeshProUGUI distance;
    [SerializeField] private TextMeshProUGUI speed;
    
    [SerializeField] private TextMeshProUGUI speedOfMeter;
    [SerializeField] private Road road;
    
    [SerializeField] private Collection collections;
    [SerializeField] private TextMeshProUGUI displayDiamonds;

    [SerializeField] private TextMeshProUGUI displayDistance;
    [SerializeField] private Record record;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera hitCamera;
     private void Start()
    {
        Car.GameOver += SetGameOver;
        Diamond.AddDiamond += AddDiamond;
        AudioManager.instance.Play("Music");
    }

    private void Update()
    {
        DisplayInfo();
    }
    private void DisplayInfo()
    {
        string speed = GetRoundOffFloat(road.speed);
        string distance = GetRoundOffFloat(road.totalDistanceKm);

        speedOfMeter.text = speed + " km/h";
        displayDistance.text = distance + " km";
        displayDiamonds.text = collections.diamods.ToString();
    }
    private void AddDiamond()
    {
        AudioManager.instance.Play("Collect");
        collections.AddDiamond(1);
    }
    private void SetGameOver()
    {
        AudioManager.instance.StopAll();

        mainCamera.gameObject.SetActive(false);
        hitCamera.gameObject.SetActive(true);


        speed.text = "Speed: " + GetRoundOffFloat(road.speed);
        distance.text = "Distance: " + GetRoundOffFloat(road.totalDistanceKm);

        SetNewRecord();
        Time.timeScale = 0f;
        gameOverUi.SetActive(true);
    }

    private void SetNewRecord()
    {
        record.SetRecord(road.totalDistanceKm,road.speed);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    private string GetRoundOffFloat(float temp)
    {
        return (MathF.Round(temp * 100f) / 100f).ToString();
    }
    private void OnDisable()
    {
        SetNewRecord();
        Car.GameOver -= SetGameOver;
        Diamond.AddDiamond -= AddDiamond;
    }
}
