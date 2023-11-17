namespace Database{

    public class TextContent : Database
    {
        public int Create(string content, string messageId)
        {
            return this.Query("INSERT INTO TextContent (Content , MessageId) values ({content} , {messageId})" , new List<string> {content , messageId});
        }

        public int Get()
        {
            return this.Query("SELECT * FROM TextContent");
        }
    }

}