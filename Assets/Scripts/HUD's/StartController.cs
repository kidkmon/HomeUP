using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour {

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			LoadGameScene();
		}
	}

	public void LoadGameScene(){
		SceneManager.LoadScene("Game");
	}

}
