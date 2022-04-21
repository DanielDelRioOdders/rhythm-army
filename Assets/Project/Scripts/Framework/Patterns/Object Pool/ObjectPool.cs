using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Odders
{
    [AddComponentMenu("Odders/Patterns/Object Pool")]
    public partial class ObjectPool : BaseObject
    {
        #region Public Variables
        public int size;
        public GameObject[] prefabs;
        #endregion Public Variables


        #region Protected Variables
        protected Queue<GameObject> pool = new Queue<GameObject>();
        #endregion Protected Variables


        #region Events
        public UnityEvent<GameObject> OnDequeue, OnEnqueue;
        #endregion Events


        #region Unity Methods
        protected virtual void Start()
        {
            if (prefabs.Length <= 0) return;

            for (int i = 0; i < size; i++)
            {
                GameObject prefab = prefabs.Random();

                if (prefab != null)
                {
                    GameObject obj = Instantiate(prefabs.Random(), transform);

                    IPoolObject poolObject = obj.GetComponent<IPoolObject>();
                    if (poolObject != null) poolObject.Pool = this;

                    obj.SetActive(false);
                    pool.Enqueue(obj);
                }
            }
        }
        #endregion Unity Methods


        #region Main Methods
        public virtual GameObject Dequeue()
        {
            if (pool.Count == 0) return null;

            GameObject obj = pool.Dequeue();
            if (obj == null) return null;

            obj.SetActive(true);

            IPoolObject poolObject = obj.GetComponent<IPoolObject>();
            if (poolObject != null) poolObject.OnDequeue();

            OnDequeue?.Invoke(obj);

            return obj;
        }
        public virtual void Enqueue(GameObject obj)
        {
            if (obj == null) return;

            IPoolObject poolObject = obj.GetComponent<IPoolObject>();
            if (poolObject != null) poolObject.OnEnqueue();
            
            pool.Enqueue(obj);
            obj.SetActive(false);

            OnEnqueue?.Invoke(obj);
        }
        #endregion Main Methods
    }
}