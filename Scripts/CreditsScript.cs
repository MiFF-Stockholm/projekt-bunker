using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class CreditsScript : MonoBehaviour {

	public GUIText creditTextItem;
	private TextReader tr;
	public string path;
	private List<GUIText> CreditsGuiTextList = new List<GUIText>();
	private List<string> creditsStringList = new List<string>();
	public List<GUITexture> creditIcons = new List<GUITexture>();

	public float creditsCooldown = 2.0f;
	public float creditSpeed = 1f;
	private float timer = 0f;
	private Vector3 startPos;
	private int iconCounter = 0;
	
	void Start() {
		// Set the path for the credits.txt file
		// Create reader & open file
		tr = new StreamReader("Assets/Resources/Credits.txt", System.Text.Encoding.UTF8);
		
		string temp;
		while((temp = tr.ReadLine()) != null) {
			// Read a line of text
			creditsStringList.Add(temp);
		}
		
		// Close the stream
		tr.Close();

		startPos = GameObject.Find("CreditStart").transform.position;
		//CreateCredits();
	}
	
	void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
			Application.Quit();
        }

		if (timer <= 0) {
			timer = creditsCooldown * Time.deltaTime;
			if (creditsStringList.Count != 0) {
				CreateNewCredit();
			} else {
				if (creditIcons.Count > iconCounter) {
					MoveIcon();
				}
			}
		}

		timer -= 1 * Time.deltaTime;

		float credSpeed = creditSpeed * Time.deltaTime;

		GameObject[] creds = GameObject.FindGameObjectsWithTag("Credit");
		foreach (GameObject cred in creds){
			if (cred.transform.position.y > 1.25f) {
				Destroy(cred);
			} else {
				cred.transform.Translate(new Vector3(0f, credSpeed, 0f));
			}
		}
	}

	void CreateNewCredit(){
		string creditString = creditsStringList[0];
		Instantiate(creditTextItem);
		creditTextItem.transform.position = startPos;
		creditTextItem.text = creditString;
		CreditsGuiTextList.Add(creditTextItem);

		creditsStringList.RemoveAt(0);
	}

	void MoveIcon(){
		if (creditIcons[iconCounter]) {
			creditIcons[iconCounter++].transform.position = startPos;
		}
	}
}