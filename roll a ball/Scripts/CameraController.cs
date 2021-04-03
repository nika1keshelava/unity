using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.localPosition - player.transform.localPosition;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.localPosition = player.transform.localPosition + offset;
    }
}
