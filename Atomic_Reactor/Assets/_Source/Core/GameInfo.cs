namespace Core
{
    public class GameInfo
    {
        public bool IsPlaying { get; private set; }

        public void SetPlayingState(bool isPlaying) => IsPlaying = isPlaying;
    }
}