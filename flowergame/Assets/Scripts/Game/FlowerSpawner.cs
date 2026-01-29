using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawningObjects = new List<GameObject>();
    [SerializeField] private int _poolAmount;

    private Vector2 _currentNewPos;

    [SerializeField] public float spawnTimer;

    [SerializeField] private bool randomFlip;
    [SerializeField] private bool randomAnimationSpeed;

    [SerializeField] private Vector2 _spawnArea;
    private Vector2 currentPos;
    private Camera _camera;

    private List<GameObject> _spawnedObjects = new List<GameObject>();

    private void Awake()
    {
        _camera = Camera.main;
        currentPos = _camera.transform.position;
        
        for (int i = 0; i < _poolAmount; i++)
        {
            int obj =  Random.Range(0, _spawningObjects.Count);
            
            GameObject spawned = SpawnObject(_spawningObjects[obj]);
            _spawnedObjects.Add(spawned);
            
            spawned.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        StartCoroutine(RevealGameObject());
    }

    private GameObject SpawnObject(GameObject obj)
    {
        
        float newPosx = Random.Range(-_spawnArea.x, _spawnArea.x);
        float newPosy = Random.Range(-_spawnArea.y, _spawnArea.y);
        
        _currentNewPos = new Vector2(newPosx, newPosy);
        obj.transform.position = _currentNewPos;
        
        GameObject newObj = Instantiate(obj.gameObject, obj.transform.position, Quaternion.identity, transform);

        if (randomFlip)
        {
            SpriteRenderer newSprite = newObj.GetComponentInChildren<SpriteRenderer>();
            if(newSprite == null)
                throw new Exception($"Sprite does not exist! {obj.name}, can only use RANDOMFLIP with Sprite!");
            
            float random = Random.Range(0f, 1f);
            if(random <= 0.5f) newSprite.flipX = true;
        }

        if (randomAnimationSpeed)
        {
            Animator animator = obj.GetComponentInChildren<Animator>();
            if(animator == null)
                throw new Exception($"Animator does not exist! {obj.name}, can only use RANDOMANIMATION with Animator!");
            
            float random =  Random.Range(0f, 1f);
            animator.speed = random;
        }

        return newObj;
    }
    
    private IEnumerator RevealGameObject()
    {
        while (true)
        {
            foreach (GameObject obj in _spawnedObjects)
            {
                if(obj.activeSelf) yield return new WaitForEndOfFrame();
                
                obj.gameObject.SetActive(true);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        currentPos = Vector2.zero;
        Vector3 from = currentPos - _spawnArea;
        Vector3 to = currentPos + _spawnArea;
        
        Gizmos.DrawLine(from, new Vector3(to.x, from.y));
        Gizmos.DrawLine(new Vector3(to.x, from.y), to);
        Gizmos.DrawLine(to, new Vector3(from.x, to.y));
        Gizmos.DrawLine(new Vector3(from.x, to.y), from);
        Gizmos.DrawLine(from, to);
    }

}
