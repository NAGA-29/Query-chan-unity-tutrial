using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [SerializeField] private AudioSource _audioSource;
    private readonly Dictionary<string, AudioClip> _clips = new Dictionary<string, AudioClip>();

    public static AudioManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (null != instance)
        {
            // ���ɃC���X�^���X������ꍇ�ɂ͎��M��j������
            Destroy(gameObject);
            return;
        }

        //�V�[����J�ڂ��Ă��j������Ȃ�����
        DontDestroyOnLoad(gameObject);
        //�C���X�^���X�Ƃ��ĕێ�����
        instance = this;

        //Resource/2D_SE�f�B���N�g������Audio Clip�����ׂĎ擾
        var audioClips = Resources.LoadAll<AudioClip>("2D_SE");
        foreach (var clip in audioClips)
        {
            //Audio Clip��Dictionary�ɕێ����Ă���
            _clips.Add(clip.name, clip);
        }
    }

    //�w�肵�����O�̉����t�@�C�����Đ�����
    public void Play(string clipName)
    {
        if (!_clips.ContainsKey(clipName))
        {
            //���݂��Ȃ����O���w�肵����error
            throw new System.Exception("Sound " + clipName + " is not defined");
        }

        //�w��̖��O��clip�ɍ����ւ��čĐ�����
        _audioSource.clip = _clips[clipName];
        _audioSource.Play();
    }
}