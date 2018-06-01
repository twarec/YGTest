using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Liderboard : MonoBehaviour {
    public static List<int> GetLiderboard()
    {
        if (!File.Exists(Application.persistentDataPath + "/Liderboard.txt"))
        {
            File.Create(Application.persistentDataPath + "/Liderboard.txt").Close();
            File.WriteAllText(Application.persistentDataPath + "/Liderboard.txt", JsonUtility.ToJson(new Liders()));
        }
        return (JsonUtility.FromJson<Liders>(File.ReadAllText(Application.persistentDataPath + "/Liderboard.txt"))).lider;
    }
    public static void SetLiderBoar(int NewLider)
    {
        var save = GetLiderboard();
        save.Add(NewLider);
        save = save.OrderByDescending(x => x).ToList();
        File.WriteAllText(Application.persistentDataPath + "/Liderboard.txt", JsonUtility.ToJson(new Liders { lider = save }));
    }
}
[System.Serializable]
public class Liders
{
    public List<int> lider;
}
