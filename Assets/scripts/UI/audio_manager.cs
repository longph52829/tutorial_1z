using UnityEngine;

public class audio_manager : MonoBehaviour
{
    public AudioSource audio_source;
    public AudioSource default_audio_source;
    public AudioClip shoot_clip;
    public AudioClip reload_clip;
    public AudioClip energy_clip;
    public AudioClip die_clip;
    public AudioClip win_clip;
    public AudioClip select_clip;
    public AudioClip hit_clip;
    public AudioClip lose_clip;
    public AudioClip score_clip;
    
    public void play_shoot()
    {
        audio_source.PlayOneShot(shoot_clip);
    }
    
    public void play_reload()
    {
        audio_source.PlayOneShot(reload_clip);
    }
    
    public void play_energy()
    {
        audio_source.PlayOneShot(energy_clip);
    }
    
    public void play_die()
    {
        audio_source.PlayOneShot(die_clip);
    }
    
    public void play_win()
    {
        default_audio_source.Stop();
        audio_source.PlayOneShot(win_clip);
    }
    
    public void play_select()
    {
        audio_source.PlayOneShot(select_clip);
    }
    
    public void play_hit()
    {
        audio_source.PlayOneShot(hit_clip);
    }
    
    public void play_lose()
    {
        default_audio_source.Stop();
        audio_source.PlayOneShot(lose_clip);
    }
    
    public void play_score()
    {
        audio_source.PlayOneShot(score_clip);
    }
    
    public void play_default()
    {
        default_audio_source.Play();
    } 
    
    public void stop_all()
    {
        default_audio_source.Stop();
        audio_source.Stop();
    }
}
