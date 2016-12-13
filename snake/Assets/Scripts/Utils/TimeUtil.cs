using System;
using UnityEngine;
using System.Collections;

public class TimeUtil : MonoBehaviour
{
	public static string SecondsToHMS(float seconds)
	{
		TimeSpan time = TimeSpan.FromSeconds(seconds);

		//here backslash is must to tell that colon is
		//not the part of format, it just a character that we want in output
		// Здесь обратная косая черта является обязательным, чтобы сказать, что двоеточие
		// Не часть формата, это просто символ, который мы хотим, чтобы на выходе
		string str = string.Format("{0:D2}:{1:D2}:{2:D2}", time.Hours, time.Minutes, time.Seconds);

		return str;
	}
}
