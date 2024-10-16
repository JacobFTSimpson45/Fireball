using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed;
    public float dashTime;
    bool canDash;

    public AudioClip dashSoundClip;

    // Start is called before the first frame update
    void Start()
    {
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            SFXManager.instance.PlaySFXClip(dashSoundClip, transform, 1f);
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            canDash = false;         
            transform.Translate(Vector3.forward * dashSpeed * Time.deltaTime);
            yield return null;
            canDash = true;
        }
    }
}
