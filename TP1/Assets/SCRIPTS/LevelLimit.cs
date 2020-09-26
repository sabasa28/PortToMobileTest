using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLimit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.endOfStage = true;
        }
    }
}
