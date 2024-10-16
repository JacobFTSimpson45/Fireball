using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnRelease : MonoBehaviour
{

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Destroy(gameObject);
        }
    }
}
