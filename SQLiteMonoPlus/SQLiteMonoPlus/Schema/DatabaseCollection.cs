/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 2/28/2012
 * Time: 5:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace SQLiteMonoPlus.Schema
{
	/// <summary>
	/// Description of DatabaseCollection.
	/// </summary>
	public class DatabaseCollection : ICollection, IEnumerable
	{
		ArrayList _Databases = new ArrayList();
		public DatabaseCollection()
		{
		}

        public int Count
        {
            get { return _Databases.Count; }
        }

        public bool IsReadOnly
        {
            get { return _Databases.IsReadOnly; }
        }

        public bool IsSynchronized
        {
            get { return _Databases.IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public void Add(Database d)
        {
            _Databases.Add(d);
        }

        public bool Contains(Database d)
        {
            return _Databases.Contains(d);
        }

        public void CopyTo(Array array, int index)
        {
            _Databases.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _Databases.GetEnumerator();
        }

        public void Remove(Database d)
        {
            _Databases.Remove(d);
        }

        public void Clear()
        {
            _Databases.Clear();
        }

        public Database this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (Database)_Databases[index];
            }
        }

        public Database this[string DatabaseName]
        {
            get
            {
				int index = -1;
				for(int i = 0; i < _Databases.Count; i++)
				{
					if(((Database)_Databases[i]).DBConnection.ConnectionName == DatabaseName)
					{
						index = i;
						break;
					}
				}
				
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (Database)_Databases[index];
            }
        }
	}
}
