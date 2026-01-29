using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _waterDropsPrefabs = new List<GameObject>();
    [SerializeField] private int _poolSize = 10;
    
    private List<GameObject> _spawnedObjects = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = _waterDropsPrefabs[Random.Range(0, _waterDropsPrefabs.Count)];
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
