using UnityEngine;

namespace Chapter.State
{
    public class ToySpiningState : MonoBehaviour, IToyState
    {
        private ToyController _toyController;

        public void Handle(ToyController toyController)
        {
            if (!_toyController)
                _toyController = toyController;

            Debug.Log("SPINING!!!!");

            _toyController.transform.Rotate(45, 10 * Time.deltaTime, 45);
        }
    }
}