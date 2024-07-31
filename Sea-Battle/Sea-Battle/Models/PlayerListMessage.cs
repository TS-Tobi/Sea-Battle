using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle.Models
{
    public class PlayerListMessage : Message
    {
        /*
         The PlayerListMessage class inherits from the Message class and adds a list of players.
         */

        public string[] playerList;

        public PlayerListMessage(string user, DateTimeOffset date, char msgType, string[] playerList) : base(user, date, msgType)
        {
            this.playerList = playerList;
        }

        public override string ToJsonString()
        {
            /*
             Converts the PlayerListMessage object to a JSON string.
             Returns: A JSON string representing the PlayerListMessage object.
             */

            string MessageJson = base.ToJsonString();
            string playerListString = string.Join("$", playerList);

            return MessageJson.Substring(0, MessageJson.Length - 1) +
                   ",\"playerListString\":\"" + playerListString + "\"}";
        }
        public static PlayerListMessage JsonStringToPlayerListMessage(string jsonStringOfPlayerListMessageObj)
        {
            /*
             Converts a JSON string to a PlayerListMessage object.
             Parameter name="jsonStringOfPlayerListMessageObj": The JSON string that represents the PlayerListMessage object. 
             Returns: A PlayerListMessage object that contains the data from the JSON string.
             */

            Dictionary<string, string> propertyAndValue = JsonStringToDictionary(jsonStringOfPlayerListMessageObj);

            string user = (propertyAndValue["user"] is null) ? " " : propertyAndValue["user"];
            DateTimeOffset date = (propertyAndValue["date"] is null) ? DateTimeOffset.Parse("1900-01-01T00:00:00.0000000+00:00") : DateTimeOffset.Parse(propertyAndValue["date"].ToString());
            char msgType = (propertyAndValue["msgType"] is null) ? ' ' : Convert.ToChar(propertyAndValue["msgType"][0]);
            string playerListString = (propertyAndValue["playerListString"] is null) ? " " : propertyAndValue["playerListString"];

            string[] playerList = playerListString.Split('$');

            return new PlayerListMessage(user, date, msgType, playerList);
        }
    }
}
