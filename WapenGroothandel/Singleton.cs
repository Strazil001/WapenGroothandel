using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WapenGroothandel
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        private static T _instance;
        public static T Instance
        {
            private set { _instance = value; }
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }


        protected Singleton()
        {
            if (_instance != null && _instance != this)
            {
                _instance.ClearObject();
            }
            _instance = this as T;
        }


        public static void Clear()
        {
            if (_instance != null)
            {
                _instance.ClearObject();
                _instance = null;
            }
        }

        protected virtual void ClearObject()
        {

        }

    }
}
