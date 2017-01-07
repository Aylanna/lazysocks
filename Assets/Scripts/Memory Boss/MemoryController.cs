using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MemoryController : MonoBehaviour {

	public const int gridRows = 4;
	public const int gridCols = 4;
	public const float offsetX = 1f;
	public const float offsetY = 1.5f;

	public UIManagerM ui; 
	public MemoryCard originalCard;
	public Sprite[] images;
	public Slider bossHealthSlider;

	private MemoryCard firstRevealed;
	private MemoryCard secondRevealed;
	private int score = 8;

	private bool currentPlatformAndroid = false; 

	void Awake() {
		#if UNITY_ANDROID
			currentPlatformAndroid = true; 
		#endif
	}

	// Use this for initialization
	void Start () {
		if (currentPlatformAndroid) {
			Debug.Log ("Android"); 
		} else {
			Debug.Log ("Windows");
		}

		MakePlayingField ();
	}

	void MakePlayingField() {
		Vector3 startPos = originalCard.transform.position;
		int[] numbers = {0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7};
		numbers = ShuffleArray (numbers);

		for (int i = 0; i < gridCols; i++) {
			for (int j = 0; j < gridRows; j++) {
				MemoryCard card;
				if (i == 0 && j == 0) {
					card = originalCard;
				} else {
					card = Instantiate (originalCard) as MemoryCard;
				}

				int index = j * gridCols + i;
				int id = numbers[index];

				card.SetCard (id, images [id]);

				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3 (posX, posY, startPos.z);
			}
		}
	}

	void decreaseHealth () {
		score--; 
		bossHealthSlider.value = score; 
	}
 		
	public bool canReveal {
		get { return secondRevealed == null; }
	}

	public void CardRevealed(MemoryCard card) {
		if (firstRevealed == null) {
			firstRevealed = card;
		} else {
			secondRevealed = card;
			StartCoroutine (CheckMatch ());
		}
	}

	private IEnumerator CheckMatch() {
		if (firstRevealed.id == secondRevealed.id) {
			decreaseHealth (); 

		} else {
			yield return new WaitForSeconds (.5f);

			firstRevealed.Unreveal();
			secondRevealed.Unreveal ();
		}

		if (score <= 0) {
			WinGame (); 
		}

		firstRevealed = null;
		secondRevealed = null;
	}

	private int[] ShuffleArray(int[] numbers) {
		int[] newArray = numbers.Clone () as int[];
		for (int i = 0; i < newArray.Length; i++) {
			int tmp = newArray [i];
			int r = Random.Range (i, newArray.Length);
			newArray [i] = newArray [r];
			newArray [r] = tmp;
		}
		return newArray;
	}


	public void WinGame () {
		Debug.Log ("You won the game!"); 
		ui.GameOverBossDefeat (); 
	}

}
