using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class QController : MonoBehaviour
{
    [Header("Character Stuff")]
    
    private PlayerController _playerController;
    [SerializeField] private Animator animator;
    
    [Header ("Bow & Arrow Shader")]
    
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private Material dissolveMaterial;
    [SerializeField] private float durationDissolve = 0.5f;
    private float _timeModifier = 0;
    private bool _creating, _dissolving;
    private float _temp =0;

    [Header("Particle Effects")] 
    
    [SerializeField] private Transform spawnPos;
    [SerializeField] private ParticleSystem anticipation, mainEffect, dissipation;
    
    //Q Animations

    private bool _equipped;

    private void Awake()
    {
        _playerController = new PlayerController();
        animator = GetComponent<Animator>();
        ps = GetComponentInChildren<ParticleSystem>();
    }

    #region OnEnable && OnDisable

    private void OnEnable()
    {
        _playerController.Enable();
    }

    private void OnDisable()
    {
        _playerController.Disable();
    }

    #endregion
    
    void Start()
    {
        dissolveMaterial.SetFloat("DissolveAmount_", 1);
    }
    
    void Update()
    {
        if (_playerController.Skills.QSkill.triggered)
        {
            if (_equipped)
            {
                animator.SetTrigger("Q Shoot");
                _equipped = false;
            }
            else
            {
                animator.SetTrigger("Q Equip");
                _equipped = true;
            }
        }
        
        if (_creating)
        {
            _temp += Time.deltaTime * _timeModifier;
            dissolveMaterial.SetFloat("DissolveAmount_", 1 - _temp);
            if(_temp >= 1)
            {
                _creating = false;
                _temp = 0;
                _timeModifier = 0;
            }
        }
        if (_dissolving)
        {
            _temp -= Time.deltaTime * _timeModifier;
            dissolveMaterial.SetFloat("DissolveAmount_", 1 - _temp);
            if(_temp <= 0)
            {
                _dissolving = false;
                _temp = 0;
                _timeModifier = 0;
            }
        }
    }
    
    private void StartCreating()
    {
        _creating = true;
    }
    
    private void StartDissolving()
    {
        _dissolving = true;
    }

    public void CreateBow()
    {
        if (ps != null && dissolveMaterial != null)
        {
            ps.startLifetime = durationDissolve+0.2f;
            _timeModifier = 1 / durationDissolve;
            Invoke("StartCreating", 0.2f);
            ps.Play();
        }
    }

    public void DissolveBow()
    {
        if (ps != null && dissolveMaterial != null)
        {
            ps.startLifetime = durationDissolve+0.2f;
            _timeModifier = 1 / durationDissolve;
            Invoke("StartDissolving", 0.2f);
            ps.Play();
        }
    }

    public void ShootArrow()
    {
        Debug.Log("Arrow");
        
        var anti = Instantiate(anticipation, spawnPos);
        var main = Instantiate(mainEffect, spawnPos);
        anti.Play();
        main.Play();
    }
}
