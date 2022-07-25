using Newtonsoft.Json;
using System.Net;

namespace Lab_Deck_of_Cards.Models
{
    public class CardsDAL
    {
        public CardsModel DrawCards(int cards) 
        {                                                                                                                   
            string url = $"https://deckofcardsapi.com/api/deck/6mcu3tye8pd3/draw/?count={cards}";

            //setup request
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //capturing response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //save all of this response data as a variable
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string JSON = reader.ReadToEnd(); 

            //convert JSON to a C# object
            CardsModel result = JsonConvert.DeserializeObject<CardsModel>(JSON);

            return result;
        }

        public void ShuffleCards()
        {
            string url = $"https://deckofcardsapi.com/api/deck/6mcu3tye8pd3/shuffle/";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            
        }
    }
}
