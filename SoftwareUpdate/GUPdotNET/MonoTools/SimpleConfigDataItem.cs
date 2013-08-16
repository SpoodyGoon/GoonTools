//
//  SimpleConfigDataItem.cs
//
//  Author:
//       Andy York <goontools@brdstudio.net>
//
//  Copyright (c) 2013 Andy York
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
using System.Collections.Generic;
using System.Collections;

namespace MonoTools.IO
{
    /// <summary>
    /// Dictionary to be used with SimpleConfigFile, nothing advanced here,
    /// kept generic and simple on purpose. 
    /// Best used for hobby related work that
    /// is not well defined ahead of time.
    /// </summary>
    public class SimpleConfigDataItem : Dictionary<string, string>
    {
        public SimpleConfigDataItem()
        {
        }

        public void AddItem(string key, object value)
        {
            this.Add(key, value.ToString());
        }

        public bool GetBoolean(string key, out bool value)
        {
            bool result = false;
            value = false;
            if (!this.ContainsKey(key))
            {
                return false;
            }

            if (Boolean.TryParse(this[key], out result))
            {
                value = result;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetDateTime(string key, out DateTime value)
        {
            DateTime result = DateTime.Now;
            value = DateTime.Now;
            if (!this.ContainsKey(key))
            {
                return false;
            }

            if (DateTime.TryParse(this[key], out result))
            {
                value = result;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetString(string key, out string value)
        {
            value = string.Empty;            
            if (!this.ContainsKey(key))
            {
                return false;
            }

            value = this[key].ToString();
            return true;
        }

        public bool GetInt(string key, out int value)
        {
            int result = -1;
            value = -1;
            if (!this.ContainsKey(key))
            {
                return false;
            }

            if (int.TryParse(this[key], out result))
            {
                value = result;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetObject(string key, out object value)
        {
            value = new object();
            if (!this.ContainsKey(key))
            {
                return false;
            }

            value = (object)this[key];
            return true;
        }

        public bool GetDouble(string key, out double value)
        {
            double result = 0.0d;
            value = 0.0d;
            if (!this.ContainsKey(key))
            {
                return false;
            }

            if (double.TryParse(this[key], out result))
            {
                value = result;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetFloat(string key, out float value)
        {
            float result = 0.0f;
            value = 0.0f;
            if (!this.ContainsKey(key))
            {
                return false;
            }

            if (float.TryParse(this[key], out result))
            {
                value = result;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

