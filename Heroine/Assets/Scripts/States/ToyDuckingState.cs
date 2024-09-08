using UnityEngine;

namespace Chapter.State
{
    public class ToyDuckingState : MonoBehaviour, IToyState
    {
        private ToyController _toyController;
        
        public void Handle(ToyController toyController)
        {
            
            if (!_toyController)
                _toyController = toyController;

            Debug.Log("Duck is in control" + _toyController);

            if (_toyController.isDucking)
            {
                //Debug.Log("In Duck State");
                _toyController.transform.localScale = new Vector3(1, 0.5f, 1);
            }
            else
            {
                //Debug.Log("Get Bigger");
                _toyController.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}