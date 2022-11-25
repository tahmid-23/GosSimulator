using System;

namespace Phone
{
    public class Contact
    {
        private string _fullName;
        private string _phoneNumber;

        public Contact(string fullName, string phoneNumber)
        {
            this._fullName = fullName;
            this._phoneNumber = phoneNumber;
        }
    }
}