/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public static class ApplicationModel {
    public static DateTime startDate;   // contain date/time when application is launched
    public static float globalTime;   // contain date/time when application is launched


}
*//*
public static class ApplicationModel
{
    //public static float globalTime;
    //public static DateTime startDate;   // contain date/time when application is launched
    public static float globalTime;
    public static string startDate = DateTime.Now.ToString("s").Replace(":", "-");

}
*/
//Contains all the variables handling controller action and key variables such as the current platform

using System;

public static class ApplicationModel
{
    //public static float globalTime;
    public static string startDate = DateTime.Now.ToString("s").Replace(":", "-");

}
