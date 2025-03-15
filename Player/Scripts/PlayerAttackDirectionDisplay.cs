using Godot;
using System;

public partial class PlayerAttackDirectionDisplay : Node2D
{
    [Export]
    private Player _player = null;

    public override void _Ready()
    {
    }
    public override void _Process(double delta)
    {
        UpdateWeaponAngle(delta);
    }

    private void UpdateWeaponAngle(double delta)
    {
        Rotation = _player.CurrentAttackDirection.Angle();
    }
}
