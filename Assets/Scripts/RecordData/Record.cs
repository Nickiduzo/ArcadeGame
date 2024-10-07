using UnityEngine;

[CreateAssetMenu(fileName ="Record", menuName ="Records/Record")]
public class Record : ScriptableObject
{
    [SerializeField] private float recordDistance;
    [SerializeField] private float recordSpeed;

    public void SetRecord(float distance, float speed)
    {
        if(distance > recordDistance) distance = recordDistance;

        if(speed > recordSpeed) speed = recordSpeed;
    }
}
