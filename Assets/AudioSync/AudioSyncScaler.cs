using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncScaler : AudioSyncer
{
    public Vector2 beatScale;
    public Vector2 restScale;

    IEnumerator Scale(Vector2 target)
    {
        Vector2 current = transform.localScale;
        Vector2 initial = current;
        float timer = 0;

        while (current != target)
        {
            current = Vector2.Lerp(initial, target, timer / timeToBeat);
            timer += Time.deltaTime;

            transform.localScale = current;
            
            yield return null;
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();            

        if (IsOnBeat) return;

        if (GetComponent<SpriteRenderer>().color == Color.yellow)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }        
        transform.localScale = Vector2.Lerp(transform.localScale, restScale, restSmoothTime * Time.deltaTime);
    }

    public override void OnBeat()
    {
        base.OnBeat();

        GetComponent<SpriteRenderer>().color = Color.yellow;
        StopCoroutine("Scale");
        StartCoroutine("Scale", beatScale);
    }
}

