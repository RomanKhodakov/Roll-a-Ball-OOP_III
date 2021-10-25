using UnityEditor;

namespace RomanKhodakovHomeWork
{
	public class MenuItem
	{
		[UnityEditor.MenuItem("TestMenu/Creation")]
		private static void MenuOption()
		{
			EditorWindow.GetWindow(typeof(MyWindow) ,false, title: "Creation Wall", focus: true);
		}
	}
}
