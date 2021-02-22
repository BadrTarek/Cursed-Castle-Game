using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerControl player;
    public Pause pauseMenu;
    public bool notRepeat = false;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
        pauseMenu = GameObject.Find("PauseManager").GetComponent<Pause>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isGameOver==true && !notRepeat)
        {
            pauseMenu.GameOver();
            notRepeat = true;
        }
    }
}
