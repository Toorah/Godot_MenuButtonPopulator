using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class MenuButtonPopulator : MenuButton
{
	[Export]
	public bool clearItems;



	Dictionary<int, PopupChild> m_popupEvents = new Dictionary<int, PopupChild>();

	[ExportCategory("Debug")]
	[Export]
	public bool logPressedItems;


	public override void _Ready()
	{
		base._Ready();
		GetPopup().IdPressed += MenuPressed;

		if (clearItems)
		{
			GetPopup().Clear();
		}

		int index = 0;
		var children = GetChildren();

		foreach ( var child in children )
		{
			if(child is PopupMenu menu)
			{
				RemoveChild( menu );
				GetPopup().AddChild( menu );
				GetPopup().AddSubmenuItem(menu.Name, menu.Name, id: index++);

				menu.IdPressed += MenuPressed;

				if (clearItems)
					menu.Clear();

				var popupChildren = menu.GetChildren();
				foreach(var popupChild  in popupChildren)
				{
					if (popupChild is PopupChild pChild)
					{
						if (pChild.isSeparator)
						{
							//GetPopup().AddSeparator(id: index++);
							AddSeparator(menu, id: index++);
						}
						else if (!string.IsNullOrEmpty(pChild.labelOverride))
						{
							//GetPopup().AddItem(pChild.labelOverride, id: index++);
							AddChild(menu, pChild.labelOverride, child: pChild, id: index++);
						}
						else
						{
							AddChild(menu, pChild.Name, child: pChild, id: index++);
						}
					}
				}
			}
			else if (child is PopupChild pChild)
			{
				if (pChild.isSeparator)
				{
					//GetPopup().AddSeparator(id: index++);
					AddSeparator(GetPopup(), id: index++);
				}
				else if (!string.IsNullOrEmpty(pChild.labelOverride))
				{
					//GetPopup().AddItem(pChild.labelOverride, id: index++);
					AddChild(GetPopup(), pChild.labelOverride, child: pChild, id: index++);
				}
				else 
				{
					//GetPopup().AddItem(child.Name, id: index++);
					AddChild(GetPopup(), pChild.Name, child: pChild, id: index++);
				}
			}
		}
	}

	private void MenuPressed(long key)
	{
		if(m_popupEvents.TryGetValue((int)key, out var popupChild))
		{
			popupChild.Select();
			if(logPressedItems)
				GD.Print($"Press [{key}] {popupChild.Name}");
		}
	}

	void AddChild(PopupMenu menu, string label, PopupChild child = null, int id = -1, Key accel = Key.None)
	{
		menu.AddItem(label, id, accel);
		if(id != -1 && child != null) 
		{ 
			m_popupEvents.TryAdd(id, child);
		}
	}

	void AddSeparator(PopupMenu menu, string label = "", int id = -1)
	{
		menu.AddSeparator(label, id);
	}
}
