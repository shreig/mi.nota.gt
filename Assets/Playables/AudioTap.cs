using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSyncer))]
public class AudioTap : MonoBehaviour
{
    public GameObject messagePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        AudioSyncer audioSyncer = GetComponent<AudioSyncer>();
        Debug.Log("OnMouseDown");
        int score = 0;
        if (audioSyncer.IsOnBeat)
        {
            score = 10;
            GetComponent<SpriteRenderer>().color = Color.green;
        } else
        {
            score = -10;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        CommonObjects.gameController.AddScore(score);
        InitializeMessage(score.ToString());
    }

    private void InitializeMessage(string text)
    {
        GameObject message = Instantiate(messagePrefab, transform.position, Quaternion.identity);
        message.transform.SetParent(GameObject.Find("Canvas").transform, false);
        message.GetComponent<Text>().text = text;
    }
}
