using UnityEngine;

namespace Chapter.State {
    public class ToyController : MonoBehaviour 
    {
        public float jumpHeight = 20.0f;
        public float diveSpeed = 2.0f;
        public bool isGrounded = true;
        public bool isDucking;
        public bool isGrowing;

        public GameObject particleEffect;

        public Vector3 lastMouseCoordinate = Vector3.zero;
        public Vector3 mouseDelta = Vector3.zero;

        public Rigidbody rb;
        public float CurrentSpeed { get; set; }
        
        private IToyState 
            _jumpState, _duckState, _diveState, _spinState, _explodeState, _growState;
        
        private ToyStateContext _toyStateContext;

        private void Start() {
            _toyStateContext = 
                new ToyStateContext(this);

            _jumpState = 
                gameObject.AddComponent<ToyJumpingState>();
            _duckState = 
                gameObject.AddComponent<ToyDuckingState>();
            _diveState =
                gameObject.AddComponent<ToyDivingState>();
            _spinState =
                gameObject.AddComponent<ToySpiningState>();
            _explodeState = 
                gameObject.AddComponent<ToyExplodingState>();
            _growState =
                gameObject.AddComponent<ToyGrowingState>();
        }

        public void Jump() {
            _toyStateContext.Transition(_jumpState);
        }
        
        public void Duck() {
            _toyStateContext.Transition(_duckState);
        }

        public void Dive() {
            _toyStateContext.Transition(_diveState);
        }

        public void Spin() { 
            _toyStateContext.Transition(_spinState);
        }

        public void Explode()
        {
            _toyStateContext.Transition(_explodeState);
        }

        public void Grow()
        {
            _toyStateContext.Transition(_growState);
        }
    }
}