using System.Collections;
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
            case Around.ear:
                ShowEarAnswer();
                break;
            case Around.face:
                Debug.Log("Do nothing");
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
        ShowNoseQuestion();
    }

    IEnumerator ShowMouthInChinese()
    {
        _humanMouthTop.SetActive(false);
        _humanMouthBottom.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _mouthChinese.SetActive(true);
        //add pronounciation audio
        yield return new WaitForSeconds(3f);
        //_mouthChinese.SetActive(false);
        Destroy(_mouthChinese);
        _pandaMouth.SetActive(true);
    }


    public void ShowNoseQuestion()
    {
        _questionText.text = "WHAT IS NOSE IN CHINESE?";
        _humanNose.SetActive(true);
    }

    public void ShowNoseAnswer()
    {
        StartCoroutine(ShowNoseInChinese());
        ShowEyesQuestion();
    }

    IEnumerator ShowNoseInChinese()
    {
        _humanNose.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _noseChinese.SetActive(true);
        //add pronounciation audio
        yield return new WaitForSeconds(3f);
        //_noseChinese.SetActive(false);
        Destroy(_noseChinese);
        _pandaNose.SetActive(true);
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
        ShowEarsQuestion();
    }

    IEnumerator ShowEyesInChinese()
    {
        _humanEyeLeft.SetActive(false);
        _humanEyeRight.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _eyeChinese.SetActive(true);
        //add pronounciation audio
        yield return new WaitForSeconds(3f);
        //_eyeChinese.SetActive(false);
        Destroy(_eyeChinese);
        _pandaEye.SetActive(true);
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
        ShowFaceQuestion();
    }

    IEnumerator ShowEarsInChinese()
    {
        _humanEarRight.SetActive(false);
        _humanEarLeft.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _earChinese.SetActive(true);
        //add pronounciation audio
        yield return new WaitForSeconds(3f);
        //_earChinese.SetActive(false);
        Destroy(_earChinese);
        _pandaEar.SetActive(true);
    }


    public void ShowFaceQuestion()
    {
        _questionText.text = "WHAT IS FACE IN CHINESE?";
        // hightlight human face
    }

    public void ShowFaceAnswer()
    {
        StartCoroutine(ShowFaceInChinese());
    }

    IEnumerator ShowFaceInChinese()
    {
        //turn off human face
        yield return new WaitForSeconds(0.5f);
        //turn on Face in Chinese
        //add pronounciation audio
        yield return new WaitForSeconds(3f);
        //turn off Face in Chinese
    }
}


