using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
    public class MessageData
    {
        private const char CHEESE = '\uBEBE'; // Inserted into commands to protect them from dictionary replacements.

        public string RawString { get; internal set; }
        public string ContentsParsed { get; internal set; }
        public int ID { get; internal set; }
        public byte[] Data { get; internal set; }
        public byte[] DataParsed { get; internal set; }
        public int Address { get; internal set; }

        public MessageData(int id, int address, string rawString, byte[] rawData, string parsedString, byte[] parsedData)
        {
            this.ID = id;
            this.Address = address;
            this.Data = rawData;
            this.DataParsed = parsedData;
            this.RawString = rawString;
            this.ContentsParsed = parsedString;
        }

        public void SetMessage(string messageString)
        {
            this.ContentsParsed = messageString;
            this.RawString = this.OptimizeMessageForDictionary(messageString);
            this.RecalculateData();
        }

        private void RecalculateData()
        {
            this.Data = TextEditor.ParseMessageToData(this.RawString);
            this.DataParsed = TextEditor.ParseMessageToData(this.ContentsParsed);
        }

        public override string ToString()
        {
            return string.Format("{0:X3} - {1}", this.ID, this.ContentsParsed);
        }

        public string GetReadableDumpedContents()
        {
            StringBuilder stringBuilder = new StringBuilder(this.Data.Length * 2 + 1);
            foreach (byte b in this.Data)
            {
                stringBuilder.Append(b.ToString("X2"));
                stringBuilder.Append(" ");
            }

            stringBuilder.Append(TextEditor.MESSAGETERMINATOR.ToString("X2"));

            return string.Format("[[[[\r\nMessage {0:X3}]]]]\r\n[Contents]\r\n{1}\r\n\r\n[Data]\r\n{2}\r\n\r\n\r\n\r\n", this.ID, TextEditor.AddNewLinesToCommands(this.ContentsParsed), stringBuilder.ToString());
        }

        public string GetDumpedContents()
        {
            return string.Format("{0:X3} : {1}\r\n\r\n", this.ID, this.ContentsParsed);
        }

        private string OptimizeMessageForDictionary(string messageString)
        {
            // Build a new copy of the string where commands have their characters padded with a protective character
            // this way, we can't accidentally replace anything as we do the dictionary stuff.
            StringBuilder protons = new StringBuilder();
            bool command = false;
            foreach (char c in messageString)
            {
                if (c == '[')
                {
                    command = true;
                }
                else if (c == ']')
                {
                    command = false;
                }

                protons.Append(c);
                if (command)
                {
                    protons.Append(CHEESE);
                }
            }

            return TextEditor.ReplaceAllDictionaryWords(protons.ToString()).Replace(CHEESE.ToString(), "");
        }
    }
}
