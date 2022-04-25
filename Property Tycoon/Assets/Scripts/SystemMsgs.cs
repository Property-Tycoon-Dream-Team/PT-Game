using UnityEngine;
using UnityEngine.UI;

public class SystemMsgs : MonoBehaviour
{
    public float wait = 3;
    public Text msg;
    float timer;
    bool msgTriggerd = false;

    void Update()
    {
        if (msgTriggerd)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                msgTriggerd = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void NewMessage(string newMsg)
    {
        msg.text = newMsg;
        msgTriggerd = true;
        timer = wait;
        gameObject.SetActive(true);
    }
}
