using Modules.Chat;



namespace Modules.DatabaseChat
{
    public class DatabaseChatAdapter : IChatStorage
    {
        protected readonly Database.Livestream livestream;

        protected readonly Database.ImageContent imageContent;

        protected readonly Database.TextContent textContent;

        protected readonly Database.Message message;

        protected readonly Database.User user;

        //TODO: Do a better job at dependency injection
        public DatabaseChatAdapter(
            Database.Livestream livestream,
            Database.ImageContent imageContent,
            Database.TextContent textContent,
            Database.Message message,
            Database.User user
        )
        {
            this.livestream = livestream;
            this.imageContent = imageContent;
            this.textContent = textContent;
            this.message = message;
            this.user = user;
        }

        public void StoreUser(string username){
            this.user.Create(username);
        }

        public void StoreText(string username , string input){
            int message_id = this.message.Create(username);

            this.textContent.Create(username , message_id.ToString());
        }

        public void StoreImage(string username , string input){
            int message_id = this.message.Create(username);
            this.imageContent.Create(username , message_id.ToString());
        }
    }
}
