namespace Modules.Robot
{
    public interface IRobotOutlet
    {
        void OutputText(string text);
        void OutputMedia(string media);
        bool ValidateMedia(string media);
    }
}
