using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayGameButton : MonoBehaviour
{
    [SerializeField]
    Button PlayButton;
    // Start is called before the first frame update
    void Start()
    {
        if (!SaveManager.instance.SaveExists())
        {
            PlayButton.interactable = false;
        }
    }

}
