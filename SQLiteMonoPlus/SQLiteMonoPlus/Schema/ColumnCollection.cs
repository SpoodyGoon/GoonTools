using System;
using System.Collections;

namespace SQLiteMonoPlus.Schema
{
	public class ColumnCollection : ICollection, IEnumerable
	{
		private ArrayList _Columns = new ArrayList();
		public ColumnCollection ()
		{
		}

        public int Count
        {
            get { return _Columns.Count; }
        }

        public bool IsReadOnly
        {
            get { return _Columns.IsReadOnly; }
        }

        public bool IsSynchronized
        {
            get { return _Columns.IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public void Add(Column c)
        {
            _Columns.Add(c);
        }

        public bool Contains(Column c)
        {
            return _Columns.Contains(c);
        }

        public void CopyTo(Array array, int index)
        {
            _Columns.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _Columns.GetEnumerator();
        }

        public void Remove(Column c)
        {
            _Columns.Remove(c);
        }

        public void Clear()
        {
            _Columns.Clear();
        }

        public Column this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (Column)_Columns[index];
            }
        }

        public Column this[string ColumnName]
        {
            get
            {
				int index = -1;
				for(int i = 0; i < _Columns.Count; i++)
				{
					if(((Column)_Columns[i]).ColumnName == ColumnName)
					{
						index = i;
						break;
					}
				}
				
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (Column)_Columns[index];
            }
        }
	}
}

