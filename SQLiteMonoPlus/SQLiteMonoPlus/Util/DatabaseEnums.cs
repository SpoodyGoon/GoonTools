using System;

namespace SQLiteMonoPlus
{	
	public enum ScriptToAction
	{
		Create,
		Alter,
		Drop,
		DropCreate,
		Select,
		Insert,
		Update,
		Delete,
		Execute
	}
	
	public enum ScriptToLocation
	{
		QueryWindow,
		File,
		Clipboard
	}
}

