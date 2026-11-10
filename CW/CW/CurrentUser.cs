namespace Petkunas__Lukas___Byte_size_Quiz
{
    // store the current user in a static property for easy access throughout the program
    class CurrentUser
    {
        private static User privateCurrentUser = null
;

        public static User publicCurrentUser
        {
            get { return privateCurrentUser; }
            set { privateCurrentUser = value; }
        }
    }
}
