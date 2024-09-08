using UnityEngine;

namespace Chapter.State
{
    public class ToyJumpingState : MonoBehaviour, IToyState
    {
        private ToyController _toyController;
        
        public void Handle(ToyController toyController)
        {
            
            if (!_toyController)
                _toyController = toyController;

            _toyController.rb.velocity = Vector3.up * _toyController.jumpHeight;
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