using UnityEngine;

namespace Chapter.State
{

    public class ToyExplodingState : MonoBehaviour, IToyState
    {
        private ToyController _toyController;
        private ParticleSystem _particleSystem;
        private ParticleSystem.Burst _burst;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _burst = _particleSystem.emission.GetBurst(0);
        }

        public void Handle(ToyController toyController)
        {
            if (!_toyController)
                _toyController = toyController;

            _particleSystem.Play();
            _toyController.rb.velocity = Vector3.up * _toyController.jumpHeight * 0.5f;
            
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground") && _toyController)
            {
                Debug.Log("Hit Gtounds");
                _toyController.transform.Rotate(0, 0, 0);
                _toyController.isGrounded = true;
            }
        }
    }
}