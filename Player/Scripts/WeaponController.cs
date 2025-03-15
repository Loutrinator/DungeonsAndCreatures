using Godot;
using System;

public partial class WeaponController : Node2D
{
    [Export]
    private float _directionLerpSpeed = 0.2f;
    [Export]
    private Node2D _weaponContainer = null;

    private Vector2 _currentDirection = Vector2.Up;

    public override void _Ready()
    {
        _currentDirection = (GetViewport().GetMousePosition() - GlobalPosition).Normalized();
    }
    public override void _Process(double delta)
    {
        UpdateWeaponAngle(delta);
    }

    private void UpdateWeaponAngle(double delta)
    {
        _currentDirection = _currentDirection.Lerp((GetViewport().GetMousePosition() - GlobalPosition).Normalized(), _directionLerpSpeed * (float)delta);
        Rotation = _currentDirection.Angle();
    }
}
