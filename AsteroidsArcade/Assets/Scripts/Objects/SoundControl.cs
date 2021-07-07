using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioSource destroyAsteroid;  //���� ����������� ���������
    public AudioSource destroyUFO;      //���� ����������� UFO
    public AudioSource playerDestroy;   //���� ����������� player

    /// <summary>
    /// ����� ��� ������������ ����� ����������� ���������
    /// </summary>
    public void PlayDestroyAsteroidSound()
    {
        destroyAsteroid.Play();
    }

    /// <summary>
    /// ����� ��� ������������ ����� ����������� UFO
    /// </summary>
    public void PlayDestroUFOSound()
    {
        destroyUFO.Play();
    }

    /// <summary>
    /// ����� ��� ������������ ����� ����������� player
    /// </summary>
    public void PlayDestroPlayer()
    {
        playerDestroy.Play();
    }
}
