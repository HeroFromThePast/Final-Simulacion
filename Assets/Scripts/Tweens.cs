using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [Range(0, 1)][SerializeField] float normalizedTime;
    [SerializeField] float duration = 1;

    float currentTime = 0f;
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    [SerializeField] AnimationCurve curve;
    void Start()
    {
        transform.position = pos1.position;
    }

    void Update()
    {
        
        currentTime += Time.deltaTime;

        if(Vector3.Distance(transform.position, pos2.position) == 0)
        {
            StartTween(pos2.position, pos1.position);
        }
        else if(Vector3.Distance(transform.position, pos1.position) == 0)
        {
            StartTween(pos1.position, pos2.position);
        }


    }

    void StartTween(Vector3 actualPos, Vector3 finalPos)
    {
        currentTime = 0f;
        normalizedTime = currentTime / duration;
        transform.position = Vector3.Lerp(actualPos, finalPos, curve.Evaluate(normalizedTime));
       
    }
}
