using UnityEngine;
using UnityEngine.SceneManagement;

namespace anzal.game
{    
    public class ButtonManager : MonoBehaviour
    {        
        public void ButtonStart()
        {
            SceneManager.LoadScene(SceneStringEnum.Poko_GameScene.ToString());
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(SceneStringEnum.Poko_StartScene.ToString());
        }

        public void testButton()
        {
            SceneManager.LoadScene(SceneStringEnum.Poko_ScoreScene.ToString());
        }
    }
}
