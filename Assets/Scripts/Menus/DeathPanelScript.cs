using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathPanelScript : MonoBehaviour
{
    public TextMeshProUGUI deathPanelUiText;
    public UiManager uiManager;

    public void Update()
    {
        deathPanelUiText.text = "You died!             " + "Seconds Survived : " + uiManager.timerUIText.text + "        " + uiManager.scoreUIText.text;
    }
}
