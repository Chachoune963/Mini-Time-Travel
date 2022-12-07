using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewindable : MonoBehaviour
{
    // Storage of different transform states through time
    private List<Vector2> _positions;

    // true if time was rewund and events are playing again, false if recording data
    private bool playing;
    private int curFrame;
    
    // Start is called before the first frame update
    void Awake()
    {
        curFrame = 0;
        TimeHandlerScript.OnTimeTravel += Rewind;
        _positions = new List<Vector2>();
        _positions.Add(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            transform.position = _positions[curFrame];
            ++curFrame;
            if (curFrame >= _positions.Count) playing = false;
        }
        else
        {
            _positions.Add(transform.position);
        }
    }

    void Rewind(int frames)
    {
        playing = true;
        curFrame = _positions.Count - frames;
        Debug.Log("Frames en arrière:" + frames + "Frame actuelle:" + _positions.Count + " Frame tentée:" + curFrame);
    }

    public void SetPositionsList(List<Vector2> newList)
    {
        _positions = newList;
    }
}
