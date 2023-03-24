using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BntPause : MonoBehaviour {
    public static BntPause insance;
    public Button bntPausses,bntcontinue,bntReplay,bntMeNu;
    public GameObject gmbntPause, gmbntContinue,panelDead;
	// Use this for initialization
	void Start () {
        _makeinsatance();
        bntPausses = GetComponent<Button> ();
        bntcontinue = GetComponent<Button>();

        gmbntContinue = GameObject.Find("Button_Contuner");
        gmbntPause = GameObject.Find("Button_Pause");
        panelDead = GameObject.Find("Panel");
        gmbntContinue.SetActive(false);
        panelDead.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void _makeinsatance()
    {
        if (insance == null)
        {
            insance = this;
        }
    }
    public void _Pause()
    {
        Time.timeScale = 0;
        gmbntPause.SetActive(false);
        gmbntContinue.SetActive(true);
    }
    public void _Continue()
    {
        Time.timeScale = 1;
        gmbntPause.SetActive(true);
        gmbntContinue.SetActive(false);
    }
    public void _Repplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void _GotoMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Menu");
    }
}
