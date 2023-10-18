using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class Controller : Singleton<Controller> 
{
    [Header("PandaFaceElements")]
    public GameObject _pandaNose;
    public GameObject _pandaEye;
    public GameObject _pandaMouth;
    public GameObject _pandaEar;
    public GameObject _pandaComplete;
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
    public GameObject _askMeText;
    public GameObject _pandaIcon;
    public GameObject _quoteText;
    public GameObject _wellDoneText;

    [Header("VFX")]
    public GameObject _ConfettiRain;

    [Header("Command")]
    public string CmdHowToSayNose = "nose in chinese";
    public string CmdHowToSayEye = "eye in chinese";
    public string CmdHowToSayMouth = "mouth in chinese";
    public string CmdHowToSayEar = "ear in chinese";
    public string CmdHowToSayFace = "face in chinese";

    private bool _isAudioPlaying = true;

    void Start ( ) 
    {
        _pandaHalogram.SetActive(true);
        _pandaNose.SetActive(false);
        _pandaEar.SetActive(false);
        _pandaMouth.SetActive(false);
        _pandaEye.SetActive(false);
        _pandaComplete.SetActive(false);
        _questionText.text = "";
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
        _pandaIcon.SetActive(true);
        _askMeText.SetActive(true);
        _quoteText.SetActive(true);
        _questionText.text = "MOUTH IN CHINESE?";
        _humanMouthTop.SetActive(true);
        _humanMouthBottom.SetActive(true);
    }

    public void ShowMouthAnswer()
    {
        StartCoroutine(ShowMouthInChinese());
    }

    IEnumerator ShowMouthInChinese()
    {
        _askMeText.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        AudioMouth.Instance.playMouthAudio();
        _mouthChinese.SetActive(true);
        yield return new WaitForSeconds(5f);
        Destroy(_mouthChinese);
        Destroy(_humanMouthTop);
        Destroy(_humanMouthBottom);
        yield return new WaitForSeconds(0.5f);
        _pandaMouth.SetActive(true);
        ShowEyesQuestion();
    }

    public void ShowNoseQuestion()
    {
        _askMeText.SetActive(true);
        _questionText.text = "NOSE IN CHINESE?";
        _humanNose.SetActive(true);
    }

    public void ShowNoseAnswer()
    {
        StartCoroutine(ShowNoseInChinese());
    }

    IEnumerator ShowNoseInChinese()
    {
        _askMeText.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        AudioNose.Instance.playNoseAudio();
        _noseChinese.SetActive(true);
        yield return new WaitForSeconds(5f);
        Destroy(_noseChinese);
        Destroy(_humanNose);
        yield return new WaitForSeconds(0.5f);
        _pandaNose.SetActive(true);
        ShowEarsQuestion();
    }

    public void ShowEyesQuestion()
    {
        _askMeText.SetActive(true);
        _questionText.text = "EYE IN CHINESE?";
        _humanEyeLeft.SetActive(true);
        _humanEyeRight.SetActive(true);
    }

    public void ShowEyesAnswer()
    {
        StartCoroutine(ShowEyesInChinese());
    }

    IEnumerator ShowEyesInChinese()
    {
        _askMeText.SetActive(false);
        _isAudioPlaying = false;
        yield return new WaitForSeconds(0.5f);
        if (_isAudioPlaying == false)
        {
            AudioEyes.Instance.playEyesAudio();
        }
        _eyeChinese.SetActive(true);
        yield return new WaitForSeconds(5f);
        Destroy(_eyeChinese);
        Destroy(_humanEyeLeft);
        Destroy(_humanEyeRight);
        yield return new WaitForSeconds(0.5f);
        _pandaEye.SetActive(true);
        ShowNoseQuestion();
    }

    public void ShowEarsQuestion()
    {
        _askMeText.SetActive(true);
        _questionText.text = "EAR IN CHINESE?";
        _humanEarRight.SetActive(true);
        _humanEarLeft.SetActive(true);
    }

    public void ShowEarAnswer()
    {
        StartCoroutine(ShowEarsInChinese());
    }

    IEnumerator ShowEarsInChinese()
    {
        Destroy(_questionText);
        Destroy(_quoteText);
        _askMeText.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        AudioEar.Instance.playEarAudio();
        _earChinese.SetActive(true);
        yield return new WaitForSeconds(5f);
        Destroy(_earChinese);
        Destroy(_humanEarLeft);
        Destroy(_humanEarRight);
        yield return new WaitForSeconds(0.5f);
        _pandaEar.SetActive(true);
        ShowFullFace();
    }

    public void ShowFullFace()
    {
        StartCoroutine(ShowFullFaceSequence());
    }

    IEnumerator ShowFullFaceSequence()
    {
        yield return new WaitForSeconds(3f);
        _wellDoneText.SetActive(true);
        _pandaComplete.SetActive(true);
        AudioApplause.Instance.playApplauseAudio();
        _ConfettiRain.SetActive(true);

        _pandaHalogram.SetActive(false);
        _pandaEar.SetActive(false);
        _pandaEye.SetActive(false);
        _pandaMouth.SetActive(false);
        _pandaNose.SetActive(false);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


