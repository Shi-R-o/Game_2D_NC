using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public void PlayGame(){
		Application.LoadLevel("Main1");
    }
    public void quit()
    {
        Application.Quit();
    }
}
