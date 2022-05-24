using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EController : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particleSystemExtremities;
    [SerializeField] ParticleSystem particleSystemHip;
    [SerializeField] GameObject shield;
    [SerializeField] ParticleSystem shieldEffects;
    [SerializeField] Transform shieldPosition;
    [SerializeField] ParticleSystem smoke;

    private PlayerController _playerController;
    [SerializeField] private Animator animator;
    [SerializeField] Material dissolveMaterial;
    [SerializeField] AudioSource audioSource;

    bool timerizer;
    float _temp = 0;
    float temporizador = 0;

    [SerializeField] float _timeModifier = 1;

    private bool _equipped = false;
    [SerializeField] bool _creating, _dissolving;

    void Awake()
    {
        _playerController = new PlayerController();
        shieldEffects = shield.GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerController.Enable();
    }

    private void OnDisable()
    {
        _playerController.Disable();
    }

    void Update()
    {
        if (_playerController.Skills.ESkill.triggered)
        {
            if (_equipped)
            {
                animator.SetTrigger("E Shoot");
                _equipped = false;
            }
            else
            {
                animator.SetTrigger("E Equip");
                _equipped = true;
            }
        }

        

        if (_creating)
        {
            _temp += Time.deltaTime * _timeModifier;
            dissolveMaterial.SetFloat("DissolveAmount",1 - _temp);
            if (_temp >= 0.9)
            {
                _creating = false;
                _temp = 0;
                _timeModifier = 0;
                _dissolving = true;
            }
        }
        if (_dissolving)
        {
            _temp -= Time.deltaTime * _timeModifier;
            dissolveMaterial.SetFloat("DissolveAmount",1 + _temp);
            if (_temp <= 0)
            {
                _dissolving = false;
                _temp = 0;
                _timeModifier = 0;
            }
        }

        

    }

    void EXPLODE()
    {
        audioSource.Play();
        for (int i = 0; i < particleSystemExtremities.Length; i++)
        {
            particleSystemExtremities[i].Play();
        }
        particleSystemHip.Play();
        shield.transform.position = shieldPosition.position;
        shieldEffects.Play();
        smoke.Play();
        _creating = true;
        _dissolving = false;
        timerizer = true;
    }

}
