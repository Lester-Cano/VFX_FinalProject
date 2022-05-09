using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QController : MonoBehaviour
{
    [SerializeField]ParticleSystem ps;
    [SerializeField]Material dissolveMaterial;
    [SerializeField] float durationDisolve = 0.5f;
    float timeModifier = 0;
    bool Disolving;
    float temp =0;
    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        dissolveMaterial.SetFloat("DissolveAmount_", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && ps != null && dissolveMaterial != null){
            ps.startLifetime = durationDisolve+0.2f;
            timeModifier = 1 / durationDisolve;
            Invoke("StartDissolving", 0.2f);
            ps.Play();  
        }
        if (Disolving)
        {
            temp += Time.deltaTime * timeModifier;
            dissolveMaterial.SetFloat("DissolveAmount_", 1- temp);
            if(temp>= 1)
            {
                Disolving=false;
                temp = 0;
                timeModifier=0;
            }
        }
    }
    void StartDissolving()
    {
        Disolving = true;
    }
}
