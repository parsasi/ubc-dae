
namespace Modules.Chat
{

    public class Chat
    {   
        protected IChatInetgration chatInetgration;

        protected IChatStorage? chatStorage;

        protected Dictionary<ChatFeature, Action<string,string>> featureToHandler = new Dictionary<ChatFeature, Action<string,string>>();

        protected readonly List<ChatFeature> InputlessFeatures = new List<ChatFeature> { ChatFeature.Leave };


        public Chat(IChatInetgration chatInetgration , IChatStorage? chatStorage = null)
        {
            this.chatInetgration = chatInetgration;
            this.chatStorage = chatStorage;
            this.featureToHandler.Add(ChatFeature.Text, this.handleText);
            this.featureToHandler.Add(ChatFeature.Image, this.handleImage);
            this.featureToHandler.Add(ChatFeature.Leave, this.handleLeave);
        }

        public void Create()
        {
            Console.WriteLine("Welcome to the chat!");
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine() ?? this.getAnonymousUsername();
            this.StoreUser(username);
            while(true){
                OutputMenu();
                var command = Console.ReadLine();

                if(command == null || !ValidateCommand(command))
                {
                    Console.WriteLine("Invalid command! Please try again.");
                    continue;
                }

                var featureName = ConvertCommandToFeature(int.Parse(command));

                Action<string,string> handler = this.featureToHandler.First(x => x.Key == featureName).Value;
                
                if(handler == null){
                    Console.WriteLine("Feature is not implemented yet! Please try again.");
                    continue;
                }

                if(InputlessFeatures.Contains(featureName))
                {   
                    handler.Invoke("" , username);
                    return;
                }

                Console.WriteLine($"Please enter your {featureName} input:");
                var input = Console.ReadLine();

                if(!ValidateInput(input))
                {
                    Console.WriteLine("Invalid input! Please try again.");
                    continue;
                }

                //This should never happen. Putting it here to make the compiler happy
                if(input == null)
                    throw new Exception("Input is null!");

                handler.Invoke(input , username);
            }
            
        }

        protected void handleText(string input , string username){
            this.chatInetgration.TextInput(input);
            this.StoreText(username , input);
        }

        protected void handleImage(string input , string username){
            this.chatInetgration.ImageInput(input);
            this.StoreImage(username , input);
        }

        protected void handleLeave(string input , string username){
            Environment.Exit(0);
        }

        protected void OutputMenu()
        {
            Console.WriteLine("Menu:");
            foreach (ChatFeature feature in Enum.GetValues(typeof(ChatFeature)))
            {
                Console.WriteLine($"{(int)feature}. {feature}");
            }
        }

        protected bool ValidateCommand(string input)
        {
            //TODO: do this more elegantly
            try{
                int.Parse(input);
            }
            catch{
                return false;
            }

            int inputInt = int.Parse(input);
            //TODO: there's gotta be a better way to do this
            foreach (ChatFeature feature in Enum.GetValues(typeof(ChatFeature)))
            {
               if(inputInt == (int)feature)
               {
                   return true;
               } 
            }
            return false;
        }

        //TODO: there is probably a way to combine with ValidateCommand
        protected ChatFeature ConvertCommandToFeature(int input){
            foreach (ChatFeature feature in Enum.GetValues(typeof(ChatFeature)))
            {
               if(input == (int)feature)
               {
                   return feature;
               } 
            }
            throw new Exception("Invalid input!");
        }

        protected bool ValidateInput(string? input)
        {
            return input != null && input.Length > 0;
        }

        protected void StoreUser(string username)
        {
            if(this.chatStorage != null)
                this.chatStorage.StoreUser(username);
        }

        protected void StoreText(string username , string input)
        {
            if(this.chatStorage != null)
                this.chatStorage.StoreText(username , input);
        }


        protected void StoreImage(string username , string input)
        {
            if(this.chatStorage != null)
                this.chatStorage.StoreImage(username , input);
        }

        protected String getAnonymousUsername()
        {
            return "Anonymous";
        }

    }
}
