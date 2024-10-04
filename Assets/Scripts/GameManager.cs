using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUi;
    private void Start()
    {
        Car.GameOver += SetGameOver;
    }

    private void SetGameOver()
    {
        Time.timeScale = 0f;
        gameOverUi.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    private void OnDisable()
    {
        Car.GameOver -= SetGameOver;
    }
}
