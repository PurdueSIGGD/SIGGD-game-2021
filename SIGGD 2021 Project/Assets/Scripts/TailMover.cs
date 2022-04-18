using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMover : MonoBehaviour
{
    [SerializeField] private Transform[] tails;
    [SerializeField] private float dist; //distance tail parts are expected to be at rest
    [SerializeField] private float spring; //amount of "force" the spring of the tail is
    [SerializeField] private float flex; //ratio the tail adjusts to be behind the player

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tails.Length - 1; i++)
        {
            moveTailParts(tails[i], tails[i + 1]);
        }
    }

    private void moveTailParts(Transform prev, Transform current)
    {
        Vector3 dragPos = prev.position + (current.position - prev.position).normalized * dist;
        Vector3 followPos = prev.position - prev.parent.up * dist;
        Vector3 targetPos = Vector3.Lerp(dragPos, followPos, flex);
        current.position = Vector3.Lerp(current.position, targetPos, Time.deltaTime * spring);
        float rotAngle = Vector3.SignedAngle(prev.parent.right, prev.position - current.position, Vector3.forward);
        current.localRotation = Quaternion.Euler(new Vector3(0, 0, rotAngle - 90));
        current.localScale = Vector3.Lerp(current.localScale, new Vector3(1, 2 * Vector3.Distance(prev.position, current.position)/dist, 1), Time.deltaTime * spring);
    }
}
