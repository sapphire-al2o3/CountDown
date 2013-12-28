using UnityEngine;
using System;
using System.Collections;

public class CountDown : MonoBehaviour
{
	public TextMesh days;
	public TextMesh hours;
	public TextMesh mins;
	public TextMesh secs;

	DateTime _newYear;
	int _sec;
	bool _mute = false;

	void Start()
	{
		DateTime now = DateTime.Now;
		_newYear = new DateTime(2014, 1, 1);
		var delta = _newYear - now;
		days.text = delta.Days.ToString();
		hours.text = delta.Hours.ToString("D2");
		mins.text = delta.Minutes.ToString("D2");
		secs.text = delta.Seconds.ToString("D2");
		_sec = now.Second;
	}

	void Mute(bool e)
	{
		_mute = e;
	}

	void Tweet()
	{
		DateTime now = DateTime.Now;
		var delta = _newYear - now;
		string text = String.Format("今年もあと{0}日と{1}時間{2}分{3}秒です。",
		                            delta.Days,
		                            delta.Hours,
		                            delta.Minutes,
		                            delta.Seconds);
		Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(text));
	}
	
	void Update()
	{
		DateTime now = DateTime.Now;
		if (now.Second != _sec)
		{
			var delta = _newYear - now;
			days.text = delta.Days.ToString();
			hours.text = delta.Hours.ToString("D2");
			mins.text = delta.Minutes.ToString("D2");
			secs.text = delta.Seconds.ToString("D2");
			_sec = now.Second;
			if (!_mute)
			{
				audio.Play();
			}
		}
	}
}
