using System;

namespace Phone
{
    public static class FetchContact
    {
        public static Contact GetContact(string npcName)
        {
            if (string.Equals(npcName, "Lucrative Larry"))
            {
                return new Contact("Lucrative Larry", "2015646966");
            }

            return null;
        }
    }
}