using System;
using System.Collections;

namespace SQLiteMonoPlus.Schema
{
	/// <summary>
	/// Description of TriggerCollection.
	/// </summary>
	public class TriggerCollection : ICollection, IEnumerable
	{
		private ArrayList _Triggers = new ArrayList();
		public TriggerCollection()
		{
		}
		   
		public int Count
        {
            get { return _Triggers.Count; }
        }

        public bool IsReadOnly
        {
            get { return _Triggers.IsReadOnly; }
        }

        public bool IsSynchronized
        {
            get { return _Triggers.IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public void Add(Trigger t)
        {
            _Triggers.Add(t);
        }

        public bool Contains(Trigger t)
        {
            return _Triggers.Contains(t);
        }

        public void CopyTo(Array array, int index)
        {
            _Triggers.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _Triggers.GetEnumerator();
        }

        public void Remove(Trigger t)
        {
            _Triggers.Remove(t);
        }

        public void Clear()
        {
            _Triggers.Clear();
        }

        public Trigger this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (Trigger)_Triggers[index];
            }
        }

        public Trigger this[string TriggerName]
        {
            get
            {
				int index = -1;
				for(int i = 0; i < _Triggers.Count; i++)
				{
					if(((Trigger)_Triggers[i]).TriggerName == TriggerName)
					{
						index = i;
						break;
					}
				}
				
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (Trigger)_Triggers[index];
            }
        }
	
	}
}
