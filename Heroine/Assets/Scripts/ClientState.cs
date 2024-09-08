using UnityEngine;

namespace Chapter.State
{
    public class ClientState : MonoBehaviour
    {
        private ToyController _toyController;

        void Start()
        {
            _toyController =
                (ToyController)
                FindObjectOfType(typeof(ToyController));
        }

        void Update()
        {
            //Move to Jump State
            if (Input.GetKeyDown(KeyCode.Space) && _toyController.isGrounded)
            {
                Debug.Log("Jumped");
                _toyController.isGrounded = false;
                _toyController.isJumping = true;
                _toyController.Jump();
            }

            //Move to Dive State
            if (Input.GetKey(KeyCode.S) && !_toyController.isGrounded && _toyController.isJumping)
            {
                _toyController.Dive();
            }

            //Move to Ducking State
            if (Input.GetKey(KeyCode.S) && _toyController.isGrounded && !_toyController.isGrowing)
            {
                _toyController.isDucking = true;
                _toyController.Duck();
            }
            else if (Input.GetKeyUp(KeyCode.S) && !_toyController.isGrowing)
            {
                _toyController.isDucking = false;
                _toyController.Duck();
            }

            //Move to Spin State
            if (Input.GetMouseButton(0))
                _toyController.mouseDelta = Input.mousePosition - _toyController.lastMouseCoordinate;

            if (Input.GetMouseButton(0) && _toyController.mouseDelta.y < 0 && _toyController.isGrounded && !_toyController.isDucking && !_toyController.isGrowing)
                _toyController.Spin();


            _toyController.lastMouseCoordinate = _toyController.mouseDelta;

            if (Input.GetMouseButtonUp(0))
                _toyController.mouseDelta = Vector3.zero;

            //Move to Explode State
            if (Input.GetKeyDown(KeyCode.Q) && _toyController.isDucking && _toyController.isGrounded)
            {
                _toyController.isGrounded = false;
                _toyController.Explode();
            }

            //Move to Growing State
            if (Input.GetKey(KeyCode.W) && _toyController.isGrounded && !_toyController.isDucking)
            {
                _toyController.isGrowing = true;
                _toyController.Grow();
            }
            else if (Input.GetKeyUp(KeyCode.W) && !_toyController.isDucking)
            {
                _toyController.isGrowing = false;
                _toyController.Grow();
            }

        }
    }
}