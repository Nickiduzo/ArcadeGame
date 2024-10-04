using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;

    [SerializeField] private Transform leftSpawner;
    [SerializeField] private Transform rightSpawner;

    private float startDelay = 3f;
    private float delay = 2.5f;

    private List<GameObject> cars = new List<GameObject>();
    private void Start()
    {
        InvokeRepeating("SpawnVechicleCoroutine",startDelay,delay);
    }

    private void SpawnVechicleCoroutine()
    {
        if (cars.Count < 25)
        {
            SpawnProcess();
        }
    }

    private void SpawnProcess()
    {
        if (RandomDirection() == 1)
        {
            var newVechicle = Instantiate(GetRandomVechicle(), rightSpawner.position, transform.rotation);
            newVechicle.transform.position = new Vector3(rightSpawner.position.x, 0, RightPointRand());
            cars.Add(newVechicle);
        }
        else
        {
            var newVechicle = Instantiate(GetRandomVechicle(), leftSpawner.position, transform.rotation);
            newVechicle.transform.Rotate(0, 180, 0);
            newVechicle.transform.position = new Vector3(leftSpawner.position.x, 0, LeftPointRand());
            cars.Add(newVechicle);
        }
    }
    private float RightPointRand()
    {
        return Random.Range(rightSpawner.transform.position.z, rightSpawner.transform.position.z + 25);
    }

    private float LeftPointRand()
    {
        return Random.Range(leftSpawner.transform.position.z, rightSpawner.transform.position.z + 25);
    }

    private int RandomDirection()
    {
        return Random.Range(0, 2);
    }

    private GameObject GetRandomVechicle()
    {
        return prefabs[prefabs.Length - 1];
    }
}
