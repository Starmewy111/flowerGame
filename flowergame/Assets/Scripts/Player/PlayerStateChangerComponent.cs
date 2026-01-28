using UnityEngine;

public class PlayerStateChangerComponent : MonoBehaviour
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
        if (_playerController._rb.linearVelocity.magnitude > 0.1f)
        {
            if (_playerController._rb.linearVelocity.y > 0.1f)
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
        _playerAnimator.Flip(_playerController._rb);
    }
}
