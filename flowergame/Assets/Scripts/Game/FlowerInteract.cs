using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class FlowerInteract : MonoBehaviour,  IInteractable
    {
        [SerializeField] private ParticleSystem _interactParticles;

        public UnityAction Interact()
        {
            gameObject.SetActive(false);
            
            return null;
        }
    }
}