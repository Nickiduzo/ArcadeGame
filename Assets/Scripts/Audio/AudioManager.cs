using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }

        DontDestroyOnLoad(gameObject);
        Initialization();
    }

    private void Initialization()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.name = s.clipName;
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        foreach(Sound s in sounds)
        {
            if (s.clipName == name)
            {
                s.source.Play();
                break;
            }
        }
    }

    public void Stop(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.clipName == name)
            {
                s.source.Stop();
                break;
            }
        }
    }
}
