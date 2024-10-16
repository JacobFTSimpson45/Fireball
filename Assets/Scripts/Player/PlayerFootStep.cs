using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    public AudioClip footStepSoundClip;

    private void Step()
    {
        SFXManager.instance.PlaySFXClip(footStepSoundClip, transform, 1f);
    }
}
