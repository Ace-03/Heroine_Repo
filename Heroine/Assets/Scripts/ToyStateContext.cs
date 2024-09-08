namespace Chapter.State
{
    public class ToyStateContext
    {
        public IToyState CurrentState
        {
            get; set;
        }
        
        private readonly ToyController _toyController;

        public ToyStateContext(ToyController toyController)
        {
            _toyController = toyController;
        }

        public void Transition()
        {
            CurrentState.Handle(_toyController);
        }
        
        public void Transition(IToyState state)
        {
            CurrentState = state;
            CurrentState.Handle(_toyController);
        }
    }
}