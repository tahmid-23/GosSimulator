using System;

namespace Phone
{
    public class Contact
    {
        private String _fullName;
        private String _phoneNumber;

        public Contact(String fullName, String phoneNumber)
        {
            this._fullName = fullName;
            this._phoneNumber = phoneNumber;
        }
    }
}