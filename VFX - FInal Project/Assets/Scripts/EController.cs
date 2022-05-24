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

    bool timerizer;
    float timer = 0;

    private bool _equipped = false;

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
    }

    void EXPLODE()
    {
        for (int i = 0; i < particleSystemExtremities.Length; i++)
        {
            particleSystemExtremities[i].Play();
        }
        particleSystemHip.Play();
        shield.transform.position = shieldPosition.position;
        shieldEffects.Play();
        smoke.Play();
    }

}
