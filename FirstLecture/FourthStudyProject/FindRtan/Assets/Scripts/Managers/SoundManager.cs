using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get { return instance; }
    }

    public AudioSource sfxSource;       //sfx전용 오디오 변수
    public AudioSource bgmSource;       //bgm전용 오디오 변수

    private Dictionary<SfxType, AudioClip> sfxClipDic = new Dictionary<SfxType, AudioClip>();       //sfx클립 저장해놓는 Dic
    private Dictionary<BgmType, AudioClip> bgmClipDic = new Dictionary<BgmType, AudioClip>();       //bgm클립 저장해놓는 Dic

    /// <summary>
    /// SFX 재생 함수
    /// </summary>
    public void PlaySFX(SfxType type)
    {
        sfxSource.PlayOneShot(sfxClipDic[type]);
    }

    /// <summary>
    /// BGM 재생 함수
    /// </summary>
    public void PlayBGM(BgmType type)
    {
        if (bgmSource.clip == bgmClipDic[type])
            return;

        bgmSource.clip = bgmClipDic[type];
        bgmSource.Play();
    }

    /// <summary>
    /// SoundManager 생성 함수
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        GameObject go = new GameObject("SoundManager");
        instance = go.AddComponent<SoundManager>();

        DontDestroyOnLoad(go);

        GameObject sfxGo = new GameObject("SFX");
        GameObject bgmGo = new GameObject("BGM");

        sfxGo.transform.SetParent(go.transform);
        bgmGo.transform.SetParent(go.transform);

        instance.sfxSource = sfxGo.AddComponent<AudioSource>();
        instance.bgmSource = bgmGo.AddComponent<AudioSource>();

        instance.bgmSource.playOnAwake = false;
        instance.bgmSource.loop = true;
        instance.sfxSource.playOnAwake = false;

        var sfxClipArr = Resources.LoadAll<AudioClip>("Sounds/SFX");
        instance.ClipLoader(ref instance.sfxClipDic, sfxClipArr);

        var bgmClipArr = Resources.LoadAll<AudioClip>("Sounds/BGM");
        instance.ClipLoader(ref instance.bgmClipDic, bgmClipArr);
    }

    /// <summary>
    /// 클립 읽어주는 함수
    /// </summary>
    public void ClipLoader<T>(ref Dictionary<T, AudioClip> dic, AudioClip[] arr) where T : Enum
    {
        for (int i = 0; i < arr.Length; i++)
        {
            try
            {
                T type = (T)Enum.Parse(typeof(T), arr[i].name);
                dic.Add(type, arr[i]);
            }
            catch
            {
                Debug.LogWarning("Need Enum : " + arr[i].name);
            }
        }
    }
}
