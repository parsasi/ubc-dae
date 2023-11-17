namespace Database{

    public class Message : Database
    {
        public int Create(string userId)
        {
            return this.Query("INSERT INTO Messages (UserId) values ({userId})" , new List<string> {userId});
        }

        public int Get()
        {
            return this.Query("SELECT * FROM Messages");
        }
    }

}