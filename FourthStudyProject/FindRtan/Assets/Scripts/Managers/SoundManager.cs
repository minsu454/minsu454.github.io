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

    public AudioSource sfxSource;       //sfx���� ����� ����
    public AudioSource bgmSource;       //bgm���� ����� ����

    private Dictionary<SfxType, AudioClip> sfxClipDic = new Dictionary<SfxType, AudioClip>();       //sfxŬ�� �����س��� Dic
    private Dictionary<BgmType, AudioClip> bgmClipDic = new Dictionary<BgmType, AudioClip>();       //bgmŬ�� �����س��� Dic

    /// <summary>
    /// SFX ��� �Լ�
    /// </summary>
    public void PlaySFX(SfxType type)
    {
        sfxSource.PlayOneShot(sfxClipDic[type]);
    }

    /// <summary>
    /// BGM ��� �Լ�
    /// </summary>
    public void PlayBGM(BgmType type)
    {
        if (bgmSource.clip == bgmClipDic[type])
            return;

        bgmSource.clip = bgmClipDic[type];
        bgmSource.Play();
    }

    /// <summary>
    /// SoundManager ���� �Լ�
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
    /// Ŭ�� �о��ִ� �Լ�
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
