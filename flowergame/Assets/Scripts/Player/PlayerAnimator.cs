using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

[System.Serializable]
public struct StateInformation
{
    [SerializeField] public PlayerStates _playerState;
    [SerializeField] public string _animationName;
}
public enum PlayerStates
{
    idle,
    backidle,
    walking,
    backwalking,
    collecting,
    backcollecting,
    giving,
    backgiving,
    
}
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] public List<StateInformation> animations;
    
    private Animator _animator;
    public PlayerStates _currentState;
    public SpriteRenderer _sprite;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeState(PlayerStates state)
    {
        if (state == _currentState) return;
        _currentState = state;
        
        string currentAnimName = GetAnimationName(state);
        
        switch (_currentState)
        {
            case PlayerStates.idle:
                _animator.CrossFade(currentAnimName, 0.0f, 0);
                break;
            
            case PlayerStates.backidle:
                _animator.CrossFade(currentAnimName, 0.0f, 0);
                break;
       
            case PlayerStates.walking:
                _animator.CrossFade(currentAnimName, 0.0f, 0);
                break;
            
            case PlayerStates.backwalking: 
                _animator.CrossFade(currentAnimName, 0.0f, 0);
                break;
            
            case PlayerStates.giving:
                _animator.CrossFade(currentAnimName, 0.0f, 0);
                break;
            
            case PlayerStates.backgiving:
                _animator.CrossFade(currentAnimName, 0.0f, 0);
                break;
        }
    }

    public void ResetAnimation()
    {
        FindAnyObjectByType<PlayerStateChangerComponent>().GetComponent<IAnimation>().ResetAnimation();
    }

    private string GetAnimationName(PlayerStates state)
    {
        foreach (var anim in animations)
        {
            if (anim._playerState == state)
                return anim._animationName;
        }

        throw new Exception($"no animation found for {state}");
    }
}
