using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioSource destroyAsteroid;  //Звук уничтожения астероида
    public AudioSource destroyUFO;      //Звук уничтожения UFO
    public AudioSource playerDestroy;   //Звук уничтожения player

    /// <summary>
    /// Метод для проигрывания звука уничтожения астероида
    /// </summary>
    public void PlayDestroyAsteroidSound()
    {
        destroyAsteroid.Play();
    }

    /// <summary>
    /// Метод для проигрывания звука уничтожения UFO
    /// </summary>
    public void PlayDestroUFOSound()
    {
        destroyUFO.Play();
    }

    /// <summary>
    /// Метод для проигрывания звука уничтожения player
    /// </summary>
    public void PlayDestroPlayer()
    {
        playerDestroy.Play();
    }
}
