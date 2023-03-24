using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountCoin : MonoBehaviour {
    public int Levelload = 1;
    public static CountCoin instance;
    public float Total_coin = 0;
    public float highscore = 0;
    public float MS ;
    [SerializeField]
    private Text txt_coin;
    [SerializeField]
    private Text txt_coin_panel;
    [SerializeField]
    private Text txt_highcoin;
    [SerializeField]
    private Text txt_MS;
    [SerializeField]
    private Text txt_MS_panel;
    // Use this for initialization
    void Awake()
    {
        MakeIntance(); 
    }
    void Start () {
        txt_highcoin.text = ("" + PlayerPrefs.GetFloat("highscore"));
        highscore = PlayerPrefs.GetFloat("highscore", 0);
        if (PlayerPrefs.HasKey("point"))
        {
            Scene ActiveScreen = SceneManager.GetActiveScene();
            if (Application.loadedLevel == 0)
            {
                PlayerPrefs.DeleteKey("point");
                Total_coin = 0;
            }
            else
                Total_coin = PlayerPrefs.GetFloat("point");
        }
		if (PlayerPrefs.HasKey ("highscore")) {
			highscore = PlayerPrefs.GetFloat("highscore");
		}
    }
	
	// Update is called once per frame
	void Update () {
        Count_Coin();
        MS += Time.deltaTime;
        if (Mathf.RoundToInt(MS) >=5000)
        {
            savescore();
            SceneManager.LoadScene(Levelload);
        }
        txt_MS.text = Mathf.RoundToInt(MS).ToString()+" m";
        txt_MS_panel.text = Mathf.RoundToInt(MS).ToString() + " m";
    }
    void MakeIntance()
    {
        if (instance ==null)
        {
            instance = this;
        }
    }
    void Count_Coin()
    {
        txt_coin.text = "" + Total_coin;
        txt_coin_panel.text = "" + Total_coin;
    }
    void savescore()
    {

        if (Application.loadedLevel == 0)
        {
            PlayerPrefs.DeleteKey("point");
            Total_coin = 0;
        }
        else
        {
            PlayerPrefs.SetFloat("point", Total_coin);
            //Total_coin = PlayerPrefs.GetFloat("point");//
        }
    }
}
