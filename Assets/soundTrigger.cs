using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTrigger : MonoBehaviour
{
    public bool TriggerToBe;
    public playerControl PC;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "door") return;
        audiomanager.AM.isOutside = TriggerToBe;
        audiomanager.AM.updateSnowStorm(false);
        PC.stepUpdate(TriggerToBe);
    }
    
}
