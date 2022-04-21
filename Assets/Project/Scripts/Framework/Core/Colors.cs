using Color = UnityEngine.Color;

namespace Odders
{
	public static class Colors
	{
		public static Color Black			{ get; private set; } = "000000".ToColor();
		public static Color DarkBlue		{ get; private set; } = "0000AA".ToColor();
		public static Color DarkGreen		{ get; private set; } = "00AA00".ToColor();
		public static Color DarkAqua		{ get; private set; } = "00AAAA".ToColor();
		public static Color DarkRed			{ get; private set; } = "AA0000".ToColor();
		public static Color DarkPurple		{ get; private set; } = "AA00AA".ToColor();
		public static Color Gold			{ get; private set; } = "FFAA00".ToColor();
		public static Color Gray			{ get; private set; } = "AAAAAA".ToColor();
		public static Color DarkGray		{ get; private set; } = "555555".ToColor();
		public static Color Blue			{ get; private set; } = "5555FF".ToColor();
		public static Color Green			{ get; private set; } = "55FF55".ToColor();
		public static Color Aqua			{ get; private set; } = "55FFFF".ToColor();
		public static Color Red				{ get; private set; } = "FF5555".ToColor();
		public static Color LightPurple		{ get; private set; } = "FF55FF".ToColor();
		public static Color Yellow			{ get; private set; } = "FFFF55".ToColor();
		public static Color White			{ get; private set; } = "FFFFFF".ToColor();
	}
}