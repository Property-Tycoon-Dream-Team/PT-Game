using UnityEngine;
using UnityEngine.UI;

public class SystemMsgs : MonoBehaviour
{
    public float wait = 3f;
    float bigTimer;
    float timer = 3f;
    public Text msg;
    bool msgTriggerd = false;

    void Update()
    {
        if (msgTriggerd)
        {
            bigTimer -= Time.deltaTime;
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                msg.text = msg.text.Substring(msg.text.IndexOf('\n') + 1);
                timer = 3f;
            }
            if (bigTimer <= 0f)
            {
                msg.text = "";
            }

            if (timer <= 0f && bigTimer <= 0f)
            {
                msgTriggerd = false;
            }
        }
    }

    public void NewMessage(string newMsg)
    {
        msg.text += newMsg + "\n";
        msgTriggerd = true;
        bigTimer = wait;
    }
}
