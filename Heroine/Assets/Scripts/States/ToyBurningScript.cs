using UnityEngine;

namespace Chapter.State
{
    public class ToyBurningState : MonoBehaviour, IToyState
    {
        private ToyController _toyController;

        public void Handle(ToyController toyController)
        {
            if (!_toyController)
                _toyController = toyController;


        }
    }
}