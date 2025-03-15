using Godot;
using System;

[GlobalClass]
public partial class Player : CharacterBody2D
{
	[Export]
	private float _moveSpeed = 100.0f;

	[Export]
	private AnimationPlayer _animationPlayer = null;
	[Export]
	private Sprite2D _sprite2D = null;

	private Vector2 _direction = new Vector2(0,0);
	private String state = "Idle";
	
	public override void _Ready()
	{
		int i = 42;
		_animationPlayer.Play("Idle");
		Game.SetMainCharacter(this);
	}
	
	public override void _Process(double delta)
	{
		_direction.X = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		_direction.Y = Input.GetActionStrength("down") - Input.GetActionStrength("up");
		
		Velocity = _direction.Normalized() * _moveSpeed;
		UpdateSpriteDirection();
		if(UpdateState())
		{
			UpdateAnimation();
		}
		//direction.x = Input.GetActionStrength();
	}

    public override void _PhysicsProcess(double delta)
    {
		MoveAndSlide();
    }

	private bool SetDirection()
	{
		return true;
	}
	private bool UpdateState()
	{
		String newState = _direction == Vector2.Zero ? "Idle" : "Run";
		if(newState == state){
			return false;
		}
		state = newState;
		return true;
	}

	private void UpdateAnimation()
	{
		_animationPlayer.Play(state);
	}

	public void UpdateSpriteDirection()
	{
		_sprite2D.FlipH = _direction.X < 0;
	}
}
