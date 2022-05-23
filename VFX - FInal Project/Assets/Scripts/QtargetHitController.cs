using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QtargetHitController : MonoBehaviour
{
    // Start is called before the first frame update
    QController qController;
    void Start()
    {
         qController = FindObjectOfType<QController>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            qController.Spawndisipation(gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
