using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    private List<Transform> roads = new List<Transform>();
    [SerializeField] private List<GameObject> prefabs;

    [SerializeField] private Car car;

    [SerializeField] private int countOfRoads;
    [SerializeField] private float speed;
    [SerializeField] private float deleteRoadOffSetZ;

    private Transform deleteRoadPoint;

    [SerializeField] private float offsetPosZ;

    private void Start()
    {
        for (int i = 0; i < countOfRoads; i++)
            SpawnNextRoad();

        deleteRoadPoint = roads[0].transform;
    }

    private void Update()
    {
        speed = car.speed;
        AvaibleMoving();
    }

    private void SpawnNextRoad()
    {
        Vector3 spawnPos = new Vector3(0,0,0);
        if (roads.Count != 0)
        {
            spawnPos = new Vector3(0, 0, offsetPosZ * (roads.Count - 1));
        }

        var newRoad = SpawnRandomPlatfrom(spawnPos);
        
        roads.Add(newRoad);
        newRoad.SetParent(transform);
    }

    private void AvaibleMoving()
    {
        MovePlatforms();
        DeletePlatform();
    }

    private void MovePlatforms()
    {
        roads.ForEach(r => r.transform.Translate(Vector3.forward * Time.deltaTime * -speed));
    }

    private void DeletePlatform()
    {
        if (deleteRoadPoint.position.z + deleteRoadOffSetZ < transform.position.z)
        {
            Destroy(roads[0].gameObject);
            roads.RemoveAt(0);

            SpawnNextRoad();
            deleteRoadPoint = roads[0].transform;
        }
    }
    private Transform SpawnRandomPlatfrom(Vector3 position)
    {
       return Instantiate(GetRandomPrefab(),position, transform.rotation).transform;
    }
    private GameObject GetRandomPrefab()
    {
        return prefabs[Random.Range(0, prefabs.Count - 1)];
    }
}
