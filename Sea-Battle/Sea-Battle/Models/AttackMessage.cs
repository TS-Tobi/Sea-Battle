using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle.Models
{
    public class AttackMessage : Message
    {
        /*
         The AttackMessage class inherits from the Message class and adds coordinates for an attack.
         */

        public int xCoordinate;
        public int yCoordinate;

        public AttackMessage(string user, DateTimeOffset date, char msgType, int xCoordinate, int yCoordinate) : base(user, date, msgType)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

        public override string ToJsonString()
        {
            /*
             Converts the AttackMessage object to a JSON string.
             Returns: A JSON string representing AttackMessage object.
             */
            string MessageJson = base.ToJsonString();

            return MessageJson.Substring(0, MessageJson.Length - 1) +
                    ",\"xCoordinate\":\"" + xCoordinate + "\",\"yCoordinate\":\"" + yCoordinate + "\"}";
        }
        public static AttackMessage JsonStringToAttackMessage(string jsonStringOfAttackMessageObj)
        {
            /*
             Converts a JSON string to a AttackMessage object.
             Parameter name="jsonStringOfAttackMessageObj": The JSON string that represents the AttackMessage object. 
             Returns: A AttackMessage object that contains the data from the JSON string.
             */

            Dictionary<string, string> propertyAndValue = JsonStringToDictionary(jsonStringOfAttackMessageObj);

            string user = (propertyAndValue["user"] is null) ? " " : propertyAndValue["user"];
            DateTimeOffset date = (propertyAndValue["date"] is null) ? DateTimeOffset.Parse("1900-01-01T00:00:00.0000000+00:00") : DateTimeOffset.Parse(propertyAndValue["date"].ToString());
            char msgType = (propertyAndValue["msgType"] is null) ? ' ' : Convert.ToChar(propertyAndValue["msgType"][0]);
            int xCoordinate = (propertyAndValue["xCoordinate"] is null) ? 0 : Convert.ToInt32(propertyAndValue["xCoordinate"]);
            int yCoordinate = (propertyAndValue["yCoordinate"] is null) ? 0 : Convert.ToInt32(propertyAndValue["yCoordinate"]);

            return new AttackMessage(user, date, msgType, xCoordinate, yCoordinate);
        }
    }
}
