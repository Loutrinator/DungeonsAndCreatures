using Godot;
using System;

public partial class Game : Node
{
    private static Game _singleton = null;
    public static Game Singleton
    {
        get
        {
            _singleton ??= ((SceneTree)Engine.GetMainLoop()).Root.GetNode<Game>(Constants.PATH_GAMENODE);
            return _singleton;
        }
    }

    private Player _mainCharacter = null;
    

    public static void SetMainCharacter(Player player){
        Singleton._mainCharacter = player;
    }
    public static Player GetMainCharacter(){
        return Singleton._mainCharacter;
    }
}
