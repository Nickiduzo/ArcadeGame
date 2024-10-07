using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Transform leftSpawner;
    [SerializeField] private Transform rightSpawner;

    private float startDelay = 3f;
    private float delay = 2.5f;
    private void Start()
    {
        InvokeRepeating("SpawnProcess", startDelay,delay);
    }

    private void SpawnProcess()
    {
        if (RandomDirection() == 1)
        {
            var newVechicle = Instantiate(GetRandomVechicle(), GetRightPosition(), Quaternion.identity);
            newVechicle.transform.SetParent(rightSpawner);
        }
        else
        {
            var newVechicle = Instantiate(GetRandomVechicle(), GetLeftPosition(), Quaternion.Euler(0,180,0));
            newVechicle.transform.SetParent(leftSpawner);
        }
    }
    private Vector3 GetRightPosition()
    {
        float xPos = Random.Range(1.18f, 3f);
        float yPos = rightSpawner.transform.position.y;
        float zPos = Random.Range(rightSpawner.transform.position.z -15f, rightSpawner.transform.position.z + 25f);
        return new Vector3(xPos, yPos, zPos);
    }

    private Vector3 GetLeftPosition()
    {
        float xPos = Random.Range(-3f, -1.18f);
        float yPos = leftSpawner.transform.position.y;
        float zPos = Random.Range(leftSpawner.transform.position.z, leftSpawner.transform.position.z + 25f);
        return new Vector3(xPos, yPos, zPos);
    }

    private int RandomDirection()
    {
        return Random.Range(0, 2);
    }
    private GameObject GetRandomVechicle()
    {
        return prefabs[Random.Range(0,prefabs.Length)];
    }
}
