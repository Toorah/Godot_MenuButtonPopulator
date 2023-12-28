# MenuButtonPopulator

*Made for Godot 4.2 .NET*

![format-list-text-custom](https://github.com/Toorah/Godot_MenuButtonPopulator/assets/8051137/5c1369d0-ce52-48c8-931f-59a5b4117ba6)

Adds a quick method to populate a MenuButton with Items.

![MenuPopup_1](https://github.com/Toorah/Godot_MenuButtonPopulator/assets/8051137/6de7eb7f-c468-4103-aabb-254cece6123f)

By adding the custom *PopupChild* Node as a child of the *MenuButtonPopulator* Node (inherits MenuButton), you can quickly add items, in the order of the children in the Scene Tree.

You can also add a *PopupMenu* Node as a child of the *MenuButtonPopulator* and add more *PopupChild* nodes to it, to create submenus. Currently this only supports the first layer of submenus, no recursion.

Optionally, you can also use the Signal *onPopupItemSelected()* found on each *PopupChild* node, instead of having to create a function and filter the ids manually.

![MenuPopup_3](https://github.com/Toorah/Godot_MenuButtonPopulator/assets/8051137/8bd9660f-1152-491b-a078-afdb10c048f8)




## MenuButtonPopulator
Inherits from **MenuButton**

- Clear Items (boolean) : If true, it will clear any items added manually to the MenuButton >Items field, before creating new ones.
- \(Debug) Log Pressed Items (bool) : If true, will log the selected item.

![MenuPopup_4](https://github.com/Toorah/Godot_MenuButtonPopulator/assets/8051137/9490f5a4-489d-4489-926a-9f82d51016a5)

## PopupChild
Inherits from *Node*

- Is Separator (boolean) : If true, this PopupChild will be used as a Separator instead of an Item.
- Label Override (string) : If not-empty, it will override the Item Label, instead of using the *PopupChild* Node Name. This can be useful for disallowed characters in the Scene Tree.

![MenuPopup_2](https://github.com/Toorah/Godot_MenuButtonPopulator/assets/8051137/1f845159-b231-467a-a31a-957b00b5826e)


# How to Use

- Add a *MenuButton* Node to the Scene. Add the *MenuButtonPopulator.cs* Script to the *MenuButton* Node

OR

- Add the *MenuButtonPopulator* Node directly, from the *Create New Node* Menu

## Adding Items
- Add *PopupChild* Nodes under the MenuButtonPopulator. The name of each child will be used as a Popup Item.
- \(Optional) Set the *PopupChild* as a *Separator* to create a separation Line instead
- \(Optional) Set the *Label Override* to use a different Item Name than the Node Name, this is useful for using special characters not allowed in Godot's SceneTree.
- \(Optional) Use the *Signal* of each *PopupChild* Node to get a specific event for each, instead of using the *IdPressed* Signal manually. 

## Creating Submenus
- Add a *PopupMenu* Node to the *MenuButtonPopulator* Node. The Name of the *PopupMenu* Node will be used as the Submenu Name.
- Add *PopupChild* Nodes to the *PopupMenu* and repeat the steps outlined in **Adding Items**.


# Todo
- [ ] Add recursive menu building
- [ ] Disabled Items
- [ ] Add gdscipt version
- [ ] verify all godot 4.x version compatibility
- [ ] overall UX improvement
