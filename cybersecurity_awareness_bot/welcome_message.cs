using System.IO;
using System.Media;
using System;

namespace cybersecurity_awareness_bot
{
    public class welcome_message
    {
        public welcome_message()
        {
            //getting the ful location of the project
            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            //replace the bin and debug folder in the full_location
            string new_path = full_location.Replace("bin\\Debug\\", "");

            //try and catch
            try
            {
                //Cobine the path
                string full_path = Path.Combine(new_path, "greetings.wav");

                //now create instance for the soundPlayer
                using (SoundPlayer play = new SoundPlayer(full_path))
                {

                    //play the file
                    play.PlaySync();

                }//end of using
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);

            }// end of  catch

        }//end of constractor


    }//end of class
}//end of namespace


