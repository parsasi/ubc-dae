namespace Database{

    public class ImageContent : Database
    {
        public int Create(string filePath, string messageId)
        {
            return this.Query("INSERT INTO ImageContent (FilePath , MessageId) values ({filePath} , {messageId})" , new List<string> {filePath , messageId});
        }

        public int Get()
        {
            return this.Query("SELECT * FROM ImageContent");
        }
    }

}