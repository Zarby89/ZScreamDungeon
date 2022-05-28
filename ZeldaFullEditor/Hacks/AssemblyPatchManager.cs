namespace ZeldaFullEditor.Hacks
{
	public class AssemblyPatchManager
	{
		private int FreeSpace { get; }

		private readonly Dictionary<string, int> Labels = new();

		private readonly List<string> Patches = new();

		public AssemblyPatchManager()
		{

		}

		public void AddLabel(string name, int value)
		{
			if (Patches.Contains(name))
			{
				throw new DuplicateNameException();
			}

			Labels[name] = value;
		}






		public string ParseAndBuildFile(string file, Dictionary<string, object> labels)
		{
			StringBuilder ret = new();

			foreach (var line in Patches)
			{
				ret.AppendLine(line);

				ret.AppendLine(";====================");
			}

			foreach (var (name, address) in Labels)
			{
				ret.AppendLine($"{name} = ${address:X6}");
			}

			return ret.ToString();
		}
	}

}
