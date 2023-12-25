#if TOOLS
using Godot;
using System;

[Tool]
public partial class MenuButtonPopulatorPlugin : EditorPlugin
{
	public override void _EnterTree()
	{
		GD.Print("MenuButtonPopulatorPlugin Activated");
	}

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
		GD.Print("MenuButtonPopulatorPlugin Deactivated");

	}
}
#endif
