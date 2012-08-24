//
//  IDatabaseEditor.cs
//
//  Author:
//       Andy York <andy@brdstudio.net>
//
//  Copyright (c) 2012 Andy York 2012
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;

namespace SQLiteMonoPlusEditor
{
	public interface IDatabaseEditor
	{
		event SQLiteMonoPlusEditor.Events.SQLExecutedEventHandler SQLExecuted;
		event SQLiteMonoPlusEditor.Events.SQLModifiedEventHandler SQLChanged;
		SQLiteMonoPlus.Connection CurrentConnection{ get; }
		string SQLText{ get; }
		bool ExecuteComplete{ set; }
		SQLiteMonoPlus.DBEditorType EditorType{ get; }

	}
}

