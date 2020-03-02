using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    /// <summary>
    /// Class used to simulate singleton behaviour
    /// </summary>
    /// <typeparam name="T">Class to be singleted</typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// Object Instance
        /// </summary>
        protected static T m_Instance;

        public static T Instance
        {
            get
            {
                //If no references found, search it.
                if (m_Instance == null)
                    m_Instance = (T)FindObjectOfType(typeof(T));
                return m_Instance;
            }
        }
    }
}
