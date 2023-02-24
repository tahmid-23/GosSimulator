using System;
using System.Collections.Generic;

namespace PranjalDialogue
{
    public interface IInteraction
    {
        public String NextInteraction(Dictionary<String, String> parameters);
    }
}