using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	private float _moveSpeed = 100.0f;
	
	public override void _Ready()
	{
		int i = 42;
	}
	
	public override void _Process(double delta){
		Vector2 direction = new Vector2(0,0);
		direction.X = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		direction.Y = Input.GetActionStrength("down") - Input.GetActionStrength("up");
		
		Velocity = direction.Normalized() * _moveSpeed;

		//direction.x = Input.GetActionStrength();
	}

    public override void _PhysicsProcess(double delta)
    {
		MoveAndSlide();
    }
}
