using UnityEngine;

namespace Chapter.State
{
    public class ToyGrowingState : MonoBehaviour, IToyState
    {
        private ToyController _toyController;

        public void Handle(ToyController toyController)
        {
            if (!_toyController)
                _toyController = toyController;

            Debug.Log("Grow is in control" + _toyController);

            if (_toyController.isGrowing)
            {
                //Debug.Log("In Grow State");
                _toyController.transform.localScale = new Vector3(2, 2, 2);
            }
            else
            {
                //Debug.Log("Get Smaller");
                _toyController.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}