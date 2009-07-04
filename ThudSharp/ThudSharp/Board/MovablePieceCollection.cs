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
	public class MovablePieceCollection : ICollection, IEnumerable
	{
		ArrayList _MovablePieces = new ArrayList();
		public MovablePieceCollection()
		{
		}
		
		public int Count 
		{
			get { return _MovablePieces.Count; }
		}

		public bool IsReadOnly 
		{
			get { return _MovablePieces.IsReadOnly; }
		}

		public bool IsSynchronized 
		{
			get { return _MovablePieces.IsSynchronized; }
		}

		public object SyncRoot 
		{
			get { return this; }
		}

		public void Add (MovablePiece mp)
		{
			_MovablePieces.Add (mp);
		}

		public bool Contains(MovablePiece mp)
		{
			return _MovablePieces.Contains (mp);
		}

		public void CopyTo (Array array, int index)
		{
			_MovablePieces.CopyTo(array, index);
		}

		public IEnumerator GetEnumerator ()
		{
			return _MovablePieces.GetEnumerator ();
		}

		public void Remove (MovablePiece mp)
		{
			_MovablePieces.Remove(mp);
		}

		public void Clear()
		{
			_MovablePieces.Clear();
		}
		
		public MovablePiece this [int index] 
		{
			get 
			{
				if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException ("index");

				return (MovablePiece)_MovablePieces[index];
			}
		}
	}
}
