
using System;
using System.Collections;

namespace SQLiteMonoPlus.Schema
{
	public class ForeignKeyCollection : ICollection, IEnumerable
	{
		ArrayList _ForeignKeys = new ArrayList();
		public ForeignKeyCollection ()
		{
		}

        public int Count
        {
            get { return _ForeignKeys.Count; }
        }

        public bool IsReadOnly
        {
            get { return _ForeignKeys.IsReadOnly; }
        }

        public bool IsSynchronized
        {
            get { return _ForeignKeys.IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public void Add(ForeignKey fk)
        {
            _ForeignKeys.Add(fk);
        }

        public bool Contains(ForeignKey fk)
        {
            return _ForeignKeys.Contains(fk);
        }

        public void CopyTo(Array array, int index)
        {
            _ForeignKeys.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _ForeignKeys.GetEnumerator();
        }

        public void Remove(ForeignKey fk)
        {
            _ForeignKeys.Remove(fk);
        }

        public void Clear()
        {
            _ForeignKeys.Clear();
        }

        public ForeignKey this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (ForeignKey)_ForeignKeys[index];
            }
        }

        public ForeignKey this[string ForeignKeyName]
        {
            get
            {
				int index = -1;
				for(int i = 0; i < _ForeignKeys.Count; i++)
				{
					if(((ForeignKey)_ForeignKeys[i]).ForeignKeyName == ForeignKeyName)
					{
						index = i;
						break;
					}
				}
				
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (ForeignKey)_ForeignKeys[index];
            }
        }
	}
}



