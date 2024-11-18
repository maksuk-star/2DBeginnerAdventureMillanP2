using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        DuckoController controller = other.GetComponent<DuckoController>();
        if (controller != null)
        {
            controller.ChangeHealth(1);
            Destroy(gameObject);
        }
        
    }
}

