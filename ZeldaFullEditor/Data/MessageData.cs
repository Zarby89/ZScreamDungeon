using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ZeldaFullEditor.Data
{
    /// <summary>
    ///     A data class containing all the info for messages (Text dialog).
    /// </summary>
    public class MessageData
    {
        private const char CHEESE = '\uBEBE'; // Inserted into commands to protect them from dictionary replacements.

        /// <summary>
        ///     Gets the raw string for the message.
        /// </summary>
        public string RawString { get; internal set; }

        /// <summary>
        ///     Gets the parsed string for the message.
        /// </summary>
        public string ContentsParsed { get; internal set; }

        /// <summary>
        ///     Gets the ID of the message.
        /// </summary>
        public int ID { get; internal set; }

        /// <summary>
        ///     Gets the raw data for the message.
        /// </summary>
        public byte[] Data { get; internal set; }

        /// <summary>
        ///     Gets the parsed data for the message.
        /// </summary>
        public byte[] DataParsed { get; internal set; }

        /// <summary>
        ///     Gets the address for the message.
        /// </summary>
        public int Address { get; internal set; }

        public int Height { get; internal set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageData"/> class.
        /// </summary>
        /// <param name="id"> The ID. </param>
        /// <param name="address"> The address. </param>
        /// <param name="rawString"> The raw string. </param>
        /// <param name="rawData"> The raw data (bytes). </param>
        /// <param name="parsedString"> The parsed string. </param>
        /// <param name="parsedData"> The parsed data (bytes). </param>
        public MessageData(int id, int address, string rawString, byte[] rawData, string parsedString, byte[] parsedData)
        {
            this.ID = id;
            this.Address = address;
            this.Data = rawData;
            this.DataParsed = parsedData;
            this.RawString = rawString;
            this.ContentsParsed = parsedString;
            this.Height = ((Regex.Matches(rawString, @"\[1\]|\[2\]|\[3\]|\[V\]").Count) * 13)+14;
        }

        /// <summary>
        ///     Sets all the message data based on the given message string.
        /// </summary>
        /// <param name="messageString"> The string to set the message to. </param>
        // TODO: Make this use Refresh() in the next version when actual functional changes are valid.
        public void SetMessage(string messageString)
        {
            this.ContentsParsed = messageString;
            this.RawString = this.OptimizeMessageForDictionary(messageString);
            this.RecalculateData();
            this.Height = ((Regex.Matches(RawString, @"\[1\]|\[2\]|\[3\]|\[V\]").Count) * 13) + 14;
        }

		/// <summary>
		/// Refreshes the message entirely by reoptimizing it for the dictionary and recalculating the data.
		/// </summary>
		public void Refresh()
		{
			RawString = OptimizeMessageForDictionary(ContentsParsed);
			RecalculateData();
		}

		/// <summary>
		///     Returns the parsed message as a string.
		/// </summary>
		/// <returns> A string. </returns>
		public override string ToString()
        {
            return string.Format("{0:X3} - {1}", this.ID, this.ContentsParsed);
        }

        /// <summary>
        ///     Returns a string with all of the available data in the message.
        /// </summary>
        /// <returns> A string. </returns>
        public string GetReadableDumpedContents()
        {
            StringBuilder stringBuilder = new StringBuilder((this.Data.Length * 2) + 1);
            foreach (byte b in this.Data)
            {
                stringBuilder.Append(b.ToString("X2"));
                stringBuilder.Append(" ");
            }

            stringBuilder.Append(TextEditor.MessageTerminator.ToString("X2"));

            return string.Format("[[[[\r\nMessage {0:X3}]]]]\r\n[Contents]\r\n{1}\r\n\r\n[Data]\r\n{2}\r\n\r\n\r\n\r\n", this.ID, TextEditor.AddNewLinesToCommands(this.ContentsParsed), stringBuilder.ToString());
        }

        /// <summary>
        ///     Returns the parsed message as a string with some extra formating.
        /// </summary>
        /// <returns> A string. </returns>
        // TODO: INTERPOLATE
        public string GetDumpedContents()
        {
            return string.Format("{0:X3} : {1}\r\n\r\n", this.ID, this.ContentsParsed);
        }

        private void RecalculateData()
        {
            this.Data = TextEditor.ParseMessageToData(this.RawString);
            this.DataParsed = TextEditor.ParseMessageToData(this.ContentsParsed);
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

            return TextEditor.ReplaceAllDictionaryWords(protons.ToString()).Replace(CHEESE.ToString(), string.Empty);
        }
    }
}
