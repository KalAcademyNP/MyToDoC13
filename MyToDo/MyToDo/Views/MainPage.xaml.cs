using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyToDo.Models;
using System.IO;

namespace MyToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var todos = new List<ToDo>();
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData), "*.notes.txt");
            foreach (var file in files)
            {
                var todo = new ToDo
                {
                    Text = File.ReadAllText(file),
                    FileName = file,
                    Date = File.GetCreationTime(file)
                };
                todos.Add(todo);
            }
            TodoListView.ItemsSource = todos.OrderByDescending(t => t.Date);
        }

        private async void TodoListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new ToDoPage
            {
                BindingContext = (ToDo)e.SelectedItem
            });
        }
    }
}