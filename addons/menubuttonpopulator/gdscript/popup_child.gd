@icon("res://addons/menubuttonpopulator/icons/format-list-text.svg")
extends Node

class_name PopupChildGD

@export var is_separator : bool

@export var label_override : String

signal on_popup_item_selected

func select():
	on_popup_item_selected.emit()
