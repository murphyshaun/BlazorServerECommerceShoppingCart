namespace Shop.Common.Extension
{
	public static class IntegerExtension
	{
		public static int StringToInt(this string obj)
		{
			if (int.TryParse(obj.ToString(), out int result)) return result;

			return default(int);
		}
	}
}