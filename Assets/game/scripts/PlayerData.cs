using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int playerLevel;
    public int[] completedLevels;
    public SerializableVector3 playerPosition;
    public SerializableQuaternion  playerRotation;
    public int[] inventory;
    public List<int> keys;


    public PlayerData(int _playerLevel, int[] _completedLevels, int[] _inventory, Vector3 _playerPos, Quaternion _playerRot, List<int> _keys)
    {
        playerLevel = _playerLevel;
        completedLevels = _completedLevels;
        inventory = _inventory;
        playerPosition = new SerializableVector3(_playerPos);
        playerRotation = new SerializableQuaternion(_playerRot);
        keys = _keys;
    }


    [System.Serializable]
    public class SerializableVector3 // in unity Vector3 are not Serializable so this class is needed to make it so
    {
        public float x;
        public float y;
        public float z;

        public SerializableVector3(Vector3 vector3)
        {
            x = vector3.x;
            y = vector3.y;
            z = vector3.z;
        }

        public Vector3 ToVector3()
        {
            return new Vector3(x, y, z);
        }

    }

        [System.Serializable]
    public class SerializableQuaternion // in unity Quaternion are not Serializable so this class is needed to make it so
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public SerializableQuaternion(Quaternion quaternion)
        {
            x = quaternion.x;
            y = quaternion.y;
            z = quaternion.z;
            w = quaternion.w;
        }

        public Quaternion ToQuaternion()
        {
            return new Quaternion(x, y, z, w);
        }
    }


}