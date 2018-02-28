using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class box_gui : MonoBehaviour {
    Vector3 screenPosition;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main != null)
        {
            screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            screenPosition.y = Screen.height - screenPosition.y;
        
        }

    }
    void OnGUI()
    {
        if (this.GetComponent<Renderer>().isVisible)
        {
            GUI.Label(new Rect(screenPosition.x - 36, screenPosition.y - 35, Screen.width / 8, 7),"Look Here!!");
            GUI.Box(new Rect(screenPosition.x - 36, screenPosition.y - 35, 80, 20), "Look Here!!");
        }
        
    }
    }
