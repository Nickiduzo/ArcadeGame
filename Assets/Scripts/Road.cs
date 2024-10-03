using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private List<GameObject> roadInstances;
    [SerializeField] private GameObject trigger;
    [SerializeField] private int countOfPlatforms;
    [SerializeField] private float speedOfPlatform;

    private List<GameObject> roads = new List<GameObject>();
    

    private void Awake()
    {
        for(int i = 0; i < countOfPlatforms; i++)
        {
            SpawnPlatForms();
        }
    }
    private void Update()
    {
        
    }
    
    private Transform GetPositionOffRoad()
    {
        return trigger.transform;
    }

    private void SpawnPlatForms()
    {
        GameObject roadExample = Instantiate(GetRandomRoad(), GetPositionOffRoad().transform.position, Quaternion.identity);
        //roadExample.transform.position = 
        roadInstances.Add(roadExample);
    }

    private int GetLastIndex()
    {
        if (roads.Count != 0)
        {
            return roads.Count - 1;
        }
        return 1;
    }
    private GameObject GetRandomRoad()
    {
        return roadInstances[Random.Range(0, roadInstances.Count)];
    }
}
