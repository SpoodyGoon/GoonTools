/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 6/26/2009
 * Time: 10:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace ThudSharp
{
	/// <summary>
	/// Description of GameBoardRow.
	/// </summary>
	public class GameBoardRow
	{
		int _RowIndex;
		ArrayList _Cells = new ArrayList();
		
		#region Constructors
		
		public GameBoardRow()
		{
		}
		
		public GameBoardRow(ArrayList cells)
		{
			_Cells.AddRange(cells);
		}
		
		#endregion Constructors
		
		#region Public Properties
		
		public int RowIndex
		{
			set{_RowIndex=value;}
			get{return _RowIndex;}
		}
		
		public ArrayList Cells
		{
			get{return _Cells;}
		}
		
		public int Count
		{
			get{return _Cells.Count;}
		}
		
		#endregion Public Properties
		
		
		public GameBoard this [int index] 
		{
			get 
			{
				if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException ("index");

				return (GameBoard)_Cells[index];
			}
		}
		
	}
	
	public class GameBoardRowCollection : ICollection, IEnumerable
	{
		ArrayList _GameBoardRows = new ArrayList();
		public GameBoardRowCollection()
		{
		}
		
		public int Count 
		{
			get { return _GameBoardRows.Count; }
		}

		public bool IsReadOnly 
		{
			get { return _GameBoardRows.IsReadOnly; }
		}

		public bool IsSynchronized 
		{
			get { return _GameBoardRows.IsSynchronized; }
		}

		public object SyncRoot 
		{
			get { return this; }
		}

		public void Add (GameBoardRow gb)
		{
			_GameBoardRows.Add (gb);
		}

		public bool Contains(GameBoardRow gb)
		{
			return _GameBoardRows.Contains (gb);
		}

		public void CopyTo (Array array, int index)
		{
			_GameBoardRows.CopyTo(array, index);
		}

		public IEnumerator GetEnumerator ()
		{
			return _GameBoardRows.GetEnumerator ();
		}

		public void Remove (GameBoardRow gb)
		{
			_GameBoardRows.Remove(gb);
		}

		public void Clear()
		{
			_GameBoardRows.Clear();
		}
		
		public GameBoardRow this [int index] 
		{
			get 
			{
				if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException ("index");

				return (GameBoardRow)_GameBoardRows[index];
			}
		}
	}
}
