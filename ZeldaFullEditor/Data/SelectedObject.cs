namespace ZeldaFullEditor
{
    /// <summary>
    ///		Some type of temporary object used to store selected object data.
    ///		TODO: Needs more research to verify. -Jared_Brian_.
    /// </summary>
    public class SelectedObject
    {
        /// <summary>
        ///		Gets or sets the ID of the object.
        /// </summary>
        public ushort ID { get; set; }

        /// <summary>
        ///		Gets or sets the name of the object.
        /// </summary>
		public string Name { get; set; }

        /// <summary>
        ///		Gets or sets an additional bit of data used for selected sprites.
        /// </summary>
        public byte Option { get; set; } = 0;

        /// <summary>
        ///		Initializes a new instance of the <see cref="SelectedObject"/> class.
        /// </summary>
        /// <param name="id"> The ID. </param>
        /// <param name="name"> The Name. </param>
        /// <param name="option"> Aditional info. </param>
		public SelectedObject(ushort id, string name, byte option = 0)
        {
            this.Name = name;
            this.ID = id;
            this.Option = option;
        }
    }
}
