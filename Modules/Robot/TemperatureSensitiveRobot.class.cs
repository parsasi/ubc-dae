
namespace Modules.Robot
{
    public class TemperatureSensitiveRobot
    {
        protected float temperatureInCelsius = 20.0f;

        protected readonly float idealTemperatureInCelsius = 20.0f;

        protected readonly float maximumTempreture = 32.0f;

        protected int temptretureDecreaseTimeInSeconds = 3;

        protected Timer? timer;


        protected void IncreaseTemperature(float temperatureInCelsius = 1.0f)
        {
            this.temperatureInCelsius += temperatureInCelsius;
            Console.WriteLine($"Temperature increased to {this.temperatureInCelsius}°C");

            this.TriggerTimer();

            this.TempretureChangeListener();
        }

        protected void DropTemperature(object? state)
        {
            this.temperatureInCelsius -= 1.0f;

            Console.WriteLine($"Temperature dropped to {temperatureInCelsius}°C");

            if (this.temperatureInCelsius <= this.idealTemperatureInCelsius)
            {
                if(this.timer != null)
                    this.DisposeTimer();
                return;
            }
            this.TempretureChangeListener();
        }

        //TODO: actually listen to the temperatureInCelsius changing, instead of requiring a call this method
        protected void TempretureChangeListener()
        {
            if(this.temperatureInCelsius > this.maximumTempreture)
            {
                Console.WriteLine("Exploded!");
                this.DisposeTimer();
                Environment.Exit(0);
            }
        }

        protected void DisposeTimer()
        {
            if(this.timer != null){
                try{
                    this.timer.Dispose();
                }finally{
                    this.timer = null;
                }
            }
        }

        protected void TriggerTimer()
        {
            if(this.timer != null){
                this.timer.Change(TimeSpan.FromSeconds(this.temptretureDecreaseTimeInSeconds), TimeSpan.FromSeconds(this.temptretureDecreaseTimeInSeconds));
            }else{
                this.timer = new Timer(this.DropTemperature, null, TimeSpan.FromSeconds(this.temptretureDecreaseTimeInSeconds), TimeSpan.FromSeconds(this.temptretureDecreaseTimeInSeconds));
            }
        }
    }
}
