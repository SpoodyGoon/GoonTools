
using System;

namespace ThudSharp
{	
	public enum NonMovablePieceType
	{
		None,
		Light,
		Dark
	}
	
	
	public enum MovablePieceType
	{
		[System.ComponentModel.DescriptionAttribute("None")]  None,
		[System.ComponentModel.DescriptionAttribute("Dwarf")]  Dwarf,
		[System.ComponentModel.DescriptionAttribute("Troll")]  Troll
	}
}
