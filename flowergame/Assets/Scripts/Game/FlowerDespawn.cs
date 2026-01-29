using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FlowerDespawn : MonoBehaviour
{
    [SerializeField] private float _maxTimer;
    [SerializeField] private float _maxRandomiser;
    
    public float currentTimer{get; private set;}
    
    private void OnEnable()
    {
        currentTimer = _maxTimer += Random.Range(-_maxRandomiser, _maxRandomiser);
    }

    private void onDisable()
    {
        currentTimer = 0;
    }

    
    void Update()
    {
        currentTimer -= Time.deltaTime;
        currentTimer = Mathf.Clamp(currentTimer, 0 , _maxTimer);
        
        if (currentTimer <= 0) gameObject.SetActive(false);

    }
}
