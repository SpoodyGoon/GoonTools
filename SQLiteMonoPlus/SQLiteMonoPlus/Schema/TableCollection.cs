using System;
using System.Collections;

namespace SQLiteMonoPlus.Schema
{
	public class TableCollection : ICollection, IEnumerable
	{
		ArrayList _Tables = new ArrayList();
		public TableCollection ()
		{
		}

        public int Count
        {
            get { return _Tables.Count; }
        }

        public bool IsReadOnly
        {
            get { return _Tables.IsReadOnly; }
        }

        public bool IsSynchronized
        {
            get { return _Tables.IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public void Add(Table t)
        {
            _Tables.Add(t);
        }

        public bool Contains(Table t)
        {
            return _Tables.Contains(t);
        }

        public void CopyTo(Array array, int index)
        {
            _Tables.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _Tables.GetEnumerator();
        }

        public void Remove(Table t)
        {
            _Tables.Remove(t);
        }

        public void Clear()
        {
            _Tables.Clear();
        }

        public Table this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (Table)_Tables[index];
            }
        }

        public Table this[string TableName]
        {
            get
            {
				int index = -1;
				for(int i = 0; i < _Tables.Count; i++)
				{
					if(((Table)_Tables[i]).TableName == TableName)
					{
						index = i;
						break;
					}
				}
				
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (Table)_Tables[index];
            }
        }
	}
}

