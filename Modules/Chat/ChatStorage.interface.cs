namespace Modules.Chat
{
    public interface IChatStorage{
        void StoreUser(string username);
        void StoreText(string username , string input);

        void StoreImage(string username , string input);
    }
}