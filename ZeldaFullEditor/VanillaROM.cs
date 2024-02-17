using System;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	// TODO allow headered ROMs to work by trimming the header


	// This should definitely be in like the main form or something
	// but at this point with ZS, I don't care

	/// <summary>
	/// Provides of and read-only access to a vanilla ROM file.
	/// </summary>
	internal static class VanillaROM
	{
		/// <summary>
		/// SHA-256 of the vanilla US ROM
		/// </summary>
		const string USSHA = "66871D66BE19AD2C34C927D6B14CD8EB6FC3181965B6E517CB361F7316009CFB";

		/// <summary>
		/// File name of ROM in isolated storage
		/// </summary>
		const string USFileName = "alttpus.sfc";

		// For restoration/fastrom
		private static readonly IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForAssembly();

		private static byte[] vanillaROM = null;

		/// <summary>
		/// Gets a copy of the vanilla ROM for read-only access.
		/// </summary>
		public static ReadOnlyCollection<byte> Data { get; private set; } = null;

		static VanillaROM()
		{
			// Look for a file, and just leave if there isn't one
			if (!storageFile.FileExists(USFileName))
			{
				return;
			}

			using (var s = new IsolatedStorageFileStream(USFileName, FileMode.Open, storageFile))
			{
				// If it's not the right size, it's definitely wrong
				if (s.Length != Constants.VanillaROMSize)
				{
					storageFile.DeleteFile(USFileName); // delete it
					return;
				}

				// copy the ROM
				s.Position = 0;

				vanillaROM = new byte[Constants.VanillaROMSize];
				s.Read(vanillaROM, 0, Constants.VanillaROMSize);
			}

			// validate hash
			if (VerifyCurrentROM())
			{
				Data = Array.AsReadOnly(vanillaROM);
			}
			else
			{
				storageFile.DeleteFile(USFileName); // delete bad roms
			}
		}
		
		private static readonly OpenFileDialog OpenROM = new OpenFileDialog()
		{
			Filter = UIText.SNESROMType,
			Title = "Select a vanilla ALTTP ROM file",
		};

		/// <summary>
		/// Prompts the user to provide a vanilla copy of the ROM for use by other features and saves it in storage.
		/// </summary>
		/// <returns>A <see langword="bool"/> for Jared to use or something idk.</returns>
		public static bool SetVanillaROM()
		{
			// If a rom is already set, verify that it's vanilla
			// If it is, then tell the user everything is coolio
			if (Data != null)
			{
				if (VerifyCurrentROM())
				{
					MessageBox.Show(
						"You appear to already have a vanilla ROM uploaded.",
						"Good ROM",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);
					return false;
				}
			}

			MessageBox.Show(
				"Please provide a vanilla copy of the US alttp ROM\r\n" +
				"for ZScream to use for back up/reference.\r\n" +
				"This should only need to be done once;\r\n" +
				"your copy will be saved across sessions.",
				"Give ROM",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);

			string fileName;

			if (OpenROM.ShowDialog() is DialogResult.OK)
			{
				fileName = OpenROM.FileName;
			}
			else
			{
				MessageBox.Show("Operation cancelled", "Cancelled ROM", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			// read the file
			byte[] rom;

			try
			{
				using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
				{
					if (fs.Length != Constants.VanillaROMSize)
					{
						BadROM();
						fs.Close();
						return false;
					}

					fs.Position = 0;
					rom = new byte[Constants.VanillaROMSize];
					fs.Read(rom, 0, Constants.VanillaROMSize);

					fs.Close();
				}
			}
			catch
			{
				MessageBox.Show("Something went wrong loading the ROM!", "UH OH!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			// validate the hash
			if (!VerifyROM(rom))
			{
				BadROM();
				return false;
			}

			// save to storage
			try {
				using (var s = new IsolatedStorageFileStream(USFileName, FileMode.Create, FileAccess.Write, storageFile))
				{
					s.Write(rom, 0, Constants.VanillaROMSize);
				}
			}
			catch
			{
				MessageBox.Show("Something went wrong saving the ROM!", "UH OH!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			// finalize rom
			MessageBox.Show("Vanilla ROM successfully uploaded", "Good ROM!", MessageBoxButtons.OK, MessageBoxIcon.Information);

			vanillaROM = rom;
			Data = Array.AsReadOnly(rom);

			return true;
		}

		/// <summary>
		/// Shows a message box that's used by a couple things.
		/// </summary>
		private static void BadROM()
		{
			MessageBox.Show("This is not a vanilla US ROM!", "Bad ROM", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// Validates that a vanilla ROM has previously been uploaded
		/// and notifies the end-user that one is required for this feature.
		/// </summary>
		/// <returns><see langword="true"/> if a vanilla ROM is available for reference; otherwise, <see langword="false"/></returns>
		public static bool CheckForVanillaROM()
		{
			if (!VerifyCurrentROM())
			{
				MessageBox.Show(
					"This feature requires a vanilla ROM in ZS storage\r\n" +
					"which you do not appear to have.\r\n" +
					"Please upload one using the option in the File menu.",
					"Vanilla required",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
				return false;
			}

			return true;
		}

		/// <summary>
		/// Validates the currently stored ROM for being vanilla.
		/// </summary>
		/// <returns><see langword="true"/> if the provided ROM appears vanilla; otherwise, <see langword="false"/></returns>
		private static bool VerifyCurrentROM()
		{
			return VerifyROM(vanillaROM);
		}

		/// <summary>
		/// Validates a given ROM for vanillity by checking length and SHA-256.
		/// </summary>
		/// <param name="rom">an array of bytes that better be vanilla, or else</param>
		/// <returns><see langword="true"/> if the provided ROM appears vanilla; otherwise, <see langword="false"/></returns>
		private static bool VerifyROM(byte[] rom)
		{
			if ((rom?.Length ?? 0) != Constants.VanillaROMSize) // also checks for null by defaulting to 0
			{
				return false;
			}

			var checkHash = string.Concat(
				System.Security.Cryptography.SHA256.Create().ComputeHash(rom)
				.Select(b => $"{b:X2}")
			);

			return checkHash == USSHA;
		}

	}
}
