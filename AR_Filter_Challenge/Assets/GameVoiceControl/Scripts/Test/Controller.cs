﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Controller : MonoBehaviour 
{
    [Header("PandaFaceElements")]
    public GameObject _pandaNose;
    public GameObject _pandaEye;
    public GameObject _pandaMouth;
    public GameObject _pandaEar;
    //public GameObject _pandaFace;
    public GameObject _pandaHalogram;

    [Header("HumanFaceElements")]
    public GameObject _humanNose;
    public GameObject _humanEyeLeft;
    public GameObject _humanEyeRight;
    public GameObject _humanMouthTop;
    public GameObject _humanMouthBottom;
    public GameObject _humanEarLeft;
    public GameObject _humanEarRight;

    [Header("ChineseCharacters")]
    public GameObject _noseChinese;
    public GameObject _earChinese;
    public GameObject _mouthChinese;
    public GameObject _eyeChinese;


    [Header("UI")]
    public TextMeshProUGUI _questionText;


    [Header("Command")]
    public string CmdHowToSayNose = "what is nose in chinese";
    public string CmdHowToSayEye = "what is eye in chinese";
    public string CmdHowToSayMouth = "what is mouth in chinese";
    public string CmdHowToSayEar = "what is ear in chinese";
    public string CmdHowToSayFace = "what is face in chinese";

    void Start ( ) 
    {
        _pandaHalogram.SetActive(true);
        _pandaNose.SetActive(false);
        _pandaEar.SetActive(false);
        _pandaMouth.SetActive(false);
        _pandaEye.SetActive(false);
        //_pandaFace.SetActive(false);

        ShowMouthQuestion();
    }

    enum Around 
    {
        face,
        nose,
        eye,
        ear,
        mouth
    }

    private Around TurnOn = Around.face;

	void Update ( ) 
    {
        switch ( TurnOn ) 
        {
            case Around.face:
                Debug.Log("Null.");
                //ShowFaceAnswer();
                break;
            case Around.ear:
                ShowEarAnswer();
                break;
            case Around.eye:
                ShowEyesAnswer();
                break;
            case Around.nose:
                ShowNoseAnswer();
                break;
            case Around.mouth:
                ShowMouthAnswer();
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

    public void ShowMouthQuestion()
    {
        _questionText.text = "WHAT IS MOUTH IN CHINESE?";
        _humanMouthTop.SetActive(true);
        _humanMouthBottom.SetActive(true);
    }

    public void ShowMouthAnswer()
    {
        StartCoroutine(ShowMouthInChinese());
    }

    IEnumerator ShowMouthInChinese()
    {
        Destroy(_humanMouthTop);
        Destroy(_humanMouthBottom);
        yield return new WaitForSeconds(0.5f);
        _mouthChinese.SetActive(true);
        //add pronounciation audio
        yield return new WaitForSeconds(3f);
        Destroy(_mouthChinese);
        _pandaMouth.SetActive(true);
        yield return new WaitForSeconds(2f);
        ShowNoseQuestion();
    }

    public void ShowNoseQuestion()
    {
        _questionText.text = "WHAT IS NOSE IN CHINESE?";
        _humanNose.SetActive(true);
    }

    public void ShowNoseAnswer()
    {
        StartCoroutine(ShowNoseInChinese());
    }

    IEnumerator ShowNoseInChinese()
    {
        Destroy(_humanNose);
        yield return new WaitForSeconds(0.5f);
        _noseChinese.SetActive(true);
        //add pronounciation audio
        yield return new WaitForSeconds(3f);
        Destroy(_noseChinese);
        _pandaNose.SetActive(true);
        yield return new WaitForSeconds(2f);
        ShowEyesQuestion();
    }

    public void ShowEyesQuestion()
    {
        _questionText.text = "WHAT IS EYE IN CHINESE?";
        _humanEyeRight.SetActive(true);
        _humanEyeLeft.SetActive(true);
    }

    public void ShowEyesAnswer()
    {
        StartCoroutine(ShowEyesInChinese());
    }

    IEnumerator ShowEyesInChinese()
    {
        Destroy(_humanEarLeft);
        Destroy(_humanEarRight);
        yield return new WaitForSeconds(0.5f);
        _eyeChinese.SetActive(true);
        //add pronounciation audio
        yield return new WaitForSeconds(3f);
        Destroy(_eyeChinese);
        _pandaEye.SetActive(true);
        yield return new WaitForSeconds(2f);
        ShowEarsQuestion();
    }

    public void ShowEarsQuestion()
    {
        _questionText.text = "WHAT IS EAR IN CHINESE?";
        _humanEarRight.SetActive(true);
        _humanEarLeft.SetActive(true);
    }

    public void ShowEarAnswer()
    {
        StartCoroutine(ShowEarsInChinese());
    }

    IEnumerator ShowEarsInChinese()
    {
        Destroy(_humanEarLeft);
        Destroy(_humanEarRight);
        yield return new WaitForSeconds(0.5f);
        _earChinese.SetActive(true);
        //add pronounciation audio
        yield return new WaitForSeconds(3f);
        Destroy(_earChinese);
        _pandaEar.SetActive(true);
        yield return new WaitForSeconds(2f);
        ShowFullFace();
    }

    public void ShowFullFace()
    {
        StartCoroutine(ShowFullFaceSequence());
    }

    IEnumerator ShowFullFaceSequence()
    {
        yield return new WaitForSeconds(1f);
    }
}


