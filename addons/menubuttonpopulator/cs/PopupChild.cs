using Godot;
using System;

[GlobalClass, Icon("res://addons/menubuttonpopulator/icons/format-list-text.svg")]
public partial class PopupChild : Node
{
	[Export]
	public bool isSeparator;

	[Export]
	public string labelOverride = string.Empty;


	[Signal]
	public delegate void onPopupItemSelectedEventHandler();

	public void Select()
	{
		EmitSignal(SignalName.onPopupItemSelected);
	}
}
