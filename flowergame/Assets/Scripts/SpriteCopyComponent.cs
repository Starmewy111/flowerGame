using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteCopyComponent : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteToCopy;

    private SpriteRenderer _currentSprite;
    void Start()
    {
        if(_spriteToCopy == null)
            throw new Exception("no sprite to copy");
        
        _currentSprite = GetComponent<SpriteRenderer>();
        
        
        _currentSprite.sortingOrder = _spriteToCopy.sortingOrder;
        _currentSprite.sortingOrder--;
        
        _currentSprite.sprite = _spriteToCopy.sprite;
    }

    private void LateUpdate()
    {
        _currentSprite.sprite =  _spriteToCopy.sprite;
        _currentSprite.flipX = _spriteToCopy.flipX;
    }
}
