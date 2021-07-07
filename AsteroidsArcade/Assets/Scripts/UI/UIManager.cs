using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// ������ 0 - ��������� ���� (Start Menu)
    /// ������ 1 - ������� ���� (Play Menu)
    /// ������ 2 - ���� ����� ����  (Game Over)
    /// </summary>
    public Canvas[] canvasMenu; //������ ����

    public float timeShowingAnnounceMenu = 1f; //����� ������ ���� ����������

    public AudioSource startMenuFonSound; //AudioResource ��� ���������� ����

    public AudioSource gameOverFonSound; //AudioResource ��� ���� ��������� ����

    public GameObject gameController; //������ �� ������ gameController

    public GameObject player; //������ �� ������ Player


    void Start()
    {
        //��������� �������� ���� ������ 0
        //Time.timeScale = 0f;
        //���������� �������� ���������� Shoot � ������, ��� ���������� �������� �������� � ������� ����.
        //player.gameObject.GetComponentInChildren<Shoot>().enabled = false;
        //��������� ��������� ���� 
        canvasMenu[0].gameObject.SetActive(true);
        //����������� �������� ����
        canvasMenu[1].gameObject.SetActive(false);
        //����������� ���� GameOver
        canvasMenu[2].gameObject.SetActive(false);
        //��������� ��������� ������
        startMenuFonSound.Play();

    }

    public void ShowGameOverMenu()
    {
        //��������� ���� Game Over
        canvasMenu[2].gameObject.SetActive(true);
    }


    /// <summary>
    /// ��������� ������� �� ������ �����
    /// </summary>
    public void BAStartButton()
    {
        //���������� ������� ������ � ��������� ����
        startMenuFonSound.Stop();
        //����������� ��������� ���� 
        canvasMenu[0].gameObject.SetActive(false);
        //��������� �������� ����
        canvasMenu[1].gameObject.SetActive(true);

        //������������� �������� �� ��������� �������
        gameController.GetComponent<GameController>().StartInit();
        //��������� ������
        player.SetActive(true);
        //��������� �������� ���� ������ 1
        Time.timeScale = 1f;
    }

    /// <summary>
    /// ��������� ������� �� ������ �����
    /// </summary>
    public void BAExitButton()
    {
        Application.Quit();
    }

    /// <summary>
    /// ��������� ������� �� ������ �������
    /// </summary>
    public void BARestart()
    {
        SceneManager.LoadScene(0);
    }
}
