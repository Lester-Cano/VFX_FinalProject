using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Audio;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

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

    [Header("Particle Effects")] [SerializeField]
    private float speedArrow, originalSpeed, dissipationDur;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private ParticleSystem anticipation, mainEffect, dissipation, dissipationIntenseEnd;
    
    //Q Animations

    private bool _equipped;
    [SerializeField] private Slider slider;

    [Header("Sounds")] 
    public AudioManager audioManager;

    public bool _intense = true;

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
        originalSpeed = speedArrow;
        dissipationDur = dissipation.main.duration;
    }
    
    void Update()
    {
        if (_playerController.Skills.QSkill.triggered)
        {
            if (_equipped)
            {
                animator.SetTrigger("Q Shoot");
                audioManager.Play("Q - Arrow");
                _equipped = false;
            }
            else
            {
                animator.SetTrigger("Q Equip");
                audioManager.Play("Q - Equip");
                _equipped = true;
            }
        }
        
        if (_creating)
        {
            _temp += Time.deltaTime * _timeModifier;
            dissolveMaterial.SetFloat("DissolveAmount_", 1 - _temp);
            if(_temp >= 0.9)
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
        audioManager.Play("Q - Unequip");
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
        if (!_intense)
        {
            var anti = Instantiate(anticipation, spawnPos);
            anti.gameObject.transform.parent = null;
            var main = Instantiate(mainEffect, spawnPos);
            main.gameObject.transform.parent = null;
            Rigidbody mainRgb = main.gameObject.GetComponent<Rigidbody>();
            mainRgb.AddForce(Vector3.forward * speedArrow);
            main.gameObject.transform.rotation = Quaternion.identity;
            anti.Play();
            main.Play();
            Destroy(anti,5f);
            Destroy(main, 5f);
        }
    }

    public IEnumerator ShootArrowIntenseEnd()
    {
        if (_intense)
        {
            var anti = Instantiate(anticipation, spawnPos);
            anti.gameObject.transform.parent = null;
            var main = Instantiate(mainEffect, spawnPos);
            main.gameObject.transform.parent = null;
            Rigidbody mainRgb = main.gameObject.GetComponent<Rigidbody>();
            mainRgb.AddForce(Vector3.forward * speedArrow / 12);
            main.gameObject.transform.rotation = Quaternion.identity;
            anti.Play();
            main.Play();
        
            yield return new WaitForSeconds(1);
            mainRgb.AddForce(Vector3.forward * speedArrow);
        
            Destroy(anti,5f);
            Destroy(main, 5f);
        }
    }
    
    public void Spawndisipation(GameObject hitPosition)
    {
        audioManager.Play("Q - Explosion");
        var dis = Instantiate(dissipation, hitPosition.gameObject.transform);
        dis.Play();
        Destroy(dis, 5f);
    }
    
    public void SpawnDisipationIntenseEnd(GameObject hitPosition)
    {
        audioManager.Play("Q - Explosion");
        var dis = Instantiate(dissipationIntenseEnd, hitPosition.gameObject.transform);
        dis.Play();
        Destroy(dis, 5f);
    }

    public void ChangeVolume()
    {
        animator.speed = slider.value;
        speedArrow = originalSpeed * slider.value;
    }

    public void Intense()
    {
        if (_intense)
        {
            _intense = false;
        }
        else if (!_intense)
        {
            _intense = true;
        }
    }
}
