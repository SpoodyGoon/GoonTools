//
//  LocalSystemTools.cs
//
//  Author:
//       Andy York <andy@brdstudio.net>
//
//  Copyright (c) 2013 Andy York 2012
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
using so = System.IO;
using se = System.Environment;
using sr = System.Reflection;
using sc = System.Configuration;
using Gtk;

namespace MonoTools.IO
{
    public abstract class LocalSystemTools
    {
        protected string AppPath = null;
        protected string AppDataPath = null;
        protected string ProgramName = null;
        protected string UserDataPath = null;
        protected string OS = null;
        protected bool UserErrorLog = false;
        protected string ErrorLogFile = null;
        protected bool DebugMode = false;
    }
}
