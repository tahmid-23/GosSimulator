

//Stores a string, int pair.
namespace Dialogue
{
    public class Response
    {
        //string - response text
        private int _goToId;
        //int - the conversation id that is set when the player chooses this response
        private string _response;

        public Response(string response, int goToId)
        {
            _response = response;
            _goToId = goToId;
        }
        
        public int getGoToID()
        {
            return _goToId;
        }

        public string getResponseText()
        {
            return _response;
        }
    }
}
