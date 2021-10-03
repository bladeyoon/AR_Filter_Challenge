using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour 
{
    public GameObject _nose;
    public GameObject _eye;
    public GameObject _mouth;
    public GameObject _ear;
    //public GameObject _face;


	// Use this for initialization
	void Start ( ) 
    {
        _nose = GameObject.Find("Panda_Nose");
        _eye = GameObject.Find("Panda_Eyes");
        _mouth = GameObject.Find("Panda_Mouth");
        _ear = GameObject.Find("Panda_Ears");
        //_face = GameObject.Find("Panda_Face");

        _nose.SetActive(false);
        //_face.SetActive(false);
        //_ear.SetActive(false);
        _mouth.SetActive(false);
        _eye.SetActive(false);

    }

    enum Around 
    {
        face,
        nose,
        eye,
        ear,
        mouth
    }

    public string CmdHowToSayNose = "nose";
    public string CmdHowToSayEye = "eye";
    public string CmdHowToSayMouth = "mouth";
    public string CmdHowToSayEar = "ear";
    public string CmdHowToSayFace = "face";

    private Around TurnOn = Around.face;

    //private float _speed = 0.5f;
	
	// Update is called once per frame
	void Update ( ) 
    {
        switch ( TurnOn ) 
        {
            case Around.ear:
                _ear.transform.Rotate(Vector3.up, 5);
                Debug.Log("Ears on!");
                break;
            case Around.face:
                //_face.SetActive(true);
                Debug.Log("Face on!");
                break;
            case Around.eye:
                _eye.SetActive(true);
                Debug.Log("Eyes on!");
                break;
            case Around.nose:
                _nose.SetActive(true);
                Debug.Log("Nose on!");
                break;
            case Around.mouth:
                _mouth.SetActive(true);
                Debug.Log("Mouth on!");
                break;
        }
	}

    public void onReceiveRecognitionResult( string result )
    {
        if ( result.Contains(CmdHowToSayNose) )
            TurnOn = Around.nose;
        if ( result.Contains(CmdHowToSayEye) )
            TurnOn = Around.eye;
        if ( result.Contains(CmdHowToSayMouth) )
            TurnOn = Around.mouth;
        if ( result.Contains(CmdHowToSayEar) )
            TurnOn = Around.ear;
        if ( result.Contains(CmdHowToSayFace) )
            TurnOn = Around.face;
    }

}
