# EventManagerCSharp
This is the repo that i created simple event manager in c# to handle events with paramaters.
It can be used like below 

public class ExampleUsage
{
    public static void Main()
    {
        // Create an instance of the EventManager
        var eventManager = EventManager.Instance;

        // Subscribe to events with parameters
        eventManager.AddEventListener("PlayerDied", (data) => HandlePlayerDeath((string)data));
        eventManager.AddEventListener("ScoreIncreased", (data) => HandleScoreIncrease((int)data));

        // Trigger events with parameters
        eventManager.TriggerEvent("PlayerDied", "Game Over");
        eventManager.TriggerEvent("ScoreIncreased", 10);
    }

    private static void HandlePlayerDeath(string message)
    {
        Console.WriteLine($"Player died! {message}");
    }

    private static void HandleScoreIncrease(int score)
    {
        Console.WriteLine($"Score increased! New score: {score}");
    }
}

