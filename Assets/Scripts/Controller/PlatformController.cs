using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public enum PlatformType { None, CurrentPlatform, NextPlatform }
    public PlatformType platformType = PlatformType.None;

}
