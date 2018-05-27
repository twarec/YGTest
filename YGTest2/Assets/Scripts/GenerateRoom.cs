using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoom : MonoBehaviour {
    public Room room;
    public Room[] roomsGenerate;
    public static Queue<GameObject> QRooms = new Queue<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        int count = roomsGenerate.Length;
        for (int i = 0; i < count; i++)
            if (!roomsGenerate[i].RoomGameObject)
                InstateRoom(i);
    }
    private void Start()
    {
        QRooms.Enqueue(gameObject);
        if (QRooms.Count > 10)
        {
            Destroy(QRooms.Dequeue());
            QRooms.Peek().GetComponent<GenerateRoom>().room.Door.SetActive(true);
        }

    }
    public void InstateRoom(int index)
    {
        OffsetRoom offsetRoom = roomsGenerate[index].offsetRooms[Random.Range(0, roomsGenerate[index].offsetRooms.Length)];
        var Troom = Instantiate(offsetRoom.PrefabRoom);
        Room _room = roomsGenerate[index];
        _room.RoomGameObject = Troom.gameObject;
        Troom.position = transform.position + transform.TransformVector(offsetRoom.Offset);
        Troom.eulerAngles = transform.eulerAngles + offsetRoom.OffsetAngle;
        roomsGenerate[index] = _room;
    }
}
[System.Serializable]
public class Room
{
    public GameObject RoomGameObject;
    public OffsetRoom[] offsetRooms;
    public GameObject Door;
}
[System.Serializable]
public struct OffsetRoom
{
    public Vector3 OffsetAngle;
    public Vector3 Offset;
    public Transform PrefabRoom;
}
