using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickHost(){
		SceneManager.LoadScene ("hostMode");
	}
	public void OnClickTeam(){
		SceneManager.LoadScene ("teamMode");
	}
	public void OnClickMulti(){
		SceneManager.LoadScene ("multiMode");
	}

    private void OnApplicationQuit()
    {
        YouMe.YouMeVoiceAPI.GetInstance().UnInit();
    }
}
