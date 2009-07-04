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
	public class BoardPieceCollection : ICollection, IEnumerable
	{
		ArrayList _BoardPieces = new ArrayList();
		public BoardPieceCollection()
		{
		}
		
		public int Count 
		{
			get { return _BoardPieces.Count; }
		}

		public bool IsReadOnly 
		{
			get { return _BoardPieces.IsReadOnly; }
		}

		public bool IsSynchronized 
		{
			get { return _BoardPieces.IsSynchronized; }
		}

		public object SyncRoot 
		{
			get { return this; }
		}

		public void Add (BoardPiece bp)
		{
			_BoardPieces.Add (bp);
		}

		public bool Contains(BoardPiece bp)
		{
			return _BoardPieces.Contains (bp);
		}

		public void CopyTo (Array array, int index)
		{
			_BoardPieces.CopyTo(array, index);
		}

		public IEnumerator GetEnumerator ()
		{
			return _BoardPieces.GetEnumerator ();
		}

		public void Remove (BoardPiece bp)
		{
			_BoardPieces.Remove(bp);
		}

		public void Clear()
		{
			_BoardPieces.Clear();
		}
		
		public BoardPiece this [int index] 
		{
			get 
			{
				if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException ("index");

				return (BoardPiece)_BoardPieces[index];
			}
		}
	}
}
