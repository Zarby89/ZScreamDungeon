using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace ZeldaFullEditor.Gui.ExtraForms
{
	[TypeConverter(typeof(ValueRangeConverter))]
	[ComVisible(true)]
	public struct ValueRange
	{
		public int Min { get; set; }
		public int Max { get; set; }

		public ValueRange(int min, int max)
		{
			Min = min;
			Max = max;
		}

		public static bool operator ==(ValueRange a, ValueRange b)
		{
			return a.Min == b.Min && a.Max == b.Max;
		}

		public static bool operator !=(ValueRange a, ValueRange b)
		{
			return a.Min != b.Min || a.Max != b.Max;
		}

		public override bool Equals(object obj)
		{
			if (obj is ValueRange b)
			{
				return Min == b.Min && Max == b.Max;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Min << 16 | Max;
		}
	}

	public class ValueRangeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}

			return base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				return true;
			}

			return base.CanConvertTo(context, destinationType);
		}


		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string text)
			{
				string text2 = text.Trim();
				if (text2.Length == 0)
				{
					return null;
				}

				culture ??= CultureInfo.CurrentCulture;

				char c = culture.TextInfo.ListSeparator[0];
				string[] array = text2.Split(c);
				int[] array2 = new int[array.Length];
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = (int) converter.ConvertFromString(context, culture, array[i]);
				}

				if (array2.Length == 2)
				{
					return new ValueRange(array2[0], array2[1]);
				}

				throw new ArgumentException("Crap.");
			}

			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException(nameof(destinationType));
			}

			if (value is ValueRange range)
			{
				if (destinationType == typeof(string))
				{
					culture ??= CultureInfo.CurrentCulture;

					string separator = culture.TextInfo.ListSeparator + " ";
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
					string[] array = new string[2]
					{
						converter.ConvertToString(context, culture, range.Min),
						converter.ConvertToString(context, culture, range.Max)
					};
					return string.Join(separator, array);
				}

				if (destinationType == typeof(InstanceDescriptor))
				{
					ValueRange range2 = (ValueRange) value;
					ConstructorInfo constructor = typeof(ValueRange).GetConstructor(new Type[2]
					{
						typeof(int),
						typeof(int)
					});
					if (constructor != null)
					{
						return new InstanceDescriptor(constructor, new int[2]
						{
							range2.Min,
							range2.Max
						});
					}
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
		{
			if (propertyValues == null)
			{
				throw new ArgumentNullException(nameof(propertyValues));
			}

			object obj = propertyValues["Min"];
			object obj2 = propertyValues["Max"];

			if (obj is null or not int || obj2 is null or not int)
			{
				throw new ArgumentException("Shit.");
			}

			return new ValueRange((int) obj, (int) obj2);
		}

		public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(ValueRange), attributes);
			return properties.Sort(new string[2]
			{
				"Min",
				"Max"
			});
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public ValueRangeConverter()
		{
		}
	}
}
