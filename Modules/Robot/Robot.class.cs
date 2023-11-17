namespace Modules.Robot
{
    public class Robot : TemperatureSensitiveRobot
    {
        protected IRobotOutlet outlet;
        
        
        public Robot(IRobotOutlet outlet){
            this.outlet = outlet;
        }

        public void ReadMessage(string message)
        {
            this.ReadOutlet(message);
        }

        public void OpenImage(string path)
        {
            if(!this.outlet.ValidateMedia(path))
            {
                handleImageFailure();
                return;
            }
            try{
                this.OpenFile(path);
            }catch{
                handleImageFailure();
            }
        }

        public float getTemptreture(){
            return this.temperatureInCelsius;
        }


        protected void ReadOutlet(string message)
        {
            this.outlet.OutputText("We have a new message!");
            this.outlet.OutputText(message);
            this.IncreaseTemperature(3);
        }

        protected void OpenFile(string path)
        {
            this.outlet.OutputText("We have a new image to share!");
            this.outlet.OutputMedia(path);
            this.IncreaseTemperature(5);
        }

        protected void handleImageFailure()
        {
            this.outlet.OutputText("I can't open your image! I'm sorry :(");
            this.IncreaseTemperature(7);
        }
    }
}
