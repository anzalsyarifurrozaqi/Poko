
namespace anzal.game
{
    public class PauseCharacter : CharacterFunction
    {
        public override void RunFunction(bool isPaused)
        {
            if (isPaused)
            {
                GameManager.Instance.GameSpeed = 0;                
            }
            else
            {
                GameManager.Instance.GameSpeed = 1;                
            }

            control.ANIMATOR.speed = GameManager.Instance.GameSpeed;
        }
    }
}