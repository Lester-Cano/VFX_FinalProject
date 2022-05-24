using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShieldSize : MonoBehaviour
{

    [SerializeField] GameObject shield;
    ParticleSystem ParticleSystem;


    void Start()
    {
        ParticleSystem = shield.GetComponent<ParticleSystem>();
    }

   public void Pequeño()
    {
        shield.transform.localScale = new Vector3(1, 1, 1);
        Debug.Log("sirve");
    }
    public void Normal()
    {
        shield.transform.localScale = new Vector3(2, 2, 2);
    }
    public void Grande()
    {
        shield.transform.localScale = new Vector3(3, 3, 3);
    }
}
