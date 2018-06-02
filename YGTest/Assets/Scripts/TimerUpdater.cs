using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimerUpdater : MonoBehaviour {
    public float
        MinTimer,
        MaxTimer;
    private float
        Timer,
        NowTimer;
    public Image FillTimer;
    public UnityEvent UpdateTimer;

    private void Start()
    {
        Timer = Random.Range(MinTimer, MaxTimer);
    }
    private void Update()
    {
        NowTimer += Time.deltaTime;
        FillTimer.fillAmount = NowTimer / Timer;
        if(NowTimer >= Timer)
        {
            NowTimer = 0;
            Timer = Random.Range(MinTimer, MaxTimer);
            AudioManager.PlayUpdateColorCircle();
            UpdateTimer.Invoke();
        }
    }
}
