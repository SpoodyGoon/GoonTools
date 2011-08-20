
using System;
using System.Collections;

namespace SQLiteMonoPlusUI.Schema
{
	public class ViewCollection : ICollection, IEnumerable
	{
		ArrayList _Views = new ArrayList();
		public ViewCollection ()
		{
		}

        public int Count
        {
            get { return _Views.Count; }
        }

        public bool IsReadOnly
        {
            get { return _Views.IsReadOnly; }
        }

        public bool IsSynchronized
        {
            get { return _Views.IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public void Add(View v)
        {
            _Views.Add(v);
        }

        public bool Contains(View v)
        {
            return _Views.Contains(v);
        }

        public void CopyTo(Array array, int index)
        {
            _Views.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _Views.GetEnumerator();
        }

        public void Remove(View v)
        {
            _Views.Remove(v);
        }

        public void Clear()
        {
            _Views.Clear();
        }

        public View this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (View)_Views[index];
            }
        }

        public View this[string ViewName]
        {
            get
            {
				int index = -1;
				for(int i = 0; i < _Views.Count; i++)
				{
					if(((View)_Views[i]).ViewName == ViewName)
					{
						index = i;
						break;
					}
				}
				
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (View)_Views[index];
            }
        }
	}
}



