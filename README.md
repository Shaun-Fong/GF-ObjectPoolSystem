# GF-ObjectPoolSystem

ObjectPoolSystem Of GameFramework

[中文文档](README-zhc.md)

## First Thing

Please take a look [GameFramework](https://github.com/EllanJiang/GameFramework) first.

And thanks to [EllanJiang](https://github.com/EllanJiang).

## Install

### Install via git URL

Requires a version of unity that supports path query parameter for git packages (Unity >= 2019.3.4f1, Unity >= 2020.1a21). 

1. In Unity , Go to Window -> Package Manager -> Add package from git URL

2. **This module depends on the GF-Core , so you need to install GF-Core First.** , use the url  `https://github.com/shaun-he/GF-Core.git` , then click **Add** , and wait for complie finished.

3. Next , use the url `https://github.com/shaun-he/GF-ObjectPoolSystem.git` , then click **Add** ,  wait for complie finished and done !

### Install via disk

1. Go `https://github.com/shaun-he/GF-Core.git` ,  Click the **Green Code** button , then click **Download Zip**.

2. Go `https://github.com/shaun-he/GF-ObjectPoolSystem.git` , Click the **Green Code** button , then click **Download Zip**.

3. Unzip two file somewhere in your disk.

4. In Unity , Go to Window -> Package Manager -> Add package from disk

5. open the **package.json** which in your GF-Core unzip folder.

6. open the **package.json** which in your GF-ObjectPoolSystem unzip folder.

7. Done!

## About Errors

If you see Errors after install GF-ObjectPoolSystem , that means you didn't install **GF-Core**.

If you still see the Errors , go find **GF.ObjectPoolSystem.asmdef** in your unzip folder , add **GF.Core** and **GF.Runtime** to the **Assembly Definition Reference** list.

And your **GF.ObjectPoolSystem.asmdef** should look like this

![https://z3.ax1x.com/2021/06/19/RiCl3q.png](https://z3.ax1x.com/2021/06/19/RiCl3q.png)

## Usage

You can found example in **Test** folder，drag **GFObjectPoolSystem** prefab in your scene which in Prefabs folder .

Click run，you should see the log `OnSpawn` in console window and you can see the gameobject('GameObjectPoolingTest.GameObject') spawned in the **Scene** .

Gameobject should deactivated after 3 seconds and destoryed in next 3 seconds.

```
//Create the type of object pool
var objectPool = GFObjectPoolComponent.Instance.CreateSingleSpawnObjectPool<GameObjectPoolingTest>();

//Create the gameobject
GameObjectPoolingTest spawnedObjectPoolTestBase = GameObjectPoolingTest.Create("GameObjectPoolingTest", new GameObject("GameObjectPoolingTest.GameObject"));

//Register to the object pool
objectPool.Register(spawnedObjectPoolTestBase, true);

//Wait for 3 seconds
yield return new WaitForSeconds(3);

//Unspawn the gameobject
objectPool.Unspawn(spawnedObjectPoolTestBase);

//Another wait for 3 seconds ...
yield return new WaitForSeconds(3);

//Release all
objectPool.Release();
```
