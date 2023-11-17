using System;

using Modules.Robot;
using Modules.LiveStream;
using Modules.RobotChat;
using Modules.Chat;
using Modules.DatabaseChat;
using Database;

namespace LivestreamFundraisingApp
{
    class Program
    {
        static void Main()
        {
            var liveStream = new LiveStream();
            var robot = new Robot(liveStream);

            robot.ReadMessage("Hello Livestream Fundraising App!");

            var robotAdaptor = new RobotChatAdapter(robot);

            var chatStorageAdaptor = new DatabaseChatAdapter(
                new Livestream(),
                new ImageContent(),
                new TextContent(),
                new Message(),
                new User()
            );

            var chat = new Chat(robotAdaptor , chatStorageAdaptor);

            chat.Create();
        }
    }
}
