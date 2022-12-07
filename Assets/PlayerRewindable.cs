using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRewindable : MonoBehaviour
{
    public GameObject timeClonePrefab;
    // Storage of different transform states through time
    private List<Vector2> _positions;
    private int timeTravelFrames;
    
    // Start is called before the first frame update
    void Awake()
    {
        _positions = new List<Vector2>();
        _positions.Add(transform.position);
    }

    // Update is called once per frame
    void Update()
    { 
        _positions.Add(transform.position);
        if (Input.GetButton("Fire2")) timeTravelFrames++;
        if (Input.GetButtonUp("Fire2")) TTravel(timeTravelFrames);
    }

    void TTravel(int frames)
    {
        GameObject clone = Instantiate(timeClonePrefab);
        clone.GetComponent<Rewindable>().SetPositionsList(new List<Vector2>(_positions));
        TimeHandlerScript.CallTimeTravelEvent(frames);
        timeTravelFrames = 0;
    }
}
