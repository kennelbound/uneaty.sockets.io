using System.Text.RegularExpressions;
using UnityEngine;

public static class uNEATySocketIOUtils
{
    public static string JsonToString(string target, string s)
    {
        string[] newString = Regex.Split(target, s);
        return newString[1];
    }

    public static Vector3 JsonToVecter3(string target)
    {
        string[] newString = Regex.Split(target, ",");
        Vector3 newVector = new Vector3(float.Parse(newString[0]), float.Parse(newString[1]), float.Parse(newString[2]));
        return newVector;
    }
}