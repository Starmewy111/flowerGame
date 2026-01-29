using Interfaces;
using UnityEngine;

public class PlayerStateChangerComponent : MonoBehaviour, IAnimation
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private InteractController _interactController;

    private bool backAnim;
    
    void Start()
    {
        if(_playerController == null)
            throw new System.Exception("PlayerController is null");
        
        if(_playerAnimator == null)
            throw new System.Exception("PlayerAnimator is null");
    }
    
    void Update()
    {
        Rigidbody2D rb = _playerController._rb;
        
        if(rb.linearVelocity.y > 0) _playerAnimator._sprite.flipX = rb.linearVelocity.x > 0 ? true : rb.linearVelocity.x < 0 ? false : _playerAnimator._sprite.flipX;
        else _playerAnimator._sprite.flipX = rb.linearVelocity.x < 0 ? true : rb.linearVelocity.x > 0 ? false : _playerAnimator._sprite.flipX;
        
        if (_playerController.isInteracting)
        {
            if(backAnim) _playerAnimator.ChangeState(PlayerStates.backgiving);
            else _playerAnimator.ChangeState(PlayerStates.giving);
            return;
        }
        if (rb.linearVelocity.magnitude > 0.1f)
        {
            if (rb.linearVelocity.y > 0.1f)
            {
                _playerAnimator.ChangeState(PlayerStates.backwalking);
                backAnim = true;
            }
            else
            {
                _playerAnimator.ChangeState(PlayerStates.walking);
                backAnim = false;
            }
        }
        else
        {
            if(backAnim) _playerAnimator.ChangeState(PlayerStates.backidle);
            else _playerAnimator.ChangeState(PlayerStates.idle);
        }
    }

    public void ResetAnimation()
    {
        _playerController.IsInteracting();
    }
}
