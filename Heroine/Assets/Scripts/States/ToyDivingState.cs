using UnityEngine;

namespace Chapter.State
{
    public class ToyDivingState : MonoBehaviour, IToyState
    {
        private ToyController _toyController;

        public void Handle(ToyController toyController)
        {
            if (!_toyController)
                _toyController = toyController;

            _toyController.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            _toyController.rb.velocity += Vector3.up * Physics.gravity.y * (_toyController.diveSpeed - 1) * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground") && _toyController)
            {
                Debug.Log("Hit Gtounds From Dive");
                _toyController.transform.localScale = new Vector3(0f, 0f, 0f);
                _toyController.transform.Rotate(0, 0, 0);
            }
        }
    }
}
