namespace ArvidZetterberg.Utils;
using System.Timers;

public class GameLoop
{
    Action<double>? updateActions;
    Timer timer;
    TimeSpan elapsedTime;
    DateTime lastUpdate = DateTime.Now;

    public GameLoop(int updateEveryMilliseconds = 20)
    {
        timer = new Timer(updateEveryMilliseconds);
        timer.Elapsed += (object? sender, ElapsedEventArgs e) =>
        {
            elapsedTime = DateTime.Now - lastUpdate;
            lastUpdate = DateTime.Now;
            try
            {
                updateActions?.Invoke(elapsedTime.TotalMilliseconds);
            }
            catch 
            {
                Console.WriteLine("Error updateing in gameloop");
            }
        };
        timer.AutoReset = true;
        timer.Start();
    }

    public void AddToUpdate(Action<double> onUpdate) => updateActions += onUpdate;
    public void RemoveFromUpdate(Action<double> onUpdate)
    {
        if (updateActions is not null)
            updateActions -= onUpdate;
    }

    public void Dispose()
    {
        timer.Dispose();
    }
}

