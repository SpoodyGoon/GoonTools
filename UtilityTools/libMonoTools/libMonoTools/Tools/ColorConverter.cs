//
//  ColorConverter.cs
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

namespace libMonoTools.Tools
{
    public class ColorConverter
    {   
        public Gdk.Color ColorFromHex (string HexString)
        {
            Gdk.Color c = new Gdk.Color();
            if(Gdk.Color.Parse(HexString, ref c))
            {
                return c;
            }
            else
            {
                throw new System.Exception("Unable to convert the provided Hex string to a Gdk.Color." + System.Environment.NewLine + "Provided string (HexString): " + HexString);
            }
        }

        public string HexFromColor(Gdk.Color color)
        {
            return System.String.Format ("#{0:x2}{1:x2}{2:x2}", (byte)(color.Red >> 8), (byte)(color.Green >> 8),(byte)(color.Blue >> 8));
        }
    }
}

