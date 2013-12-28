using UnityEngine;
using System.Collections;

public class Speaker : MonoBehaviour
{
	public GameObject sound;
	public GameObject countdown;
	bool _mute = false;

	void OnMouseDown()
	{
		_mute = !_mute;
		sound.renderer.enabled = !_mute;
		countdown.SendMessage("Mute", _mute);
	}
}
