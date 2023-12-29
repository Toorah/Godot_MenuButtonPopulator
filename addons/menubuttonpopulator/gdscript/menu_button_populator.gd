extends MenuButton

class_name MenuButtonPopulatorGD

@export var clear_items : bool

var popup_events : Dictionary

@export_category("Debug")
@export var log_pressed_items : bool

func _ready():
	get_popup().id_pressed.connect(menu_pressed)
	
	if clear_items:
		get_popup().clear()
	
	var index = 0
	var children = get_children()
	
	for child in children:
		if child is PopupMenu:
			var menu : PopupMenu = child as PopupMenu
			menu.reparent(get_popup())
			get_popup().add_submenu_item(menu.name, menu.name, index)
			index += 1
			menu.id_pressed.connect(menu_pressed)
			
			if clear_items:
				menu.clear()
				
			var popup_children = menu.get_children()
			for popupChild in popup_children:
				if popupChild is PopupChildGD:
					var pChild = popupChild as PopupChildGD
					if pChild.is_separator:
						add_separator(menu, "", index)
						index += 1
					elif pChild.label_override != "":
						add_child_item(menu, pChild.label_override, pChild, index)
						index += 1
					else:
						add_child_item(menu, pChild.name, pChild, index)
						index += 1
		elif child is PopupChildGD:
			var pChild : PopupChildGD = child as PopupChildGD
			if pChild.is_separator:
				add_separator(get_popup(), "", index)
				index += 1
			elif pChild.label_override != "":
				add_child_item(get_popup(), pChild.label_override, pChild, index)
				index += 1
			else:
				add_child_item(get_popup(), pChild.name, pChild, index)
				index += 1
	
func menu_pressed(id):
	if popup_events.has(id):
		var popupChild : PopupChildGD = popup_events[id]
		popupChild.select()
		if log_pressed_items:
			print("Press [" + str(id) + "] " + popupChild.name)

func add_child_item(menu : PopupMenu, label : String, child : PopupChildGD = null, id : int = -1, accel : Key = 0):
	menu.add_item(label, id, accel)
	if id != -1 && child != null:
		popup_events[id] = child	

func add_separator(menu : PopupMenu, label : String = "", id : int = -1):
	menu.add_separator(label, id)
