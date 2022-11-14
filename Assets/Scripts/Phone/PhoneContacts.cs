using System.Collections;

namespace Phone
{
    public class PhoneContacts
    {
        private ArrayList _contacts = new ArrayList();

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }
    }
}