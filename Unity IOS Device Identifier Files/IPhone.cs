using UnityEngine;
using System;
public enum Generation
{
    Unknown,
    iPhone,
    iPhone3G,
    iPhone3GS,
    iPhone4,
    iPhone4S,
    iPhone5,
    iPhone5C,
    iPhone5S,
    iPhone6,
    iPhone6Plus,
    iPhone6s,
    iPhone6sPlus,
    iPhoneSE,
    iPhone7,
    iPhone7Plus,
    iPhone8,
    iPhone8Plus,
    iPhoneX,
    iPhoneXR,
    iPhoneXS,
    iPhoneXSMax,
    iPhone11,
    iPhone11Pro,
    iPhone11ProMax
}

[System.Serializable]
public class IPhoneInfo
{
    public string model;
    public string generation;
}

[System.Serializable]
public class IPhones
{
    public IPhoneInfo[] iphoneInfos;
}

public static class IPhone
{
    private static Generation _Gen { get; set; } = Generation.Unknown;

    public static Generation Generation
    {
        get
        {
            if (_Gen == Generation.Unknown)
            {
                SetGen();
            }
            return _Gen;
        }
    }
    private static void SetGen()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Apple iPhones JSON");
        IPhones devices = JsonUtility.FromJson<IPhones>(jsonFile.text);
        for (int x = 0; x < devices.iphoneInfos.Length; x++)
        {
            if (devices.iphoneInfos[x].model == SystemInfo.deviceModel)
            {
                if (Enum.TryParse(devices.iphoneInfos[x].generation, out Generation result))
                {
                    _Gen = result;
                    return;
                }
                else
                {
                    Debug.Log("Unable Parse Enum to Set Generation");
                }
            }
        }
        Debug.Log(string.Format("Device Model \"{0}\" not Recognised", SystemInfo.deviceModel));
    }
}
