using GatoSlime.Common;
using LKMQUtils;

namespace GatoSlime.Game;

public partial class GameSceneFactory : SceneFactory
{
    public GameSceneFactory()
    {
        _uids = new()
        {
            { "MainMenu", GameConstants.UIDS.MainMenu },
            { "PauseMenu", GameConstants.UIDS.PauseMenu },
            { "Stage", GameConstants.UIDS.Stage },
            { "Debug001", GameConstants.UIDS.Debug001 },
            { "OptionsMenu", GameConstants.UIDS.OptionsMenu },
            { "Player", GameConstants.UIDS.Player },
            { "DeathEffect_01", GameConstants.UIDS.DeathEffect_01 },
        };
    }

    public override void _Ready() { }
}
