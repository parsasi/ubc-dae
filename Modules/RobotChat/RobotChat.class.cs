using Modules.Robot;
using Modules.Chat;


namespace Modules.RobotChat{

    class RobotChatAdapter: IChatInetgration{
        protected Robot.Robot robot;
        public RobotChatAdapter(Robot.Robot robot){
            this.robot = robot;
        }

        public void TextInput(string input){
            robot.ReadMessage(input);
        }
        public void ImageInput(string input){
            robot.OpenImage(input);
        }
    }
}