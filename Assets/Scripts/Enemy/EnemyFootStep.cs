using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFootStep : MonoBehaviour
{
    public AudioClip footStepSoundClip;

    private void Step()
    {
        SFXManager.instance.PlaySFXClip(footStepSoundClip, transform, .5f);
    }
}
