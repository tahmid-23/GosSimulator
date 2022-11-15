using Phone;
using UnityEngine;

namespace NPC.Teachers.Beisenburg
{
    public class GosBeisenburgDialogue: TeacherBase
    {
        [SerializeField]
        private PhoneContacts _phoneContacts;
        
        public GosBeisenburgDialogue() : base(Classification.Neutral)
        {
            
        }
        
        public void OnMouseDown()
        {
            if (GetClassification() is Classification.Neutral)
            {
                Debug.Log("I don't know what things you want from me. Talk to Lucrative Larry and you leave me alone");
                _phoneContacts.AddContact(FetchContact.GetContact("Lucrative Larry"));
            }
        }
    }
}