using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float velocityMultiplier = 80;

    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    private Vector3 oldTargetPosition;
    private Vector3 newTargetPosition;
    private Vector3 targetMoved;
    private float screenRatio;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (target)
        {
            newTargetPosition = target.transform.position;
            targetMoved = newTargetPosition - oldTargetPosition;
            oldTargetPosition = target.transform.position;

            targetMoved = new Vector3(targetMoved.x, targetMoved.y / screenRatio, targetMoved.z);
        }
    }

    private void Awake()
    {
        screenRatio = (float)Screen.width / (float)Screen.height;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(target != null)
        {

            Vector3 targetPosition = target.position + offset + targetMoved * velocityMultiplier;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
