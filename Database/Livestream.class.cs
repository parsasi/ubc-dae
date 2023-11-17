namespace Database{

    public class Livestream : Database
    {
        public int Create()
        {
            return this.Query("INSERT INTO Livestream");
        }

        public int Get()
        {
            return this.Query("SELECT * FROM Livestream");
        }
    }

}