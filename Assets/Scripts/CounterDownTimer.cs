using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CounterDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 60f;
    [SerializeField] Text countDownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = "Time Left: " +currentTime.ToString("0");
        countDownText.color = Color.green;

        if(currentTime <= 3)
        {
            countDownText.color = Color.red;
        }

        if(currentTime <= 0)
        {
            currentTime = 0;
            Debug.Log("Lose Scene Loading");
            SceneManager.LoadScene("Lose");
        }
    }
}
