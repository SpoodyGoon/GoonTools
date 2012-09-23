
using System;
using System.Collections;

namespace SQLiteMonoPlus.Properties
{
	public class PragmaCollection : ICollection, IEnumerable
	{
		ArrayList _Pragmas = new ArrayList();
		public PragmaCollection ()
		{
		}
		
		public int Count
		{
			get { return _Pragmas.Count; }
		}
		
		public bool IsReadOnly
		{
			get { return _Pragmas.IsReadOnly; }
		}
		
		public bool IsSynchronized
		{
			get { return _Pragmas.IsSynchronized; }
		}
		
		public object SyncRoot
		{
			get { return this; }
		}

		public void Add(Pragma p)
		{
			_Pragmas.Add(p);
		}
		
		public bool Contains(Pragma p)
		{
			return _Pragmas.Contains(p);
		}
		
		public void CopyTo(Array array, int index)
		{
			_Pragmas.CopyTo(array, index);
		}
		
		public IEnumerator GetEnumerator()
		{
			return _Pragmas.GetEnumerator();
		}
		
		public void Remove(Pragma p)
		{
			_Pragmas.Remove(p);
		}
		
		public void Clear()
		{
			_Pragmas.Clear();
		}
		
		public Pragma this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException("index");
				
				return (Pragma)_Pragmas[index];
			}
		}
		
		public Pragma this[string PragmaName]
		{
			get
			{
				int index = -1;
				for(int i = 0; i < _Pragmas.Count; i++)
				{
					if(((Pragma)_Pragmas[i]).PragmaName.Equals(PragmaName,StringComparison.InvariantCultureIgnoreCase))
					{
						index = i;
						break;
					}
				}
				
				if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException("index", "Could not find pragma named: " + PragmaName);
				
				return (Pragma)_Pragmas[index];
			}
		}
	}
}

