using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sea_Battle.Models
{
    public class Message
    {
        /*
         This class represents a message with user, date and message type.
         */

        public string user;
        public DateTimeOffset date;
        public char msgType;

        public Message(string user, DateTimeOffset date, char msgType)
        {
            this.user = user;
            this.date = date;
            this.msgType = msgType;
        }

        public virtual string ToJsonString()
        {
            /*
             Converts the Message object to a JSON string.
             Returns: A JSON string representing Message object.
             */

            return "{\"user\":\"" + user +
                     "\",\"date\":\"" + date.ToString() +
                     "\",\"msgType\":\"" + msgType + "\"}";
        }
        public static Message JsonStringToMessage(string jsonStringOfMessageObj)
        {
            /*
             Converts a JSON string to a Message object.
             Parameter name="jsonStringOfMessageObj": The JSON string that represents the Message object. 
             Returns: A Message object that contains the data from the JSON string.
             */

            Dictionary<string, string> propertyAndValue = JsonStringToDictionary(jsonStringOfMessageObj);

            string user = (propertyAndValue["user"] is null) ? " " : propertyAndValue["user"];
            DateTimeOffset date = (propertyAndValue["date"] is null) ? DateTimeOffset.Parse("1900-01-01T00:00:00.0000000+00:00") : DateTimeOffset.Parse(propertyAndValue["date"].ToString());
            char msgType = (propertyAndValue["msgType"] is null) ? ' ' : Convert.ToChar(propertyAndValue["msgType"][0]);

            return new Message(user, date, msgType);
        }
        protected static Dictionary<string, string> JsonStringToDictionary(string jsonStringOfMessageObj)
        {
            /*
             Converts a JSON string into a dictionary
             Parameter name="jsonStringOfMessageObj": The JSON string.
             Returns: The dictionary with properties and values.
             */

            jsonStringOfMessageObj = jsonStringOfMessageObj.Trim().Replace("{", "").Replace("}", "");
            string[] stringArrayOfPropertiesAndValues = jsonStringOfMessageObj.Split(',');

            Dictionary<string, string> propertyAndValue = new Dictionary<string, string>();
            foreach (string propertyAndValueAsString in stringArrayOfPropertiesAndValues)
            {
                string pattern = @"[""][\s]?:[\s]?[""]";
                Regex regex = new Regex(pattern);
                string[] substrings = regex.Split(propertyAndValueAsString);
                string key = "", value = "";

                foreach (string match in substrings)
                {
                    string tmp = match;
                    //Is the first character a quotation mark?
                    if (match.Substring(0, 1).Equals("\""))
                    {
                        tmp = match.Substring(1, match.Length - 1);
                    }
                    match.Trim();
                    int count = 0;
                    foreach (var item in match)
                        if (Char.IsLetter(item)
                            || Char.IsDigit(item)
                            || Char.IsPunctuation(item)
                            || Char.IsSymbol(item)
                            || Char.IsWhiteSpace(item))
                            count++;
                    //Is the last visible character a quotation mark?
                    if (match.Substring(count - 1, 1).Equals("\""))
                    {
                        tmp = match.Substring(0, count - 1);
                    }

                    if (key.Length < 1) key = tmp;
                    else value = tmp;

                }
                propertyAndValue.Add(key, value);
            }

            return propertyAndValue;
        }
        public static void MessageLog(Message messageToSave, string direction, string playerName)
        {
            /*
             Saves a log message to a file that contains details about the message sent or received.
             Parameter name="messageToSave": The message to be logged.
             Parameter name="direction": The direction of the message (" in" for received, "out" for sent).
             Parameter name="playerName": The name of the player involved in the message.
            */

            string logEntry = "";

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(basePath).Parent.Parent.FullName;
            string path = projectDirectory + @"\Services\MessageLog.txt";

            if (messageToSave is AttackMessage)
            {
                AttackMessage attackMessageToSave = (AttackMessage)messageToSave;

                if (direction == " in")
                {
                    logEntry += string.Format("{0}  in AssignEnemyMessage: ", attackMessageToSave.date);
                    switch (attackMessageToSave.msgType)
                    {
                        case 'Q':
                            logEntry += string.Format("Schussanfrage von {0} auf {1}:{2}", attackMessageToSave.user, attackMessageToSave.xCoordinate, attackMessageToSave.yCoordinate);
                            break;
                        case 'H':
                            logEntry += string.Format("Treffer beim Spieler {0} auf {1}:{2}", attackMessageToSave.user, attackMessageToSave.xCoordinate, attackMessageToSave.yCoordinate);
                            break;
                        case 'F':
                            logEntry += string.Format("Kein Treffer beim Spieler {0} auf {1}:{2}", attackMessageToSave.user, attackMessageToSave.xCoordinate, attackMessageToSave.yCoordinate);
                            break;
                    }
                }
                else
                {
                    logEntry += string.Format("{0} out AssignEnemyMessage: ", attackMessageToSave.date);
                    switch (attackMessageToSave.msgType)
                    {
                        case 'Q':
                            logEntry += string.Format("Schussanfrage an {0} auf {1}:{2}", Player.GetPlayerEnemy(playerName), attackMessageToSave.xCoordinate, attackMessageToSave.yCoordinate);
                            break;
                        case 'H':
                            logEntry += string.Format("Trefferrückmeldung an den Spieler {0} mit Treffer auf {1}:{2}", playerName, attackMessageToSave.xCoordinate, attackMessageToSave.yCoordinate);
                            break;
                        case 'F':
                            logEntry += string.Format("Trefferrückmeldung an den Spieler {0} mit kein Treffer auf {1}:{2}", playerName, attackMessageToSave.xCoordinate, attackMessageToSave.yCoordinate);
                            break;

                    }
                }
            }
            else if (messageToSave is AssignEnemyMessage)
            {
                AssignEnemyMessage assignEnemyMessageToSave = (AssignEnemyMessage)messageToSave;
                logEntry += string.Format("{0} {1} AssignEnemyMessage: ", messageToSave.date, direction);

                logEntry += string.Format("Dem Spieler {0} wurde der Gegner {1} zugewiesen", playerName, assignEnemyMessageToSave.assignedEnemy);
            }
            else
            {
                logEntry += string.Format("{0} {1} Message: ", messageToSave.date, direction);
                switch (messageToSave.msgType)
                {
                    case 'J':
                        logEntry += string.Format("Der Spieler {0} will dem Spiel {1} beitreten", messageToSave.user, StaticDataService.currentServer.serverName);
                        break;
                    case 'C':
                        logEntry += string.Format("Dem Spieler {0} wurde die Verbindung bestätigt", playerName);
                        break;
                    case 'F':
                        logEntry += string.Format("Dem Spieler {0} wurde die Verbindung verweigert", playerName);
                        break;
                    case 'U':
                        logEntry += string.Format("Dem Spieler {0} wurde eine Liste mit den Aktuellen Spielern gesendet", playerName);
                        break;
                    case 'K':
                        logEntry += string.Format("Der Spieler {0} hat seine Verbindung zum Server bestätigt", messageToSave.user);
                        break;
                    case 'X':
                        logEntry += string.Format("Dem Spieler {0} wurde Mittgeteilt, dass das Spiel {1} startet", playerName, StaticDataService.currentServer.serverName);
                        break;
                    case 'D':
                        logEntry += string.Format("Der Spieler {0} hat das Spiel verlassen", messageToSave.user);
                        break;
                }
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(logEntry);
                System.Console.WriteLine("New log entry");
            };
        }
    }
}
