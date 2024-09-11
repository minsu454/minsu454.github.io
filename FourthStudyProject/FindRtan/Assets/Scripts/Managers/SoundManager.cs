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

    public AudioSource sfxSource;
    public AudioSource bgmSource;

    private Dictionary<SfxType, AudioClip> sfxClipDic = new Dictionary<SfxType, AudioClip>();
    private Dictionary<BgmType, AudioClip> bgmClipDic = new Dictionary<BgmType, AudioClip>();

    private AudioSource audioSource;
    public AudioClip clip;

    public void PlaySFX(SfxType type)
    {
        sfxSource.PlayOneShot(sfxClipDic[type]);
    }

    public void PlayBGM(BgmType type)
    {
        if (bgmSource.clip == bgmClipDic[type])
            return;

        bgmSource.clip = bgmClipDic[type];
        bgmSource.Play();
    }

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
        for (int i = 0; i < sfxClipArr.Length; i++)
        {
            try
            {
                SfxType type = (SfxType)Enum.Parse(typeof(SfxType), sfxClipArr[i].name);
                instance.sfxClipDic.Add(type, sfxClipArr[i]);
            }
            catch
            {
                Debug.LogWarning("Need SfxType Enum : " + sfxClipArr[i].name);
            }
        }

        var bgmClipArr = Resources.LoadAll<AudioClip>("Sounds/BGM");
        for (int i = 0; i < bgmClipArr.Length; i++)
        {
            try
            {
                BgmType type = (BgmType)Enum.Parse(typeof(BgmType), bgmClipArr[i].name);
                instance.bgmClipDic.Add(type, bgmClipArr[i]);
            }
            catch
            {
                Debug.LogWarning("Need SfxType Enum : " + sfxClipArr[i].name);
            }
        }
    }
}
