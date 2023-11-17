namespace Database{

    public class User : Database
    {
        public void Create(string username)
        {
            this.Query("INSERT INTO Users {username}" , new List<string> {username});
        }

        public int Get()
        {
            return this.Query("SELECT * FROM Users");
        }
    }

}