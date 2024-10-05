using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Car car;
    [SerializeField] private GameObject[] roadPrefab;
    
    [SerializeField] private float speed = 20;
    
    [SerializeField] private int amountOfRoads;

    [SerializeField] private float valueOfSpeed;

    [SerializeField] private Transform endPoint;

    private float zPosSpawner = 66.5f;
    private List<GameObject> roads = new List<GameObject>();

    private void Start()
    {
        RoadInitialization();
    }

    private void Update()
    {
        speed = car.speed;

        GenerateMove();
    }

    private void RoadInitialization()
    {
        for(int i = 0; i < amountOfRoads;i++)
        {
            SpawnRoad();
        }
    }

    private void SpawnRoad()
    {
        if (roads.Count == 0)
        {
            GameObject newRoad = Instantiate(GetRandomRoad(),transform.position,transform.rotation);
            newRoad.transform.SetParent(transform);
            roads.Add(newRoad);
        }
        else
        {
            GameObject newRoad = Instantiate(GetRandomRoad(),GetPosition(), transform.rotation);
            newRoad.transform.SetParent(transform);
            roads.Add(newRoad);
        }
    }
    
    private void GenerateMove()
    {
        MoveRoad();
        DeleteRoad();
    }
    private void MoveRoad()
    {
        foreach (GameObject road in roads)
        {
            road.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }

    private void DeleteRoad()
    {
        foreach(GameObject road in roads)
        {
            if (road.transform.position.z <= endPoint.position.z)
            {
                Destroy(road);
                roads.Remove(road);
                SpawnRoad();
                break;
            }
        }

    }

    private Vector3 GetPosition()
    {
        return new Vector3(roads[roads.Count - 1].transform.position.x, roads[roads.Count - 1].transform.position.y, roads[roads.Count - 1].transform.position.z + zPosSpawner);
    }
    private GameObject GetRandomRoad()
    {
        return roadPrefab[Random.Range(0, roadPrefab.Length)];
    }
}
