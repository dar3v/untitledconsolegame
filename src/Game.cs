using NetCoreAudio;
using static System.Console;

namespace Ghost_in_The_PowerShell
{
    internal class Game
    {
        private static Player? bgPlayer;

        public void Start()
        {
            Title = "Ghost In The PowerShell";
            playMusic("./files/HomeMenubg.wav");
            runHomeMenu();
        }

        private void runHomeMenu()
        {
            string prompt =
                @"
  ▄████  ██░ ██  ▒█████    ██████ ▄▄▄█████▓    ██▓ ███▄    █    ▄▄▄█████▓ ██░ ██ ▓█████ 
 ██▒ ▀█▒▓██░ ██▒▒██▒  ██▒▒██    ▒ ▓  ██▒ ▓▒    ▓██▒ ██ ▀█   █    ▓  ██▒ ▓▒▓██░ ██▒▓█   ▀
▒██░▄▄▄░▒██▀▀██░▒██░  ██▒░ ▓██▄   ▒ ▓██░ ▒░    ▒██▒▓██  ▀█ ██▒   ▒ ▓██░ ▒░▒██▀▀██░▒███   
▒██░▄▄▄░▒██▀▀██░▒██░  ██▒░ ▓██▄   ▒ ▓██░ ▒░    ░██░▓██▒  ▐▌██▒   ░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄ 
░▓█  ██▓░▓█ ░██ ▒██   ██░  ▒   ██▒░ ▓██▓ ░     ░██░▒██░   ▓██░     ▒██▒ ░ ░▓█▒░██▓░▒████▒
░▒▓███▀▒░▓█▒░██▓░ ████▓▒░▒██████▒▒  ▒██▒ ░     ░▓  ░ ▒░   ▒ ▒      ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░
 ░▒   ▒  ▒ ░░▒░▒░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░  ▒ ░░        ▒ ░░ ░░   ░ ▒░       ░     ▒ ░▒░ ░ ░ ░  ░
  ░   ░  ▒ ░▒░ ░  ░ ▒ ▒░ ░ ░▒  ░ ░    ░         ▒ ░   ░   ░ ░      ░       ░  ░░ ░   ░   
░ ░   ░  ░  ░░ ░░ ░ ░ ▒  ░  ░  ░     ░                    ░              ░  ░  ░   ░  ░
                 
   ██▓███   ▒█████   █     █░▓█████  ██▀███    ██████  ██░ ██ ▓█████  ██▓     ██▓    
▓██░  ██▒▒██▒  ██▒▓█░ █ ░█░▓█   ▀ ▓██ ▒ ██▒▒██    ▒ ▓██░ ██▒▓█   ▀ ▓██▒    ▓██▒    
▓██░ ██▓▒▒██░  ██▒▒█░ █ ░█ ▒███   ▓██ ░▄█ ▒░ ▓██▄   ▒██▀▀██░▒███   ▒██░    ▒██░    
▒██▄█▓▒ ▒▒██   ██░░█░ █ ░█ ▒▓█  ▄ ▒██▀▀█▄    ▒   ██▒░▓█ ░██ ▒▓█  ▄ ▒██░    ▒██░    
▒██▒ ░  ░░ ████▓▒░░░██▒██▓ ░▒████▒░██▓ ▒██▒▒██████▒▒░▓█▒░██▓░▒████▒░██████▒░██████▒
▒▓▒░ ░  ░░ ▒░▒░▒░ ░ ▓░▒ ▒  ░░ ▒░ ░░ ▒▓ ░▒▓░▒ ▒▓▒ ▒ ░ ▒ ░░▒░▒░░ ▒░ ░░ ▒░▓  ░░ ▒░▓  ░
░░       ░ ░ ░ ▒    ░   ░     ░     ░░   ░ ░  ░  ░   ░  ░░ ░   ░     ░ ░     ░ ░   
░ ░      ░       ░  ░   ░           ░   ░  ░  ░   ░  ░    ░  ░    ░  ░

Use Your Arrow Keys To Hover Through The Selections and Press Enter to Select";
            string[] options = { "Play", "About", "Exit" };
            Menu homeMenu = new Menu(prompt, options);
            int indexSelected = homeMenu.Run();

            switch (indexSelected)
            {
                case 0:
                    playGame();
                    break;
                case 1:
                    aboutGame();
                    break;
                case 2:
                    exitGame();
                    break;
            }
        }

        private void playGame()
        {
            Clear();
            Engine mEngine = new Engine();
            mEngine.Start();
            runHomeMenu();
        }

        private void aboutGame()
        {
            Clear();
            WriteLine("Development in progress.."); //TODO: add aboutGame logic here
            ReadKey();
            ReadKey(true);
            runHomeMenu();
        }

        private void exitGame()
        {
            Clear();
            Console.WriteLine(
                "Are You Sure You Want To Exit? \nIf So, Press Enter Key To Escape Your Impending Doom!"
            );
            Console.ReadKey();
            if (bgPlayer != null)
                bgPlayer.Stop();
            Environment.Exit(0);
        }

        private static void playMusic(string filepath)
        {
            bgPlayer = new Player();
            bgPlayer.Play(filepath);
        }
    } // class bracket
} //namespace bracket
