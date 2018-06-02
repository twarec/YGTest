using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    public UnityEvent StartEvent;
    public UnityEvent EndGame;
    public static GameManager gameManager;

    private string loadStructure = "";
    public string LoadStructure
    {
        get
        {
            if (loadStructure == "")
                loadStructure = Resources.Load<TextAsset>("GameStructures").text;
            return loadStructure;
        }
    }
    public static Color[] GetColors()
    {
        string[] load = gameManager.LoadStructure.Trim().Split('\n');
        int count = load.Length;
        Color[] colors = new Color[count - 1];
        for (int i = 1; i < count; i++)
        {
            string[] c = load[i].Trim().Split(' ');
            colors[i - 1] = new Color
                (
                System.Int32.Parse(c[0]) / 255f,
                System.Int32.Parse(c[1]) / 255f,
                System.Int32.Parse(c[2]) / 255f
                );
        }
        return colors;
    }
    public static int GetTimerGame()
    {
        return System.Int16.Parse(gameManager.LoadStructure.Trim().Split('\n')[0]);
    }

    public GameObject DeadPanel;

    private float
        TimeGame,
        NowTimeGame;
    public System.Action<float, int> UpdateTimeGameAction;

    public System.Action<int> UpdatePoint;
    private static int points;
    public static int Point
    {
        get
        {
            return points;
        }
        set
        {
            if (gameManager.UpdatePoint != null)
                gameManager.UpdatePoint(value);
            points = value;
        }
    }

    private void Awake()
    {
        points = 0;
        gameManager = this;
    }

    private void Start()
    {
        StartEvent.Invoke();
        TimeGame = GetTimerGame();
        NowTimeGame = TimeGame;
    }
    private void Update()
    {
        NowTimeGame -= Time.deltaTime;
        if (UpdateTimeGameAction != null)
            UpdateTimeGameAction(NowTimeGame / TimeGame, (int)NowTimeGame);
        if (NowTimeGame <= 0)
        {
            EndGame.Invoke();
            enabled = false;
        }
    }

    public void EndGamed()
    {
        Liderboard.SetLiderBoar(points);
        DeadPanel.SetActive(true);
    }
}
