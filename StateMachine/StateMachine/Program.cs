using System;

namespace StateMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var externalState = CarState.Stopped;
            var car = new Stateless.StateMachine<CarState, CarAction>(
                () => externalState,
                s => externalState = s
            );

            car.OnTransitioned(t => Console.WriteLine($"Transition : {t.Source} -> {t.Destination}"));

            car.Configure(CarState.Stopped).Permit(CarAction.Start, CarState.Started);

            car.Configure(CarState.Started)
                .Permit(CarAction.Accelerate, CarState.Running)
                //.Ignore(CarAction.Start)
                .PermitReentry(CarAction.Start)
                .Permit(CarAction.Stop, CarState.Stopped)
                .OnEntry(s => Console.WriteLine($"Entry : {s.Source} -> {s.Destination}"))
                .OnExit(s => Console.WriteLine($"Exit : {s.Source} -> {s.Destination}"));

            var triggerWithParam = car.SetTriggerParameters<int>(CarAction.Accelerate);

            car.Configure(CarState.Running)
                .SubstateOf(CarState.Started)
                .Permit(CarAction.Stop, CarState.Stopped)
                .OnEntryFrom(triggerWithParam, speed => Console.WriteLine($"Speed : {speed}"))
                .InternalTransition(CarAction.Start, () => Console.WriteLine("Start called while running !!"));

            Console.WriteLine($"State : {externalState}");

            car.Fire(CarAction.Start);
            Console.WriteLine($"State : {externalState}");

            car.Fire(CarAction.Start);
            Console.WriteLine($"State : {externalState}");

            car.Fire(CarAction.Accelerate);
            Console.WriteLine($"State : {externalState}");

            car.Fire(triggerWithParam, 50);
            Console.WriteLine($"State : {externalState}");

            car.Fire(CarAction.Start);
            Console.WriteLine($"State : {externalState}");

            car.Fire(CarAction.Stop);
            Console.WriteLine($"State : {externalState}");

            Console.ReadLine();
        }
    }
}
