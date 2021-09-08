using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GF.ObjectPoolSystem;

namespace GF.ObjectPoolSystem.Test
{

    public sealed class GameObjectPoolingTest : ObjectBase
    {

        private GameObject m_GameObject;

        public static GameObjectPoolingTest Create(string name, GameObject gameObject)
        {
            if (gameObject == null)
            {
                throw new GameFrameworkException("gameObject is invalid.");
            }

            GameObjectPoolingTest objectPool = new GameObjectPoolingTest()
            {
                m_GameObject = gameObject
            };

            objectPool.Initialize(name, gameObject);

            return objectPool;
        }

        protected override void OnSpawn()
        {
            Debug.Log("OnSpawn");
            m_GameObject.SetActive(true);
        }

        protected override void OnUnspawn()
        {
            Debug.Log("OnUnspawn");
            m_GameObject.SetActive(false);
        }

        protected override void Release(bool isShutdown)
        {
            Debug.Log("Released");
            GameObject.Destroy(m_GameObject);
            m_GameObject = null;
        }

        public override void Clear()
        {
            base.Clear();
            GameObject.Destroy(m_GameObject);
            m_GameObject = null;
        }
    }

    public class ObjectPoolTest : MonoBehaviour
    {

        void Start()
        {
            StartCoroutine(ObjectPoolTestEnumerator());
        }

        private IEnumerator ObjectPoolTestEnumerator()
        {

            //Create the type of object pool
            //创建对应的对象池
            var objectPool = GFObjectPoolComponent.Instance.CreateSingleSpawnObjectPool<GameObjectPoolingTest>();

            //Create the gameobject
            //创建对象池对象
            GameObjectPoolingTest spawnedObjectPoolTestBase = GameObjectPoolingTest.Create("GameObjectPoolingTest", new GameObject("GameObjectPoolingTest.GameObject"));

            //Register to the object pool
            //把这个对象注册进对象池
            objectPool.Register(spawnedObjectPoolTestBase, true);

            //Wait for 3 seconds
            //等待三秒
            yield return new WaitForSeconds(3);

            //Unspawn the gameobject
            //回收对象
            objectPool.Unspawn(spawnedObjectPoolTestBase);

            //Another wait for 3 seconds ...
            //等待三秒。。。
            yield return new WaitForSeconds(3);

            //Release all
            //释放所有对象池的对象
            objectPool.Release();

        }

    }
}
