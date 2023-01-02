using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SadakoVoiceControl : MonoBehaviour
{
    
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("stop it", Stop);
        actions.Add("freeze",Stop);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

        rb = GetComponent<Rigidbody>();

    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Stop()
    {
        transform.Translate(0, 0, 0.6f);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, -0.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
