using System.Collections.ObjectModel;

namespace revestodolist;

public partial class MainPage : ContentPage
{
    ObservableCollection<ToDoClass> todoList;
    int currentId = 1;
    ToDoClass selectedItem = null;

    public MainPage()
    {
        InitializeComponent();

        todoList = new ObservableCollection<ToDoClass>();
        todoLV.ItemsSource = todoList;
    }
    
    private void AddToDoItem(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(titleEntry.Text))
        {
            DisplayAlert("Error", "Title cannot be empty.", "OK");
            return;
        }

        todoList.Add(new ToDoClass
        {
            id = currentId++,
            title = titleEntry.Text,
            detail = detailsEditor.Text
        });

        ClearFields();
    }
    
    private void TodoLV_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        selectedItem = (ToDoClass)e.SelectedItem;

        titleEntry.Text = selectedItem.title;
        detailsEditor.Text = selectedItem.detail;

        addBtn.IsVisible = false;
        editBtn.IsVisible = true;
        cancelBtn.IsVisible = true;
    }
    
    private void EditToDoItem(object sender, EventArgs e)
    {
        if (selectedItem == null)
            return;

        selectedItem.title = titleEntry.Text;
        selectedItem.detail = detailsEditor.Text;

        todoLV.SelectedItem = null;
        CancelEdit(null, null);
    }
    
    private void DeleteToDoItem(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int itemId = int.Parse(btn.ClassId);

        var itemToRemove = todoList.FirstOrDefault(x => x.id == itemId);

        if (itemToRemove != null)
        {
            todoList.Remove(itemToRemove);
        }
    }
    
    
    private void CancelEdit(object sender, EventArgs e)
    {
        selectedItem = null;
        todoLV.SelectedItem = null;

        addBtn.IsVisible = true;
        editBtn.IsVisible = false;
        cancelBtn.IsVisible = false;

        ClearFields();
    }

    private void ClearFields()
    {
        titleEntry.Text = string.Empty;
        detailsEditor.Text = string.Empty;
    }
}
