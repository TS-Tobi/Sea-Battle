using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle.Models
{
    public class AssignEnemyMessage : Message
    {
        /*
         The AssignEnemyMessage class inherits from the Message class and adds an assigned enemy.
         */

        public string assignedEnemy;

        public AssignEnemyMessage(string user, DateTimeOffset date, char msgType, string assignedEnemy) : base(user, date, msgType)
        {
            this.assignedEnemy = assignedEnemy;
        }

        public override string ToJsonString()
        {
            /*
             Converts the AssignEnemyMessage object to a JSON string.
             Returns: A JSON string representing AssignEnemyMessage object.
             */

            string MessageJson = base.ToJsonString();

            return MessageJson.Substring(0, MessageJson.Length - 1) +
                   ",\"assignedEnemy\":\"" + assignedEnemy + "\"}";
        }
        public static AssignEnemyMessage JsonStringToAssignEnemyMessage(string jsonStringOfAssignEnemyMessageObj)
        {
            /*
             Converts a JSON string to a AssignEnemyMessage object.
             Parameter name="jsonStringOfAssignEnemyMessageObj": The JSON string that represents the AssignEnemyMessage object. 
             Returns: A AssignEnemyMessage object that contains the data from the JSON string.
             */

            Dictionary<string, string> propertyAndValue = JsonStringToDictionary(jsonStringOfAssignEnemyMessageObj);

            string user = (propertyAndValue["user"] is null) ? " " : propertyAndValue["user"];
            DateTimeOffset date = (propertyAndValue["date"] is null) ? DateTimeOffset.Parse("1900-01-01T00:00:00.0000000+00:00") : DateTimeOffset.Parse(propertyAndValue["date"].ToString());
            char msgType = (propertyAndValue["msgType"] is null) ? ' ' : Convert.ToChar(propertyAndValue["msgType"][0]);
            string assignedEnemy = (propertyAndValue["assignedEnemy"] is null) ? "" : propertyAndValue["assignedEnemy"];

            return new AssignEnemyMessage(user, date, msgType, assignedEnemy);
        }
    }
}
