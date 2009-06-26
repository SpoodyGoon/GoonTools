/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 6/26/2009
 * Time: 4:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace ThudSharp
{
	/// <summary>
	/// Description of GameBoardColumnCollection.
	/// </summary>
	public class GameBoardColumnCollection : ICollection, IEnumerable
	{
		ArrayList _GameBoardColumns = new ArrayList();
		public GameBoardColumnCollection()
		{
		}
		
		public int Count 
		{
			get { return _GameBoardColumns.Count; }
		}

		public bool IsReadOnly 
		{
			get { return _GameBoardColumns.IsReadOnly; }
		}

		public bool IsSynchronized 
		{
			get { return _GameBoardColumns.IsSynchronized; }
		}

		public object SyncRoot 
		{
			get { return this; }
		}

		public void Add (GameBoard gb)
		{
			_GameBoardColumns.Add (gb);
		}

		public bool Contains(GameBoard gb)
		{
			return _GameBoardColumns.Contains (gb);
		}

		public void CopyTo (Array array, int index)
		{
			_GameBoardColumns.CopyTo(array, index);
		}

		public IEnumerator GetEnumerator ()
		{
			return _GameBoardColumns.GetEnumerator ();
		}

		public void Remove (GameBoard gb)
		{
			_GameBoardColumns.Remove(gb);
		}

		public void Clear()
		{
			_GameBoardColumns.Clear();
		}
		
		public GameBoard this [int index] 
		{
			get 
			{
				if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException ("index");

				return (GameBoard)_GameBoardColumns[index];
			}
		}
	}
}
