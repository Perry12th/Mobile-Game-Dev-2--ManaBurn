using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUIScript : MonoBehaviour
{
    public TextMeshProUGUI roundsLastedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roundsLastedText.text = SaveManager.instance.GetWaveNum().ToString();
    }
}
