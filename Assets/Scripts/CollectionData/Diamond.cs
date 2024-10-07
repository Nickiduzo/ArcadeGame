using System;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public static event Action AddDiamond;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddDiamond?.Invoke();
            Destroy(gameObject);
        }
    }
}
