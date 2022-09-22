using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;

    private int m, s;

    [SerializeField] private TextMeshProUGUI timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startTimer()
    {
        timer.enabled = true;
        m = minutes;
        s = seconds;
        writeTimer(m, s);
        Invoke("updateTimer", 1f);
    }

    public void stopTimer()
    {
        timer.enabled = false;
        CancelInvoke();
    }

    private void updateTimer()
    {
        s--;

        if (s < 0)
        {
            if (m == 0)
            {
                stopTimer();
            }
            else
            {
                m--;
                s = 59;
            }
        }

        writeTimer(m, s);
        Invoke("updateTimer", 1f);
    }

    private void writeTimer(int m, int s)
    {
        if (s < 10)
        {
            timer.text = m.ToString() + ":0" + s.ToString();
        }
        else
        {
            timer.text = m.ToString() + ":" + s.ToString();
        }
    }
}
