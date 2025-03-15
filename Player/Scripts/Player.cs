using Godot;
using System;
using System.Diagnostics;

[GlobalClass]
public partial class Player : CharacterBody2D
{
	[Export]
	private float _moveSpeed = 100.0f;
	[Export]
	private float _attackDirectionLerpSpeed = 5.0f;

	[Export]
	private AnimationPlayer _animationPlayer = null;
	[Export]
	private Sprite2D _sprite2D = null;

	private Vector2 _direction = new Vector2(0,0);
	private String state = "Idle";

	private Vector2 _currentAttackDirection = Vector2.Up;
	public Vector2 CurrentAttackDirection => _currentAttackDirection;
	
	public override void _Ready()
	{
		int i = 42;
		_animationPlayer.Play("Idle");
		Game.SetMainCharacter(this);
        _currentAttackDirection = (GetViewport().GetMousePosition() - GlobalPosition).Normalized();
	}
	
	public override void _Process(double delta)
	{
		_direction.X = Input.GetActionStrength(Constants.INPUTCODE_RIGHT) - Input.GetActionStrength(Constants.INPUTCODE_LEFT);
		_direction.Y = Input.GetActionStrength(Constants.INPUTCODE_DOWN) - Input.GetActionStrength(Constants.INPUTCODE_UP);
		if(Input.IsActionJustPressed(Constants.INPUTCODE_DASH)){
			Debug.WriteLine("dash !");
		}
		Velocity = _direction.Normalized() * _moveSpeed;
		UpdateAttackDirection(delta);

		UpdateSpriteDirection();
		if(UpdateState())
		{
			UpdateAnimation();
		}
		//direction.x = Input.GetActionStrength();
	}
	private void UpdateAttackDirection(double delta){
	
		var mousePos = GetLocalMousePosition();
		var viewport = GetViewport();
		Vector2 halfScreenSize = ((Vector2)viewport.GetWindow().Size)/2f;
        _currentAttackDirection = _currentAttackDirection.Lerp((new Vector2(-mousePos.Y, mousePos.X) ).Normalized(), _attackDirectionLerpSpeed * (float)delta);
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
