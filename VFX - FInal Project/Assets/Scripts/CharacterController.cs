using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private PlayerController _playerController;
    [SerializeField] private GameObject character;
    private Animator _animator;

    private void Awake()
    {
        _playerController = new PlayerController();
        _animator = character.GetComponent<Animator>();
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
    
    private void Update()
    {
        if (_playerController.Skills.QSkill.triggered)
        {
            Debug.Log("Q Skill");
        }
        
        if (_playerController.Skills.ESkill.triggered)
        {
            Debug.Log("E Skill");
        }
        
        if (_playerController.Skills.RSkill.triggered)
        {
            Debug.Log("R Skill");
        }
    }
}
