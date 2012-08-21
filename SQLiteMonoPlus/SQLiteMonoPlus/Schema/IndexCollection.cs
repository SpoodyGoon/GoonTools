
using System;
using System.Collections;

namespace SQLiteMonoPlus.Schema
{
	public class IndexCollection : ICollection, IEnumerable
	{
		ArrayList _Indexs = new ArrayList();
		public IndexCollection ()
		{
		}

        public int Count
        {
            get { return _Indexs.Count; }
        }

        public bool IsReadOnly
        {
            get { return _Indexs.IsReadOnly; }
        }

        public bool IsSynchronized
        {
            get { return _Indexs.IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public void Add(Index i)
        {
            _Indexs.Add(i);
        }

        public bool Contains(Index i)
        {
            return _Indexs.Contains(i);
        }

        public void CopyTo(Array array, int index)
        {
            _Indexs.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _Indexs.GetEnumerator();
        }

        public void Remove(Index i)
        {
            _Indexs.Remove(i);
        }

        public void Clear()
        {
            _Indexs.Clear();
        }

        public Index this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (Index)_Indexs[index];
            }
        }

        public Index this[string IndexName]
        {
            get
            {
				int index = -1;
				for(int i = 0; i < _Indexs.Count; i++)
				{
					if(((Index)_Indexs[i]).IndexName.Equals(IndexName,StringComparison.InvariantCultureIgnoreCase))
					{
						index = i;
						break;
					}
				}
				
                if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException("index", "Could not find index named: " + IndexName);

                return (Index)_Indexs[index];
            }
        }
	}
}



