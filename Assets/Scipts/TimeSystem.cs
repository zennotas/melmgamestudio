using UnityEngine;
using System.Collections;

public class TimeSystem {
	public static int Hours { get; set; }
	public static int Minutes { get; set; }
	public static int DayMode = 2;
	public static GameObject GlobalLight;

	public enum Time : int {
		Day = 0,
		Evening = 1,
		Night = 2
	}

	public static string ToStringTime ()
	{
		string hours = Hours < 10 ? string.Format("0{0}", Hours) : string.Format("{0}",Hours);
		string minutes = Minutes < 10 ? string.Format("0{0}", Minutes) : string.Format("{0}",Minutes);
		return string.Format("{0}:{1}", hours, minutes);
	}

	public static void AddMinute(int minutes) {
		Minutes += minutes;
		if (Minutes > 59) {
			Hours += Minutes / 60;
			Minutes %= 60; 
		}
		if (Hours >= 24) Hours %= 24;  
		CheckDayMode ();
	}

	static void CheckDayMode() {
		Vector3 rot = GlobalLight.transform.eulerAngles;
		float angle = 0;
		switch (DayMode) {
			case (int)Time.Day:
				if (Hours == 17 && Minutes >= 0) {
					DayMode = (int)Time.Evening;
					Player.gun.ToggleFlashLight(true);
				}
			break;
			case (int)Time.Evening:
				if (Hours == 22 && Minutes >= 0) {
					DayMode = (int)Time.Night;
					Player.gun.ToggleFlashLight(true);
				}
			break;
			case (int)Time.Night:
				if (Hours == 8 && Minutes >= 0) {
					DayMode = (int)Time.Day;
					Player.gun.ToggleFlashLight(false);
				}
			break;
		}
	}

}
