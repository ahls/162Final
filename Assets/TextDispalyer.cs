using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextDispalyer : MonoBehaviour
{
    string displayText = "";
    char[] storedText;
    Text txt;
    public int displayDelay;
    int displayTimer = 0;
    int displayIndex = 0;
    int maxIndex;
    public bool displayOnStart;
    public TextDispalyer next;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        storedText = txt.text.ToCharArray();
        maxIndex = storedText.Length;
        txt.text = displayText;

        this.enabled = displayOnStart;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (displayTimer > 0)
        {
            displayTimer--;
        }
        else if(displayTimer <= 0)
        {
            Debug.Log(displayIndex);
            displayText += storedText[displayIndex];
            displayIndex++;
            displayTimer = displayDelay;
            txt.text = displayText;
            if(displayIndex  == maxIndex)
            {
                if (next != null)
                    next.enabled = true;
                this.enabled = false;
            }
        }
    }
}
