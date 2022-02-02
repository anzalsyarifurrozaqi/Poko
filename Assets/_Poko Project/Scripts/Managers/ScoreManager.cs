
namespace anzal.game
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public int ScoreInt = 0;

        private void OnEnable() 
        {
            DontDestroyOnLoad(this.gameObject);
        }        
    }
}
