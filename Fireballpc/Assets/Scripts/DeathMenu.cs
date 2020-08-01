using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Image backgroundImage;
    public Text scoreText;
    private float transition = 0.0f;

    private bool isShowned = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShowned)
            return;

        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0, 0, 0,0),Color.black,transition);
    }
    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShowned = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        BGsoundScript.Instance.gameObject.GetComponent<AudioSource>().Play();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
        BGsoundScript.Instance.gameObject.GetComponent<AudioSource>();
    }
}
