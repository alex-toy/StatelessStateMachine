namespace StateMachine
{
    public partial class Car
    {
        private CarState state = CarState.Stopped;
        public CarState CurrentState { get { return state; } }

        public void TakeAction(CarAction action)
        {
            if (state == CarState.Stopped && action == CarAction.Start) state = CarState.Started;
            if (state == CarState.Started && action == CarAction.Accelerate) state = CarState.Running;
            if (state == CarState.Started && action == CarAction.Stop) state = CarState.Stopped;
            if (state == CarState.Running && action == CarAction.Stop) state = CarState.Stopped;
        }
    }
}