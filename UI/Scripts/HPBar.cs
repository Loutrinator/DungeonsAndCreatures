using Godot;
using System;

public partial class HPBar : HBoxContainer
{
	[Export]
	private PackedScene _hPDisplay;

	public override void _Ready()
	{
		base._Ready();

		for(int i = 0; i < 3; i++)
		{

		HPDisplay hpDisplay = _hPDisplay.Instantiate() as HPDisplay;
		
		AddChild(hpDisplay);
		}
	}

}
