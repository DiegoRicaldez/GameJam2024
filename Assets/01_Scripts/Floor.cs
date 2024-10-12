using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && !activated)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<PathGenerator>().Advance();
                activated = true;
            }
        }
    }
}
