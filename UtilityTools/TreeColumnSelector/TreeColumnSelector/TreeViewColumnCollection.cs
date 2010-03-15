/*************************************************************************
 *                      TreeViewColumnCollection.cs
 *
 *	 	Copyright (C) 2010
 *		Andrew York <goontools@brdstudio.net>
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

using System;
using System.Collections;
using Gtk;
namespace GoonTools.ColumnSelector
{
	public class TreeViewColumnCollection : ICollection, IEnumerable
	{
		System.Collections.ArrayList _TreeViewColumns;
		public TreeViewColumnCollection ()
		{
			_TreeViewColumns = new ArrayList();
		}

		public int Count
		{
			get { return _TreeViewColumns.Count; }
		}

		public int IndexOf(TreeViewColumn tc)
		{
			return _TreeViewColumns.IndexOf (tc);
		}

		public bool IsReadOnly
		{
			get { return _TreeViewColumns.IsReadOnly; }
		}

		public bool IsSynchronized
		{
			get { return _TreeViewColumns.IsSynchronized; }
		}

		public object SyncRoot
		{
			get { return this; }
		}

		public void Add (TreeViewColumn tc)
		{
			_TreeViewColumns.Add (tc);
		}

		public void Insert (int index, TreeViewColumn tc)
		{
			_TreeViewColumns.Insert (index, tc);
		}
		
		public void InsertRange(int index, TreeViewColumn[] tc)
		{
			_TreeViewColumns.InsertRange(index, tc);
		}

		public bool Contains  (TreeViewColumn tc)
		{
			return _TreeViewColumns.Contains (tc);
		}

		public void CopyTo (Array array, int index)
		{
			_TreeViewColumns.CopyTo (array, index);
		}

		public IEnumerator GetEnumerator ()
		{
			return _TreeViewColumns.GetEnumerator ();
		}

		public void Remove  (TreeViewColumn tc)
		{
			_TreeViewColumns.Remove (tc);
		}

		public void Clear()
		{
			_TreeViewColumns.Clear();
		}
		
		public TreeViewColumn this [int index]
		{
			get
			{
				if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException ("index");

				return (TreeViewColumn)_TreeViewColumns[index];
			}
		}
	}
}